using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
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
                try
                {
                    new RecreateSwatterDatabaseInitializer().InitializeDatabase(context);
                }
                catch (DbEntityValidationException e)
                {
                    Console.WriteLine($"{nameof(DbEntityValidationException)}: {e.Message}");
                    foreach (var validationError in e.EntityValidationErrors)
                    {
                        Debug.WriteLine($"- {validationError.Entry.Entity.GetType().Name}");
                        foreach (var error in validationError.ValidationErrors)
                        {
                            Debug.WriteLine($"  * {error.PropertyName}: {error.ErrorMessage}");
                        }
                        throw;
                    }
                }
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
                    Chief = "blowfly@honey.pot",
                    Flies =
                    {
                        new Fly
                        {
                            Head = "Cannot fly",
                            Body = @"This morning I awoke
realized that I cannot fly. :-(",
                            Creator = "fly@hornets.net",
                            Weight = Weight.Heavy
                        },
                        new Fly
                        {
                            Head = "I'm tired",
                            Body = @"Every evening I'm getting tired. Need help!",
                            Creator = "zzz@honey.cup"
                        },
                        new Fly
                        {
                            Head = "The landlord slaps",
                            Body =
                                @"Everytime I sip at landlord's coffee he takes the swatter and tries to kill me!!!
Could it be he doesn't like me?",
                            Creator = "shy@coffee.cup",
                            Weight = Weight.Heavy
                        },
                        new Fly
                        {
                            Head = "I hear myself buzzing",
                            Body = @"Zzzzzzzzzzzzzzzzzzhhhh. Everywhere I fly. Cannot escape...
Drives me nuts",
                            Creator = "wacky@honey.pot",
                            Weight = Weight.Trivial
                        }
                    }
                },
                new Pot
                {
                    Abbreviation = "CU",
                    Name = "Cucumber pot",
                    Description = @"Terrible sour! You don't be here unless you have to.",
                    Chief = "mayfly@cucumber.pot",
                    Flies =
                    {
                        new Fly
                        {
                            Head = "So sour",
                            Body = @"So sour, so boring. Why should I am waiting here?",
                            Creator = "mayfly@cucumber.pot"
                        }
                    }
                }
            });

            // Will call SaveChanges() for us.
            base.Seed(context);
        }
    }
}