using Xunit;
using Universal_XML_Auditor;

namespace Universal_XML_Auditor.Tests;

public class ValidationTests
{
    [Fact]
    public void Validate_ReturnsFalse_WhenFileNotFound()
    {
        // Arrange
        var auditor = new XmlAuditor();
        string fakeXml = "C:\\fake_file.xml";
        string fakeXsd = "C:\\fake_schema.xsd";

        // Act
        // We pass the required 5 arguments: path, path, and 3 empty/default values
        bool result = auditor.Validate(fakeXml, fakeXsd, null, null, default);

        // Assert
        Assert.False(result, "The auditor should return false when given invalid file paths.");
    }

    [Fact]
    public void Validate_ReturnsFalse_WhenXmlFailsSchemaValidation()
    {
        // Arrange: Create ephemeral test files
        var auditor = new XmlAuditor();
        string tempXsd = Path.GetTempFileName();
        string tempXml = Path.GetTempFileName();

        // A strict XSD requiring a <Root> element with a <Name> child
        string xsdContent = @"<?xml version=""1.0"" encoding=""utf-8""?>
        <xs:schema xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
          <xs:element name=""Root"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""Name"" type=""xs:string""/>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
        </xs:schema>";

        // An invalid XML (missing the required <Name> element)
        string xmlContent = @"<?xml version=""1.0"" encoding=""utf-8""?>
        <Root>
        </Root>";

        File.WriteAllText(tempXsd, xsdContent);
        File.WriteAllText(tempXml, xmlContent);

        try
        {
            // Act: Run the validator
            bool result = auditor.Validate(tempXml, tempXsd, null, null, default);

            // Assert: The audit should fail, and the Errors list should be populated
            Assert.False(result, "The auditor should return false for schema violations.");
            Assert.NotEmpty(auditor.Errors);
            Assert.Contains(auditor.Errors, e => e.Contains("SCHEMA"));
        }
        finally
        {
            // Cleanup: Always destroy ephemeral test data
            if (File.Exists(tempXsd)) File.Delete(tempXsd);
            if (File.Exists(tempXml)) File.Delete(tempXml);
        }
    }

    [Fact]
    public void Validate_ReturnsFalse_WhenParentChildNestingIsInvalid()
    {
        // Arrange
        var auditor = new XmlAuditor();
        string tempXsd = Path.GetTempFileName();
        string tempXml = Path.GetTempFileName();

        // XSD requires strict nesting: <Catalog> -> <Book> -> <Title>
        string xsdContent = @"<?xml version=""1.0"" encoding=""utf-8""?>
        <xs:schema xmlns:xs=""http://www.w3.org/2001/XMLSchema"">
          <xs:element name=""Catalog"">
            <xs:complexType>
              <xs:sequence>
                <xs:element name=""Book"">
                  <xs:complexType>
                    <xs:sequence>
                      <xs:element name=""Title"" type=""xs:string""/>
                    </xs:sequence>
                  </xs:complexType>
                </xs:element>
              </xs:sequence>
            </xs:complexType>
          </xs:element>
        </xs:schema>";

        // Invalid XML: <Title> is placed directly under <Catalog>, skipping <Book>
        string xmlContent = @"<?xml version=""1.0"" encoding=""utf-8""?>
        <Catalog>
          <Title>The Site Reliability Workbook</Title>
        </Catalog>";

        File.WriteAllText(tempXsd, xsdContent);
        File.WriteAllText(tempXml, xmlContent);

        try
        {
            // Act
            bool result = auditor.Validate(tempXml, tempXsd, null, null, default);

            // Assert
            Assert.False(result, "The auditor should return false when child elements are improperly nested.");
            Assert.NotEmpty(auditor.Errors);
            // Verify that the error is specifically a SCHEMA violation
            Assert.Contains(auditor.Errors, e => e.Contains("SCHEMA"));
        }
        finally
        {
            // Cleanup ephemeral data
            if (File.Exists(tempXsd)) File.Delete(tempXsd);
            if (File.Exists(tempXml)) File.Delete(tempXml);
        }
    }
}