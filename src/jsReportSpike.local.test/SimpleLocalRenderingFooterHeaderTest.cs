using jsReportSpike.local.test.fixture;

namespace jsReportSpike.local.test
{
    [Collection("JsReportingSharedTestinstanceFixture")]
    public class SimpleLocalRenderingFooterHeaderTest
    {
        private readonly JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture;
        private readonly EmbeddedImageResourceLoader embeddedImageResourceLoader;

        public SimpleLocalRenderingFooterHeaderTest(JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture)
        {
            this.jsReportingSharedTestinstanceFixture = jsReportingSharedTestinstanceFixture;
            this.embeddedImageResourceLoader = new EmbeddedImageResourceLoader();
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_With_Footer_And_Header_Test()
        {
            var data = InvoiceFixtureBuilder.BuildInvoiceData(1);

            data.base64Image =
                embeddedImageResourceLoader.LoadImageAsBase64("jsReportSpike.local.test.fixture.data.emer-logo.png");

            var invoiceReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                .RenderByNameAsync($"invoice-main", data);
            invoiceReport.Content.CopyTo(File.OpenWrite($"output/invoice_footer_header.pdf"));
        }
    }
}