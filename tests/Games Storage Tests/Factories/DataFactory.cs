using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games_Storage_Tests.Factories
{
    public abstract class DataFactory
    {
        protected IEnumerable<TModel> LoadModels<TModel>(string shortPath) where TModel : class
        {
            string absolutePath = Directory.GetCurrentDirectory() + shortPath;

            try
            {
                using (StreamReader streamReader = new StreamReader(absolutePath))
                {
                    string json = streamReader.ReadToEnd();

                    var jsonSerializerSetting = new JsonSerializerSettings();
                    jsonSerializerSetting.NullValueHandling = NullValueHandling.Ignore;

                    var output = JsonConvert.DeserializeObject<IEnumerable<TModel>>(json, jsonSerializerSetting);

                    if (output == null || !output.Any())
                        throw new NullReferenceException();

                    return output;
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException($"DataFactory was not able to find any data at this path: {absolutePath}");
            }
        }
    }
}
