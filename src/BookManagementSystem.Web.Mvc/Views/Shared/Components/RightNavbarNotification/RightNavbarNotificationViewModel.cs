using System;
using System.Collections.Generic;

namespace BookManagementSystem.Web.Views.Shared.Components.RightNavbarNotification
{
    public class RightNavbarNotificationViewModel
    {
        public int UnreadCount { get; set; }
        public List<NotificationViewModel> Notifications { get; set; }
    }

    public class NotificationViewModel
    {
        public string Id { get; set; }
        public DateTime CreationTime { get; set; }
        public string State { get; set; }
        public string Data { get; set; }
        public string Target { get; set; }
        public string SignalRGroupName { get; set; }
        //public string Url { get; set; }
        //public string Title { get; set; }
        //public string Message { get; set; }
    }
}
