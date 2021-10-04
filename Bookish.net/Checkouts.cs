using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookish.net
{
    public class Checkouts
    {
        public int CheckoutID { get; set; }
        public int UserID { get; set; }
        public int CopyID { get; set; }
        public DateTime DueDateReturn { get; set; }
    }
}
