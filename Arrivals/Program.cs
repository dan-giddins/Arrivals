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
			////Console.WriteLine("Getting modes...");
			////var modes = await restHelper.Get<List<Mode>>("Meta/Modes");
			////Console.WriteLine($"Getting lines...");
			////var lines = await restHelper.Get<List<Line>>($"Mode/{string.Join(",", modes.Select(x => x.ModeName))}");
			//var lines = await restHelper.Get<List<Line>>($"Mode/tube");
			//while (true)
			//{
			//	Console.WriteLine($"Getting arrivals...");
			//	var arrivals = await restHelper.Get<List<Arrival>>($"{string.Join(",", lines.Select(x => x.Id))}/Arrivals");
			//	//var arrivals = await restHelper.Get<List<Arrival>>($"victoria/Arrivals");
			//	var arrivalsAtStation = arrivals.Where(x => x.TimeToStation < 60);
			//	foreach (var arrival in arrivalsAtStation.OrderBy(x => x.TimeToStation))
			//	{
			//		Console.WriteLine($"{arrival.VehicleId} on the {arrival.LineName} line is arriving at {arrival.StationName} in {arrival.TimeToStation} seconds.");
			//	}
			//	Console.WriteLine();
			//	Thread.Sleep(10000);
			//}
			Console.WriteLine("Getting data...");
			while (true)
			{
				var arrivals = await restHelper.Get<List<Arrival>>($"victoria/Arrivals");
				var trainData = arrivals.GroupBy(x => x.VehicleId).OrderBy(x => x.Key)
					.Select(x => (x.Key, x.OrderBy(x => x.TimeToStation).First()));
				var trains = new List<Train>();
				foreach (var t in trainData)
				{
					var currentLocationData = t.Item2.CurrentLocation;
					var currentLocation = string.Empty;
					if (currentLocationData == "At Platform")
					{
						currentLocation = $"at {t.Item2.StationName}";
					}
					else if (currentLocationData.StartsWith("Departed"))
					{
						currentLocation = $"leaving {currentLocationData[9..]}";
					}
					else
					{
						currentLocation = $"{char.ToLower(currentLocationData[0])}{currentLocationData[1..]}";
					}
					var train = new Train
					{
						VehicleId = t.Key,
						LineName = t.Item2.LineName,
						CurrentLocation = currentLocation,
						Towards = t.Item2.Towards,
					};
					trains.Add(train);
				}
				Console.Clear();
				foreach (var train in trains)
				{
					Console.WriteLine($"{train.VehicleId} on the {train.LineName} line is {train.CurrentLocation.PadRight(50)} heading towards {train.Towards}.");
				}
				Thread.Sleep(10000);
			}
		}
	}
}
