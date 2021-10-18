using Microsoft.EntityFrameworkCore;

namespace Psyent.DataModels
{
    public class PsyentDbContext : DbContext
    {
        public PsyentDbContext(DbContextOptions options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Mentor> Mentors { get; set; }

        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        FirstName = "Pera",
                        LastName = "Peric",
                        Password = "admin",
                        Username = "peraadmin"
                    }
                );

            modelBuilder.Entity<Mentor>()
                .HasData(
                    new Mentor
                    {
                        Id = 1,
                        FirstName = "Bob",
                        LastName = "Bobsky",
                        Description = "Lorem ipsum dolor sit amet consectetur adipisicing elit. Quae dolorem aut odit suscipit adipisci nostrum nulla est omnis officia! Necessitatibus laborum voluptates illo aliquam aliquid? Incidunt facere molestias odit tempore voluptatem ad sint repudiandae magnam illum suscipit hic fugiat eveniet dolores aliquid iure accusamus earum.Ad maiores deserunt sunt illo",
                        Address = "Skopje, Franklin Roozevelt br.2",
                        MentorType = "HR Specialist",
                        AreaOfExpertise = "HR",
                        SessionAvailability = 30,
                        YearsOfExperiance = 10,
                        Price = 25,
                        Email = "bob@bobsky.al",
                        Facebook = "https://www.facebook.com/bobsky",
                        Linkedin = "https://www.linkedin.com/bobsky",
                        Twitter = "https://www.twitter.com/bobsky",
                        Phone = 2398169029,
                        Mobile = 3203804539,
                        Image = "https://randomuser.me/api/portraits/men/1.jpg"
                    }
                );
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Seed(modelBuilder);
        }

    }
}
