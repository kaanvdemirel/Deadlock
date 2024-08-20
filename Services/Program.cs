using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
     public class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                if (args[0] == "MessageSendingService")
                {
                    MessageSendingService.Send();
                }
                else if (args[0] == "MessageReceivingService")
                {
                    MessageReceivingService.Receive();
                }
                else
                {
                    Console.WriteLine("Unknown argument. Use 'MessageSendingService' or 'MessageReceivingService'.");
                }
            }
            else
            {
                Console.WriteLine("No arguments provided. Use 'MessageSendingService' or 'MessageReceivingService'.");
            }
        }
    }
}
