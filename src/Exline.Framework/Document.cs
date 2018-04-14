namespace Exline.Framework
{
    public class Document<TPrimaryKey>
        : IDocument<TPrimaryKey>
    {
        public TPrimaryKey Id { get; set; }
    }
}