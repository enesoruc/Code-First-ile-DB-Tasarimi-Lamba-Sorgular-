using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ariza_Bildirim.Model
{
    public class Personel
    {
        [Key]
        public int PersonelID { get; set; }
        [MaxLength(50)]
        public string PersonelAdı { get; set; }
        [MaxLength(50)]
        public string PersonelSoyadı { get; set; }
        public int PersonelTelefon { get; set; }
    }
}
