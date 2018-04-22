using System.Globalization;

namespace Exline.Framework.Localization.Dictionaries
{
    public class LanguageInfo
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Icon { get; set; }
        public bool IsRigthToLeft
        {
            get
            {
                try
                {
                    return CultureInfo.GetCultureInfo(this.Name).TextInfo?.IsRightToLeft ?? false;
                }
                catch
                {
                    return false;
                }
            }
        }
        public bool IsDefault { get; set; }
        public bool IsDisabled { get; set; }

        public LanguageInfo(string name,string displayName,string icon=null,bool isDefault=false,bool isDisabled=false)
        {
            this.Name=name;
            this.DisplayName=displayName;
            this.Icon=icon;
            this.IsDefault=isDefault;
            this.IsDisabled=isDisabled;
        }


    }
}