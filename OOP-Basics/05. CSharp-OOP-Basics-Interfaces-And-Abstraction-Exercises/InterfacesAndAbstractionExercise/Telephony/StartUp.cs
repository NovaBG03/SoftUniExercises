using System;

namespace Telephony
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Smartphone smartphone = new Smartphone();

            ICaller caller = smartphone;
            string[] phoneNumbers = Console.ReadLine().Split();
            caller.Call(phoneNumbers);

            IBrowser browser = smartphone;
            string[] urls = Console.ReadLine().Split();
            browser.Browse(urls);
        }
    }
}
