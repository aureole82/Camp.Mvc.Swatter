using System.Data.Entity;

namespace Camp.Mvc.Swatter.Models
{
    public class SwatterContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public SwatterContext() : base("name=SwatterContext")
        {
        }

        public DbSet<Pot> Pots { get; set; }

        public DbSet<Fly> Flies { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pot>()
                .HasMany(pot => pot.Flies)
                .WithRequired()
                .HasForeignKey(fly => fly.PotId)
                // Not neccessary. Entity Framework creates ON DELETE CASCADE constraint implicitly if appropriate.
                //.WillCascadeOnDelete(true)
                ;

            base.OnModelCreating(modelBuilder);
        }
    }
}