namespace jsReportSpike.local.test.fixture
{
    internal static class InvoiceFixtureBuilder
    {
        public static InvoiceDto BuildInvoiceData(int index)
        {
            return new InvoiceDto
            {
                index = index,
                number = "56-457-5454",
                seller = new InvoiceAddressDto
                {
                    name = "exanic AG",
                    road = "Weststrasse 3",
                    country = "6340 Baar"
                },
                buyer = new InvoiceAddressDto
                {
                    name = "Acme Corp.",
                    road = "Ententeich 323",
                    country = "7000 Entenhausen"
                },
                items = new List<InvoiceItemDto>
                {
                    new InvoiceItemDto { name = "Erster Eintrag", price = 300 },
                    new InvoiceItemDto { name = "Zweiter Eintrag", price = 55 },
                    new InvoiceItemDto { name = "Dritter Eintrag", price = 56 },
                    new InvoiceItemDto { name = "Vierter Eintrag", price = 57 },
                    new InvoiceItemDto { name = "F�nfter Eintrag", price = 58 }
                }
            };
        }
    }
}
