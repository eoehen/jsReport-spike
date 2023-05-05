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
        public async Task Local_ChromePdf_Rendering_With_Dyn_Data_By_Custome_RenderRequest_To_Local_FileSystem_Test()
        {
            var customReport = await localReportingSystem.RenderAsync(CustomRenderRequest);
            customReport.Content.CopyTo(File.OpenWrite("customReport.pdf"));
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_With_Dyn_Data_RenderByName_To_Local_FileSystem_Test()
        {
            var invoiceReport = await localReportingSystem.RenderByNameAsync("Invoice", InvoiceData);
            invoiceReport.Content.CopyTo(File.OpenWrite("invoice.pdf"));
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_6_Times_With_Dyn_Data_RenderByName_To_Local_FileSystem_Test()
        {
            for (var i = 1; i < 7; i++)
            {
                var invoiceReport = await localReportingSystem.RenderByNameAsync($"Invoice{i}", BuildInvoiceData(i));
                invoiceReport.Content.CopyTo(File.OpenWrite($"invoice{i}.pdf"));
            }
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

        private object BuildInvoiceData(int index)
        {
            return new
            {
                index,
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
                    new { name = "Zweiter Eintrag", price = 55 },
                    new { name = "Dritter Eintrag", price = 56 },
                    new { name = "Vierter Eintrag", price = 57 },
                    new { name = "F�nfter Eintrag", price = 58 }
                }
            };
        }

        static object InvoiceData = new
        {
            index = "0",
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
                new { name = "Zweiter Eintrag", price = 55 },
                new { name = "Dritter Eintrag", price = 56 },
                new { name = "Vierter Eintrag", price = 57 },
                new { name = "F�nfter Eintrag", price = 58 }
            }
        };
    }
}