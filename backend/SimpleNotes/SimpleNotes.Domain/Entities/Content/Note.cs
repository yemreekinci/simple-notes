using SimpleNotes.Domain.Entities.Common;

namespace SimpleNotes.Domain.Entities.Content
{
    public class Note : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Order {  get; set; }
    }
}
