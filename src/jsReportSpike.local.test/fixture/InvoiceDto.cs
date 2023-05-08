namespace jsReportSpike.local.test.fixture
{
    internal class InvoiceDto
    {
        public int index { get; set; }
        public string number { get; set; }
        public InvoiceAddressDto seller { get; set; }
        public InvoiceAddressDto buyer { get; set; }
        public string base64Image { get; set; }
        public List<InvoiceItemDto> items { get; set; } = new List<InvoiceItemDto>();
        public string dynHtml { get; set; }

    }

    internal class InvoiceAddressDto
    {
        public string name { get; set; }
        public string road { get; set; }
        public string country { get; set; }
    }

    internal class InvoiceItemDto
    {
        public bool visible => price > 0;
        public string name { get; set; }
        public decimal price { get; set; }
    }

}
