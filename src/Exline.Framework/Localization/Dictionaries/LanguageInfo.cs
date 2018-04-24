using System.Globalization;

namespace Exline.Framework.Localization.Dictionaries
{
    public class LanguageInfo
    {
        public static LanguageInfo Current { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Icon { get; set; }
        public string Acronym { get; set; }
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

        public LanguageInfo(string name,string displayName,string acronym,string icon=null,bool isDefault=false,bool isDisabled=false)
        {
            this.Name=name;
            this.DisplayName=displayName;
            this.Acronym=acronym;
            this.Icon=icon;
            this.IsDefault=isDefault;
            this.IsDisabled=isDisabled;
        }


    }
}