namespace WorkPermit.BLL.Dto
{
    public class WorkPermitDto
    {

        public int? EmployeeId { get; set; }
        public int? DepartmentId { get; set; }
        public List<ActivityDto>? ActivitiesDto { get; set; }
        public List<EquipmentDto>? EquipmentDto { get; set; }
        public EmployeeDto? EmployeeDto { get; set; }
        public DepartmentDto? DepartmentDto { get; set; }

    }
}
