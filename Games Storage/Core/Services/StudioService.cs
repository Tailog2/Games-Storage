using AutoMapper;
using Games_Storage.Core.Models;
using Games_Storage.Core.Services.Dtos;
using Games_Storage.Core.Services.Exceptions;
using Games_Storage.Core.Services.IServices;

namespace Games_Storage.Core.Services
{
    public class StudioService : IStudioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public StudioService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public StudioDto CreateStudio(StudioDto studioDto)
        {
            var studio = _mapper.Map<StudioDto, Studio>(studioDto);
            try
            {
                _unitOfWork.Studios.Add(studio);
                _unitOfWork.Complete();
            }
            catch (Exception)
            {
                if (_unitOfWork.Games.Exists(g => g.Id == studio.Id))
                {
                    throw new ConflictException();
                }

                throw new Exception();
            }

            return _mapper.Map<Studio, StudioDto>(studio);
        }

        public void DeleteStudio(int id)
        {
            var studio = _unitOfWork.Studios.Get(id);

            if (studio is null)
                throw new NotFoundException();

            _unitOfWork.Studios.Remove(studio);
        }

        public StudioDto GetStudio(int id)
        {
            var studio = _unitOfWork.Studios.Get(id);

            if (studio is null)
                throw new NotFoundException();

            _unitOfWork.Complete();
            return _mapper.Map<Studio, StudioDto>(studio);
        }

        public IEnumerable<StudioDto> GetStudios(string? query = null)
        {
            IEnumerable<Studio> studios;

            if (query != null)
            {
                studios = _unitOfWork.Studios.Find(g => g.Name.Contains(query));
            }
            else
            {
                studios = _unitOfWork.Studios.GetAll();
            }

            _unitOfWork.Complete();
            return studios?.Select(s => _mapper.Map<Studio, StudioDto>(s));
        }

        public void UpdateStudio(int id, StudioDto studioDto)
        {
            var studio = _mapper.Map<StudioDto, Studio>(studioDto);

            if (id != studio.Id)
                throw new BadRequestException();

            try
            {
                _unitOfWork.Studios.Update(studio);
                _unitOfWork.Complete();
            }
            catch (Exception)
            {
                if (!_unitOfWork.Studios.Exists(g => g.Id == id))
                {
                    throw new NotFoundException();
                }

                throw new Exception();
            }
        }
    }
}
