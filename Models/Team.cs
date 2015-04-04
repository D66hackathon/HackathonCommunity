using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon_Community.Models
{
    public class Team
    {
        public virtual long Id { get; set; }
        public virtual string Naam { get; set; }
        public virtual IList<Lid> Leden { get; set; }
        public virtual string Idee { get; set; }
        public virtual string Datum { get; set; }
    }

    public class TeamMap : ClassMap<Team>
    {
        public TeamMap()
        {
            Id(x => x.Id);
            Map(x => x.Naam);
            HasMany(x => x.Leden);
            Map(x => x.Idee);
            Map(x => x.Datum);
        }
    }
}