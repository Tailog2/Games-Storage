using Games_Storage_Tests.Factories;
using KellermanSoftware.CompareNetObjects;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Games_Storage_Tests.Helpers
{
    internal class TestHelper
    {
        public bool CompareProp(object expectedModel, object actualModel)
        {
            CompareLogic compareLogic = new CompareLogic();
            compareLogic.Config.CompareChildren = true;
            compareLogic.Config.IgnoreMissingProperties = true;
            compareLogic.Config.IgnoreMissingFields = true;
            compareLogic.Config.IgnoreMissingFields = true;

            ComparisonResult result = compareLogic.Compare(expectedModel, actualModel);

            return result.AreEqual;
        }  
    }
}
