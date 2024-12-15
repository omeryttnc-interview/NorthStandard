Feature: Check Page Title2


Scenario: Verify the page title of Selenium.dev2
	Given I have set the driver
	When I navigate to the page url "https://www.selenium.dev/"
	Then the page title should be "Selenium"

	@firefox
Scenario: Verify the page title of Selenium.dev with Firefox2
	Given I have set the driver
	When I navigate to the page url "https://www.selenium.dev/"
	Then the page title should be "Selenium"

	@pixel
Scenario: Verify the page title of Selenium.dev with Pixel2
	Given I have set the driver
	When I navigate to the page url "https://www.selenium.dev/"
	Then the page title should be "Selenium"

	@iphone
Scenario: Verify the page title of Selenium.dev with iPhone2
	Given I have set the driver
	When I navigate to the page url "https://www.selenium.dev/"
	Then the page title should be "Selenium"

	@galaxy
Scenario: Verify the page title of Selenium.dev with galaxy2
	Given I have set the driver
	When I navigate to the page url "https://www.selenium.dev/"
	Then the page title should be "Selenium"



