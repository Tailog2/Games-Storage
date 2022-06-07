using AutoMapper;
using Games_Storage.Core.Models;
using Games_Storage.Core.Services.Dtos;
using Games_Storage.Core.Services.Exceptions;
using Games_Storage.Core.Services.IServices;
using System.Linq;

namespace Games_Storage.Core.Services
{
    public class GameService : IGameService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public GameDto CreateGame(NewGameDto gameDto)
        {
            var game = _mapper.Map<NewGameDto, Game>(gameDto);
            try
            {
                _unitOfWork.Games.Add(game);
                _unitOfWork.Complete();
            }
            catch (Exception)
            {
                if (_unitOfWork.Games.Exists(g => g.Id == game.Id))
                {
                    throw new ConflictException();
                }                    

                throw new Exception(); 
            }

            game.Studio = _unitOfWork.Studios.Get(game.StudioId);
            foreach (var gg in game.GamesGenres)
            {
                gg.Genre = _unitOfWork.Genres.Get(gg.GenresId);
            }
            return _mapper.Map<Game, GameDto>(game);
        }

        public void DeleteGame(int id)
        {
            var game = _unitOfWork.Games.Get(id);

            if (game is null)
                throw new NotFoundException();

            _unitOfWork.Games.Remove(game);
            _unitOfWork.Complete();
        }

        public GameDto GetGame(int id)
        {
            var game = _unitOfWork.Games.Get(id);

            if (game is null)
                throw new NotFoundException();

            _unitOfWork.Complete();
            return _mapper.Map<Game, GameDto>(game);
        }

        public IEnumerable<GameDto> GetGames(string? query = null)
        {
            IEnumerable<Game> games;

            if (query != null)
            {
                games = _unitOfWork.Games.Find(g => g.Name.Contains(query));
            }
            else
            {
                games = _unitOfWork.Games.GetAll();
            }

            _unitOfWork.Complete();
            return games?.Select(g => _mapper.Map<Game, GameDto>(g));
        }

        public IEnumerable<GameDto> GetGamesByGenre(byte genreId)
        {
            var gener = _unitOfWork.Genres.Get(genreId);
            if (gener == null)
            {
                throw new NotFoundException();
            }

            var games = _unitOfWork.Games.GetGamesByGenre(gener);

            _unitOfWork.Complete();
            return games?.Select(g => _mapper.Map<Game, GameDto>(g));
        }

        public void UpdateGame(int id, EditGameDto gameDto)
        {
            var game = _mapper.Map<EditGameDto, Game>(gameDto);

            if (id != game.Id)
                throw new BadRequestException();

            try
            {
                _unitOfWork.Games.Update(game);
                _unitOfWork.Complete();
            }
            catch (Exception)
            {
                if (!_unitOfWork.Games.Exists(g => g.Id == id))
                {
                    throw new NotFoundException();
                }

                throw new Exception();
            }
        }
    }
}
