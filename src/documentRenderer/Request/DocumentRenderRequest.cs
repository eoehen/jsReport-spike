namespace documentRenderer.Request
{
    public class DocumentRenderRequest
    {
        public string TemplateName { get; set; }

        public string Language { get; set; }

        public string PageHeight { get; set; }

        public string PageWidth { get; set; }

        public string Recipe { get; set; }

        public string OutputFileType { get; set; }

        public object Data { get; set; }
    }
}
