using System.Xml.Serialization;

namespace Insight.Cbr
{
    [XmlRoot("ValuteCursOnDate")]
    public sealed class CurrencyRate
    {
        [XmlElement("Vname")]
        public string Name { get; set; }

        [XmlElement("Vcurs")]
        public decimal Rate { get; set; }

        [XmlElement("Vcode")]
        public string IsoCode { get; set; }

        [XmlElement("VchCode")]
        public string Code { get; set; }

        [XmlElement("Vnom")]
        public string RublesAmount { get; set; }
    }
}