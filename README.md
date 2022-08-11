# Completed Tech Assessment Notes

- Completed
    - Parsing of 
        - Get Request
        - IP Address
        - URL
        - URL Resources
        - DateTime
    - Prints Information Log
        - Most Active IP Addresses
        - Total Unique IP Addresses
        - Most Visted Websites - Simplified Implmentation due to Time Constraints
    - Implementation of
        - Models
        - Helper Class
        - Repository for Data

- Duration
    - I spent 4 hours on the challenge
    - The URL Parsing ended up being a time sink, and I ultimately decided to do a simply implementation to submit on time

- Improvements
    - Unit Tests (I should have done them as I went tbh)
        - I was intending on using NUnit for this
    - Refine URL Parsing - Split Methods were not playing nice and ended up wasting a lot of time
        - When googling about how to best approach the URL Parsing I found mostly results that specified that Regex was the best approach
        - Original Implementation would count each instance of the
            - Domain
            - Subroute

# Programming Task Overview

The goal of this task is to create a solution we can use to have a conversation about your
software development skills. To this end we are looking for readable code and passing
tests.

Please provide a solution that meets the deliverables stated below.

**Time and effort**

Whilst there is no time limit, we expect this should take between 2-4 hours to complete. If
you find yourself spending more time you may want to revisit your approach or ask for
clarification.

**The task**

The task is to parse a log file containing HTTP requests and to report on its contents. For a
given log file we want to know:
- The number of unique IP addresses
- The top 3 most visited URLs
- The top 3 most active IP addresses

**Example Data**

177.71.128.21 - - [10/Jul/2018:22:21:28 +0200] "GET /intranet-analytics/ HTTP/1.1" 200 3574
A log file with test data is included with this assignment.

**Deliverables**

- For this task you can choose from any coding language, e.g. Java, Python,
JavaScript, Kotlin, Go or C# etc
- There are no restrictions on using third-party libraries.
- Please include tests that demonstrate your solution is working.
- You can submit your solution as a zip file containing the source code or a public git
repository.
- This exercise will form the basis of your technical interview – please send via the
link within the email or through to emergingcareers@mantelgroup.com.au 24
hours prior to your interview

**Handy hints and tips**

- We will be looking to assess your problem-solving skills, so be prepared to talk
through how, and why, you reached this solution at interview
- Ensure you use clean code
- Be prepared to talk about potential changes to your code and how this might
impact your solution