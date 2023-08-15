using EventsPro.Domain.Entities.Base;

namespace EventsPro.Domain.Entities
{
    public class SpeakerEvent : BaseEntity
    {
        public int SpeakerId { get; set; }
        public Speaker? Speaker { get; set; }
        public int EventId { get; set; }
        public Event? Event { get; set; }
    }
}