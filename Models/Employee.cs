namespace crud_emp_role_dept_leave.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int RoleId { get; set; }
        public virtual Role Role { get; set; }
        public int DepartmentId { get; set; }
        public virtual Department Department { get; set; }
        public int Salary { get; set; }

        public IEnumerable<Leave> leaves { get; set; }

    }
}
