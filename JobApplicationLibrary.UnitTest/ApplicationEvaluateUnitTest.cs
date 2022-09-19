using JobApplicationLibrary.Models;

namespace JobApplicationLibrary.UnitTest
{
    public class ApplicationEvaluateUnitTest
    {
        //UnitofWork_Condition_ExpectedResult(test_name_part)
        [Test]
        public void Application_WithUnderAge_TransfferedtoAutoRejected()
        {
            //Arrange
            var evaluator = new ApplicationEvaluator();
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
            var evaluator=new ApplicationEvaluator();
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
            var evaluator = new ApplicationEvaluator();
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


    }
}