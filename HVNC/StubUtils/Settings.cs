using System;
using System.IO;
using Newtonsoft.Json;

namespace ShitarusPrivate.HVNC.StubUtils
{
    public class Settings
    {
        private static string savepath = AppDomain.CurrentDomain.BaseDirectory + "\\bin\\settings.json";

        public static SettingsObject Load()
        {
            if (File.Exists(savepath))
            {
                return JsonConvert.DeserializeObject<SettingsObject>(File.ReadAllText(savepath));
            }
            return null;
        }

        public static void Save(SettingsObject obj)
        {
            File.WriteAllText(savepath, JsonConvert.SerializeObject(obj, Formatting.Indented));
        }
    }
}
