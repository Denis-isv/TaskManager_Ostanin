using Microsoft.EntityFrameworkCore;
using TaskManager_Ostanin.Classes.Database;
using TaskManager_Ostanin.Models;

namespace TaskManager_Ostanin.Context
{
    public class TasksContext : DbContext
    {
        public DbSet<Tasks> Tasks { get; set; }
        public TasksContext()
        {
            Database.EnsureCreated();
            Tasks.Load();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.connection, Config.version);
        }
    }
}
