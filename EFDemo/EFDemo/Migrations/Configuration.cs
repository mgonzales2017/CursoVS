namespace EFDemo.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFDemo.CodeFirst.MenuContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(EFDemo.CodeFirst.MenuContext context)
        {
            var menu = new CodeFirst.Menu()
            {
                Id = Guid.NewGuid(),
            };
            context.Cafes.Add(new CodeFirst.Cafe()
            {
                Grano = "Molido " + new Random().Next(1, 100).ToString(),
                Id = Guid.NewGuid(),
                Menu = menu,
                MenuId = menu.Id,
            });
            context.Menus.Add(menu);
            context.Tes.Add(new CodeFirst.Te()
            {
                Infusion = "Pulverizada " + new Random().Next(1, 100).ToString(),
                Id = Guid.NewGuid(),
                Menu = menu,
                MenuId = menu.Id,
                Aroma = "Aroma " + new Random().Next(1, 100).ToString(),
            });
            context.SaveChanges();
            
        }
    }
}
