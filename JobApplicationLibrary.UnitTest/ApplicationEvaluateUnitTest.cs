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

        
       
    }
}