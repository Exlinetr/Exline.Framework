namespace Exline.Framework.Data.Sql.Dapper.Test
{
    public class BrandDocument
        : IDocument<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}