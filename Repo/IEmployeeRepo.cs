using LearnDapper.Model;

namespace LearnDapper.Repo
{
    public interface IEmployeeRepo
    {
        public Task<List<Employee>> GetAll();
    }
}
