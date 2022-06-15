using Confluent.Kafka;
using Geo;
using geo_server.Redis;

namespace geo_server.Services
{
    public class CountryInfoProducerService : BackgroundService
    {
        private readonly IProducer<string, string> _producer;

        private readonly ILogger<CountryInfoProducerService> _logger;

        private static readonly Random rand = new Random();
        private readonly RedisService _redisService;

        public CountryInfoProducerService(
            RedisService redisService,
            ILogger<CountryInfoProducerService> logger)
        {
            _redisService = redisService;

            var producerConfig = new ProducerConfig
            {
                BootstrapServers = "localhost:9092"
            };
            _producer = new ProducerBuilder<string, string>(producerConfig).Build();

            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    var countries = _redisService.Get<IEnumerable<Country>>("AllCountries");

                    foreach (var item in countries)
                    {
                        var dr = await this._producer.ProduceAsync("countryinfos", new Message<string, string>()
                        {
                            Key = rand.Next(maxValue: 5000).ToString(),
                            Value = System.Text.Json.JsonSerializer.Serialize(item)
                        });
                    }

                    await Task.Delay(30000);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                }
            }
        }
    }
}