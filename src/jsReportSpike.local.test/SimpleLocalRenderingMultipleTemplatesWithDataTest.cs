using jsReportSpike.local.test.fixture;

namespace jsReportSpike.local.test
{
    [Collection("JsReportingSharedTestinstanceFixture")]
    public class SimpleLocalRenderingMultipleTemplatesWithDataTest
    {
        private readonly JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture;

        public SimpleLocalRenderingMultipleTemplatesWithDataTest(JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture)
        {
            this.jsReportingSharedTestinstanceFixture = jsReportingSharedTestinstanceFixture;
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_6_Times_With_Dyn_Data_RenderByName_To_Local_FileSystem_Test()
        {
            for (var i = 1; i < 7; i++)
            {
                var invoiceReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                    .RenderByNameAsync($"Invoice{i}", InvoiceFixtureBuilder.BuildInvoiceData(i));
                invoiceReport.Content.CopyTo(File.OpenWrite($"invoice{i}.pdf"));
            }
        }
    }
}