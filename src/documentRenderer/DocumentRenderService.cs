using documentRenderer.Request;
using documentRenderer.Response;
using documentRenderer.Server;

namespace documentRenderer
{
    public class DocumentRenderService
    {
        private readonly IDocumentRenderServer documentRenderServer;

        public DocumentRenderService(IDocumentRenderServer documentRenderServer)
        {
            this.documentRenderServer = documentRenderServer;
        }

        public DocumentRenderResponse Render(DocumentRenderRequest documentRenderRequest)
        {
            return documentRenderServer.Render(documentRenderRequest);
        }
    }
}
