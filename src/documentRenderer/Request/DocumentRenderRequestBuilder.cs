namespace documentRenderer.Request
{
    public class DocumentRenderRequestBuilder
    {
        private DocumentRenderRequest documentRenderRequest = new DocumentRenderRequest();

        public DocumentRenderRequestBuilder UseTemplate(string template)
        {
            documentRenderRequest.TemplateName = template;
            return this;
        }

        public DocumentRenderRequestBuilder UseRecipe(string recipe)
        {
            documentRenderRequest.Recipe = recipe;
            return this;
        }
        public DocumentRenderRequestBuilder UsePageFormatA3()
        {
            documentRenderRequest.PageHeight = "420mm";
            documentRenderRequest.PageWidth = "297mm";
            return this;
        }

        public DocumentRenderRequestBuilder UsePageFormatA4()
        {
            documentRenderRequest.PageHeight = "297mm";
            documentRenderRequest.PageWidth = "210mm";
            return this;
        }

        public DocumentRenderRequestBuilder UsePageFormatA5()
        {
            documentRenderRequest.PageHeight = "210mm";
            documentRenderRequest.PageWidth = "148mm";
            return this;
        }

        public DocumentRenderRequestBuilder UsePageHeight(string pageHeightWithUnitOfMeasurement)
        {
            documentRenderRequest.PageHeight = pageHeightWithUnitOfMeasurement;
            return this;
        }

        public DocumentRenderRequestBuilder UsePageWidth(string pageWidthWithUnitOfMeasurement)
        {
            documentRenderRequest.PageWidth = pageWidthWithUnitOfMeasurement;
            return this;
        }

        public DocumentRenderRequestBuilder UseOutputFileType(string outputFileType)
        {
            documentRenderRequest.OutputFileType = outputFileType;
            return this;
        }

        public DocumentRenderRequestBuilder UseLanguage(string language)
        {
            documentRenderRequest.Language = language;
            return this;
        }

        public DocumentRenderRequestBuilder ToPDF()
        {
            documentRenderRequest.Recipe = "pdf";
            return this;
        }

        public DocumentRenderRequestBuilder ToHTML()
        {
            documentRenderRequest.Recipe = "html";
            return this;
        }

        public DocumentRenderRequestBuilder ToImage()
        {
            documentRenderRequest.Recipe = "image";
            return this;
        }

        public DocumentRenderRequestBuilder ToDocx()
        {
            documentRenderRequest.Recipe = "docx";
            return this;
        }

        public DocumentRenderRequestBuilder ToXlsx()
        {
            documentRenderRequest.Recipe = "xlsx";
            return this;
        }

        public DocumentRenderRequestBuilder SetData(object data)
        {
            documentRenderRequest.Data = data;
            return this;
        }

        public DocumentRenderRequest Build()
        {
            return documentRenderRequest;
        }
    }
}
