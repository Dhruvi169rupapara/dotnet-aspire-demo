﻿using Microsoft.EntityFrameworkCore;
using StudentAspireApp.ApiService.Model;

namespace StudentAspireApp.AppHost.Model
{
    public class StudentContext : DbContext
    {
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().ToTable("Students");
        }
    }
}