using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ariza_Bildirim.Model
{
    public class Musteri
    {
        public Musteri()
        {
            Islemler = new HashSet<Islem>();
        }
        [Key]
        public int MusteriID { get; set; }
        [Required]

        [MaxLength(50)]
        public string MusteriAdi { get; set; }
        [Required]

        [MaxLength(50)]
        public string MusteriSoyadi { get; set; }

        public long MusteriTelefon { get; set; }

        public int IslemNo { get; set; }

        //Nav Props
        public ICollection<Islem> Islemler { get; set; }
    }
}
