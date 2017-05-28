using System.Xml.Serialization;

namespace WeatherService.Services.Models
{    
    [XmlRoot("", Namespace = "http://www.webserviceX.NET"), XmlType("string")]
    public class CountryCities
    {
        [XmlArray("NewDataSet")]
        public Table[] Cities { get; set; }
    }

    public class Table
    {
        public string Country { get; set; }
        public string City { get; set; }
    }
}
