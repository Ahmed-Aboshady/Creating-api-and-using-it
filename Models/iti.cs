namespace api_lab2
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class iti : DbContext
    {
        public iti()
            : base("name=iti")
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<Topic> Topics { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
