using jsreport.Types;
using jsReportSpike.local.test.fixture;
using System.Text;

namespace jsReportSpike.local.test
{
    /// <summary>
    /// https://papersizes.io/a
    /// </summary>
    [Collection("JsReportingSharedTestinstanceFixture")]
    public class SimpleLocalRenderingLocalizationTest
    {
        private readonly JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture;

        public SimpleLocalRenderingLocalizationTest(
            JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture)
        {
            this.jsReportingSharedTestinstanceFixture = jsReportingSharedTestinstanceFixture;
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_With_Localization_en_Test()
        {
            var data = InvoiceFixtureBuilder.BuildInvoiceData(1);

            var pageSizeReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                .RenderAsync(new RenderRequest()
                {
                    Template = new Template()
                    {
                        Recipe = Recipe.ChromePdf,
                        Engine = Engine.Handlebars,
                        Name = "Invoice-Localized",
                        Chrome = new Chrome
                        {
                            Width = "210mm", 
                            Height = "297mm",
                        },
                        
                    },
                    Data = data, Options = new RenderOptions()
                    {
                        Localization = new Localization
                        {
                            Language = "en"
                        }
                    }

                });

            await pageSizeReport.Content.CopyToAsync(File.OpenWrite($"output/invoice-localized-en.pdf"));
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_With_Localization_de_Test()
        {
            var data = InvoiceFixtureBuilder.BuildInvoiceData(1);

            var pageSizeReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                .RenderAsync(new RenderRequest()
                {
                    Template = new Template()
                    {
                        Recipe = Recipe.ChromePdf,
                        Engine = Engine.Handlebars,
                        Name = "Invoice-Localized",
                        Chrome = new Chrome
                        {
                            Width = "210mm",
                            Height = "297mm",
                        },

                    },
                    Data = data,
                    Options = new RenderOptions()
                    {
                        Localization = new Localization
                        {
                            Language = "de"
                        }
                    }

                });

            await pageSizeReport.Content.CopyToAsync(File.OpenWrite($"output/invoice-localized-de.pdf"));
        }
    }
}