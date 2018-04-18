using System;
using System.Collections;
using System.Collections.Generic;

namespace Exline.Framework.Data.InMemory
{
    internal class MemoryDatabase
    {

        private readonly IDictionary<Type,IList> _tables;
        private readonly  object _lockObject=new object();
        public MemoryDatabase()
        {
            _tables= new Dictionary<Type,IList>();
        }


        public IList<TDocument> Set<TDocument>()
        {
            Type documentType=typeof(TDocument);

            lock (_lockObject)
            {
                if(!_tables.ContainsKey(documentType))
                {
                    _tables.Add(documentType,new List<TDocument>());
                }
                return _tables[documentType] as List<TDocument>;
            }
        }

        public void Drop()
        {
            _tables.Clear();
        }

        public bool Exists<TDocument>(string collectionName=null)
            where TDocument:IDocument
        {
            return _tables.ContainsKey(typeof(TDocument));
        }

    }
}
