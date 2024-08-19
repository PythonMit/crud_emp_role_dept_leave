namespace crud_emp_role_dept_leave.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

    }
}
