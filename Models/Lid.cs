using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon_Community.Models
{
    public class Lid
    {
        public virtual long Id { get; set; }
        public virtual string Naam { get; set; }
    }

    public class LidMap : ClassMap<Lid>
    {
        public LidMap()
        {
            Id(x => x.Id);
            Map(x => x.Naam);
        }
    }
}