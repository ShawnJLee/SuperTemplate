using System.Data.Entity.ModelConfiguration;
using SuperTemplate.Core.Entities;

namespace SuperTemplate.EF.Maps
{
    public class AppointmentMap : EntityTypeConfiguration<Appointment>
    {
        public AppointmentMap()
        {
            HasKey(x => x.Id);
            Property(x => x.StartTime);
            Property(x => x.EndTime);
            HasMany(x => x.Invitations);
            HasOptional(x => x.Location);
            ToTable("Appointments");
        }
    }
}
