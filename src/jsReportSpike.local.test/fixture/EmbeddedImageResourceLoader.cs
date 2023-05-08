using System.Drawing;
using System.Drawing.Imaging;
using System.Reflection;

namespace jsReportSpike.local.test.fixture
{
    internal class EmbeddedImageResourceLoader
    {
        private readonly Assembly? assembly;

        public EmbeddedImageResourceLoader()
        {
            assembly = Assembly.GetAssembly(typeof(EmbeddedImageResourceLoader));
        }

        public string LoadImageAsBase64(string key)
        {
            var stream = assembly.GetManifestResourceStream("jsReportSpike.local.test.fixture.data.emer-logo.png");

            using (var ms = new MemoryStream())
            {
                using (var bitmap = new Bitmap(stream))
                {
                    bitmap.Save(ms, ImageFormat.Png);
                    return "data:image/png;base64," + Convert.ToBase64String(ms.GetBuffer());
                }
            }
        }
    }
}
