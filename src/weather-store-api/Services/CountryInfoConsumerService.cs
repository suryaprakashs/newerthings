using Confluent.Kafka;

namespace weather_store.Services
{
    public class CountryInfoConsumerService : BackgroundService
    {
        private readonly IConsumer<string, string> _consumer;

        private readonly ILogger<CountryInfoConsumerService> _logger;

        public CountryInfoConsumerService(ILogger<CountryInfoConsumerService> logger)
        {
            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092",
                GroupId = "Sample-Consumer",
                AutoOffsetReset = AutoOffsetReset.Earliest
            };
            _consumer = new ConsumerBuilder<string, string>(config).Build();
            _consumer.Subscribe(new List<string> { "countryinfos" });
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {

                    var countryRequest = _consumer.Consume(TimeSpan.FromSeconds(0.5));

                    if (countryRequest != null && !string.IsNullOrWhiteSpace(countryRequest.Value))
                    {
                        var country = System.Text.Json.JsonSerializer.Deserialize<Country>(countryRequest.Value);
                        _logger.LogInformation($"Processing the country info for {country.Name}");
                    }
                    else
                    {
                        await Task.Delay(2000);
                    }

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.ToString());
                }
            }
        }
    }

    public class Country
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }


}