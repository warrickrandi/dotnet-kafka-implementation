﻿using Confluent.Kafka;

namespace dotnet_kafka_implementation
{
    public class KafkaConsumer
    {
        private IConsumer<string, string> _consumer;
        private ConsumerConfig consumerConfig;
        public KafkaConsumer()
        {
            consumerConfig = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092", //Replace the Kafka BootstrapServer
                GroupId = "OrderRequestConsumerGroup",
                AutoOffsetReset = AutoOffsetReset.Earliest,
            };
        }

        //Consume Method
        public async Task<string> Consume(string topic)
        {
            try
            {
                _consumer = new ConsumerBuilder<string, string>(consumerConfig).Build();
                _consumer.Subscribe(topic);

                var consumeResult = _consumer.Consume(TimeSpan.FromMilliseconds(1000));

                if (consumeResult != null)
                {
                    return consumeResult.Message.Value;
                }
                else
                {
                    //No message received from Kafka within the specified timeout.
                }
                return "";

            }
            catch (Exception ex)
            {
                return "";
            }
            finally
            {
                _consumer.Close();
            }
        }
    }
}
