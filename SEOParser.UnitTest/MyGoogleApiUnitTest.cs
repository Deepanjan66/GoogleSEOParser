using System;
using Xunit;
using System.Collections;
using SEOParser.Helpers;


// Testing have only been done for invalid cases as testing for
// valid cases will may result in a block from google
namespace SEOParser.UnitTest
{
    public class GoogleSEORankingUnitTest
    {

        [Fact]
        public void Test1()
        {
            var api = new MyGoogleApi();
            ArrayList results = api.getSEORankings("", "sympli", 10, false);

            Assert.True((int) results[0] == 0);
            Assert.True(results.Count == 1);
        }

        [Fact]
        public void Test2()
        {
            var api = new MyGoogleApi();
            ArrayList results = api.getSEORankings("sympli.com", "", 10, false);

            Assert.True((int)results[0] == 0);
            Assert.True(results.Count == 1);
        }

        [Fact]
        public void Test3()
        {
            var api = new MyGoogleApi();
            ArrayList results = api.getSEORankings("", "", 10, false);

            Assert.True((int)results[0] == 0);
            Assert.True(results.Count == 1);
        }

        [Fact]
        public void Test4()
        {
            var api = new MyGoogleApi();
            ArrayList results = api.getSEORankings("", "", 10, true);

            Assert.True((int)results[0] == 0);
            Assert.True(results.Count == 1);
        }

        [Fact]
        public void Test5()
        {
            var api = new MyGoogleApi();
            ArrayList results = api.getSEORankings("sympli.com", "", 10, true);

            Assert.True((int)results[0] == 0);
            Assert.True(results.Count == 1);
        }

        [Fact]
        public void Test6()
        {
            var api = new MyGoogleApi();
            ArrayList results = api.getSEORankings("sympli.com", "sympli", -1, true);

            Assert.True((int)results[0] == 0);
            Assert.True(results.Count == 1);
        }

    }
}
