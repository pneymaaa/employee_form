using hrd.Models;

namespace hrd.Data.Services
{
    public interface IEmployeeServices 
    {
        //Task<IEnumerable<MstReligion>> GetReligionsAsync();
        Task<IEnumerable<MstReligion>> GetReligions();
        Task<MstEmployee> GetEmployee(int id);
        Task<IEnumerable<vwEmployeeReligion>> GetListEmployeeReligion();
        Task AddEmployee(vwEmployeeReligion model);
        Task DeleteEmployee(string ids);
        Task UpdateEmployee(vwEmployeeReligion model);
    }
}