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

            var swatterContext = new SwatterContext();
            if (_hasModelChecked)
            {
                Debug.WriteLine($"  - Schema ok!");
                return swatterContext;
            }

            Debug.WriteLine($"  - Checking Database...");
            if (!swatterContext.Database.CompatibleWithModel(false))
            {
                Debug.WriteLine($"  - Schema not ok, recreating database...");
                new DropCreateDatabaseIfModelChanges<SwatterContext>().InitializeDatabase(swatterContext);
                Debug.WriteLine($"  - Recreation done.");
            }
            else
            {
                Debug.WriteLine($"  - Schema ok!");
            }

            _hasModelChecked = true;
            return swatterContext;
        }
    }
}