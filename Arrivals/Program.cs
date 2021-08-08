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
			Console.WriteLine($"Getting lines...");
			//var lines = await restHelper.Get<List<Line>>($"Mode/{string.Join(",", modes.Select(x => x.ModeName))}");
			var lines = await restHelper.Get<List<Line>>($"Mode/tube");
			Console.WriteLine($"Getting positions...");
			while (true)
			{
				var arrivals = await restHelper.Get<List<Arrival>>($"{string.Join(",", lines.Select(x => x.Id))}/Arrivals");
				//var arrivals = await restHelper.Get<List<Arrival>>($"victoria/Arrivals");
				var arrivalsGrouped = arrivals.Where(x => !string.IsNullOrWhiteSpace(x.CurrentLocation))
					.GroupBy(x => $"{x.VehicleId}_{x.LineId}");
				//var issues = arrivalsGrouped.Select(x => (x.Key, x.GroupBy(y => y.Towards))).Where(x => x.Item2.Count() > 1);
				var trainData = arrivalsGrouped.Select(x =>
					(x.Key, x.OrderBy(x => x.TimeToStation).First()));
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
						Id = t.Key,
						VehicleId = t.Item2.VehicleId,
						LineName = t.Item2.LineName,
						CurrentLocation = currentLocation,
						Towards = t.Item2.Towards,
						TimeToStation = t.Item2.TimeToStation,
					};
					trains.Add(train);
				}
				Console.Clear();
				foreach (var train in trains.OrderBy(x => x.LineName).ThenBy(x => x.VehicleId))
				{
					Console.WriteLine($"Trian {train.VehicleId} on the {train.LineName.PadRight(20)} line is {train.CurrentLocation.PadRight(55)} heading towards {train.Towards.PadRight(25)} and is currently {train.TimeToStation.ToString().PadRight(3)} seconds away from the next stop.");
				}
				Thread.Sleep(10000);
			}
		}
	}
}
