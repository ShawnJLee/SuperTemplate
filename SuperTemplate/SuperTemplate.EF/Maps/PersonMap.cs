using System.Data.Entity.ModelConfiguration;
using SuperTemplate.Core.Entities;

namespace SuperTemplate.EF.Maps
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public PersonMap()
        {
            HasKey(x => x.Id);
            Property(x => x.FirstName);
            Property(x => x.LastName);
            ToTable("People");
        }
    }
}
