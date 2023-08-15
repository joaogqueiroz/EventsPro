using EventsPro.Domain.Entities.Base;

namespace EventsPro.Domain.Entities
{
    public class Event : BaseEntity
    {
        public string? Place { get; set; }        
        public DateTime? EventDate { get; set; }        
        public string? Theme  { get; set; }        
        public int TotalPeople  { get; set; }        
        public string? TicketLot  { get; set; }        
        public string? UrlImage  { get; set; }        
        public string? Phone  { get; set; }        
        public string? Email  { get; set; }        
        public IEnumerable<Batch>? Batches  { get; set; }        
        public IEnumerable<SocialNetwork>? SocialNetworks  { get; set; }        
        public IEnumerable<SpeakerEvent>? SpeakersEvents { get; set; }        
        
    }
}