using System;
using Workflow.Base.DDD.Domain.SharedKernel;
using NHibernate;
using Workflow.Base.DDD.Domain;
using Workflow.Dashboard.Domain.Abstract;
using Workflow.Basic.Presentation;
using Workflow.Basic.Domain.Domain.Entities;
using System.IO;
using Conf = System.Configuration;
using Workflow.Base.Infrastructure.Config;

namespace Workflow.Base.Infrastructure.NHibernate
{
    public class SampleDataGenerator
    {
        private ISession _session;

        public void Generate(ISession session)
        {            
            _session = session;

            ExecuteSQLQuery();

            _session.Flush();                        
        }

        private void ExecuteSQLQuery()
        {
            string tempPath = SettingsProvider.BaseSettings.TempPath;
            string q;

            using (StreamReader sr = new StreamReader(tempPath + "Workflow\\insert.sql"))
            {
                q = sr.ReadToEnd();
            }

            IQuery query = _session.CreateSQLQuery(q);
            query.ExecuteUpdate();
        }
    }
}