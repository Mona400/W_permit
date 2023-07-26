using WorkPermit.DAL.Models;

namespace WorkPermit.BLL.Dto
{
    public enum WorkPermitStatus
    {
        New,
        Approved,
        Rejected
    }

    public class GetWorkPermitDto
    {
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        public EmployeeDto? Employee { get; set; }
        public DepartmentDto? Department { get; set; }
        public List<Activity>? Activities { get; set; }
        public List<Equipment>? Equipment { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public WorkPermitStatus? Status { get; set; }

    }
}
