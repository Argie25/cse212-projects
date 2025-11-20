using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class FeatureCollection
{
    public string type { get; set; }
    public Metadata metadata { get; set; }
    public List<Feature> features { get; set; }
}

public class Metadata
{
    public long generated { get; set; }
    public string url { get; set; }
    public string title { get; set; }
    public int status { get; set; }
    public string api { get; set; }
    public int count { get; set; }
}

public class Feature
{
    public string type { get; set; }
    public Properties properties { get; set; }
    public Geometry geometry { get; set; }
    public string id { get; set; }
}

public class Properties
{
    public double mag { get; set; }
    public string place { get; set; }
    public long time { get; set; }
    public long updated { get; set; }
    public int tz { get; set; }
    public string url { get; set; }
    public string detail { get; set; }
    public int felt { get; set; }
    public double cdi { get; set; }
    public double mmi { get; set; }
    public double alert { get; set; }
    public string status { get; set; }
    public int tsunami { get; set; }
    public int sig { get; set; }
    public string net { get; set; }
    public string code { get; set; }
    public string ids { get; set; }
    public string sources { get; set; }
    public string types { get; set; }
    public int nst { get; set; }
    public double dmin { get; set; }
    public double rms { get; set; }
    public double gap { get; set; }
    public string magType { get; set; }
    public string type { get; set; }
    public string title { get; set; }
}

public class Geometry
{
    public string type { get; set; }
    public List<double> coordinates { get; set; }
}

public class Program
{
    public static async Task<string[]> EarthquakeDailySummary()
    {
        string url = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        
        using (HttpClient client = new HttpClient())
        {
            string json = await client.GetStringAsync(url);
            FeatureCollection data = JsonConvert.DeserializeObject<FeatureCollection>(json);
            
            List<string> summaries = new List<string>();
            foreach (var feature in data.features)
            {
                string summary = $"{feature.properties.place} - Mag {feature.properties.mag}";
                summaries.Add(summary);
            }
            
            return summaries.ToArray();
        }
    }
    
    // Example usage (for testing purposes)
    public static async Task Main()
    {
        string[] results = await EarthquakeDailySummary();
        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }
}
