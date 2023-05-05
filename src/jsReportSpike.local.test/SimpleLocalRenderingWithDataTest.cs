using jsreport.Binary;
using jsreport.Local;
using jsreport.Types;

namespace jsReportSpike.local.test
{
    public class SimpleLocalRenderingWithDataTest
    {
        private readonly ILocalUtilityReportingService localReportingSystem;

        public SimpleLocalRenderingWithDataTest()
        {
            var currentDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "jsreport");

            localReportingSystem =
                new LocalReporting()
                .UseBinary(JsReportBinary.GetBinary())
                .RunInDirectory(currentDirectoryPath)
                .KillRunningJsReportProcesses()
                .Configure(cfg => cfg.DoTrustUserCode().FileSystemStore().BaseUrlAsWorkingDirectory())
                .AsUtility()
                .Create();
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_With_Dyn_Data_To_Local_FileSystem_Test()
        {
            var invoiceReport = await localReportingSystem.RenderByNameAsync("Invoice", InvoiceData);
            invoiceReport.Content.CopyTo(File.OpenWrite("invoice.pdf"));

            var customReport = await localReportingSystem.RenderAsync(CustomRenderRequest);
            customReport.Content.CopyTo(File.OpenWrite("customReport.pdf"));
        }

        private static RenderRequest CustomRenderRequest = new RenderRequest()
        {
            Template = new Template()
            {
                Content = "Helo world from {{message}}",
                Engine = Engine.Handlebars,
                Recipe = Recipe.ChromePdf
            },
            Data = new
            {
                message = "jsreport for .NET!!!"
            }
        };

        static object InvoiceData = new
        {
            number = "56-457-5454",
            seller = new
            {
                name = "exanic AG",
                road = "Weststrasse 3",
                country = "6340 Baar"
            },
            buyer = new
            {
                name = "Acme Corp.",
                road = "Ententeich 323",
                country = "7000 Entenhausen"
            },
            items = new[]
    {
                new { name = "Erster Eintrag", price = 300 },
                new { name = "Zweiter Eintrag", price = 55 }
            }
        };
    }
}