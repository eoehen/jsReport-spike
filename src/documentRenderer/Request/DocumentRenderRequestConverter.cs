using jsreport.Types;
using Mapster;

namespace documentRenderer.Request
{
    public static class DocumentRenderRequestConverter
    {
        static DocumentRenderRequestConverter()
        {
            TypeAdapterConfig.GlobalSettings.Default.NameMatchingStrategy(NameMatchingStrategy.Exact);
            TypeAdapterConfig.GlobalSettings.RequireExplicitMapping = true;
            TypeAdapterConfig.GlobalSettings.RequireDestinationMemberSource = true;

            TypeAdapterConfig<DocumentRenderRequest, RenderRequest>.NewConfig()
                .Map(dest => dest.Template.Name, src => src.TemplateName)
                .Map(dest => dest.Options.Localization.Language, src => src.Language)
                .Map(dest => dest.Template.Chrome.Height, src => src.PageHeight)
                .Map(dest => dest.Template.Chrome.Width, src => src.PageWidth)
                .Map(dest => dest.Template.Recipe, src => src.Recipe)
                .Map(dest => dest.Template.ChromeImage.Type, src => src.OutputFileType)
                .Map(dest => dest.Data, src => src.Data);
        }

        internal static RenderRequest ConvertToRenderRequest(DocumentRenderRequest documentRenderRequest)
        {
            return documentRenderRequest.Adapt<RenderRequest>();
        }
    }
}
