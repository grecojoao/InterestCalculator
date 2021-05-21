﻿namespace InterestCalculator.Domain.Notifications.Entities
{
    public sealed class Notification
    {
        public string Property { get; private set; }
        public string Message { get; private set; }

        public Notification(string property, string message)
        {
            Property = property;
            Message = message;
        }
    }
}