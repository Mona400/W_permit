namespace WorkPermit.DAL.Models
{
    public class Activity
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? WorkPermitRequestId { get; set; }
        //[ForeignKey("WorkPermitRequestId")]
        //public WorkPermitRequest? WorkPermitRequest { get; set; }

    }
}
