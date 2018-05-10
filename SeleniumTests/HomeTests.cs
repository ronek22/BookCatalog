using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestClass]
    public class HomeTests
    {
        [TestMethod]
        public void HomePageHasCorrectTitle()
        {
            // Arange
            var driver = new InternetExplorerDriver();
            var url = "https://localhost:44342/";

            // Act
            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);
                Assert.AreEqual("Home Page - BookCatalog", driver.Title);
                //var tableTitle
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void NotLoggedInRedirectToLoginPageAfterClickOnAuthorsLink()
        {
            // Arange
            var driver = new InternetExplorerDriver();
            var url = "https://localhost:44342/";

            // Act
            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);
                var authorField = driver.FindElement(By.Id("AuthorsLink"));
                authorField.Click();
                Assert.AreEqual("Log in - BookCatalog", driver.Title);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void NotLoggedInRedirectToLoginPageAfterClickOnAuthorsButton()
        {
            // Arange
            var driver = new InternetExplorerDriver();
            var url = "https://localhost:44342/";

            // Act
            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);
                var authorField = driver.FindElement(By.Id("AuthorsButton"));
                authorField.Click();
                Assert.AreEqual("Log in - BookCatalog", driver.Title);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void NotLoggedInRedirectToLoginPageAfterClickOnBooksLink()
        {
            // Arange
            var driver = new InternetExplorerDriver();
            var url = "https://localhost:44342/";

            // Act
            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);
                var authorField = driver.FindElement(By.Id("BooksLink"));
                authorField.Click();
                Assert.AreEqual("Log in - BookCatalog", driver.Title);
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void NotLoggedInRedirectToLoginPageAfterClickOnAboutButton()
        {
            // Arange
            var driver = new InternetExplorerDriver();
            var url = "https://localhost:44342/";

            // Act
            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);
                var authorField = driver.FindElement(By.Id("AboutButton"));
                authorField.Click();
                Assert.IsTrue(driver.Url.Contains("About"));
            }
            catch (Exception e)
            {
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void UserName_IsVisible_InNavbar_AfterLogin()
        {
            // Arrange
            var driver = new InternetExplorerDriver();
            var url = "https://localhost:44342/account/login";

            // Act
            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);
                var emailField = driver.FindElement(By.Id("Email"));
                emailField.Click();
                emailField.SendKeys("admin@admin.com");

                var passwordField = driver.FindElement(By.Id("Password"));
                passwordField.Click();
                passwordField.SendKeys("admin1");

                var submitButton = driver.FindElement(By.Id("LoginButton"));
                submitButton.SendKeys("\n");

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.Until(UrlToBe("https://localhost:44342/"));
            
                var userGreet = driver.FindElement(By.Id("UserName")).Text;

                // Assert
                StringAssert.Contains(userGreet, "admin@admin.com");
            }
            catch (Exception e)
            {
                // Assert
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void EmailError_Appears_WhenUserTriesToRegister_WithInvalidEmail()
        {
            // Arrange
            var driver = new InternetExplorerDriver();
            var url = "https://localhost:44342/account/register";

            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);

                // Act
                var emailField = driver.FindElement(By.Id("Email"));
                emailField.Click();
                emailField.SendKeys("wrong email");

                var passwordField = driver.FindElement(By.Id("Password"));
                passwordField.Click();
                passwordField.SendKeys("password");

                var confirmField = driver.FindElement(By.Id("ConfirmPassword"));
                confirmField.Click();
                confirmField.SendKeys("password");

                var submitButton = driver.FindElement(By.Id("RegisterButton"));
                submitButton.Click();

                var emailError = driver.FindElement(By.Id("Email-error")).Text;

                // Assert
                StringAssert.Contains(emailError, "not a valid e-mail address");
            }
            catch (Exception e)
            {
                // Assert
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }

        [TestMethod]
        public void FirstNameErrorAppearsWhenModeratorTryToAddInvalidAuthor()
        {
            // Arrange
            var driver = new InternetExplorerDriver();
            var url = "https://localhost:44342/account/login";

            try
            {
                var nav = driver.Navigate();
                nav.GoToUrl(url);
                var emailField = driver.FindElement(By.Id("Email"));
                emailField.Click();
                emailField.SendKeys("mod@mod.com");

                var passwordField = driver.FindElement(By.Id("Password"));
                passwordField.Click();
                passwordField.SendKeys("moderator1");

                var submitButton = driver.FindElement(By.Id("LoginButton"));
                submitButton.SendKeys("\n");

                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
                wait.Until(UrlToBe("https://localhost:44342/"));

                driver.FindElement(By.Id("AuthorsLink")).Click();
                driver.FindElement(By.Id("CreateAuthor")).Click();

                var firstNameField = driver.FindElement(By.Id("FirstName"));
                firstNameField.Click();
                firstNameField.SendKeys("a");

                var lastNameField = driver.FindElement(By.Id("LastName"));
                lastNameField.Click();
                lastNameField.SendKeys("Kupiec");

                var createButton = driver.FindElement(By.Id("CreateButton"));
                createButton.SendKeys("\n");

                var creationError = driver.FindElement(By.Id("FirstName-error")).Text;

                StringAssert.Contains(creationError, "The field First Name must be a string with a minimum length of 2 and a maximum length of 20.");
                
            }
            catch (Exception e)
            {
                // Assert
                Assert.Fail(e.Message);
            }
            finally
            {
                driver.Quit();
            }
        }


        public static Func<IWebDriver, bool> UrlToBe(string url)
        {
            return (driver) => { return driver.Url.ToLowerInvariant().Equals(url.ToLowerInvariant()); };
        }
    }
}
