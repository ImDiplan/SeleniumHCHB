# Selenium Test

This repository contains a Selenium test script written in C# that automates a series of actions on a website using the Selenium WebDriver. The test script uses the ChromeDriver to interact with a website, perform actions, and validate results.

## Prerequisites

Before running the Selenium test, make sure you have the following prerequisites installed on your system:

- [Google Chrome](https://www.google.com/chrome/)
- [ChromeDriver](https://sites.google.com/chromium.org/driver/)

## Getting Started

1. Clone this repository to your local machine.

2. Ensure that you have Chrome installed on your machine.

3. Download the ChromeDriver executable and place it in the project directory or any directory included in your system's PATH.

## Running the Test

To run the Selenium test, follow these steps:

1. Open the project in your preferred C# IDE (e.g., Visual Studio).

2. Build the project to ensure all dependencies are resolved.

3. Locate the `SeleniumTests` class within the project.

4. Inside the `RunSeleniumTest` method, you can find the series of steps that the test script will perform.

5. Make sure the ChromeDriver executable is available in your system's PATH or provide the full path to the ChromeDriver in the `ChromeDriver` instantiation.

6. Execute the test by running the `RunSeleniumTest` method.

7. The test will automate actions such as navigating to Google, searching for "Selenium HQ," verifying search results, and filling out a form. It will also validate that error messages are displayed correctly.

8. If the test runs successfully, you will see a "Test Passed" message. If any issues occur during the test, error messages will be displayed.

## Test Scenario

The Selenium test script performs the following actions:

1. Navigates to the Google homepage.

2. Searches for "Selenium HQ" using the search bar.

3. Verifies that search results containing "Selenium" are displayed.

4. Clears the search box, enters "HCHB," and searches again.

5. Verifies that the hchb.com link is displayed and navigates to it.

6. Asserts the contact information on the HCHB website.

7. Clicks on the "Request Demo" button and verifies the page URL.

8. Fills in mandatory fields of a form but leaves two fields empty.

9. Clicks the Submit button.

10. Validates that specific error messages are displayed correctly, including the "Please correct the errors below" header, "This field is required" error next to the Services Offered field, and "Invalid CAPTCHA" error next to the Captcha element.

11. Close the Browser