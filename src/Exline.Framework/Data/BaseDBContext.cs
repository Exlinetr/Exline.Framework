using System;
using System.Linq;
using System.Threading.Tasks;

namespace Exline.Framework.Data
{
    public abstract class BaseDBContext
        : IDBContext
    {

        public string GetCollectionName(Type type,string collectionName)
        {
            if(string.IsNullOrEmpty(collectionName))
                collectionName=GetAttributeCollectionName(type);
            return collectionName;
        }

        public string GetAttributeCollectionName(Type type)
        {
            string name = (type
                .GetCustomAttributes(typeof(CollectionNameAttribute),false)
                .FirstOrDefault() as CollectionNameAttribute)?.Name;
            if(string.IsNullOrEmpty(name))
                name=type.Name;
            return name; 
        }
        public abstract Task DropAsync();
    }
}