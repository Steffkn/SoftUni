namespace SoftJail.DataProcessor.ImportDto
{
    public class PrisonerImportDTO
    {
        public string FullName { get; set; }

        public string Nickname { get; set; }

        public int Age { get; set; }

        public string IncarcerationDate { get; set; }

        public string ReleaseDate { get; set; }

        public decimal? Bail { get; set; }

        public int? CellId { get; set; }

        public MailImportDTO[] Mails { get; set; }
    }

    public class MailImportDTO
    {
        public string Description { get; set; }

        public string Sender { get; set; }

        public string Address { get; set; }
    }
}
