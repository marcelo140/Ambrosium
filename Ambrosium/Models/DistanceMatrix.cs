using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace Ambrosium.Models
{

    public class DistanceMatrix
    {
        public string[] destination_addresses { get; set; }
        public string[] origin_addresses { get; set; }
        public Row[] rows { get; set; }
        public string status { get; set; }

        public static DistanceMatrix GetDistanceFull(string origins, string destinations)
        {
            string json;
            string url = "https://maps.googleapis.com/maps/api/distancematrix/json?origins=" + origins + "&destinations=" + destinations + "&key=AIzaSyCnsHMUvRACvgzNiL_DHWyzOgZcErXLkcI";

            using (WebClient client = new WebClient())
                try
                {
                    json = client.DownloadString(url);
                }
                catch (Exception e)
                {
                    return null;
                }
            
            return JsonConvert.DeserializeObject<DistanceMatrix>(json);
        }

        public static int GetDistanceValue(string origins, string destinations)
        {
            DistanceMatrix res = GetDistanceFull(origins, destinations);

            if (res == null || res.rows[0].elements[0].distance == null)
                return -1;

            return res.rows[0].elements[0].distance.value;
        }

        public static string GetDistanceText(string origins, string destinations)
        {
            DistanceMatrix res = GetDistanceFull(origins, destinations);

            if (res.rows[0].elements[0].distance == null)
                return "Indisponível";

            return res.rows[0].elements[0].distance.text;
        }
    }

    public class Row
    {
        public Element[] elements { get; set; }
    }

    public class Element
    {
        public Distance distance { get; set; }
        public Duration duration { get; set; }
        public string status { get; set; }
    }

    public class Distance
    {
        public string text { get; set; }
        public int value { get; set; }
    }

    public class Duration
    {
        public string text { get; set; }
        public int value { get; set; }
    }

}