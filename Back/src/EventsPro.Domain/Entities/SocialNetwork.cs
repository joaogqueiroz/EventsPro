using EventsPro.Domain.Entities.Base;

namespace EventsPro.Domain.Entities
{
    public class SocialNetwork : BaseEntity
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public int? EventId { get; set; }
        public Event Event { get; set; }
        public int? SpeakerId { get; set; }
        public Speaker Speaker { get; set; }
    }
}