using System;
using System.Net.Sockets;

namespace SetterInjection
{
    public interface IMesageSender
    {
        void SendMessage(string message);
    }

    public class EmailSender : IMesageSender
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("Gui email" + message);
        }
    }
    public class SmsSender : IMesageSender
    {
            public void SendMessage(string message)
            {
                Console.WriteLine("Gui SMS: " + message);
        }
    }
    public class NotificationService 
    {
        private IMesageSender _messageSender;
        public void SetMessageSender(IMesageSender messageSender)
        {
            _messageSender = messageSender;
        }
        public void Notify(string message)
        {
            if (_messageSender == null)
            {
                Console.WriteLine("Chua cos IMessage nao duoc thiet lap!");
            }
            else
            {
                _messageSender.SendMessage(message);
            }
        }

    }
    public class  Program 
    {
        public static void Main()
        {
            NotificationService notificationService = new NotificationService();
            notificationService.SetMessageSender(new EmailSender());
            notificationService.Notify("Chao cau ,day la email thong bao");

            NotificationService notificationService1 = new NotificationService();
            notificationService.SetMessageSender(new SmsSender());
            notificationService.Notify("Chao ban, day la sms thong bao");
        }
    }
}


