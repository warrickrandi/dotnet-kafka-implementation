using Confluent.Kafka;

namespace dotnet_kafka_implementation
{
    public class KafkaProducer
    {
        private readonly IProducer<string, string> _producer;

        public KafkaProducer(IConfiguration configuration)
        {
            var producerConfig = new ProducerConfig
            {
                BootstrapServers = configuration["Kafka:BootstrapServers"]
            };

            //Build the Producer
            _producer = new ProducerBuilder<string,string>(producerConfig).Build();
        }

        //Method for Produce the Message to Kafka Topic
        public async Task ProduceMessageAsync(string topic, string value)
        {
            var kafkaMessage = new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = value
            };

            //Produce the Message
            await _producer.ProduceAsync(topic, kafkaMessage);
        }
    }
}
