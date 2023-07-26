using WorkPermit.DAL.Models;
using WorkPermit.DAL.Repo.GenericRepo;

namespace WorkPermit.DAL.Repo.WorkPermitRepo
{
    public interface IWorkPermitRepo : IGenericRepo<WorkPermitRequest>
    {
        WorkPermitRequest? UpdateStatusByWorkPermitId(int? WorkPerzmitId);
        public void AddWorkPermit(WorkPermitRequest workPermitRequest);
        // public void AddWorkPermit(WorkPermitRequest workPermitRequest, List<Activity> activities, List<Equipment> equipment);
        public List<WorkPermitRequest> GetAllWorkPermitRequests();
        public WorkPermitRequest GetWorkPermitRequestById(int Id);

    }
}
