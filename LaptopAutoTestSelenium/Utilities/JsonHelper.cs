using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LaptopAutoTestSelenium.Utilities
{
    public class JsonHelper
    {
        private dynamic data;

        public JsonHelper(string filePath)
        {
            var json = File.ReadAllText(filePath);
            data = JsonConvert.DeserializeObject(json);
        }

        public dynamic GetData(string key)
        {
            return data[key];
        }

        public string GetValue(string parent, string child)
        {
            return data[parent][child].ToString();
        }

        public string GetValue(string parent, string child, string field)
        {
            return data[parent][child][field].ToString();
        }
    }
}
