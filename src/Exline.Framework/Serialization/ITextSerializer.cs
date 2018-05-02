namespace Exline.Framework.Serialization
{
    public interface ITextSerializer
        : ISerializer
    {
        string Serialize(object obj);
        string Serialization<TObject>(TObject obj);
        object Desrialize(string text);
        TObject Desrialize<TObject>(string text);
    }
}