using documentRenderer.Request;
using documentRenderer.Response;
using jsreport.Binary;
using jsreport.Local;
using jsreport.Types;
using System.Runtime.InteropServices;

namespace documentRenderer.Server.JsReport
{
    public class JsReportLocal : IDocumentRenderServer
    {
        private readonly ILocalUtilityReportingService localReportingSystem;

        public JsReportLocal(string pathToTemplates)
        {
            localReportingSystem = new LocalReporting()
                .UseBinary(RuntimeInformation.IsOSPlatform(OSPlatform.Windows) ?
                    JsReportBinary.GetBinary() :
                    jsreport.Binary.Linux.JsReportBinary.GetBinary())

                .RunInDirectory(pathToTemplates)
                .KillRunningJsReportProcesses()
                .Configure(cfg => cfg.DoTrustUserCode().FileSystemStore().BaseUrlAsWorkingDirectory())
                .AsUtility()
                .Create();
        }

        public DocumentRenderResponse Render(DocumentRenderRequest documentRenderRequest)
        {
            Task<Report> jsReportResponse = localReportingSystem.RenderAsync(DocumentRenderRequestConverter
                .ConvertToRenderRequest(documentRenderRequest));

            return ReportConverter.ConvertToDocumentRenderResponse(jsReportResponse.Result);
        }
    }
}