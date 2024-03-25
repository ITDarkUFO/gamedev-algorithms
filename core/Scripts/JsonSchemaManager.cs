using Json.Schema;
using Json.Schema.DataGeneration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace Core.Scripts
{
    internal class JsonSchemaManager
    {
        #region Fields

        private static JsonSchemaManager _instance;
        private readonly Dictionary<string, JsonSchema> _jsonSchemas = [];

        #endregion

        private JsonSchemaManager()
        {
            var files = Directory.GetFiles("JsonSchemas", $"*.json");

            foreach (var file in files)
            {
                var jsonSchema = JsonSchema.FromFile(file);
                SchemaRegistry.Global.Register(jsonSchema);

                if (!_jsonSchemas.TryAdd(Path.GetFileNameWithoutExtension(file), jsonSchema))
                    throw new Exception($"Не удалось добавить json схему {Path.GetFileName(file)} в коллекцию.");
            }
        }

        public static JsonSchemaManager GetInstance()
        {
            _instance ??= new JsonSchemaManager();
            return _instance;
        }

        public void GenerateSample(string schemaName)
        {
            if (_jsonSchemas.TryGetValue(schemaName, out var jsonSchema))
            {
                var generationResult = jsonSchema.GenerateData();

                if (generationResult.IsSuccess)
                {
                    Directory.CreateDirectory(Path.Combine("JsonSchemas", "Results"));

                    var _fileStream = File.Create(Path.Combine("JsonSchemas", "Results", $"result-{Guid.NewGuid()}"));
                    JsonSerializer.Serialize(_fileStream, generationResult.Result);
                    _fileStream.Close();
                }
            }
            else
            {
                throw new KeyNotFoundException("Указанная схема не найдена.");
            }
        }

        public bool EvaluateData(string schemaName, JsonDocument jsonDocument, out IReadOnlyDictionary<string, string> errors)
        {
            if (_jsonSchemas.TryGetValue(schemaName, out var jsonSchema))
            {
                var result = jsonSchema.Evaluate(jsonDocument);
                errors = result.Errors;
                return result.IsValid;
            }
            else
            {
                throw new KeyNotFoundException("Указанная схема не найдена.");
            }
        }
    }
}
