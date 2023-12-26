namespace NorthArena.Dtos
{
    public class IntroDto
    {
        public int? Id { get; set; }
        public string IntorEn { get; set; }
        public string IntorAr { get; set; }

        public IFormFile Imgage { get; set; }
    }
}
