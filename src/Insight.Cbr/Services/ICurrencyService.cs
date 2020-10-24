using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Insight.Cbr
{
	public interface ICurrencyService
	{
		Task<IReadOnlyCollection<CurrencyRate>> GetCurrencyRatesToDate(DateTime date,
			CancellationToken cancellationToken = default);
	}
}