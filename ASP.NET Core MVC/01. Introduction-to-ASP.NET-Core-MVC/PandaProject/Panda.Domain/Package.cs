using Panda.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Panda.Domain
{
    public class Package
    {
        //•	Has an Id – a GUID String or an Integer.
        //•	Has a Description – a string.
        //•	Has a Weight – a floating-point number.
        //•	Has a Shipping Address – a string.
        //•	Has a Status – can be one of the following values (“Pending”, “Shipped”, “Delivered”, “Acquired”)
        //•	Has an Estimated Delivery Date – A DateTime object.
        //•	Has a Recipient – a User object.

        public string Id { get; set; }

        public string Description { get; set; }

        public float Weight { get; set; }

        public string ShippingAddress { get; set; }

        public PackageStatus Status { get; set; }

        public DateTime? DeliveryDate { get; set; }

        public string RecipientId { get; set; }

        public PandaUser Recipient { get; set; }

        public Receipt Receipt { get; set; }
    }
}
