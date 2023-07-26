namespace WorkPermit.DAL.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? WorkPermitRequestId { get; set; }
        //[ForeignKey("WorkPermitRequestId")]
        //public WorkPermitRequest? WorkPermitRequest { get; set; }

    }
}
