using Domain.Requests.Enums;
using Domain.Users;

namespace Domain.request
{
    public class Request
    {
        public long RegustId { get; set; }
        public long RegustedUserId { get; set; }
        public required User RegustedUser { get; set; }
        public string? Reason { get; set; }
        public DateTime CratedDate {  get; set; }
        public DateTime StardDate {  get; set; }
        public DateTime FinishDateDate {  get; set; }
        public RequestStatus Status { get; set; }
        public string? AdminResponse { get; set; }
    }
}
