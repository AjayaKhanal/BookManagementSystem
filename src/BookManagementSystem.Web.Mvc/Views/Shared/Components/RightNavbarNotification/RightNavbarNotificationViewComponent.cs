using Abp.Notifications;
using Abp.Runtime.Session;
using BookManagementSystem.Authorization.Users;
using BookManagementSystem.Web.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookManagementSystem.Web.Views.Shared.Components.RightNavbarNotification
{
    public class RightNavbarNotificationViewComponent : BookManagementSystemViewComponent
    {
        private readonly IUserNotificationManager _notificationUserManager;
        private readonly INotificationStore _notificationStore;
        private readonly IHubContext<NotificationHub> _hubContext;

        public RightNavbarNotificationViewComponent(
            IUserNotificationManager notificationUserManager,
            INotificationStore notificationStore,
            IHubContext<NotificationHub> hubContext) // Add IHubContext parameter
        {
            _notificationUserManager = notificationUserManager;
            _notificationStore = notificationStore;
            _hubContext = hubContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notifications = await _notificationUserManager.GetUserNotificationsAsync(
                AbpSession.ToUserIdentifier(), UserNotificationState.Unread);

            var model = new RightNavbarNotificationViewModel
            {
                UnreadCount = notifications.Count,
                Notifications = notifications
                    .OrderByDescending(n => n.Notification.CreationTime)
                    .Take(10)
                    .Select(n => new NotificationViewModel
                    {
                        Id = n.Id.ToString(),
                        CreationTime = n.Notification.CreationTime,
                        State = n.State.ToString().ToLower(),
                        Data = n.Notification.Data.ToString(),
                        Target = n.TargetNotifiersList.ToString(),
                        SignalRGroupName = GetSignalRGroupName(n.Notification.NotificationName)
                    }).ToList()
            };

            //// Join the SignalR group for real-time notifications
            //var userId = AbpSession.GetUserId();
            //if (userId != default(long))
            //{
            //    var connectionId = Context.ConnectionId;
            //    await _hubContext.Groups.AddToGroupAsync(connectionId, GetSignalRGroupName(userId));
            //}

            return View(model);
        }

        private string GetSignalRGroupName(long userId)
        {
            return $"User:{userId}";
        }

        private string GetSignalRGroupName(string notificationName)
        {
            return notificationName.ToLower().Replace(" ", "-");
        }
    }

}

