using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace WebApp.Areas.Admin.ViewComponents.Statistics
{
	public class HomeWeather : ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			using (var client = new WebClient())
			{
				var json = client.DownloadString("https://api.openweathermap.org/data/2.5/weather?q=istanbul&lang=tr&units=metric&appid=93634a166d54ccd1949c33364f2239f2");

				var result = JsonConvert.DeserializeObject<Result>(json);

				return View(result);
			}
		}
	}

	public class Result
	{
		public Weather[] Weather { get; set; }
		public Main Main { get; set; }
	}

	public class Weather
	{
		public string Description { get; set; }
	}

	public class Main
	{
		public string Temp { get; set; }
	}
}
