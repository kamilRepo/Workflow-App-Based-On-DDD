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
using Workflow.Basic.Domain.Domain.Entities.Dictionaries;
using Workflow.Base.Infrastructure.Attributes;
using Workflow.Base.Interface.Domain.Dictionaries;

namespace Workflow.Dashboard.Infrastructure.Finders
{
    [Finder]
    public class EmployeeFinder : IEmployeeFinder
    {
        public IEntityManager EntityManager { get; set; }

        #region Finders

        [ApplicationLayerException(ErrorNumbers.EmployeeFinderFindEmployee, "ErrorDataDownload")]
        public EmployeeDto FindEmployee(int id)
        {
            var s = EntityManager.CurrentSession;
            
            return (
                from 
                    e in s.Query<B_Employee>()
                where
                    (e.Id == id)
                select 
                    new EmployeeDto(e.FirstName, e.LastName, e.EmployeeNumber, e.PhoneNumber, e.MobilePhoneNumber, e.Email,
                        e.Pesel, e.Education)
           ).FirstOrDefault();
        }

        [ApplicationLayerException(ErrorNumbers.EmployeeFinderFindEmployees, "ErrorDataDownload")]
        public List<EmployeeDto> FindEmployees(EmployeeSearchCriteria criteria)
        {     
            string sql = @"
                SELECT 
                    e.Id as Id,
                    e.FirstName as FirstName, 
                    e.LastName as LastName, 
                    e.EmployeeNumber as EmployeeNumber, 
                    e.PhoneNumber as PhoneNumber, 
                    e.MobilePhoneNumber as MobilePhoneNumber, 
                    e.Email as Email,
                    e.Pesel as Pesel, 
                    oc.Name as OrganizationalCell,
                    em.Position as Position,
                    em.DirectSupervisor_id as DirectSupervisorID
                FROM B_Employee e
                    Left JOIN B_EmployeeMembership em
                        ON e.id = em.Employee_id                            
                    LEFT JOIN B_OrganizationalUnit ou
                        ON em.OrganizationalUnit_id = ou.id
                    LEFT JOIN B_OrganizationalCell oc
                        ON em.OrganizationalCell_id = oc.id
            ";

            sql = ApplyCriteria(sql, criteria);

            var list = SetCriteria(sql, criteria);                

            return list.ToList();
        }

        [ApplicationLayerException(ErrorNumbers.EmployeeFinderFindEmployeeMembership, "ErrorDataDownload")]
        public EmployeeMembershipDto FindEmployeeMembership(int id)
        {
            var s = EntityManager.CurrentSession;

            string hql = @"
                SELECT 
                    em.Id as Id,
                    ou.Name as OrganizationalUnit, 
                    mou.FirstName as ManagerBranchName, 
                    mou.LastName as ManagerBranchSurName, 
                    mou.Email as ManagerBranchEmail, 
                    se.Name as Section, 
                    em.Room as Room, 
                    oc.Name as OrganizationalCell, 
                    em.Position as Position
                FROM B_EmployeeMembership em
                    LEFT JOIN em.Section se
                    JOIN em.DirectSupervisor ds
                    LEFT JOIN em.OrganizationalCell oc
                    LEFT JOIN em.OrganizationalUnit ou
                    LEFT JOIN ou.ManagerOrganizationalUnit mou
                WHERE
                    em.Employee = :id AND
                    em.Status = :status
            ";

            var list = s.CreateQuery(hql)
                .SetInt32("id", id)
                .SetInt32("status", (int)EntityStatus.Active)
                .SetResultTransformer(Transformers.AliasToBean<EmployeeMembershipDto>())
                .List<EmployeeMembershipDto>();

            return list.FirstOrDefault();
        }

        [ApplicationLayerException(ErrorNumbers.EmployeeFinderFindEmployeeAdress, "ErrorDataDownload")]
        public List<EmployeeAddressDto> FindEmployeeAdress(int id)
        {
            var s = EntityManager.CurrentSession;

            return (
                from
                    e in s.Query<B_EmployeeAddress>()
                where
                    (e.Employee.Id == id) 
                select
                    new EmployeeAddressDto(e.Id, e.Street, e.BuildingNo, e.LocalNo, e.PostalCode, e.City, e.PostOffice, e.IsCorrespondence)
           ).ToList();
        }

        #endregion
        #region Criteria

