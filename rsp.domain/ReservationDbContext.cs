using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

public class ReservationDbContextFactory : IDesignTimeDbContextFactory<ReservationDbContext>
{
    internal static string connectionString =
        "Host=localhost;Database=reservation;Username=postgres;Password=P@ssw0rd";
    public ReservationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ReservationDbContext>();
        optionsBuilder.UseNpgsql(connectionString);

        return new ReservationDbContext(optionsBuilder.Options);
    }
}
public class ReservationDbContext : DbContext
{
    public ReservationDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
            optionsBuilder.UseNpgsql(ReservationDbContextFactory.connectionString);

        base.OnConfiguring(optionsBuilder);
    }


    public DbSet<User> Users { get; set; }
    public DbSet<Reservation> Reservations { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reservation>()
        .HasOne(reservation => reservation.User)
        .WithMany(user => user.Reservations)
        .HasForeignKey(reservation => reservation.UserId)
        .HasConstraintName("FK_User_Reservation");
    }


}