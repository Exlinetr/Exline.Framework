namespace Exline.Framework.Localization.Dictionaries
{
    public interface IDictionarySourceInfo
    {
        string Path { get; }
        bool IsReaded { get; }
        string Name { get; }
    }
}