using System.Collections.ObjectModel;
using GreenGuard.Models;

namespace GreenGuard.Services
{
    public class MessageService
    {
        public static MessageService Current { get; } = new MessageService();

        public ObservableCollection<NotificationMessage> AllMessages { get; } = new();

        private MessageService()
        {
            // Initial system message
            AllMessages.Add(new NotificationMessage
            {
                From = "System",
                To = "Admin",
                Subject = "Welcome",
                Body = "Admin message system initialized successfully.",
                Time = DateTime.Now.ToString("g")
            });
        }

        // ✅ The only correct AddMessage method
        public void AddMessage(GreenGuard.Models.NotificationMessage message)
        {
            AllMessages.Add(message);
        }


        // ✅ Returns messages based on role
        public IEnumerable<NotificationMessage> GetMessagesForRole(string role)
        {
            if (role == "Admin")
            {
                // Admin sees everything
                return AllMessages;
            }
            else if (role == "NGO")
            {
                // NGO sees messages exchanged with Admin
                return AllMessages.Where(m =>
                    (m.From == "Admin" && m.To == "NGO") ||
                    (m.From == "NGO" && m.To == "Admin"));
            }
            else if (role == "Leader")
            {
                return AllMessages.Where(m =>
                    (m.From == "Leader" && m.To == "Admin") ||
                    (m.From == "Admin" && m.To == "Leader") ||
                    (m.From == "Leader" && m.To == "Volunteer") ||
                    (m.From == "Volunteer" && m.To == "Leader"));
            }
            else if (role == "Volunteer")
            {
                return AllMessages.Where(m =>
                    (m.From == "Leader" && m.To == "Volunteer") ||
                    (m.From == "Volunteer" && m.To == "Leader"));
            }

            return Enumerable.Empty<NotificationMessage>();
        }

        internal void AddMessage(Views.NotificationMessage response)
        {
            throw new NotImplementedException();
        }
    }
}
