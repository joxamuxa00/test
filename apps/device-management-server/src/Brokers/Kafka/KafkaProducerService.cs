using DeviceManagement.Brokers.Infrastructure;

namespace DeviceManagement.Brokers.Kafka;

public class KafkaProducerService : InternalProducer
{
    public KafkaProducerService(string bootstrapServers)
        : base(bootstrapServers) { }
}
