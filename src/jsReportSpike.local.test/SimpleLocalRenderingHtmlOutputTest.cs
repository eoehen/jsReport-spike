using jsreport.Types;
using jsReportSpike.local.test.fixture;
using System.Text;

namespace jsReportSpike.local.test
{
    [Collection("JsReportingSharedTestinstanceFixture")]
    public class SimpleLocalRenderingHtmlOutputTest
    {
        private readonly JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture;

        public SimpleLocalRenderingHtmlOutputTest(
            JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture)
        {
            this.jsReportingSharedTestinstanceFixture = jsReportingSharedTestinstanceFixture;
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_Content_To_Html_Output_Test()
        {
            var htmlReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                .RenderAsync(new RenderRequest()
                {
                    Template = new Template()
                    {
                        Recipe = Recipe.Html,
                        Engine = Engine.Handlebars,
                        Content = "This is a <b>simple</b> HTML rendering test."
                    }
                });

            var htmlContent = StreamToString(htmlReport.Content);
            File.WriteAllText($"output/content-rendered-html.html", htmlContent);

            // This is not working - I don't know why ????
            // await htmlReport.Content.CopyToAsync(File.OpenWrite($"output/rendered-html.html"));
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_Template_To_Html_Output_Test()
        {
            var data = InvoiceFixtureBuilder.BuildInvoiceData(1);

            var invoiceReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                .RenderByNameAsync($"ToHtmlTemplate", data);

            invoiceReport.Content.CopyTo(File.OpenWrite($"output/template-rendered-html.html"));
        }

        public static string StreamToString(Stream stream)
        {
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                return reader.ReadToEnd();
            }
        }

    }
}