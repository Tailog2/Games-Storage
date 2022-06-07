using AutoMapper;
using Games_Storage.Core.Models;
using Games_Storage.Core.Services.Dtos;
using Games_Storage.Core.Services.Exceptions;
using Games_Storage.Core.Services.IServices;

namespace Games_Storage.Core.Services
{
    public class GenreService : IGenreService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GenreService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public GenreDto GetGenre(byte id)
        {
            var gener = _unitOfWork.Genres.Get(id);

            if (gener is null)
                throw new NotFoundException();

            _unitOfWork.Complete();
            return _mapper.Map<Genre, GenreDto>(gener);
        }

        public IEnumerable<GenreDto> GetGenres()
        {
            var genres = _unitOfWork.Genres.GetAll();

            _unitOfWork.Complete();
            return genres?.Select(g => _mapper.Map<Genre, GenreDto>(g));
        }
    }
}
