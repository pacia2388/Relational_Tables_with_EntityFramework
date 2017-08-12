using System.Data.Entity.ModelConfiguration;

namespace EntityFrameworkUsingFluentAPI.EntityConfigurations
{
    class CurseConfigurations : EntityTypeConfiguration<Course>
    {
        public CurseConfigurations()
        {
            /*Configuration Sequence
             * 1 Table Name
             * 2 Primary Keys
             * 3 Property Configurations (A - Z)
             * 4 Relationship configurations (A - Z)             * 
             */

            //Overriding the table Name from Course to tbl_Course
            //ToTable("tbl_Course"); //uncoment to apply table name


            //The Description column in the Course Table is set to not nullable
            //The Max length of the Name column is 2000 characters

            Property(c => c.Description)
                .IsRequired()
                .HasMaxLength(2000);

            //The Name column in the Course Table is set to not nullable
            //The Max length of the Name column in 255 characters
            Property(c => c.Name)
            .IsRequired()
            .HasMaxLength(255);

            //The Course and Author table has a many to one relationship
            //A course can only have one author
            //An author can have many courses
            //Cascade on deleting an author is set to false
            HasRequired(c => c.Author)
            .WithMany(a => a.Courses)
            .HasForeignKey(c => c.AuthorId)
            .WillCascadeOnDelete(false);

            //The Course and Cover table has a one to one relationship
            //Course table acts as a principal or parent table
            //while the Cover table acts a dependent or child table
            HasRequired(c => c.Cover)
                .WithRequiredPrincipal(c => c.Course);

            //The Course and Tags table has a many to many relationship
            //A course can have many tags
            //A tag can have many courses
            HasMany(c => c.Tags)
            .WithMany(t => t.Courses)
            .Map(m =>
            {
                m.ToTable("CourseTags");
                m.MapLeftKey("CourseId");
                m.MapRightKey("TagId");
            });
        }
    }
}
