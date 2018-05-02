using Newtonsoft.Json;

namespace Exline.Framework.Serialization.JSON
{
    public class JSONSerializer
        : IJSONSerializer
    {
        private readonly JsonSerializerSettings _settings;

        public JSONSerializer()
            : this(new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            })
        {

        }
        public JSONSerializer(JsonSerializerSettings settings)
        {
            _settings = settings;
        }
        public object Desrialize(string text)
        {
            return JsonConvert.DeserializeObject(text, _settings);
        }

        public TObject Desrialize<TObject>(string text)
        {
            return JsonConvert.DeserializeObject<TObject>(text, _settings);
        }

        public string Serialization<TObject>(TObject obj)
        {
            return JsonConvert.SerializeObject(obj, _settings);
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, _settings);
        }
    }
}