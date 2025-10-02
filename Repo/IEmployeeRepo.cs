using LearnDapper.Model;

namespace LearnDapper.Repo
{
    public interface IEmployeeRepo
    {
        public Task<List<Employee>> GetAll();
        public Task<List<Employee>> GetAllByRole(string role);
        public Task<Employee> GetByCode(int code);
        public Task<string> Create(Employee employee);
        public Task<string> Update(Employee employee, int code);
        public Task<string> Remove(int code);
    }
}
