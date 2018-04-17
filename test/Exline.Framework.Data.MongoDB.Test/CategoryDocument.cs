namespace Exline.Framework.Data.MongoDB.Test
{
    public class CategoryDocument
        : IDocument<string>
    {
        public string Id {get;set;}
        public string Name { get; set; }
    }
}