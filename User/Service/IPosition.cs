using UserService.Model;

namespace UserService.Service
{
    public interface IPosition
    {
        public Task<IEnumerable<Position>> GetAllUsers();
        public Task<Position> GetPosById(string id);
        public Task AddPos(ImageUploadModel us, string idkhoa, string idpos);
        public Task<PositionModel> EditUsers(PositionModel us, string id);
        public void DeleteUsers(string id);
    }
}
