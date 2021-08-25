using Microsoft.EntityFrameworkCore;

namespace LoseCoupledMonolithic.PaymentService
{
    public class PaymentContext : DbContext
    {
        public PaymentContext(DbContextOptions<PaymentContext> options) : base(options) { }

        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payment>().ToTable("Payments", "payment");
            modelBuilder.Entity<Payment>().HasKey(x => x.Id);
            modelBuilder.Entity<Payment>().Property(x => x.Id).ValueGeneratedOnAdd();

            base.OnModelCreating(modelBuilder);
        }
    }
}
