
using Newtonsoft.Json;

namespace Exline.Framework.Serialization.JSON
{
    public static class Extensions
    {
        public static TObject ToObject<TObject>(this string text,JsonSerializerSettings settings)
        {
            ITextSerializer serializer=new JSONSerializer(settings);
            return serializer.Desrialize<TObject>(text);
        }
        public static TObject ToObject<TObject>(this string text)
        {
            return text.ToObject<TObject>(new JsonSerializerSettings(){
                NullValueHandling=NullValueHandling.Ignore,
                DefaultValueHandling=DefaultValueHandling.Ignore
            });
        }
    }
}