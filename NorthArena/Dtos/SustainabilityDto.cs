namespace NorthArena.Dtos
{
    public class SustainabilityDto
    {
        public int? Id { get; set; }
        public string SustainabilityEnTitle { get; set; }
        public string SustainabilityArTitle { get; set; }

        public string SustainabilityEnQuotes { get; set; }
        public string SustainabilityArQuotes { get; set; }

        public IFormFile Image { get; set; }
    }


    public class SustainabilityLst
    {
       public List<SustainabilityDto> SustainabilityDtos { get; set; }
    }
}
