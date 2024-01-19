using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using Xunit;
using SeleniumExtras.WaitHelpers;

namespace SeleniumTest
{
    public class SeleniumTests : IDisposable
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        public SeleniumTests()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void Dispose()
        {
            // Step 11: Close the browser
            driver.Quit();
        }

        [Fact]
        public void RunSeleniumTest()
        {
            try
            {
                // Step 1: Access Google and search for "Selenium HQ"
                driver.Navigate().GoToUrl("http://google.com");

                var searchBox = wait.Until(d => d.FindElement(By.XPath("//textarea[@type='search']")));
                searchBox.SendKeys("Selenium HQ");
                var searchButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("btnK")));
                searchButton.Click();

                // Step 2: Wait for search results and verify content
                wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("div#search")));
                IWebElement resultsStats = driver.FindElement(By.CssSelector("div#search"));
                Assert.Contains("Selenium", resultsStats.Text);

                // Step 3: Clear search box, input "HCHB", and search
                var searchInput = wait.Until(d => d.FindElement(By.XPath("//textarea[@type='search']")));
                searchInput.Clear();
                searchInput.SendKeys("HCHB");
                var searchBtn = wait.Until(d => d.FindElement(By.XPath("//button[@type='submit']")));
                searchBtn.Click();

                // Step 4: Verify hchb.com is displayed and navigate to it
                IWebElement hchbLink = wait.Until(d => d.FindElement(By.XPath("//a[@href='https://hchb.com/']")));
                IWebElement citeElement = hchbLink.FindElement(By.XPath(".//cite[text()='https://hchb.com']"));
                Assert.Equal("https://hchb.com", citeElement.Text);
                hchbLink.Click();

                // Step 5: Assert contact information
                IWebElement contactInfo = wait.Until(ExpectedConditions.ElementExists(By.ClassName("elementor-widget-container")));
                IWebElement phoneNumber = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".elementor-icon-list-items .elementor-inline-item a")));
                IWebElement emailAddress = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".elementor-icon-list-items .elementor-inline-item:nth-child(2) a")));

                Assert.Equal("866-535-4242", phoneNumber.Text);
                Assert.Equal("info@hchb.com", emailAddress.Text);

                // Step 6: Click on the ‘Request Demo’ button
                IWebElement requestDemoButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//a[text()='Request a Demo']")));
                requestDemoButton.Click();

                // Step 7: Verify that the app navigates to https://hchb.com/request-demo/ page
                Assert.Equal("https://hchb.com/request-demo/", driver.Url);

                // Step 8: Fill in all the mandatory fields but two (First and Last name, Email etc).

                IWebElement iframeElement = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("iframe.pardotform")));
                driver.SwitchTo().Frame(iframeElement);
                IWebElement firstNameField = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.first_name input")));
                IWebElement lastNameField = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.last_name input")));
                IWebElement emailField = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.email input")));
                IWebElement phoneField = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.phone input")));
                IWebElement roleDropdown = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.Role select")));
                IWebElement companyField = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.company input")));
                IWebElement cityField = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.city input")));
                IWebElement stateDropdown = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.state select")));
                IWebElement censusDropdown = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.Census select")));
                IWebElement servicesHomeHealth = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.Services_Provided_By_Your_Agency input[name*='2893875']")));
                IWebElement servicesHospice = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.Services_Provided_By_Your_Agency input[name*='2893878']")));
                IWebElement servicesInpatientUnit = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.Services_Provided_By_Your_Agency input[name*='2893881']")));
                IWebElement servicesPrivateDuty = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.Services_Provided_By_Your_Agency input[name*='2893884']")));
                IWebElement servicesPalliativeCare = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.Services_Provided_By_Your_Agency input[name*='2893887']")));
                IWebElement servicesPersonalCare = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.Services_Provided_By_Your_Agency input[name*='2893890']")));
                IWebElement servicesSkilledNursing = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.Services_Provided_By_Your_Agency input[name*='2893893']")));
                IWebElement servicesBehavioralHealth = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.Services_Provided_By_Your_Agency input[name*='2893896']")));
                IWebElement servicesPediatrics = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.Services_Provided_By_Your_Agency input[name*='2893899']")));
                IWebElement submitButton = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("input[type='submit']")));

                // Fill in the fields with sample data
                firstNameField.SendKeys("John");
                phoneField.SendKeys("1234567890");
                SelectElement roleDropdownSelect = new SelectElement(roleDropdown);
                roleDropdownSelect.SelectByText("Executive");
                companyField.SendKeys("ABC Company");
                cityField.SendKeys("New York");
                SelectElement stateDropdownSelect = new SelectElement(stateDropdown);
                stateDropdownSelect.SelectByText("NY");
                SelectElement censusDropdownSelect = new SelectElement(censusDropdown);
                censusDropdownSelect.SelectByText("0 - 500");

                // Step 9: Click Submit button
                submitButton.Click();

                // Step 10: Verify that following validation errors are displayed on the page:
                // a. Please correct the errors below: header is displayed on top. 
                // b. This field is required error displayed next to Services offered field. 
                // c. Invalid CAPTCHA error displayed next to Captcha element.

                IWebElement errorHeader = wait.Until(ExpectedConditions.ElementExists(By.CssSelector("p.errors")));
                Assert.Equal("Please correct the errors below:", errorHeader.Text);

                // Specific selector for Services Offered error
                IWebElement servicesError = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='pardot-form']/p[14]")));
                Assert.Equal("This field is required", servicesError.Text);

                // Specific selector for Captcha error
                IWebElement captchaError = wait.Until(ExpectedConditions.ElementExists(By.XPath("//*[@id='pardot-form']/p[17]")));
                Assert.Equal("Invalid CAPTCHA", captchaError.Text);

                // Switch back to the default content
                driver.SwitchTo().DefaultContent();


            }
            catch (Exception ex)
            {
                Assert.Fail("Test failed: " + ex.Message);
            }
        }
    }
}
