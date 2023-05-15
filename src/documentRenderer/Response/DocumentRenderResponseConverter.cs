using jsreport.Types;
using Mapster;

namespace documentRenderer.Response
{
    public static class ReportConverter
    {
        static ReportConverter()
        {
            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Exact);
            TypeAdapterConfig.GlobalSettings.RequireExplicitMapping = true;
            TypeAdapterConfig.GlobalSettings.RequireDestinationMemberSource = true;

            TypeAdapterConfig<Report, DocumentRenderResponse>.NewConfig()
                .Map(dest => dest.Content, src => src.Content)
                .Map(dest => dest.ContentType, src => src.Meta.ContentType)
                .Map(dest => dest.FileExtension, src => src.Meta.FileExtension)
                .Map(dest => dest.SavedResultLocation, src => src.Meta.AsyncReportLocation);
        }

        internal static DocumentRenderResponse ConvertToDocumentRenderResponse(Report report)
        {
            return report.Adapt<DocumentRenderResponse>();
        }
    }
}
