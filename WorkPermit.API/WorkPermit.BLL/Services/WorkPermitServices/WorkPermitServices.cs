using WorkPermit.BLL.Dto;
using WorkPermit.DAL.Models;
using WorkPermit.DAL.Repo.WorkPermitRepo;

namespace WorkPermit.BLL.Services.WorkPermitServices
{
    public class WorkPermitServices : IWorkPermitServices
    {
        private readonly IWorkPermitRepo _workPermitRepo;

        public WorkPermitServices(IWorkPermitRepo workPermitRepo)
        {
            _workPermitRepo = workPermitRepo;
        }



        public void Add(WorkPermitDto? addWorkPermitDto)
        {

            var WorkPermit = new WorkPermitRequest
            {
                // Id = addWorkPermitDto.Id,
                EmployeeId = addWorkPermitDto?.EmployeeId,
                DepartmentId = addWorkPermitDto?.DepartmentId,
                StartDate = DateTime.Now,
                EndDate = DateTime.Now,
            };
            _workPermitRepo.AddWorkPermit(WorkPermit);
            _workPermitRepo.SaveChanges();

        }


        public void Delete(int id)
        {
            WorkPermitRequest? workPermitRequest = _workPermitRepo.GetWorkPermitRequestById(id);

            if (workPermitRequest == null) { return; }

            _workPermitRepo.Delete(workPermitRequest);
            _workPermitRepo.SaveChanges();
        }


        public void Edit(int id, WorkPermitDto workPermitDto)
        {
            WorkPermitRequest? workPermitRequest = _workPermitRepo.GetById(id);
            if (workPermitRequest == null) { return; }

            workPermitRequest.DepartmentId = (int)workPermitDto?.DepartmentId;

            workPermitRequest.EmployeeId = (int)workPermitDto?.EmployeeId;
            workPermitRequest.Employee = new Employee { Role = workPermitDto.EmployeeDto.Role, Name = workPermitDto.EmployeeDto.Name };

            workPermitRequest.Department = new Department { Name = workPermitDto.DepartmentDto.Name };
            workPermitRequest.Activities = workPermitDto.ActivitiesDto.Select(re => new Activity
            {
                Description = re.Description

            }).ToList();
            workPermitRequest.Equipment = workPermitDto.EquipmentDto?.Select(e => new Equipment
            {
                Name = e.Name
            }).ToList();



            _workPermitRepo.Update(workPermitRequest);
            _workPermitRepo.SaveChanges();

        }



        public List<GetWorkPermitDto> GetAll()
        {
            var workPermitRequests = _workPermitRepo.GetAllWorkPermitRequests()

                .Select(w => new GetWorkPermitDto
                {
                    Id = w.Id,
                    EmployeeId = (int)w?.EmployeeId,
                    Employee = new EmployeeDto { Role = w.Employee.Role, Name = w.Employee.Name },
                    DepartmentId = (int)w?.DepartmentId,
                    Department = new DepartmentDto { Name = w.Department.Name },
                    Activities = w.Activities?.Select(a => new Activity { Description = a.Description }).ToList(),
                    Equipment = w.Equipment?.Select(e => new Equipment { Name = e.Name }).ToList(),
                    StartDate = (DateTime)w?.StartDate,
                    EndDate = (DateTime)w?.EndDate,
                    Status = (WorkPermitStatus?)w.Status
                })
                .ToList();

            return workPermitRequests;
        }


        public GetWorkPermitDto? GetById(int Id)
        {
            WorkPermitRequest? workPermitRequest = _workPermitRepo.GetWorkPermitRequestById(Id);

            if (workPermitRequest == null) { return null; }
            var workPermitDto = new GetWorkPermitDto();
            workPermitDto.Id = workPermitRequest.Id;
            workPermitDto.DepartmentId = (int)workPermitRequest?.DepartmentId;
            workPermitDto.EmployeeId = (int)workPermitRequest?.EmployeeId;
            workPermitDto.StartDate = (DateTime)workPermitRequest?.StartDate;
            workPermitDto.EndDate = (DateTime)workPermitRequest?.EndDate;
            workPermitDto.Status = (WorkPermitStatus?)workPermitRequest.Status;
            workPermitDto.Employee = new EmployeeDto { Role = workPermitRequest.Employee.Role, Name = workPermitRequest.Employee.Name };
            workPermitDto.Department = new DepartmentDto
            {
                Name = workPermitRequest.Department.Name
            };

            workPermitDto.Activities = workPermitRequest.Activities?.Select(re => new Activity
            {
                Description = re.Description

            }).ToList();
            workPermitDto.Equipment = workPermitRequest.Equipment?.Select(e => new Equipment
            {
                Name = e.Name
            }).ToList();
            return workPermitDto;
        }

        public WorkPermitDto? UpdateStatusByWorkPermitId(int? WorkPermitId)
        {
            throw new NotImplementedException();
        }


    }
}
