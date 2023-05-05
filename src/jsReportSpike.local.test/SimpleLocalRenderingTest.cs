using FluentAssertions;
using jsreport.Binary;
using jsreport.Local;
using jsreport.Types;

namespace jsReportSpike.local.test
{
    [Collection("JsReportingSharedTestinstanceFixture")]
    public class SimpleLocalRenderingTest
    {
        private readonly JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture;

        public SimpleLocalRenderingTest(JsReportingSharedTestinstanceFixture jsReportingSharedTestinstanceFixture)
        {
            this.jsReportingSharedTestinstanceFixture = jsReportingSharedTestinstanceFixture;
        }

        [Fact]
        public async Task Local_ChromePdf_Rendering_With_Content_To_Local_FileSystem_Test()
        {
            var report = await jsReportingSharedTestinstanceFixture.LocalReportingInstance.RenderAsync(new RenderRequest()
            {
                Template = new Template()
                {
                    Recipe = Recipe.ChromePdf,
                    Engine = Engine.None,
                    Content = "This is a <b>simple</b> PDF rendering test."
                }
            });

            report.Should().NotBeNull();
            report.Content.Should().NotBeNull();

            var outputFolderPath = @".\output\";

            if (!Directory.Exists(outputFolderPath))
                Directory.CreateDirectory(outputFolderPath);

            var outputFilePath = @".\output\test.pdf";

            if (File.Exists(outputFilePath))
                File.Delete(outputFilePath);

            using (var fileStream = File.Create(outputFilePath))
            {
                report.Content.Seek(0, SeekOrigin.Begin);
                report.Content.CopyTo(fileStream);
            }

            File.Exists(outputFilePath).Should().BeTrue();
        }
    }
}