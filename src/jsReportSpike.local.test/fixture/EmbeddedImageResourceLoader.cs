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

        public byte[]? ReadManifestResourceAsBinaryArray(string key)
        {
            if (assembly != null)
            {
                var stream = assembly.GetManifestResourceStream(key);
                using MemoryStream ms = new();
                if (stream != null)
                {
                    stream.CopyTo(ms);
                    return ms.ToArray();
                }
            }
            return null;
        }

        public string LoadImageAsBase64(string key)
        {
            var binaryArray = ReadManifestResourceAsBinaryArray(key);
            if (binaryArray != null)
            {
                return "data:image/png;base64," + Convert.ToBase64String(binaryArray);
            }
            return string.Empty;
        }
    }
}
