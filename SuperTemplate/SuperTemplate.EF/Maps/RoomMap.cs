using System.Data.Entity.ModelConfiguration;
using SuperTemplate.Core.Entities;

namespace SuperTemplate.EF.Maps
{
    public class RoomMap : EntityTypeConfiguration<Room>
    {
        public RoomMap()
        {
            HasKey(x => x.Id);
            Property(x => x.Name);
            Property(x => x.LocationDescription);
            ToTable("Rooms");
        }
    }
}
