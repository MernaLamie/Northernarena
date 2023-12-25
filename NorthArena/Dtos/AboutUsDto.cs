namespace NorthArena.Dtos
{
    public class AboutUsDto
    {
        public int? id { get; set; }
        public string Title { get; set; }
        public IFormFile Image { get; set; }
        public string Description { get; set; }

        public string Subcategory { get; set; }
    }
}
