using System;
using System.Collections;
using System.Linq;

namespace Telephony
{
    class Smartphone : ICaller, IBrowser
    {
        public void Browse(ICollection urls)
        {
            foreach (string url in urls)
            {
                if (url.Any(x => char.IsDigit(x)))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    Console.WriteLine($"Browsing: {url}!"); 
                }
            }
        }

        public void Call(ICollection phoneNumbers)
        {
            foreach (string phoneNumber in phoneNumbers)
            {
                if (phoneNumber.All(x => char.IsDigit(x)))
                {
                    Console.WriteLine($"Calling... {phoneNumber}");
                }
                else
                {
                    Console.WriteLine("Invalid number!");
                }
            }
        }

    }
}
