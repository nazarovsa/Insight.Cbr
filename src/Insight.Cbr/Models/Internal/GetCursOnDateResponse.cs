using System.Xml.Serialization;

namespace Insight.Cbr.Internal
{
    [XmlRoot("root")]
    public sealed class GetCursOnDateResponse
    {
        [XmlElement("ValuteCursOnDate")] public CurrencyRate[] Rates { get; set; }
    }
}