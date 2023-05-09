using jsReportSpike.local.test.fixture;

namespace jsReportSpike.local.test
{
    [Collection("JsReportingSharedTestinstanceFixture")]
    public class SimpleLocalRenderingPageBreakTest
    {
        private readonly JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture;
        private readonly EmbeddedImageResourceLoader embeddedImageResourceLoader;

        public SimpleLocalRenderingPageBreakTest(JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture)
        {
            this.jsReportingSharedTestinstanceFixture = jsReportingSharedTestinstanceFixture;
            this.embeddedImageResourceLoader = new EmbeddedImageResourceLoader();
        }



        [Fact]
        public async Task Local_ChromePdf_Rendering_With_Page_Break_Test()
        {
            if (File.Exists($"output/invoice_page_break.pdf"))
                File.Delete($"output/invoice_page_break.pdf");

            var data = InvoiceFixtureBuilder.BuildInvoiceData(1);
            var invoiceReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                .RenderByNameAsync($"Invoice3", data);
            invoiceReport.Content.CopyTo(File.OpenWrite($"output/invoice_page_break.pdf"));
        }
    }
}