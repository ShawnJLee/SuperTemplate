using System.Data.Entity.ModelConfiguration;
using SuperTemplate.Core.Entities;

namespace SuperTemplate.EF.Maps
{
    public class InvitationMap : EntityTypeConfiguration<Invitation>
    {
        public InvitationMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Accepted);
            HasOptional(x => x.Appointment);
            HasOptional(x => x.Person);
            ToTable("Invitations");
        }
    }
}
