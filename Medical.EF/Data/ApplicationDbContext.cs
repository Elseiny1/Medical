using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Medical.Core.Models;
using Medical.EF.Models;

namespace Medical.EF.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationIdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<PostImage>()
           .HasKey(b => new { b.PostId, b.Image_Url });

            builder.Entity<PostVedio>()
           .HasKey(b => new { b.PostId, b.Vedio_Url });
        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor> Doctors { get; set; }

        public DbSet<Post> Posts { get; set; }

        public DbSet<PostImage> PostImages { get; set; }

        public DbSet<PostVedio> PostVedios { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public DbSet<Clinic> Clinics { get; set; }

        public DbSet<Book> Books { get; set; }

        public virtual Doctor Doctor { get; set; } = null!;

        public virtual Patient Patient { get; set; } = null!;

    }
}
