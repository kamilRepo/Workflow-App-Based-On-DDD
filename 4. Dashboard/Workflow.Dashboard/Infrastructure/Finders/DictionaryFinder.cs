using Workflow.Base.CQRS.Query.Attributes;
using Workflow.Base.Infrastructure.NHibernate;
using Workflow.Dashboard.Interface.Presentation.Abstract;
using Workflow.Dashboard.Interface.Presentation.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate.Linq;
using Workflow.Dashboard.Interface.Presentation.Criteria;
using NHibernate.Transform;
using Workflow.Basic.Domain.Domain.Entities;
using Workflow.Base.DDD.Domain.Exceptions;
using Workflow.Base.Infrastructure.Attributes;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.Dashboard.Infrastructure.Finders
{
    [Finder]
    public class DictionaryFinder : IDictionaryFinder
    {
        public IEntityManager EntityManager { get; set; }

        #region Finders

        [ApplicationLayerException(ErrorNumbers.DictionaryFinderFindSection, "ErrorDataDownload")]
        public List<DictionaryDto> FindSection()
        {
            var s = EntityManager.CurrentSession;

            return (
                from
                    e in s.Query<B_Section>()
                orderby 
                    e.Name
                select
                    new DictionaryDto(e.Id, e.Name)
           ).ToList();
        }

        [ApplicationLayerException(ErrorNumbers.DictionaryFinderFindOrganizationalUnit, "ErrorDataDownload")]
        public List<DictionaryDto> FindOrganizationalUnit()
        {
            var s = EntityManager.CurrentSession;

            return (
                from
                    e in s.Query<B_OrganizationalUnit>()
                orderby
                    e.Name
                select
                    new DictionaryDto(e.Id, e.Name)
           ).ToList();
        }

        [ApplicationLayerException(ErrorNumbers.DictionaryFinderFindOrganizationalCell, "ErrorDataDownload")]
        public List<DictionaryDto> FindOrganizationalCell()
        {
            var s = EntityManager.CurrentSession;

            return (
                from
                    e in s.Query<B_OrganizationalCell>()
                orderby
                    e.Name
                select
                    new DictionaryDto(e.Id, e.Name)
           ).ToList();
        }

        [ApplicationLayerException(ErrorNumbers.DictionaryFinderFindSilo, "ErrorDataDownload")]
        public List<DictionaryDto> FindSilo()
        {
            var s = EntityManager.CurrentSession;

            return (
                from
                    e in s.Query<B_Silo>()
                orderby
                    e.Name
                select
                    new DictionaryDto(e.Id, e.Name)
           ).ToList();
        }

        #endregion
        #region Criteria



        #endregion
    }
}
