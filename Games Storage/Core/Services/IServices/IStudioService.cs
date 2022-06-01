using Games_Storage.Core.Services.Dtos;

namespace Games_Storage.Core.Services.IServices
{
    public interface IStudioService
    {
        public IEnumerable<StudioDto> GetStudios(string? query = null);
        public StudioDto GetStudio(int id);
        public StudioDto CreateStudio(StudioDto studioDto);
        public void UpdateStudio(int id, StudioDto studioDto);
        public void DeleteStudio(int id);
    }
}
