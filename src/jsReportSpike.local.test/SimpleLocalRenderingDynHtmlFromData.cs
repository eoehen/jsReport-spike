using jsReportSpike.local.test.fixture;

namespace jsReportSpike.local.test
{
    [Collection("JsReportingSharedTestinstanceFixture")]
    public class SimpleLocalRenderingDynHtmlFromData
    {
        private readonly JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture;

        public SimpleLocalRenderingDynHtmlFromData(
            JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture)
        {
            this.jsReportingSharedTestinstanceFixture = jsReportingSharedTestinstanceFixture;
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_Dyn_Html_From_Data_Test()
        {
            var data = InvoiceFixtureBuilder.BuildInvoiceData(1);

            var invoiceReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                .RenderByNameAsync($"dynHtml", data);
            invoiceReport.Content.CopyTo(File.OpenWrite($"output/dyn_html.pdf"));
        }
    }
}