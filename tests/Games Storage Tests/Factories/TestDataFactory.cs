using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Games_Storage_Tests.Factories
{
    public class TestDataFactory : DataFactory
    {
        public IEnumerable<Game> CreateFillingGames()
        {
            return LoadModels<Game>(@"\PrepData\DbFillingData\Games.json");
        }

        public IEnumerable<Studio> CreateFillingStudios()
        {
            return LoadModels<Studio>(@"\PrepData\DbFillingData\Studios.json");
        }

        public IEnumerable<NewGameDto> CreateValidNewGameDto()
        {
            return LoadModels<NewGameDto>(@"\PrepData\TestData\ValidNewGamesDtos.json");
        }

        public IEnumerable<NewGameDto> CreateInvalidNewGameDto()
        {
            return LoadModels<NewGameDto>(@"\PrepData\TestData\InvalidNewGamesDtos.json");
        }

        public IEnumerable<StudioDto> CreateValidStudiosDtos()
        {
            return LoadModels<StudioDto>(@"\PrepData\TestData\ValidStudiosDtos.json");
        }
    }
}
