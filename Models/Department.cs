namespace crud_emp_role_dept_leave.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string Deptname { get; set; }

        public IEnumerable<Employee> employees { get; set; }

    }
}
