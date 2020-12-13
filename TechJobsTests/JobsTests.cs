using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechJobsOO;

namespace JobsTests
{
    [TestClass]
    public class JobsTests
    {

        [TestMethod]
        public void TestSettingJobId()
        {
            Job test_job_1 = new Job();
            Job test_job_2 = new Job();
            Assert.IsFalse(test_job_1.Id == test_job_2.Id);
            Assert.AreEqual(1, test_job_1.Id);
            Assert.AreEqual(2, test_job_2.Id);
        }

        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Job test_job_2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Assert.AreEqual("Product tester", test_job_2.Name);
            Assert.AreEqual("ACME", test_job_2.EmployerName.Value);
            Assert.AreEqual("Desert", test_job_2.EmployerLocation.Value);
            Assert.AreEqual("Quality control", test_job_2.JobType.Value);
            Assert.AreEqual("Persistence", test_job_2.JobCoreCompetency.Value);

        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Job test_job_1 = new Job();
            Job test_job_2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Assert.IsFalse(test_job_2.Equals(test_job_1));
        }

        [TestMethod]
        public void TestToStringForEmptyLines()
        {
            Job test_job_2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            Assert.IsTrue(test_job_2.ToString().StartsWith("\n"));
            Assert.IsTrue(test_job_2.ToString().EndsWith("\n"));
        }

        [TestMethod]
        public void TestToStringForAllProperties()
        {
            Job test_job_2 = new Job("Product tester", new Employer("ACME"), new Location("Desert"), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            string expectedResult = "\nID: 1\nName: Product tester\nEmployer: ACME\nLocation: Desert\nPosition Type: Quality control\nCore Competency: Persistence\n";
            Assert.AreEqual(expectedResult, test_job_2.ToString());
        }

        [TestMethod]
        public void TestToStringForEmptyField()
        {
            Job test_job_3 = new Job("Product tester", new Employer("ACME"), new Location(""), new PositionType("Quality control"), new CoreCompetency("Persistence"));
            string expectedResult = "\nID: 1\nName: Product tester\nEmployer: ACME\nLocation: Data not available\nPosition Type: Quality control\nCore Competency: Persistence\n";
            Assert.AreEqual(expectedResult, test_job_3.ToString());
        }

    }
}
