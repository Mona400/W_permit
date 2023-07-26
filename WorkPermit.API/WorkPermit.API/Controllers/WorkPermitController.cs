using Microsoft.AspNetCore.Mvc;
using WorkPermit.API.Helper;
using WorkPermit.BLL.Dto;
using WorkPermit.BLL.Services.WorkPermitServices;
using WorkPermit.DAL.Context;
using WorkPermit.DAL.Models;
using WorkPermit.DAL.Repo.WorkPermitRepo;

namespace WorkPermit.API.Controllers
{

    [ApiController]
    public class WorkPermitController : ControllerBase
    {
        private readonly IWorkPermitServices _workPermitServices;
        private readonly IWorkPermitRepo _workPermitRepo;
        private readonly ApplicationDbContext _dbContext;

        public WorkPermitController(IWorkPermitServices workPermitServices, ApplicationDbContext dbContext, IWorkPermitRepo workPermitRepo)
        {
            _workPermitServices = workPermitServices;
            _dbContext = dbContext;
            _workPermitRepo = workPermitRepo;
        }


        [HttpGet(Router.WorkPermitRouting.List)]
        public ActionResult<List<GetWorkPermitDto>> GetAll()
        {
            return _workPermitServices.GetAll();
        }
        [HttpGet(Router.WorkPermitRouting.GetByID)]
        public ActionResult<GetWorkPermitDto?> GetById(int id)
        {
            return _workPermitServices.GetById(id);
        }
        [HttpPut(Router.WorkPermitRouting.Edit)]
        public ActionResult Edit(int id, [FromBody] WorkPermitDto workPermitDto)
        {

            _workPermitServices.Edit(id, workPermitDto);
            return CreatedAtAction(
           actionName: nameof(GetAll),
           value: "Updated Successfully");

        }
        [HttpDelete(Router.WorkPermitRouting.Delete)]
        public ActionResult<WorkPermitDto> Delete(int id, WorkPermitDto WorkPermitDto)
        {

            _workPermitServices.Delete(id);
            return CreatedAtAction(
           actionName: nameof(GetAll),
           value: "Deleted Successfully");

        }
        [HttpPut(Router.WorkPermitRouting.EditWorkPermitStatus)]
        public IActionResult UpdateStatus(int id, [FromBody] StatusModel model)
        {
            var request = _dbContext.WorkPermitRequests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            if (string.IsNullOrEmpty(model.NewStatus))
            {
                return BadRequest("Invalid status value value should be {1 or 2 or 3} also can be {New or Approved or Rejected}");
            }

            if (!Enum.TryParse<WorkPermitRequest.WorkPermitStatus>(model.NewStatus, out var status))
            {
                return BadRequest("Invalid status value value should be {1 or 2 or 3} also can be {New,Approved,Rejected}");
            }

            request.Status = status;

            // Set the EndDate property to the current datetime
            request.EndDate = DateTime.UtcNow;

            _dbContext.SaveChanges();

            return Ok();
        }
        [HttpPost(Router.WorkPermitRouting.Create)]
        public ActionResult Add([FromBody] WorkPermitDto workPermitDto)
        {
            try
            {
                _workPermitServices.Add(workPermitDto);
                return CreatedAtAction(
                  actionName: nameof(GetAll),
                  value: "Added Successfully");
            }
            catch (ArgumentException ex)
            {
                return BadRequest("EmployeeID ,DepartmentID Is Invalid Or Missing");
            }
        }

    }
}


