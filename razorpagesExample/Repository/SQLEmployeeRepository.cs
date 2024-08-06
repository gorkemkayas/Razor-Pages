using razorpagesExample.Models;

namespace razorpagesExample.Repository;

public class SQLEmployeeRepository : IEmployeeRepository
{
    private readonly DataContext _dataContext;

    public SQLEmployeeRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public IEnumerable<Employee> GetAll()
    {
        return _dataContext.Employees.ToList();
    }

    public Employee GetById(int id)
    {
        return _dataContext.Employees.FirstOrDefault(i=> i.Id == id);
    }

    public Employee Update(Employee entity)
    {
        var entityUpdate = _dataContext.Employees.FirstOrDefault(i => i.Id == entity.Id);

        if(entityUpdate != null)
        {
            entityUpdate.Name = entity.Name;
            entityUpdate.Email = entity.Email;
            entityUpdate.Department = entity.Department;
            entityUpdate.Photo = entity.Photo;

            _dataContext.SaveChanges();
        }
        return entityUpdate;

    }
}