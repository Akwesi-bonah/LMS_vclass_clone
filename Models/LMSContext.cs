using System.Data.Entity;

namespace vclass_clone.Models
{
    public class LMSContext : DbContext
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
        public DbSet<AssignmentDB> Assignments { get; set; }
        public DbSet<CourseMaterialDB> CourseMaterials { get; set; }
        public DbSet<CourseMaterialFileDB> CourseMaterialFiles { get; set; }
        public DbSet<AssignmentSubmissionDB> AssignmentSubmissions { get; set; }
        public DbSet<CourseEnrollmentDB> CourseEnrollments { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // AdminDB configuration
            modelBuilder.Entity<AdminDB>()
                .HasRequired(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .WillCascadeOnDelete(true);

            // FacilitatorDB configuration
            modelBuilder.Entity<FacilitatorDB>()
                .HasRequired(f => f.User)
                .WithMany()
                .HasForeignKey(f => f.UserId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<FacilitatorDB>()
                .HasRequired(f => f.Department)
                .WithMany()
                .HasForeignKey(f => f.DepartmentId)
                .WillCascadeOnDelete(false);

            // StudentDB configuration
            modelBuilder.Entity<StudentDB>()
                .HasRequired(s => s.User)
                .WithMany()
                .HasForeignKey(s => s.UserId)
                .WillCascadeOnDelete(true);

            modelBuilder.Entity<StudentDB>()
                .HasOptional(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId)
                .WillCascadeOnDelete(false);

            // GroupDB configuration
            modelBuilder.Entity<GroupDB>()
                .HasRequired(g => g.Department)
                .WithMany()
                .HasForeignKey(g => g.DepartmentId)
                .WillCascadeOnDelete(false);

            // CourseDB configuration
            modelBuilder.Entity<CourseDB>()
                .HasMany(c => c.CourseAssignments)
                .WithRequired(ca => ca.Course)
                .HasForeignKey(ca => ca.CourseId)
                .WillCascadeOnDelete(false);

            // CourseAssignmentDB configuration
            modelBuilder.Entity<CourseAssignmentDB>()
                .HasRequired(ca => ca.Facilitator)
                .WithMany(f => f.CourseAssignments)
                .HasForeignKey(ca => ca.FacilitatorId)
                .WillCascadeOnDelete(false);

            // CourseEnrollment configuration
            modelBuilder.Entity<CourseEnrollmentDB>()
                .HasRequired(e => e.Course)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.CourseId)
                .WillCascadeOnDelete(true);


            modelBuilder.Entity<CourseEnrollmentDB>()
                .HasRequired(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId)
                .WillCascadeOnDelete(true); 



            base.OnModelCreating(modelBuilder);
        }

    }

}
