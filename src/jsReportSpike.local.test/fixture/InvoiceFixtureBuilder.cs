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
                    new InvoiceItemDto { name = "0 CHF Eintrag", price = 0 },
                    new InvoiceItemDto { name = "Dritter Eintrag", price = 56 },
                    new InvoiceItemDto { name = "Vierter Eintrag", price = 57 },
                    new InvoiceItemDto { name = "Fünfter Eintrag", price = 58 }
                },
                dynHtml = @"<b>This is a dyn Html content</b>" +
                    "<ul><li>Example 1</li><li>Example 2</li><li>Example 3</li></ul>"
            };
        }
    }
}
