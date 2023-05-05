using jsReportSpike.local.test.fixture;

namespace jsReportSpike.local.test
{
    [Collection("JsReportingSharedTestinstanceFixture")]
    public class SimpleLocalRenderingDynImageTest
    {
        private readonly JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture;

        public SimpleLocalRenderingDynImageTest(JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture)
        {
            this.jsReportingSharedTestinstanceFixture = jsReportingSharedTestinstanceFixture;
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_With_Dyn_Image_To_Local_FileSystem_Test()
        {
            var invoiceReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                .RenderByNameAsync($"Invoice", InvoiceFixtureBuilder.BuildInvoiceData(1));
            invoiceReport.Content.CopyTo(File.OpenWrite($"invoice.pdf"));
        }
    }
}