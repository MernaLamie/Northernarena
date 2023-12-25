using Microsoft.EntityFrameworkCore;

namespace NorthArena.Models
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext() { }
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder OptionsBuilder)
        {
            if (!OptionsBuilder.IsConfigured)
            {
                OptionsBuilder.UseSqlServer("Data Source=.;database=NorthernArena;Trusted_Connection=True;TrustServerCertificate=true;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
       public DbSet<AboutUS> AboutUs { get; set; } = null;
    public    DbSet<ContactUs> ContactUs { get; set; } = null;
      public  DbSet<Reservation> Reservations { get; set; } = null;
      public  DbSet<Intro> Intro { get; set; } = null;
        public DbSet<WebSiteData> WebsiteData { get; set; } = null;

        public DbSet<Sustainability> Sustainabilities { get; set; } = null;




    }

}
