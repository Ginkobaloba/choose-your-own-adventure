using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Xml.Linq;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            var address = "W156N7507 Pilgrim Rd, menomonee falls wi, 53051";
            var requestUri = string.Format("http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=false", Uri.EscapeDataString(address));

            var request = WebRequest.Create(requestUri);
            var response = request.GetResponse();
            var xdoc = XDocument.Load(response.GetResponseStream());

            var result = xdoc.Element("GeocodeResponse").Element("result");
            var locationElement = result.Element("geometry").Element("location");
            var lat = locationElement.Element("lat");
            var lng = locationElement.Element("lng");
            string stringlat = lat.ToString();
            string stringlng = lng.ToString();
            stringlat = stringlat.Substring(5, stringlat.IndexOf("</lat>")-5);
            stringlat = stringlat.Substring(5, stringlat.IndexOf("</lng>")-5);
            Console.WriteLine("{0} {1}", stringlat, stringlng);
            Console.ReadLine();


        }
    }
}
