using EventsPro.Domain.Entities.Base;

namespace EventsPro.Domain.Entities
{
    public class Speaker : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageURL { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public IEnumerable<SocialNetwork>? SocialNetworks { get; set; }
        public IEnumerable<SpeakerEvent>? SpeakersEvents { get; set; }
    }
}