using crud_emp_role_dept_leave.Data;
using crud_emp_role_dept_leave.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace crud_emp_role_dept_leave.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly DbcontextData _dbcontextData;
        public EmployeeController(DbcontextData dbcontextData)
        {
            _dbcontextData = dbcontextData;
        }

        public async Task<IActionResult> Index()
        {
            var data= await _dbcontextData.Employees
                .Include(x=>x.Role).Include(x=>x.Department).ToListAsync();
            ViewData["testdata"] = "hello";
            return View(data);
        }

        public IActionResult Create()
        {

            ViewData["RoleId"] = new SelectList(_dbcontextData.Roles, "RoleId", "RoleName");
            ViewData["DepartmentId"] = new SelectList(_dbcontextData.Departments, "DepartmentId", "Deptname");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee)
        {
            _dbcontextData.Employees.Add(employee);
            await _dbcontextData.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id > 0)
            {
                var data = await _dbcontextData.Employees.Include(x => x.Role).Include(x => x.Department).Include(x => x.leaves).Where(x => x.Id == id).FirstOrDefaultAsync(); ;

                return View(data);
            }
            return NotFound();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            if (id > 0)
            {
                var data = await _dbcontextData.Employees.Include(x => x.Role).Include(x => x.Department).Include(x => x.leaves).FirstOrDefaultAsync(x => x.Id == id);
                ViewData["RoleId"] = new SelectList(_dbcontextData.Roles, "RoleId", "RoleName");
                ViewData["DepartmentId"] = new SelectList(_dbcontextData.Departments, "DepartmentId", "Deptname");
                return View(data);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Employee employee)
        {
            if (id == employee.Id)
            {
                var data = await _dbcontextData.Employees.AsNoTracking().Include(x => x.Role).Include(x => x.Department).Include(x => x.leaves).FirstOrDefaultAsync(x => x.Id == id);
                Employee employeeData = new Employee();
                employeeData.Id = employee.Id;
                employeeData.Name = employee.Name;
                employeeData.RoleId = employee.RoleId;
                employeeData.DepartmentId = employee.DepartmentId;
                employeeData.Salary = employee.Salary;
                _dbcontextData.Employees.Update(employeeData);
                await _dbcontextData.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id > 0)
            {
                var data = await _dbcontextData.Employees.FirstOrDefaultAsync(x => x.Id == id);
                _dbcontextData.Employees.Remove(data);
                await _dbcontextData.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return NotFound();
        }
        public IActionResult CreateLeave()
        {
            return View();
        }
    }
}
