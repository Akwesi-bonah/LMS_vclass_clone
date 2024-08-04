using System.Data.Entity;


namespace vclass_clone.Models
{
    public class LMSContext: DbContext
    {
        public LMSContext() : base("name=LMSContext")
        {
        }

        public DbSet<UserDB> Users { get; set; }
        public DbSet<DepartmentDB> Departments { get; set; }
        public DbSet<AdminDB> Admins { get; set; }
        public DbSet<StudentDB> Students { get; set; }
        public DbSet<GroupDB> Groups { get; set; }
        public DbSet<FacilitatorDB> Facilitators { get; set; }
        public DbSet<CourseDB> Courses { get; set; }
        public DbSet<CourseAssignmentDB> CourseAssignments { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminDB>()
                .HasRequired(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<FacilitatorDB>()
                .HasRequired(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .WillCascadeOnDelete(true);
            ;

            modelBuilder.Entity<StudentDB>()
                .HasRequired(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .WillCascadeOnDelete(true);

            

            base.OnModelCreating(modelBuilder);
        }

    }
}
