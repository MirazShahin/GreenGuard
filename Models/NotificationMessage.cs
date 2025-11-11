namespace GreenGuard.Models
{
    public class NotificationMessage
    {
        public string From { get; set; } = "";
        public string To { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Body { get; set; } = "";
        public string Time { get; set; } = ""; 
        public int? VolunteerCount { get; set; }
        public string Zone { get; set; }
    }
}
