using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Environment;

namespace distilled_community_recorder.Libs
{
    public class ConfigController
    {
        string configPath = "";
        public ConfigModel Config = null!;

        string rootPath = GetFolderPath(SpecialFolder.CommonApplicationData);
        string appPath = "";
        

        public ConfigController()
        {
            appPath =  string.Format("{0}\\exc_recorder", rootPath);
            configPath = string.Format("{0}\\config.json", appPath);

            if (!Directory.Exists(appPath))
            {
                Directory.CreateDirectory(appPath);
            }


            if (!File.Exists(configPath))
            {
                ConfigModel model = new ConfigModel();
                string json = JsonConvert.SerializeObject(model);

                File.WriteAllText(configPath, json);
            }


        }

        public void writeConfig(ConfigModel model)
        {
            string json = JsonConvert.SerializeObject(model);
            File.WriteAllText(configPath, json);
        }

        public void getConfig()
        {

            if (File.Exists(configPath))
            {
                string jsonData = System.IO.File.ReadAllText(configPath);

                ConfigModel? model = JsonConvert.DeserializeObject<ConfigModel>(jsonData);

                if (model == null)
                {
                    Config = new ConfigModel();
                }
                else
                {
                    Config = model;
                }
            }
            else
            {
                Config = new ConfigModel();
            }
        }
    }
}
