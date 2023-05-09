using jsreport.Client;
using jsReportSpike.local.test.fixture;
using jsreport.Types;
using System.Net;

namespace jsReportSpike.test
{
    public class Rendering
    {
        // Jsreport needs to run as docker container and sample templates
        // need to be available for successfull test runs.

        [Fact(Skip = "local running jsreport-container needed")]
        public async Task RenderingTestInvoice()
        {

            var reportingService = new ReportingService("http://localhost:15488", "admin", "password");

            var data = InvoiceFixtureBuilder.BuildInvoiceData(1);

            var report = await reportingService.RenderByNameAsync("invoice-main", data);

            Assert.NotNull(report.Content);
        }

        [Fact(Skip = "local running jsreport-container needed")]
        public async Task RenderingTestInvoiceNoCredentials()
        {
            var reportingService = new ReportingService("http://localhost:15488");

            var data = InvoiceFixtureBuilder.BuildInvoiceData(1);

            Task renderReport() => reportingService.RenderByNameAsync("invoice-main", data);

            await Assert.ThrowsAsync<JsReportException>(renderReport).ConfigureAwait(false);
        }

        [Fact(Skip = "local running jsreport-container needed")]
        public void RenderingTestInvoiceSavePDFOnFileSystemWithCustomTitel()
        {
            var reportingService = new ReportingService("http://localhost:15488", "admin", "password");

            var data = InvoiceFixtureBuilder.BuildInvoiceData(1);

            var report = reportingService.RenderAsync(new RenderRequest()
            {
                Template = new Template()
                {
                    Name = "invoice-main"
                },
                Data = data,
                Options = new RenderOptions()
                {
                    Reports = new ReportsOptions()
                    {
                        Save = true,
                        Async = true,
                        BlobName = "invoice_custom_titel"
                    }
                }
            });

            Assert.NotNull(report.Result.Meta.AsyncReportLocation);
        }

        [Fact(Skip = "local running jsreport-container needed")]
        public async Task RenderingTestServerAvailabilityCheck()
        {
            using var client = new HttpClient();

            var result = await client.GetAsync("http://localhost:15488/api/ping");

            Assert.True(result.IsSuccessStatusCode);
        }
    }
}