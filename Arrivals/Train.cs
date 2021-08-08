using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrivals
{
	class Train
	{
		public string VehicleId { get; internal set; }
		public string LineName { get; internal set; }
		public string CurrentLocation { get; internal set; }
		public string Towards { get; internal set; }
	}
}
