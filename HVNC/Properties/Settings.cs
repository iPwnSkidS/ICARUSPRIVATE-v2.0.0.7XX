using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace ShitarusPrivate.HVNC.Properties
{
    [CompilerGenerated]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "16.10.0.0")]
    internal sealed class Settings : ApplicationSettingsBase
    {
        private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

        public static Settings Default => defaultInstance;

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string PORT
        {
            get
            {
                return (string)this["PORT"];
            }
            set
            {
                this["PORT"] = value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string IP
        {
            get
            {
                return (string)this["IP"];
            }
            set
            {
                this["IP"] = value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string remUsername
        {
            get
            {
                return (string)this["remUsername"];
            }
            set
            {
                this["remUsername"] = value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string remPassword
        {
            get
            {
                return (string)this["remPassword"];
            }
            set
            {
                this["remPassword"] = value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string remKey
        {
            get
            {
                return (string)this["remKey"];
            }
            set
            {
                this["remKey"] = value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string HOOK
        {
            get
            {
                return (string)this["HOOK"];
            }
            set
            {
                this["HOOK"] = value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string TGID
        {
            get
            {
                return (string)this["TGID"];
            }
            set
            {
                this["TGID"] = value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string TGTOKEN
        {
            get
            {
                return (string)this["TGTOKEN"];
            }
            set
            {
                this["TGTOKEN"] = value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string FTPHOST
        {
            get
            {
                return (string)this["FTPHOST"];
            }
            set
            {
                this["FTPHOST"] = value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string FTPUSER
        {
            get
            {
                return (string)this["FTPUSER"];
            }
            set
            {
                this["FTPUSER"] = value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string FTPPASS
        {
            get
            {
                return (string)this["FTPPASS"];
            }
            set
            {
                this["FTPPASS"] = value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string PHPLINK
        {
            get
            {
                return (string)this["PHPLINK"];
            }
            set
            {
                this["PHPLINK"] = value;
            }
        }

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string SESSION
        {
            get
            {
                return (string)this["SESSION"];
            }
            set
            {
                this["SESSION"] = value;
            }
        }
    }
}
