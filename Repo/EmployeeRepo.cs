using Dapper;
using LearnDapper.Model;
using LearnDapper.Model.Data;
using System.Data;

namespace LearnDapper.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DapperDBContext _context;
        public EmployeeRepo(DapperDBContext context) {
            this._context = context;
        }

        public async Task<string> Create(Employee employee)
        {
            string response = string.Empty;
            string query = "INSERT INTO dbo.employee(code, name, email, phone, designation) values(@code, @name, @email, @phone, @designation)";
            var parameters = new DynamicParameters();
            parameters.Add("code", employee.code, DbType.Int32);
            parameters.Add("name", employee.name, DbType.String);
            parameters.Add("email", employee.email, DbType.String);
            parameters.Add("phone", employee.phone, DbType.String);
            parameters.Add("designation", employee.designation, DbType.String);
            using (var connection = this._context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = "Inserted Successfully";
            }
            return response;
        }

        public async Task<List<Employee>> GetAll()
        {
            string query = "SELECT * FROM dbo.employee";
            using (var connection = this._context.CreateConnection())
            {
                var emplist = await connection.QueryAsync<Employee>(query);
                return emplist.ToList();
            }
        }

        public async Task<List<Employee>> GetAllByRole(string role)
        {
            //string query = "exec sp_getemployeebyrole @role";
            //using (var connection = this._context.CreateConnection())
            //{
            //    var emplist = await connection.QueryAsync<Employee>(query, new {role});
            //    return emplist.ToList();
            //}
            string query = "sp_getemployeebyrole";
            using (var connection = this._context.CreateConnection())
            {
                var emplist = await connection.QueryAsync<Employee>(query, new { role }, commandType: CommandType.StoredProcedure);
                return emplist.ToList();
            }
        }

        public async Task<Employee> GetByCode(int code)
        {
            string query = "SELECT * FROM dbo.employee where code=@code";
            using (var connection = this._context.CreateConnection())
            {
                var emplist = await connection.QueryFirstOrDefaultAsync<Employee>(query, new {code});
                return emplist;
            }
        }

        public async Task<string> Remove(int code)
        {
            string response = string.Empty;
            string query = "DELETE FROM dbo.employee where code=@code";
            using (var connection = this._context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new { code });
                response = "Deleted Successfully";
            }
            return response;
        }

        public async Task<string> Update(Employee employee, int code)
        {
            string response = string.Empty;
            string query = "update dbo.employee set name=@name,email=@email,phone=@phone,designation=@designation where code=@code ";
            var parameters = new DynamicParameters();
            parameters.Add("code", employee.code, DbType.Int32);
            parameters.Add("name", employee.name, DbType.String);
            parameters.Add("email", employee.email, DbType.String);
            parameters.Add("phone", employee.phone, DbType.String);
            parameters.Add("designation", employee.designation, DbType.String);
            using (var connection = this._context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
                response = "Updated Successfully";
            }
            return response;
        }
    }
}