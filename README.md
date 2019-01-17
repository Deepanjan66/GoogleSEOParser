# GoogleSEOParser

This is a tool that you can use to check how well your website is optimised for google search. Just supply a keyword that is relevant to your website and the domain name of your website. The tool will scrape the top 100 results and determines which ones directly link to that domain name.

[[__WARNING__: THE RESULTS MIGHT NOT BE 100% ACCURATE AS THERE ARE PARSED FROM HTML SOURCE AND NOT USING GOOGLE'S API]]

![](https://github.com/Deepanjan66/GoogleSEOParser/blob/master/sample_screenshot.png)

## Strategies

1. If brute force mode is not enabled, the parser will parse result by pages. The parser will get all the result links and the *related* links as marked by google in its results. This approach will only make 9-10 requests (Recommended).

For example:

keyword: `facebook`
url: `www.facebook.com`

![](https://github.com/Deepanjan66/GoogleSEOParser/blob/master/sample_webpage.png)

will also capture https://www.facebook.com/login/, https://www.facebook.com/games/, https://www.facebook.com/accentureaustralia/, https://www.facebook.com/facebook/about/ and number them as they have been shown as related results. (The order may be slightly different from your browser.The numbers are generated from top to bottom by parsing through the source)

2. If brute force mode is enabled, the parser will make 100 requests and accurately find only urls in search results. This is very inefficent as it will take significantly longer. When google receives a large number of requests from an ip within a short period of time, it will temporarily block the ip. To avoid this, a 5 second delay has been added after every request. However, this delay might not be enough to stop google from temporarily blocking requests from your ip (Not Recommended).

## How to run

To run the project, open it in Visual Studio and click on the play button (run button).
