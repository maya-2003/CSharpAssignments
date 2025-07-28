using OOPAssignment3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment3.Classes
{
    internal class PushNotificationService : INotificationService
    {
        public void SendNotification(string recepient, string message)
        {
            Console.WriteLine($"Notification: \n to: {recepient} \n {message}");
        }
    }
}
