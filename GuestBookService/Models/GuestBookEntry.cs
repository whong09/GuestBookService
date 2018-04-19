using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuestBookService.Models
{
    public class GuestBookEntry
    {
        public string GuestName { get; set; }
        public string GuestComment { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
