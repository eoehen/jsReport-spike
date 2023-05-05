using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jsReportSpike.local.test.fixture
{
    internal static class InvoiceFixtureBuilder
    {
        public static object BuildInvoiceData(int index)
        {
            return new
            {
                index,
                number = "56-457-5454",
                seller = new
                {
                    name = "exanic AG",
                    road = "Weststrasse 3",
                    country = "6340 Baar"
                },
                buyer = new
                {
                    name = "Acme Corp.",
                    road = "Ententeich 323",
                    country = "7000 Entenhausen"
                },
                items = new[]
                {
                    new { name = "Erster Eintrag", price = 300 },
                    new { name = "Zweiter Eintrag", price = 55 },
                    new { name = "Dritter Eintrag", price = 56 },
                    new { name = "Vierter Eintrag", price = 57 },
                    new { name = "F�nfter Eintrag", price = 58 }
                }
            };
        }
    }
}
