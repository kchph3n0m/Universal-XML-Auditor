using System.Xml;
using System.Xml.Schema;
using System.Text.RegularExpressions;

namespace Universal_XML_Auditor;

public class XmlAuditor
{
    public List<string> Errors { get; private set; } = [];
    private bool _hasAlertedPath = false;

    private static readonly Regex FilePattern = new(@"\.(pdf|txt|jpg|csv|zip|png)$",
        RegexOptions.IgnoreCase | RegexOptions.Compiled);

    public void Validate(string xmlPath, string xsdPath, IProgress<int>? progressPct = null, IProgress<string>? progressError = null, CancellationToken ct = default)
    {
        Errors = [];
        _hasAlertedPath = false;
        int uiReportCount = 0;
        const int MaxUiErrors = 1000;
        string? xmlDirectory = Path.GetDirectoryName(xmlPath);

        try
        {
            var settings = new XmlReaderSettings { ValidationType = ValidationType.Schema };
            settings.Schemas.Add(null, xsdPath);

            settings.ValidationEventHandler += (sender, e) => {
                string msg = $"[{DateTime.Now:HH:mm:ss}] SCHEMA: Line {e.Exception.LineNumber}: {e.Message}";
                Errors.Add(msg);
                if (uiReportCount < MaxUiErrors)
                {
                    progressError?.Report(msg);
                    uiReportCount++;
                }
            };

            using var fileStream = new FileStream(xmlPath, FileMode.Open, FileAccess.Read);
            long totalBytes = fileStream.Length;
            using var reader = XmlReader.Create(fileStream, settings);

            var lineInfo = (IXmlLineInfo)reader;
            string currentElement = string.Empty;

            while (reader.Read())
            {
                // Check if the user has requested a cancellation
                ct.ThrowIfCancellationRequested();

                if (reader.NodeType == XmlNodeType.Element)
                {
                    currentElement = reader.Name;
                    int percent = (int)((fileStream.Position * 100) / totalBytes);
                    progressPct?.Report(percent);
                }

                if (reader.NodeType == XmlNodeType.Text || reader.NodeType == XmlNodeType.CDATA)
                {
                    string textValue = reader.Value.Trim();
                    if (FilePattern.IsMatch(textValue))
                    {
                        if (!_hasAlertedPath)
                        {
                            string alert = $"[{DateTime.Now:HH:mm:ss}] INFO: File path detected in element: <{currentElement}>. Verifying files exist..";
                            progressError?.Report(alert);
                            _hasAlertedPath = true;
                        }

                        string fullPath = Path.Combine(xmlDirectory ?? "", textValue);
                        if (!File.Exists(fullPath))
                        {
                            string msg = $"[{DateTime.Now:HH:mm:ss}] ERROR: [Line {lineInfo.LineNumber}] FILE MISSING: {textValue}";
                            Errors.Add(msg);

                            if (uiReportCount < MaxUiErrors)
                            {
                                progressError?.Report(msg);
                                uiReportCount++;

                                if (uiReportCount == MaxUiErrors)
                                {
                                    progressError?.Report("--- UI Limit Reached. Use Export to see full log. ---");
                                }
                            }
                        }
                    }
                }
            }
            progressPct?.Report(100);
        }
        catch (OperationCanceledException)
        {
            progressError?.Report($"[{DateTime.Now:HH:mm:ss}] Audit manually cancelled by user.");
        }
        catch (Exception ex)
        {
            progressError?.Report($"FATAL ERROR: {ex.Message}");
        }
    }
}