namespace NorthArena.Dtos
{
    public class SustainabilityDto
    {
        public int? Id { get; set; }
        public string SustainabilityQuotes { get; set; }
        public IFormFile Image { get; set; }
    }


    public class SustainabilityLst
    {
       public List<SustainabilityDto> SustainabilityDtos { get; set; }
    }
}
