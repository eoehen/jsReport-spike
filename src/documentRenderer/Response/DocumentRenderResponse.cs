namespace documentRenderer.Response
{
    public class DocumentRenderResponse
    {
        public Stream Content { get; set; }

        public string ContentType { get; set; }

        public string FileExtension { get; set; }

        public string SavedResultLocation { get; set; }
    }
}
