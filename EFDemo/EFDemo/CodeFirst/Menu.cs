using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFDemo.CodeFirst
{
    [Table("MENUS")]
    public class Menu
    {
        [Key]
        [Column("MENU_ID")]
        public Guid Id { get; set; }
        public virtual List<Cafe> Cafes{get;set;}
        public virtual List<Te> Tes { get; set; }
    }

    [Table("CAFES")]
    public class Cafe
    {
        [Key]
        [Column("CAFE_ID")]
        public Guid Id { get; set; }
        public Guid MenuId { get; set; }
        public string Grano { get; set; }
        [ForeignKey("MenuId")]
        public virtual Menu Menu { get; set; }
    }

    [Table("TES")]
    public class Te
    {
        [Key]
        [Column("TE_ID")]
        public Guid Id { get; set; }

        [ForeignKey("Menu")]
        public Guid MenuId { get; set; }
        public string Infusion { get; set; }
        public string Textura { get; set; }
        public string Aroma { get; set; }
        public virtual Menu Menu { get; set; }
    }

    public class Refresco
    {
        [Key]
        public Guid Id { get; set; }
    }
    public class MenuContext : DbContext 
    {
        public MenuContext()
        {

        }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Cafe> Cafes { get; set; }
        public DbSet<Te> Tes { get; set; }
        public DbSet<Refresco> Resfrescos { get; set; }
    }
}
