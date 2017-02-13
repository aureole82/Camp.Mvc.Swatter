using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;

namespace Camp.Mvc.Swatter.Models
{
    internal class SwatterContextFactory : IDbContextFactory<SwatterContext>
    {
        private bool _hasModelChecked;

        public SwatterContext Create()
        {
            Debug.WriteLine($"{nameof(SwatterContextFactory)}.{nameof(Create)}()...");
            var context = new SwatterContext
            {
                Database = {Log = s => Debug.Write(s)}
            };

            if (_hasModelChecked)
            {
                Debug.WriteLine("  - Schema already validated!");
                return new SwatterContext();
            }

            Debug.WriteLine("  - Checking Database...");
            if (!context.Database.Exists() || !context.Database.CompatibleWithModel(false))
            {
                Debug.WriteLine("  - Database doesn't exist or invalid schema, recreating database...");

                new RecreateSwatterDatabaseInitializer().InitializeDatabase(context);
                Debug.WriteLine("  - Seeding done.");
            }
            else
            {
                Debug.WriteLine("  - Schema ok!");
            }

            _hasModelChecked = true;
            return context;
        }
    }

    public class RecreateSwatterDatabaseInitializer : DropCreateDatabaseIfModelChanges<SwatterContext>
    {
        protected override void Seed(SwatterContext context)
        {
            context.Pots.AddRange(new[]
            {
                new Pot
                {
                    Abbreviation = "HY",
                    Name = "The honey pot",
                    Description = @"The sweetest spot!
Where everything happens :-)",
                    Chief = "blowfly@honey.pot"
                },
                new Pot
                {
                    Abbreviation = "CU",
                    Name = "Cucumber pot",
                    Description = @"Terrible sour! You don't be here unless you have to.",
                    Chief = "mayfly@cucumber.pot"
                }
            });

            // Will call SaveChanges() for us.
            base.Seed(context);
        }
    }
}