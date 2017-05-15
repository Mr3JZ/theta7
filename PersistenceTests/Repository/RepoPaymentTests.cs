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
                Conference c = new Conference();
                User user = new User(1, "username", "pass", "Name", "Affiliation", "email@yahoo.com", false, 1, "www.website.com");
                User user2 = new User(2, "username", "pass", "Name", "Affiliation", "email@yahoo.com", false, 2, "www.website.com");
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