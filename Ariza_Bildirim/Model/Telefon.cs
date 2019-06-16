using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ariza_Bildirim.Model
{
    public class Telefon
    {
        [Key]
        public int TelefonID { get; set; }
        [MaxLength(100)]
        public string TelefonMarkası { get; set; }
    }
}
