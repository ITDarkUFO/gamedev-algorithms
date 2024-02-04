using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.Scripts
{
	internal class GeneratorData
	{
		public string Name { get; set; }

		public string Version { get; set; }

		public GeneratorSettings Settings { get; set; }

		public class GeneratorSettings
		{
			public bool IsFixed { get; set; }

			public int[][] Dimensions { get; set; }
		}
	}
}