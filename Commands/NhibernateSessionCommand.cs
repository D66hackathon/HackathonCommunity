using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Hackathon_Community.Models;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hackathon_Community.Commands
{
    public class NhibernateSessionCommand
    {
        private static ISessionFactory sessionFactory;
        private static Configuration configuration;

        public static ISessionFactory CreateSessionFactory()
        {
            try
            {
                sessionFactory =  Fluently.Configure()
                .Database(SQLiteConfiguration.Standard.UsingFile("D:\\test.db"))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Team>())
                .ExposeConfiguration(cfg => configuration = cfg)
                .BuildSessionFactory();

                var export = new SchemaExport(configuration);
                export.Drop(false, true);
                export.Create(false, true);

                return sessionFactory;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static ISession OpenSession()
        {
            ISession session = sessionFactory.OpenSession();

            return session;
        } 
    }
}