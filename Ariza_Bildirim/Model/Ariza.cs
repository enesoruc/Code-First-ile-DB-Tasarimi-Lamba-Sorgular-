using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ariza_Bildirim.Model
{
    public class Ariza
    {
        [Key]
        public int ArizaID { get; set; }
        [MaxLength(250)]
        public string ArizaTanimi { get; set; }
    }
}
