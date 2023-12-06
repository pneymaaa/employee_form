using System.Data;
using Dapper;
using hrd.Models;

namespace hrd.Data.Services
{
    public class EmployeeService : IEmployeeServices
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<MstEmployee> GetEmployee(int id)
        {
            var query = "SELECT * FROM MstEmployee WHERE ID = @Id";
            using (var connection = _context.CreateConnection())
            {
                var employee = await connection.QueryAsync<MstEmployee>(query, new { Id = id });
                return employee.First();
            }
        }

        public async Task<IEnumerable<MstReligion>> GetReligions()
        {
            string query = "SELECT * FROM MstReligion";
            using (var connection = _context.CreateConnection())
            {
                var selectionsReligions = await connection.QueryAsync<MstReligion>(query);
                return selectionsReligions.ToList();
            }
        }

        public async Task<IEnumerable<vwEmployeeReligion>> GetListEmployeeReligion()
        {
            string query = "SELECT * FROM vwEmployeeReligion";
            using (var connection = _context.CreateConnection())
            {
                var listEmployeeReligion = await connection.QueryAsync<vwEmployeeReligion>(query);
                return listEmployeeReligion.ToList();
            }
        }

        public async Task AddEmployee(vwEmployeeReligion model)
        {
            string procedureName = "spAddEmployee";

            var parameters = new DynamicParameters();
            parameters.Add("name", model.Name, DbType.String, ParameterDirection.Input, 50);
            parameters.Add("address", model.Address, DbType.String, ParameterDirection.Input, 200);
            parameters.Add("religionCode", model.ReligionCode, DbType.String, ParameterDirection.Input, 4);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task DeleteEmployee(string ids)
        {
            string procedureName = "spDeleteEmployee";
            string[] arrId = ids.Split(',');
            foreach (var i in arrId)
            {
                var parameters = new DynamicParameters();
                parameters.Add("Id", i, DbType.Int32, ParameterDirection.Input);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
                }
            }
        }

        public async Task UpdateEmployee(vwEmployeeReligion model)
        {
            string procedureName = "spUpdateEmployee";

            var parameters = new DynamicParameters();
            parameters.Add("id", model.ID, DbType.Int32, ParameterDirection.Input);
            parameters.Add("name", model.Name, DbType.String, ParameterDirection.Input, 50);
            parameters.Add("address", model.Address, DbType.String, ParameterDirection.Input, 200);
            parameters.Add("religionCode", model.ReligionCode, DbType.String, ParameterDirection.Input, 4);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}