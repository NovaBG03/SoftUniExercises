using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Domain
{
    public class Receipt
    {
        //•	Has an Id – a GUID String or an Integer.
        //•	Has a Fee – a decimal number.
        //•	Has an Issued On – a DateTime object.
        //•	Has a Recipient – a User object.
        //•	Has a Package – a Package object.

        public string Id { get; set; }

        public decimal Fee { get; set; }

        public DateTime IssuedOn { get; set; }

        public string RecipientId { get; set; }

        public PandaUser Recipient { get; set; }

        public string PackageId { get; set; }

        public Package Package { get; set; }
    }
}
