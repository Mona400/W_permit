using Microsoft.EntityFrameworkCore;
using WorkPermit.DAL.Context;
using WorkPermit.DAL.Models;
using WorkPermit.DAL.Repo.GenericRepo;

namespace WorkPermit.DAL.Repo.WorkPermitRepo
{
    public class WorkPermitRepo : GenericRepo<WorkPermitRequest>, IWorkPermitRepo
    {
        private readonly ApplicationDbContext _context;
        public WorkPermitRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }



        public void AddWorkPermit(WorkPermitRequest workPermitRequest)
        {
            _context.WorkPermitRequests.Add(workPermitRequest);

            _context.SaveChanges();
        }
        public WorkPermitRequest? UpdateStatusByWorkPermitId(int? WorkPermitId)
        {
            var WorkPermit = _context.WorkPermitRequests
              .Where(r => r.Id == WorkPermitId)
             .FirstOrDefault();
            return WorkPermit;

        }
        public List<WorkPermitRequest> GetAllWorkPermitRequests()
        {

            return _context.WorkPermitRequests
                .Include(w => w.Department)
                .Include(w => w.Equipment)
                .Include(w => w.Employee)
                .Include(w => w.Activities)
                .ToList();
        }
        public WorkPermitRequest GetWorkPermitRequestById(int Id)
        {
            var PermitRequest = _context.WorkPermitRequests
                .Where(w => w.Id == Id)
               .Include(w => w.Department)
                .Include(w => w.Equipment)
                .Include(w => w.Employee)
                .Include(w => w.Activities)
                .FirstOrDefault()
           ;
            return PermitRequest;
        }
    }
}
