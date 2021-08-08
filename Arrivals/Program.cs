using RestHelperLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Arrivals
{
	class Program
	{
		static async Task Main()
		{
			var restHelper = new RestHelper("https://api.tfl.gov.uk/Line/");
			//Console.WriteLine("Getting modes...");
			//var modes = await restHelper.Get<List<Mode>>("Meta/Modes");
			//Console.WriteLine($"Getting lines...");
			//var lines = await restHelper.Get<List<Line>>($"Mode/{string.Join(",", modes.Select(x => x.ModeName))}");
			var lines = await restHelper.Get<List<Line>>($"Mode/tube");
			while (true)
			{
				Console.WriteLine($"Getting arrivals...");
				var arrivals = await restHelper.Get<List<Arrival>>($"{string.Join(",", lines.Select(x => x.Id))}/Arrivals");
				//var arrivals = await restHelper.Get<List<Arrival>>($"victoria/Arrivals");
				var arrivalsAtStation = arrivals.Where(x => x.TimeToStation < 60);
				foreach (var arrival in arrivalsAtStation.OrderBy(x => x.TimeToStation))
				{
					Console.WriteLine($"{arrival.VehicleId} on the {arrival.LineName} line is arriving at {arrival.StationName} in {arrival.TimeToStation} seconds.");
				}
				Console.WriteLine();
				Thread.Sleep(10000);
			}
		}
	}
}
