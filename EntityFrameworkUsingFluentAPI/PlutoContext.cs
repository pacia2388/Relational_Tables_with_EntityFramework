using System.Data.Entity;

namespace EntityFrameworkUsingFluentAPI
{
    class PlutoContext : DbContext
    {
        public PlutoContext()
            : base("name=PlutoContext")
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Cover> Covers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //The Name column in the Course Table is set to not nullable
            //The Max length of the Name column in 255 characters
            modelBuilder.Entity<Course>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(255);

            //The Description column in the Course Table is set to not nullable
            //The Max length of the Name column is 2000 characters
            modelBuilder.Entity<Course>()
                .Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            //The Course and Author table has a many to one relationship
            //A course can only have one author
            //An author can have many courses
            //Cascade on deleting an author is set to false
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Author)
                .WithMany(a => a.Courses)
                .HasForeignKey(c => c.AuthorId)
                .WillCascadeOnDelete(false);

            //The Course and Tags table has a many to many relationship
            //A course can have many tags
            //A tag can have many courses
            modelBuilder.Entity<Course>()
                .HasMany(c => c.Tags)
                .WithMany(t => t.Courses)
                .Map(m =>
                {
                    m.ToTable("CourseTags");
                    m.MapLeftKey("CourseId");
                    m.MapRightKey("TagId");
                });

            //The Course and Cover table has a one to one relationship
            //Course table acts as a principal or parent table
            //while the Cover table acts a dependent or child table
            modelBuilder.Entity<Course>()
                .HasRequired(c => c.Cover)
                .WithRequiredPrincipal(c => c.Course);

            base.OnModelCreating(modelBuilder);
        }
    }
}
