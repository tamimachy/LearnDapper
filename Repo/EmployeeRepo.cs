using Dapper;
using LearnDapper.Model;
using LearnDapper.Model.Data;

namespace LearnDapper.Repo
{
    public class EmployeeRepo : IEmployeeRepo
    {
        private readonly DapperDBContext _context;
        public EmployeeRepo(DapperDBContext context) {
            this._context = context;
        }

        public async Task<List<Employee>> GetAll()
        {
            string query = "SELECT * FROM tbl_employee";
            using (var connection = this._context.CreateConnection())
            {
                var emplist = await connection.QueryAsync<Employee>(query);
                return emplist.ToList();
            }
        }
    }
}