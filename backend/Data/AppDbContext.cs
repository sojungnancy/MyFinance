using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
public class AppDbContext : DbContext
{
    public AppDbContext() {}  

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) {}

    public DbSet<User> Users => Set<User>();
    
    public DbSet<Transaction> Transactions => Set<Transaction>();
    public DbSet<Budget> Budgets => Set<Budget>();

    public DbSet<Announcement> Announcements => Set<Announcement>();
    public DbSet<UserNotification> UserNotifications => Set<UserNotification>();
    public DbSet<Feedback> Feedbacks => Set<Feedback>();
    }
}