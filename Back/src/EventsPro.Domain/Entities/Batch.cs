using EventsPro.Domain.Entities.Base;

namespace EventsPro.Domain.Entities
{
    public class Batch : BaseEntity
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public int Amount { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}