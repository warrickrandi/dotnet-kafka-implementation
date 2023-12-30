using dotnet_kafka_implementation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace dotnet_kafka_implementation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly KafkaProducer _producer;
        public OrderController(KafkaProducer producer)
        {
            _producer = producer;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(OrderRequest request)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            //Produce the Order Request to the Kafka Topic
            await _producer.ProduceMessageAsync("OrderRequest",JsonSerializer.Serialize(request));


            return Ok("Order request is Processing!");
        }
    }
}
