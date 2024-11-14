using DeviceManagement.Brokers.Infrastructure;
using DeviceManagement.Brokers.Kafka;
using Microsoft.Extensions.DependencyInjection;

namespace DeviceManagement.Brokers.Kafka;

public class KafkaConsumerService : KafkaConsumerService<KafkaMessageHandlersController>
{
    public KafkaConsumerService(IServiceScopeFactory serviceScopeFactory, KafkaOptions kafkaOptions)
        : base(serviceScopeFactory, kafkaOptions) { }
}
