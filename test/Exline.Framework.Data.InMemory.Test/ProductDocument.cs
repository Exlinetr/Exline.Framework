namespace Exline.Framework.Data.InMemory.Test
{
    public class ProductDocument
        : IDocument<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public float Price { get; set; }

        public ProductDocument()
        {
            
        }
    }
}