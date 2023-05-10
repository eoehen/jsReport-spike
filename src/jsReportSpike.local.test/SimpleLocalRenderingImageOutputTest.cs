using jsreport.Types;
using jsReportSpike.local.test.fixture;
using System.Text;

namespace jsReportSpike.local.test
{
    [Collection("JsReportingSharedTestinstanceFixture")]
    public class SimpleLocalRenderingImageOutputTest
    {
        private readonly JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture;

        public SimpleLocalRenderingImageOutputTest(
            JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture)
        {
            this.jsReportingSharedTestinstanceFixture = jsReportingSharedTestinstanceFixture;
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_Content_To_Image_Output_Test()
        {
            var htmlReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                .RenderAsync(new RenderRequest()
                {
                    Template = new Template()
                    {
                        Recipe = Recipe.ChromeImage,
                        Engine = Engine.Handlebars,
                        Content = "This is a <b>simple</b> HTML rendering test."
                    }
                });

            var htmlContent = StreamToString(htmlReport.Content);
            File.WriteAllText($"output/content-rendered-image.png", htmlContent);

            // This is not working - I don't know why ????
            //await htmlReport.Content.CopyToAsync(File.OpenWrite($"output/content-rendered-image.png"));
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_Template_To_Image_png_Output_Test()
        {
            var data = InvoiceFixtureBuilder.BuildInvoiceData(1);

            var invoiceReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                .RenderByNameAsync($"ToImageTemplate", data);

            invoiceReport.Content.CopyTo(File.OpenWrite($"output/template-rendered-image.png"));
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_Template_To_Jpeg_Image_Output_Test()
        {
            var data = InvoiceFixtureBuilder.BuildInvoiceData(1);

            var invoiceReport = await jsReportingSharedTestinstanceFixture.LocalReportingInstance
                .RenderByNameAsync($"ToJpegImageTemplate", data);

            invoiceReport.Content.CopyTo(File.OpenWrite($"output/template-rendered-image.jpeg"));
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