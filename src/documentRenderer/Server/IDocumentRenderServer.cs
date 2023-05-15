using documentRenderer.Request;
using documentRenderer.Response;

namespace documentRenderer.Server
{
    public interface IDocumentRenderServer
    {
        DocumentRenderResponse Render(DocumentRenderRequest documentRenderRequest);
    }
}
