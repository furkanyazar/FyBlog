using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;
using System.Text.RegularExpressions;

namespace WebApp.Areas.Admin.ViewComponents.Statistics
{
	public class HomeWeather : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			using (var client = new WebClient())
			{
				var jsonLocation = client.DownloadString("http://api.ipstack.com/" + GetIPAddress() + "?access_key=8316c5bc70b632e69feb7ea2f69166b2");

				var location = JsonConvert.DeserializeObject<Location>(jsonLocation);

				var jsonWeather = client.DownloadString("http://api.openweathermap.org/data/2.5/weather?zip=" + location.zip + "," + location.country_code + "&lang=tr&units=metric&appid=93634a166d54ccd1949c33364f2239f2");

				var weather = JsonConvert.DeserializeObject<Weather>(jsonWeather);

				weather.region_name = location.region_name;
				weather.city = location.city;

				return View(weather);
			}
		}

		public string GetIPAddress()
		{
			using (var client = new WebClient())
			{
				var dnsString = client.DownloadString("http://checkip.dyndns.org");

				dnsString = (new Regex(@"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b")).Match(dnsString).Value;

				return dnsString;
			}
		}
	}

	public class Location
	{
		public string zip { get; set; }
		public string country_code { get; set; }
		public string region_name { get; set; }
		public string city { get; set; }
	}

	public class Weather
	{
		public Temperature main { get; set; }
		public Cloud[] weather { get; set; }
		public string region_name { get; set; }
		public string city { get; set; }
	}

	public class Temperature
	{
		public string temp { get; set; }
	}

	public class Cloud
	{
		public string description { get; set; }
	}
}
