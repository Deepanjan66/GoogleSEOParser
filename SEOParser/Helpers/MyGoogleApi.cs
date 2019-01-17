using System;
using System.Collections;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SEOParser.Helpers
{
    public class MyGoogleApi
    {
        private const string searchFormatUrl = 
                    "https://www.google.com/search?q={0}&start={1}";
        private const int bruteFroceDelay = 3000;
        private const int delay = 2000;

        /// <summary>
        /// This method returns a list containing the indices at which the
        /// specified url appears in the top numResults results in google search
        /// </summary>
        /// <param name="url">A string consisting of the query url</param> 
        /// <param name="keyword">A string which will be used as the keyword to 
        /// search on google with</param>
        /// <param name="numResults">Int representing the number of results the 
        /// search will look at</param>
        /// <param name="tryBruteForce">Boolean to tell if the slower and more 
        /// accurate
        /// parsing is required</param>
        /// <returns>
        /// ArrayList<Integer> con
        /// </returns>
        public ArrayList getSEO(string url, string keyword, int numResults, 
                                Boolean tryBrute)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(keyword))
            {
                var retArray = new ArrayList();
                retArray.Add(0);
                return retArray;
            }
            // To keep track of the number of urls checked so far
            int currUrlNum = 0;

            // client for making get requests
            SEOClient client = new SEOClient();
            // This regex will ignore all links except the ones mentioned
            // in the result cards. Will also included related results.
            string search = "url\\?q=[^&]+";

            // List for storing target indices
            ArrayList resultIndices = new ArrayList();

            while (currUrlNum < numResults)
            {
                // Get html for get request
                string responseHtml = client.getRequest(formatURL(keyword, 
                                                                  currUrlNum));

                MatchCollection matches = Regex.Matches(responseHtml, search);
                ArrayList arrMatches = new ArrayList(matches);

                if (tryBrute)
                {
                    // if brute force is enabled, only look at 
                    // top result. The top result is guaranteed to
                    // be a valid search result and not marked as 
                    // related by google
                    arrMatches = arrMatches.GetRange(0, 1);
                    // Extra delay for brute force method on top
                    // of the normal delay
                    Task.Delay(bruteFroceDelay).Wait();
                }

                foreach (Match match in arrMatches)
                {
                    currUrlNum += 1;
                    if (currUrlNum > numResults) break;

                    // check if seo url is in the currently matched
                    // url and if it is not a webcached link
                    if (checkIfContains(url, match.Value) && 
                        !checkIfContains("webcache", match.Value))
                    {
                        resultIndices.Add(currUrlNum);
                    }
                }
                // To not get blocked by Google
                Task.Delay(delay).Wait();
            }

            if (resultIndices.Count == 0)
            {
                resultIndices.Add(0);
            }

            return resultIndices;


        }

        // Private method or checking if haystack string contains
        // needle string
        private Boolean checkIfContains(string needle, string haystack)
        {
            var escapedNeedle = Regex.Escape(needle);
            return Regex.Match(haystack, escapedNeedle, RegexOptions.IgnoreCase)
                   .Success;
        }

        // private method for including values by replacing placeholders
        // in format string url
        private string formatURL(string keyword, int numResult)
        {
            var queryString = String.Format(searchFormatUrl, keyword, numResult);

            return queryString;
        }
    }
}
