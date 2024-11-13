namespace SkillUpHub.Notification.Interfaces;

public interface IMessageBusClient
{
    void Initialize();
    void PublishMessage<T>(T message, string exchange, string routingKey);
    void PublishErrorMessage(Exception exception);
    void Subscribe<T>(string queueName, Func<T, Task> onMessageReceived);
}