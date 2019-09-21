namespace BillsPaymentSystem.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public User()
        {
            this.PaymentMethods = new HashSet<PaymentMethod>();
        }

        public int UserId { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [MinLength(3), MaxLength(80)]
        public string Email { get; set; }

        [Required]
        [MinLength(3), MaxLength(25)]
        public string Password { get; set; }

        public ICollection<PaymentMethod> PaymentMethods { get; set; }
    }
}
