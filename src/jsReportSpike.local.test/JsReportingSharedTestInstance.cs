using jsreport.Binary;
using jsreport.Local;

namespace jsReportSpike.local.test
{
    [CollectionDefinition("JsReportingSharedTestinstanceFixture")]
    public class JsReportingSharedTestinstanceFixture: ICollectionFixture<JsReportingSharedTestinstanceFixture>
    {
        private readonly ILocalUtilityReportingService localReportingSystem;

        public JsReportingSharedTestinstanceFixture()
        {
            var currentDirectoryPath = Path.Combine(Directory.GetCurrentDirectory(), "jsreport");

            localReportingSystem =
                new LocalReporting()
                .UseBinary(JsReportBinary.GetBinary())
                .RunInDirectory(currentDirectoryPath)
                .KillRunningJsReportProcesses()
                .Configure(cfg => cfg.DoTrustUserCode().FileSystemStore().BaseUrlAsWorkingDirectory())
                .AsUtility()
                .Create();
        }

        public ILocalUtilityReportingService LocalReportingInstance => this.localReportingSystem;
    }
}
