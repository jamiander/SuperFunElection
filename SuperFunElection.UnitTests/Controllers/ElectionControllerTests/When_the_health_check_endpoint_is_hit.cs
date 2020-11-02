using Machine.Fakes;
using Machine.Specifications;
using Microsoft.AspNetCore.Mvc;
using SuperFunElection.Controllers;

namespace SuperFunElection.UnitTests.Controllers.ElectionControllerTests
{
    public class When_the_health_check_endpoint_is_hit : WithSubject<ElectionController>
    {
        //Establish that =()=>
        //{
        //    // Put the code to set stuff up if necessary
        //};

        protected static OkResult healthCheckResult;

        Because of = async ()=>
        {
            healthCheckResult = (OkResult)await Subject.HealthCheck();
        };

        It should_give_a_response =()=>
            healthCheckResult.ShouldNotBeNull();

        It should_have_a_200_code =()=>
            healthCheckResult.StatusCode.ShouldEqual(200);
    }
}
