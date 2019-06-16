using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ariza_Bildirim.Model
{
    public class Islem
    {
        [Key]
        public int IslemID { get; set; }
        [ForeignKey("Musteri")]
        public int MusteriID { get; set; }
        [ForeignKey("Personel")]
        public int PersonelID { get; set; }
        [ForeignKey("Telefon")]
        public int TelefonID { get; set; }
        [ForeignKey("Ariza")]
        public int ArizaID { get; set; }
        [ForeignKey("Ucret")]
        public int UcretID { get; set; }
        public DateTime AlinanTarih { get; set; }
        public DateTime VerilenTarih { get; set; }

        //Nav Props
        public Musteri Musteri { get; set; }
        public Personel Personel { get; set; }
        public Telefon Telefon { get; set; }
        public Ariza Ariza { get; set; }
        public Ucret Ucret { get; set; }
    }
}
