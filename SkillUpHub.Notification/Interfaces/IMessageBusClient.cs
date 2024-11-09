namespace SkillUpHub.Notification.Interfaces;

public interface IMessageBusClient
{
    void PublishMessage<T>(T message, string routingKey);
    void Subscribe<T>(string queueName, Func<T, Task> onMessageReceived);
}