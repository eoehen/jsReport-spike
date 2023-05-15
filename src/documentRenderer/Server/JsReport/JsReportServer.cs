using documentRenderer.Request;
using documentRenderer.Response;
using jsreport.Client;
using jsreport.Types;

namespace documentRenderer.Server.JsReport
{
    public class JsReportServer : IDocumentRenderServer
    {
        private readonly ReportingService reportingService;

        public JsReportServer(string serverUrl, string username, string password)
        {
            reportingService = new ReportingService(serverUrl, username, password);
        }

        public DocumentRenderResponse Render(DocumentRenderRequest documentRenderRequest)
        {
            Task<Report> jsReportResponse = reportingService.RenderAsync(DocumentRenderRequestConverter
                .ConvertToRenderRequest(documentRenderRequest));

            return ReportConverter.ConvertToDocumentRenderResponse(jsReportResponse.Result);
        }
    }
}
