using EventsPro.API.Models.Base;

namespace EventsPro.API.Models
{
    public class Event : BaseEntity
    {
        public string? Place { get; set; }        
        public DateTime EventDate { get; set; }        
        public string? Theme  { get; set; }        
        public int TotalPeople  { get; set; }        
        public string? TicketLot  { get; set; }        
        public string? UrlImage  { get; set; }        
    }
}