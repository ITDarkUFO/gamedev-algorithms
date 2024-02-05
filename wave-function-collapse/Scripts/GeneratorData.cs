using System.Collections.Generic;

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

			public List<List<int>> Dimensions { get; set; }
		}
	}
}