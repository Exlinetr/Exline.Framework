namespace Exline.Framework
{
    public interface IDocument<TPrimaryKey>
    {
        TPrimaryKey Id{get;set;}
    }
}