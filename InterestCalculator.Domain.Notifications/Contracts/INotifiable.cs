using InterestCalculator.Domain.Notifications.Entities;
using System.Collections.Generic;

namespace InterestCalculator.Domain.Notifications.Contracts
{
    interface INotifiable
    {
        IReadOnlyCollection<Notification> Notifications { get; }
        bool IsInvalid { get; }
        bool IsValid { get; }

        void AddNotification(Notification notification);
        void AddNotifications(IEnumerable<Notification> notifications);
        string NotificationsMessage();
    }
}