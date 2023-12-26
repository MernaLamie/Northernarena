namespace NorthArena.Dtos
{
    public class AboutUsDto
    {
        public int? id { get; set; }
        public string TitleEn { get; set; }
        public string TitleAr { get; set; }
        public IFormFile Image { get; set; }
        public string DescriptionEn { get; set; }
        public string DescriptionAr { get; set; }


     
    }
}