        private string ApplyCriteria(string query, EmployeeSearchCriteria criteria)
        {
            // WHERE
            query = query + " Where e.status = :estatus ";
            query = query + " AND em.status = :emstatus ";

            if (criteria.EmployeeID > 0)
            {
                query = query + " AND e.Id = :EmployeeID ";
            }

            if (criteria.DirectSupervisorID > 0)
            {
                query = query + " AND em.DirectSupervisor_id = :DirectSupervisorID ";
            }

            if (!string.IsNullOrEmpty(criteria.FirstName))
            {
                query = query + " AND e.FirstName LIKE :FirstName ";
            }

            if (!string.IsNullOrEmpty(criteria.LastName))
            {
                query = query + " AND e.LastName LIKE :LastName ";
            }

            if (!string.IsNullOrEmpty(criteria.Position))
            {
                query = query + " AND em.Position LIKE :Position ";
            }

            if (!string.IsNullOrEmpty(criteria.PhoneNumber))
            {
                query = query + " AND e.PhoneNumber LIKE :PhoneNumber ";
            }

            if (!string.IsNullOrEmpty(criteria.MobilePhoneNumber))
            {
                query = query + " AND e.MobilePhoneNumber LIKE :MobilePhoneNumber ";
            }

            if (!string.IsNullOrEmpty(criteria.Email))
            {
                query = query + " AND e.Email LIKE :Email ";
            }

            if (!string.IsNullOrEmpty(criteria.Section) && !criteria.Section.Equals("0"))
            {
                query = query + " AND em.Section_id = :Section ";
            }

            if (!string.IsNullOrEmpty(criteria.OrganizationalUnit) && !criteria.OrganizationalUnit.Equals("0"))
            {
                query = query + " AND em.OrganizationalUnit_id = :OrganizationalUnit ";
            }

            if (!string.IsNullOrEmpty(criteria.OrganizationalCell) && !criteria.OrganizationalCell.Equals("0"))
            {
                query = query + " AND em.OrganizationalCell_id = :OrganizationalCell ";
            }

            if (!string.IsNullOrEmpty(criteria.Room))
            {
                query = query + " AND em.Room = :Room ";
            }

            if (!string.IsNullOrEmpty(criteria.EmployeeNumber))
            {
                query = query + " AND e.EmployeeNumber = :EmployeeNumber ";
            }

            // ORDER BY

            return query;
        }

        private List<EmployeeDto> SetCriteria(string query, EmployeeSearchCriteria criteria)
        {
            var s = EntityManager.CurrentSession.CreateSQLQuery(query);

            if (criteria.EmployeeID > 0)
            {
                s.SetInt32("EmployeeID", criteria.EmployeeID);
            }

            if (criteria.DirectSupervisorID > 0)
            {
                s.SetInt32("DirectSupervisorID", criteria.DirectSupervisorID);
            }

            if (!string.IsNullOrEmpty(criteria.FirstName))
            {
                s.SetString("FirstName", BuildLikeAttribute(criteria.FirstName));
            }

            if (!string.IsNullOrEmpty(criteria.LastName))
            {
                s.SetString("LastName", BuildLikeAttribute(criteria.LastName));
            }

            if (!string.IsNullOrEmpty(criteria.Position))
            {
                s.SetString("Position", BuildLikeAttribute(criteria.Position));
            }

            if (!string.IsNullOrEmpty(criteria.PhoneNumber))
            {
                s.SetString("PhoneNumber", BuildLikeAttribute(criteria.PhoneNumber));
            }

            if (!string.IsNullOrEmpty(criteria.MobilePhoneNumber))
            {
                s.SetString("MobilePhoneNumber", BuildLikeAttribute(criteria.MobilePhoneNumber));
            }

            if (!string.IsNullOrEmpty(criteria.Email))
            {
                s.SetString("Email", BuildLikeAttribute(criteria.Email));
            }

            if (!string.IsNullOrEmpty(criteria.Section) && !criteria.Section.Equals("0"))
            {
                s.SetInt32("Section", Convert.ToInt32(criteria.Section));
            }

            if (!string.IsNullOrEmpty(criteria.OrganizationalUnit) && !criteria.OrganizationalUnit.Equals("0"))
            {
                s.SetInt32("OrganizationalUnit", Convert.ToInt32(criteria.OrganizationalUnit));
            }

            if (!string.IsNullOrEmpty(criteria.OrganizationalCell) && !criteria.OrganizationalCell.Equals("0"))
            {
                s.SetInt32("OrganizationalCell", Convert.ToInt32(criteria.OrganizationalCell));
            }

            if (!string.IsNullOrEmpty(criteria.Room))
            {
                s.SetString("Room", criteria.Room.Trim());
            }

            if (!string.IsNullOrEmpty(criteria.EmployeeNumber))
            {
                s.SetString("EmployeeNumber", criteria.EmployeeNumber.Trim());
            }

            return s
                .SetInt32("estatus", (int)EntityStatus.Active)
                .SetInt32("emstatus", (int)EntityStatus.Active)
                .SetResultTransformer(Transformers.AliasToBean<EmployeeDto>())
                .List<EmployeeDto>()
                .ToList();
        }

        private string BuildLikeAttribute(string value)
        {
            var sb = new StringBuilder();

            sb.Append("%");
            sb.Append(value.Trim());
            sb.Append("%");

            return sb.ToString();
        }

        #endregion
    }
}
