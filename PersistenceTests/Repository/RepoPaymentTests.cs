using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repository.Tests
{
    [TestClass()]
    public class RepoPaymentTests
    {
        [TestMethod()]
        public void addPaymentTest()
        {
            try
            {
                RepoPayment repo = new RepoPayment();
                Model.Conference c = new Model.Conference();
                Model.User user = new Model.User(1, "username", "pass", "Name", "Affiliation", "email@yahoo.com", false, "www.website.com");
                Model.User user2 = new Model.User(2, "username", "pass", "Name", "Affiliation", "email@yahoo.com", false, "www.website.com");
                Participant p = new Participant(1, user, c, false, false, true, true);
                Participant p2 = new Participant(2, user2, c, false, false, true, true);
                repo.addPayment(p, 1);
                repo.addPayment(p2, 10);

                Assert.AreEqual(repo.getPayments().Count, 2);
            }
            catch (RepositoryException e)
            {
                Console.Write(e.StackTrace);
            }
        }
    }
}