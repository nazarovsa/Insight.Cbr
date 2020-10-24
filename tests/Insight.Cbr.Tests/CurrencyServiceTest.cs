using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Insight.Cbr.Tests
{
    public sealed class CurrencyServiceTest
    {
        private readonly CurrencyService _currencyService;

        public CurrencyServiceTest()
        {
            _currencyService = new CurrencyService();
        }

        [Fact]
        public async Task Should_get_currency_rates_to_today()
        {
            var rates = await _currencyService.GetCurrencyRatesToDate(DateTime.UtcNow);

            Assert.NotNull(rates);
            Assert.NotEmpty(rates);
            Assert.NotNull(rates.FirstOrDefault(x =>
                x.Code.Equals("Usd", StringComparison.InvariantCultureIgnoreCase)));
        }

        [Fact]
        public async Task Should_cancel_get_currency_rates_to_today_request()
        {
            var cancellationToken = new CancellationTokenSource(100).Token;
            await Assert.ThrowsAsync<TaskCanceledException>(async () =>
                await _currencyService.GetCurrencyRatesToDate(DateTime.UtcNow, cancellationToken));
        }
    }
}