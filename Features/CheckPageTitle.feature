Feature: Check Page Title


Scenario: 1 Verify the page title of Selenium.dev
	Given I have set the driver
	When I navigate to the page url "https://www.selenium.dev/"
	Then the page title should be "Selenium"


@firefox
Scenario: 2 Verify the page title of Selenium.dev with Pixel
	Given I have set the driver
	When I navigate to the page url "https://www.selenium.dev/"
	Then the page title should be "Selenium"

@iphone
Scenario: 3 Verify the page title of Selenium.dev with iPhone
	Given I have set the driver
	When I navigate to the page url "https://www.selenium.dev/"
	Then the page title should be "Selenium"




