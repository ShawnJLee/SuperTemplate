
namespace SuperTemplate.Core.Entities
{
    public class Invitation : BaseEntity
    {
        public Appointment Appointment { get; set; }
        public Person Person { get; set; }
        public bool Accepted { get; set; }
    }
}
