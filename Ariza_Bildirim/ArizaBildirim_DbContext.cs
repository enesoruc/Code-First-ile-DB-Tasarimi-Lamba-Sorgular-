using Ariza_Bildirim.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ariza_Bildirim
{
    class ArizaBildirim_DbContext : DbContext        
    {
        public ArizaBildirim_DbContext()
            :base("ArizaBildirimDB")
        {

        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
        public DbSet<Ariza> Arizalar { get; set; }
        public DbSet<Islem> Islemler { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Telefon> Telefonlar { get; set; }
        public DbSet<Ucret> Ucretler { get; set; }
    }
}
