using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Generated;
using Insight.Cbr.Internal;

namespace Insight.Cbr
{
    public sealed class CurrencyService : SoapServiceBase, ICurrencyService
    {
        public CurrencyService()
        {
        }

        public CurrencyService(DailyInfoSoapClient soapClient) : base(soapClient)
        {
        }

        public async Task<IReadOnlyCollection<CurrencyRate>> GetCurrencyRatesToDate(DateTime date,
            CancellationToken cancellationToken = default)
        {
            var result = await CallWithCancellation(SoapClient.GetCursOnDateXMLAsync(date), cancellationToken);

            XmlDocument xmlDocument = new XmlDocument();
            var root = xmlDocument.CreateElement("root");
            root.InnerXml = result.InnerXml;
            xmlDocument.AppendChild(root);

            var response = Deserialize<GetCursOnDateResponse>(xmlDocument);
            foreach (var rate in response.Rates)
                rate.Name = rate.Name.Trim();

            return response.Rates;
        }

        private T Deserialize<T>(XmlDocument document)
        {
            return (T) new XmlSerializer(typeof(T)).Deserialize(new XmlNodeReader(document));
        }
    }
}