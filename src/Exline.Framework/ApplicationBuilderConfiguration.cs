namespace Exline.Framework
{
    public class ApplicationBuilderConfiguration
    {
        public bool IsUseRequestLocalization { get; set; }
        public bool IsUseSecurityHeaders { get; set; }
        public bool IsUseLogger { get; set; }

        public ApplicationBuilderConfiguration()
        {
            IsUseLogger = true;
            IsUseSecurityHeaders = true;
            IsUseRequestLocalization = true;
        }

    }
}