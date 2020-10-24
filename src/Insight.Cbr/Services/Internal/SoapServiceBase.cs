using System;
using System.ServiceModel;
using System.Threading;
using System.Threading.Tasks;
using Generated;

namespace Insight.Cbr.Internal
{
    public abstract class SoapServiceBase
    {
        protected DailyInfoSoapClient SoapClient { get; }

        protected SoapServiceBase()
        {
            SoapClient = new DailyInfoSoapClient(DailyInfoSoapClient.EndpointConfiguration.DailyInfoSoap);
        }

        protected SoapServiceBase(DailyInfoSoapClient soapClient)
        {
            SoapClient = soapClient ?? throw new ArgumentNullException(nameof(soapClient));
        }

        protected async Task<T> CallWithCancellation<T>(Task<T> task,
            CancellationToken cancellationToken = default)
        {
            cancellationToken.Register(() => SoapClient.Abort());

            try
            {
                return await task;
            }
            catch (CommunicationObjectAbortedException ex)
            {
                throw new TaskCanceledException("Soap request was cancelled", ex);
            }
        }
    }
}