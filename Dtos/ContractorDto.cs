namespace OrderProject.Dtos
{
    /// <summary>
    /// Dto is for creating Contractor
    /// </summary>
    public class ContractorDto : BaseDto
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Position { get; set; }

        public string CompanyName { get; set; }

        public int CompanyId { get; set; }

        public string OrderName { get; set; }

        public int OrderId { get; set; }
    }
}
