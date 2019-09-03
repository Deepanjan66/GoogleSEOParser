using System;
using Xunit;
using System.Collections;
using SEOParser.Helpers;


namespace SEOParser.UnitTest
{
    public class GoogleSEORankingUnitTest
    {

        [Fact]
        public void Test_Empty_URL_Should_Return_Zero_Id()
        {
            var api = new MyGoogleApi();
            ArrayList results = api.getSEORankings("", "somewebsite", 10, false);

            Assert.True((int) results[0] == 0);
            Assert.True(results.Count == 1);
        }

        [Fact]
        public void Test_Empty_Keyword_Should_Return_Zero_Id()
        {
            var api = new MyGoogleApi();
            ArrayList results = api.getSEORankings("somewebsite.com", "", 10, false);

            Assert.True((int)results[0] == 0);
            Assert.True(results.Count == 1);
        }
    }
}
