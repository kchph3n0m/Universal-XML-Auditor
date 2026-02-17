namespace Universal_XML_Auditor;

public partial class Form1 : Form
{
    private List<string> _lastResults = new();
    private CancellationTokenSource? _cts; // Manages the cancellation state

    public Form1() => InitializeComponent();

    private string SelectFile(string filter)
    {
        using OpenFileDialog ofd = new() { Filter = filter };
        return ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : string.Empty;
    }

    private void btnBrowseXml_Click(object sender, EventArgs e) => txtXmlPath.Text = SelectFile("XML Files|*.xml");
    private void btnBrowseXsd_Click(object sender, EventArgs e) => txtXsdPath.Text = SelectFile("XSD Files|*.xsd");

    private async void btnValidate_Click(object sender, EventArgs e)
    {
        // 1. If an audit is already running, treat click as "Cancel"
        if (_cts != null)
        {
            _cts.Cancel();
            btnRun.Enabled = false; // Prevent multiple cancellation requests
            lblStatus.Text = "Cancelling audit...";
            return;
        }

        // 2. Start Audit Logic
        lstErrors.Items.Clear();
        _lastResults.Clear();
        btnRun.Text = "Cancel";
        toolStripProgressBar1.Value = 0;
        lblStatus.Text = "Audit in progress...";

        _cts = new CancellationTokenSource();
        var barProgress = new Progress<int>(percent => toolStripProgressBar1.Value = percent);
        var errorProgress = new Progress<string>(msg =>
        {
            lstErrors.Items.Add(msg);
            lstErrors.TopIndex = lstErrors.Items.Count - 1;
        });

        try
        {
            // 3. Pass the Token to the background thread
            _lastResults = await Task.Run(() =>
            {
                var auditor = new XmlAuditor();
                auditor.Validate(txtXmlPath.Text, txtXsdPath.Text, barProgress, errorProgress, _cts.Token);
                return auditor.Errors;
            }, _cts.Token);
        }
        catch (Exception)
        {
            // Exceptions are caught and reported within the XmlAuditor.Validate method
        }
        finally
        {
            // 4. Reset UI State when finished or cancelled
            btnRun.Text = "Run Audit";
            btnRun.Enabled = true;
            _cts.Dispose();
            _cts = null;
            lblStatus.Text = $"Done. Found {_lastResults.Count} total issues.";
        }
    }

    private void btnExport_Click(object sender, EventArgs e)
    {
        if (_lastResults.Count == 0) return;

        using SaveFileDialog sfd = new() { Filter = "Text Files|*.txt", Title = "Save Audit Report" };
        if (sfd.ShowDialog() == DialogResult.OK)
        {
            File.WriteAllLines(sfd.FileName, _lastResults);
            MessageBox.Show("Report exported successfully.");
        }
    }
}