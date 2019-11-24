using Microsoft.EntityFrameworkCore;
using Hospital.Model;

namespace Hospital.DB
{
    public class DBHospitalContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Server=127.0.0.1;User Id=postgres;Password=nagimullin;Database=hospital;");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<AuthM> AuthMs { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<OutpatentCard> OutpatentCards { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<MedCard> MedCards { get; set; }
    }
}
