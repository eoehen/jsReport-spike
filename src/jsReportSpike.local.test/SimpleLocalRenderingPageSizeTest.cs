using jsreport.Types;
using jsReportSpike.local.test.fixture;
using System.Text;

namespace jsReportSpike.local.test
{
    /// <summary>
    /// https://papersizes.io/a
    /// </summary>
    [Collection("JsReportingSharedTestinstanceFixture")]
    public class SimpleLocalRenderingPageSizeTest
    {
        private readonly JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture;

        public SimpleLocalRenderingPageSizeTest(
            JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture)
        {
            this.jsReportingSharedTestinstanceFixture = jsReportingSharedTestinstanceFixture;
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_PageSize_A4_Test()
        {
            var data = InvoiceFixtureBuilder.BuildInvoiceData(1);

            var pageSizeReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                .RenderAsync(new RenderRequest()
                {
                    Template = new Template()
                    {
                        Recipe = Recipe.ChromePdf,
                        Engine = Engine.Handlebars,
                        Name = "ToImageTemplate",
                        Chrome = new Chrome
                        {
                            Width = "210mm", 
                            Height = "297mm",
                        }

                    },
                    Data = data
                });

            await pageSizeReport.Content.CopyToAsync(File.OpenWrite($"output/pageSize_A4.pdf"));
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_PageSize_A5_Test()
        {
            var data = InvoiceFixtureBuilder.BuildInvoiceData(1);

            var pageSizeReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                .RenderAsync(new RenderRequest()
                {
                    Template = new Template()
                    {
                        Recipe = Recipe.ChromePdf,
                        Engine = Engine.Handlebars,
                        Name = "ToImageTemplate",
                        Chrome = new Chrome
                        {
                            Width = "148mm",
                            Height = "210mm",
                        }

                    },
                    Data = data
                });

            await pageSizeReport.Content.CopyToAsync(File.OpenWrite($"output/pageSize_A5.pdf"));
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_PageSize_A3_Test()
        {
            var data = InvoiceFixtureBuilder.BuildInvoiceData(1);

            var pageSizeReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                .RenderAsync(new RenderRequest()
                {
                    Template = new Template()
                    {
                        Recipe = Recipe.ChromePdf,
                        Engine = Engine.Handlebars,
                        Name = "ToImageTemplate",
                        Chrome = new Chrome
                        {
                            Width = "297mm",
                            Height = "420mm",
                        }

                    },
                    Data = data
                });

            await pageSizeReport.Content.CopyToAsync(File.OpenWrite($"output/pageSize_A3.pdf"));
        }

    }
}