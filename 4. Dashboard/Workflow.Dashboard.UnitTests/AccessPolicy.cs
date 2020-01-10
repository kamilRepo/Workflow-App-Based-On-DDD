using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Workflow.Dashboard.Infrastructure.Finders;
using Workflow.Dashboard.Domain.Services;
using Workflow.Dashboard.Interface.Presentation.Abstract;
using Workflow.Dashboard.Domain.Factory;

namespace Workflow.Dashboard.UnitTests
{
    [TestClass]
    public class AccessPolicy
    {
        [TestMethod]
        public void Has_Access_In_My_Portal()
        {
            //Preparation
            var myPortalAccessPolicyFactory = new MyPortalAccessPolicyFactory();

            Mock<IEmployeeMembershipFinder> mockEmployeeMembershipFinder = new Mock<IEmployeeMembershipFinder>();
            mockEmployeeMembershipFinder.Setup(x => x.FindDirectSupervisorId(2)).Returns<int>(x => 1);
            mockEmployeeMembershipFinder.Setup(x => x.FindDirectSupervisorId(3)).Returns<int>(x => 2);
            mockEmployeeMembershipFinder.Setup(x => x.FindDirectSupervisorId(4)).Returns<int>(x => 3);

            var service = new AccessPolicyService();
            service.EmployeeMembershipFinder = mockEmployeeMembershipFinder.Object;
            service.MyPortalAccessPolicyFactory = myPortalAccessPolicyFactory;

            //Action
            var value = service.CheckAccessInMyPortal(2, 3);

            //Assertions
            Assert.AreEqual(true, value);
        }

        [TestMethod]
        public void Has_Not_Access_In_My_Portal()
        {
            //Preparation
            var myPortalAccessPolicyFactory = new MyPortalAccessPolicyFactory();

            Mock<IEmployeeMembershipFinder> mockEmployeeMembershipFinder = new Mock<IEmployeeMembershipFinder>();
            mockEmployeeMembershipFinder.Setup(x => x.FindDirectSupervisorId(2)).Returns<int>(x => 1);
            mockEmployeeMembershipFinder.Setup(x => x.FindDirectSupervisorId(3)).Returns<int>(x => 2);
            mockEmployeeMembershipFinder.Setup(x => x.FindDirectSupervisorId(4)).Returns<int>(x => 3);

            var service = new AccessPolicyService();
            service.EmployeeMembershipFinder = mockEmployeeMembershipFinder.Object;
            service.MyPortalAccessPolicyFactory = myPortalAccessPolicyFactory;

            //Action
            var value = service.CheckAccessInMyPortal(2, 1);

            //Assertions
            Assert.IsFalse(value);
        }
    }
}
