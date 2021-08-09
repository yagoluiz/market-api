using System;

namespace Market.Domain.Notification
{
    public class NotificationMessage
    {
        public NotificationMessage(string key, string value)
        {
            Id = Guid.NewGuid();
            Key = key;
            Value = value;
        }

        public Guid Id { get; }
        public string Key { get; }
        public string Value { get; }
    }
}
