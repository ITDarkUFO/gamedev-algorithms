using Json.Schema;
using Json.Schema.DataGeneration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace App.Scripts
{
	internal class JsonTemp
	{
		JsonSchema schema;
		public JsonTemp(string name)
		{
			var files = Directory.GetFiles("JsonSchemas", $"{name}.json");

			foreach (var file in files)
			{
				schema = JsonSchema.FromFile(file);
				SchemaRegistry.Global.Register(schema);
			}
		}

		public void Generate()
		{
			var generationResult = schema.GenerateData();

			if (generationResult.IsSuccess)
			{
				Directory.CreateDirectory(Path.Combine("JsonSchemas", "Results"));

				var _fileStream = File.Create(Path.Combine("JsonSchemas", "Results", $"result-{Guid.NewGuid()}"));
				JsonSerializer.Serialize(_fileStream, generationResult.Result);
				_fileStream.Close();
			}
		}
	}
}
