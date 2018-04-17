namespace Exline.Framework
{
    public interface IDocument
    {
        
    }
    public interface IDocument<TPrimaryKey>
        : IDocument
    {
        TPrimaryKey Id{get;set;}
    }
}