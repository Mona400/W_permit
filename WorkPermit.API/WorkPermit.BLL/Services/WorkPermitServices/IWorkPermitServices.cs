using WorkPermit.BLL.Dto;

namespace WorkPermit.BLL.Services.WorkPermitServices
{
    public interface IWorkPermitServices
    {
        List<GetWorkPermitDto> GetAll();
        void Add(WorkPermitDto addWorkPermitDto);
        public void Edit(int id, WorkPermitDto workPermitDto);
        public void Delete(int id);
        public GetWorkPermitDto? GetById(int Id);
        WorkPermitDto? UpdateStatusByWorkPermitId(int? WorkPermitId);
    }
}

