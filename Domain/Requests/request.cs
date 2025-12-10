using Domain.Requests.Enums;
using Domain.Users;

namespace Domain.request
{
    public class Request
    {
        public long RequestId { get; set; }
        public long RequestedUserId { get; set; }
        public User? RequestedUser { get; set; }
        public string? Reason { get; set; }
        public DateTime CratedDate {  get; set; }
        public DateTime StardDate {  get; set; }
        public DateTime FinishDateDate {  get; set; }
        public RequestStatus Status { get; set; }
        public string? AdminResponse { get; set; }
    }
}
