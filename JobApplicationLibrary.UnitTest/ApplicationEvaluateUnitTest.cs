using JobApplicationLibrary.Models;
using Moq;

namespace JobApplicationLibrary.UnitTest
{
    public class ApplicationEvaluateUnitTest
    {
        //UnitofWork_Condition_ExpectedResult(test_name_part)
        [Test]
        public void Application_WithUnderAge_TransfferedtoAutoRejected()
        {
            //Arrange
            var evaluator = new ApplicationEvaluator(null);
            var form = new JobApplication()
            {
                Applicant = new Applicant()
                {
                    Age = 17
                }
            };

            //Action

            var result = evaluator.Evaluate(form);

            //Assert

            Assert.AreEqual(result, ApplicationResult.AutoRejected);

        }

        [Test]
        public void Application_WithNoTechStack_TransfferedtoAutoRejected()
        {

            //Arrange
            var mockValidator= new Mock<IIdentityValidator>();

            var evaluator=new ApplicationEvaluator(mockValidator.Object);
            mockValidator.Setup(i=>i.IsValidIndentity()).Returns(true);

            var form = new JobApplication()
            {
                Applicant = new Applicant() { Age=20},
                TechStackList = new System.Collections.Generic.List<string>() { "" }

            };

            //Action
            var result= evaluator.Evaluate(form);

            //Assert
            Assert.AreEqual(ApplicationResult.AutoRejected,result);

        }

        [Test]
        public void Application_WithHighTechStack_TransfferedtoAutoAccepted()
        {
            //Arrange
            var mockValidator = new Mock<IIdentityValidator>();

            var evaluator = new ApplicationEvaluator(mockValidator.Object);
            mockValidator.Setup(i => i.IsValidIndentity()).Returns(true);
            
            var form = new JobApplication()
            {
                Applicant = new Applicant() { Age=25},
                TechStackList = new System.Collections.Generic.List<string>() { "C#", "RabbitMQ", "MicroServices", "Visual Studio" },
                YearsofExperience=15
                

            };

            //Action
            var result = evaluator.Evaluate(form);

            //Assert
            Assert.AreEqual(ApplicationResult.AutoAccepted, result);

        }

        [Test]
        public void Application_WithInvalidIdentity_TransfferedtoHR()
        {
            //Arrange
            var mockValidator = new Mock<IIdentityValidator>();

            var evaluator = new ApplicationEvaluator(mockValidator.Object);
            mockValidator.Setup(i => i.IsValidIndentity()).Returns(false);

            var form = new JobApplication()
            {
                Applicant = new Applicant() { Age = 25 },
            };

            //Action
            var result = evaluator.Evaluate(form);

            //Assert
            Assert.AreEqual(ApplicationResult.TransferredtoHR, result);

        }

        [Test]
        public void Application_WithValidIdentity_TransfferedtoLead()
        {
            //Arrange
            var mockValidator = new Mock<IIdentityValidator>();

            var evaluator = new ApplicationEvaluator(mockValidator.Object);
           // mockValidator.Setup(i => i.IsValidIndentity()).Returns(true);

            var form = new IdentityValidator()
            {
                Applicant = new Applicant() { Age = 25,IdentityNumber=13751688526,FirstName="Uður",LastName="Oban",BofYear=1989 },
                
            };

           

            //Action
            var result = evaluator.CheckIdentityNumber(form);

            //Assert
            Assert.AreEqual(ApplicationResult.TransferredtoLead, result);

        }


    }
}