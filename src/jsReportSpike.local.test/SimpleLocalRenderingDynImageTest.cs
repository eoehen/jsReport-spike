using jsReportSpike.local.test.fixture;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using System.Drawing;
using System.Reflection;

namespace jsReportSpike.local.test
{
    [Collection("JsReportingSharedTestinstanceFixture")]
    public class SimpleLocalRenderingDynImageTest
    {
        private readonly JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture;
        private readonly EmbeddedImageResourceLoader embeddedImageResourceLoader;

        public SimpleLocalRenderingDynImageTest(JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture)
        {
            this.jsReportingSharedTestinstanceFixture = jsReportingSharedTestinstanceFixture;
            this.embeddedImageResourceLoader = new EmbeddedImageResourceLoader();
        }



        [Fact]
        public async Task Local_ChromePdf_Rendering_With_Dyn_Image_To_Local_FileSystem_Test()
        {
            var data = InvoiceFixtureBuilder.BuildInvoiceData(1);

            data.base64Image = 
                embeddedImageResourceLoader.LoadImageAsBase64("jsReportSpike.local.test.fixture.data.emer-logo.png");

            var invoiceReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                .RenderByNameAsync($"Invoice", data);
            invoiceReport.Content.CopyTo(File.OpenWrite($"invoice_image.pdf"));
        }
    }
}