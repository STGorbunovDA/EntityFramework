using EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore
{
    class Context : DbContext
    {
        public Context() 
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"host=localhost;port=5433;database=db;username=postgres;password=q2")
                //.LogTo(Console.WriteLine)
                ;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>().Property(p => p.Name).HasColumnName("Title");

            modelBuilder.Entity<Person>()
                .HasOne<Department>(p => p.Department)
                .WithMany(d => d.Persons)
                .HasForeignKey(p => p.CurrentDepartmentId);

            // Разрешить удаление адреса
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Adress)
                .WithOne(a => a.Person)
                .OnDelete(DeleteBehavior.SetNull);

            //Изменить название таблицы многие ко многим
            modelBuilder.Entity<Person>()
                .HasMany(p => p.Hobbies)
                .WithMany(h => h.Persons)
                .UsingEntity(j => j.ToTable("PersonHobbies"));
        }

        public DbSet<Person> Persons { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Adress> Adresses { get; set; }
        public DbSet<Hobby> Hobbies { get; set; }
    }
}
