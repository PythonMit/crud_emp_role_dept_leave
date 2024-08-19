namespace crud_emp_role_dept_leave.Models
{
    public class Leave
    {
        public int Id { get; set; }
        public string Reason { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
      
        public virtual Employee Employee { get; set; }
    }
}
