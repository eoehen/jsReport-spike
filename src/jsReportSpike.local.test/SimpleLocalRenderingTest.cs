using FluentAssertions;
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

            report.Content.CopyTo(File.OpenWrite($"output/content-rendering.pdf"));
        }
    }
}