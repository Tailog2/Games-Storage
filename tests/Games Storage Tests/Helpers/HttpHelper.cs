using Games_Storage_Tests.Factories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Games_Storage_Tests.Helpers
{
    internal class HttpHelper
    {
        public StringContent ConvertModel(object model)
        {
            var stringModel = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8);
            stringModel.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return stringModel;
        }

        public async Task<T> ConvertResponce<T>(HttpResponseMessage responce) where T : class
        {
            var contentString = await responce.Content.ReadAsStringAsync();
            var model = JsonConvert.DeserializeObject<T>(contentString);
            return model;
        }
    }
}
