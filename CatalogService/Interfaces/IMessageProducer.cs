namespace CatalogService.Interfaces;
public interface IMessageProducer
{
    void SendMessage<T>(T message);
}