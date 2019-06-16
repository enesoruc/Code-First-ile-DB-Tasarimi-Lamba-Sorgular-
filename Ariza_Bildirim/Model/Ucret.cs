using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ariza_Bildirim.Model
{
    public class Ucret
    {
        [Key]
        public int UcretID { get; set; }
        public decimal UcretMiktar { get; set; }
    }
}
