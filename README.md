# GoogleSEOParser

This is a tool that you can use to check how well your website is optimised for google search. Just supply a keyword that is relevant to your website and the domain name of your website. The tool will scrape the top 100 results and determines which ones directly link to that domain name

## Strategies

1. If brute force mode is not enabled, the parser will parse result by pages. The parser will get all the result links and the *related* links as marked by google in its results.

2. If brute force mode is enabled, the parser will make 100 requests and accurately find only urls in search results. This is very inefficent and will take 100 * 2 seconds so that the host ip does not get blocked by google.
