using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkPermit.DAL.Models
{
    public class WorkPermitRequest
    {

        public enum WorkPermitStatus
        {
            New,
            Approved,
            Rejected
        }
        public int Id { get; set; }
        public int? EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        // Navigation properties
        public ICollection<Activity>? Activities { get; set; }
        public ICollection<Equipment>? Equipment { get; set; }

        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}")]
        public DateTime? EndDate { get; set; }
        public WorkPermitStatus? Status { get; set; } = WorkPermitStatus.New;

        [ForeignKey("EmployeeId")]
        public virtual Employee Employee { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department Department { get; set; }
    }
}