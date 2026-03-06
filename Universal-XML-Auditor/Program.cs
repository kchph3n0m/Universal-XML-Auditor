namespace Universal_XML_Auditor
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            if (args.Length > 0)
            {
                RunHeadless(args);
            }
            else
            { 
                Application.Run(new Form1());
            }
                
        }

        static void RunHeadless(string[] args)
        {
            //We expect two arguments: the XML path and the XSD path. If we don't get them, just exit.
            if (args.Length < 2)
            {
                Environment.Exit(1);
            }

            string xmlPath = args[0];
            string xsdPath = args[1];

            var auditor = new XmlAuditor();

            bool isValid = auditor.Validate(xmlPath, xsdPath);

            if (isValid)
            {
                Environment.Exit(0);
            }
            else
            {
                Environment.Exit(2);
            }
        }
    }
}