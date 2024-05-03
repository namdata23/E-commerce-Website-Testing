using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Data;
using System.Runtime.Remoting;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using System.Windows.Forms;

namespace _39_Nam_N2_TestWebnopCommerce
{
    [TestClass]
    public class _39_Nam_Login
    {
        public TestContext TestContext { get; set; }
        public Selenium_39_Nam sele = new Selenium_39_Nam();


        public void DangNhap_39_Nam(string email, string password)
        {
            // Gọi phương thức bên Selenium_39_Nam để mở trang web STT:39 - Nguyễn Hoàng Nam
            sele.SetUp();
            // Click vào Log in trên trang chủ STT:39 - Nguyễn Hoàng Nam
            sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[1]/div[1]/div[2]/div[1]/ul/li[2]/a")).Click();
            Thread.Sleep(2000);
            // Điền lần lượt mail với pass đã đăng ký
            sele.dr_39_Nam.FindElement(By.Id("Email")).SendKeys(email);
            sele.dr_39_Nam.FindElement(By.Id("Password")).SendKeys(password);

            //Nhan nut dang nhap
            sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[3]/div/div/div/div[2]/div[1]/div[2]/form/div[3]/button")).Click();
            Thread.Sleep(2000);

        }

        // Nunit
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\TestDataLogin\TestLoginThanhCong_39_Nam.csv",
            "TestLoginThanhCong_39_Nam#csv", DataAccessMethod.Sequential)]

        [TestMethod]
        public void DangNhapThanhCong_39_Nam() // Testcase 1
        {
            // STT: 39_Nguyễn Hoàng Nam
            var user = TestContext.DataRow[0].ToString();
            var pass = TestContext.DataRow[1].ToString();
            // DangNhap STT:39 - Nguyễn Hoàng Nam
            DangNhap_39_Nam(user, pass);
            Assert.AreEqual("https://demo.nopcommerce.com/", sele.dr_39_Nam.Url, "Dang nhap khong thanh cong");
            sele.dr_39_Nam.Quit();
        }


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\TestDataLogin\TestLoginEmailSai_39_Nam.csv",
           "TestLoginEmailSai_39_Nam#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void DangNhapSaiEmail_39_Nam() //Test case 2
        {
            // STT: 39_Nguyễn Hoàng Nam
            var emailKhongHopLe = TestContext.DataRow[0].ToString();
            var matkhauHopLe = TestContext.DataRow[1].ToString();
            // Dang nhp sai trường email 
            DangNhap_39_Nam(emailKhongHopLe, matkhauHopLe);
            Thread.Sleep(3000);
            IWebElement errorMessageElement = sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[3]/div/div/div/div[2]/div[1]/div[2]/form/div[2]/div[1]/span/span"));
            string actualErrorMessage = errorMessageElement.Text.Trim();
            if (actualErrorMessage.Contains("Please enter a valid email address."))
            {
                Assert.IsTrue(actualErrorMessage.Contains("Please enter a valid email address."),
                    "Thông báo lỗi không chính xác khi nhập tài khoản không hợp lệ");
            }
            else if (actualErrorMessage.Contains("The credentials provided are incorrect"))
            {
                      
                Assert.Fail("Đã nhận thông báo lỗi sai liên quan đến mật khẩu trong khi lỗi nằm ở tài khoản");
            }

            sele.dr_39_Nam.Quit();

        }



        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\TestDataLogin\TestLogInPassSai_39_Nam.csv",
           "TestLogInPassSai_39_Nam#csv", DataAccessMethod.Sequential)]
      //  [TestMethod]
        public void DangNhapSaiPass_39_Nam() // Test case 3
        {
            // STT: 39_Nguyễn Hoàng Nam

            string emailHopLe = TestContext.DataRow[0].ToString();
            string matKhauKhongHopLe = TestContext.DataRow[1].ToString();


            // Thử đăng nhập với password không hợp lệ STT:39 - Nguyễn Hoàng Nam
            DangNhap_39_Nam(emailHopLe, matKhauKhongHopLe);
            // Thông báo lỗi mật khẩu
            Thread.Sleep(3000);
            IWebElement errorMessageElement = sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[3]/div/div/div/div[2]/div[1]/div[2]/form/div[1]"));
            string actualErrorMessage = errorMessageElement.Text.Trim();


            if (actualErrorMessage.Contains("Login was unsuccessful. Please correct the errors and try again.The credentials provided are incorrect"))
            {
                Assert.IsTrue(actualErrorMessage.Contains("Login was unsuccessful. Please correct the errors and try again.The credentials provided are incorrect"),
                    "Thông báo lỗi không chính xác khi nhập mật khẩu không hợp lệ");
            }
            else if (actualErrorMessage.Contains("No customer account found"))
            {
                
                Assert.Fail("Đã nhận thông báo lỗi sai liên quan đến email trong khi lỗi nằm ở mật khẩu");
            }
            sele.dr_39_Nam.Quit();

        }

      

        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\TestDataLogin\TestLogInEmailvsPassSai_39_Nam.csv",
          "TestLogInEmailvsPassSai_39_Nam#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void DangNhapSaiEmailvaPass_39_Nam() //Test case 4
        {
            // STT: 39_Nguyễn Hoàng Nam
            var emailKhongHopLe = TestContext.DataRow[0].ToString();
            var matkhauKhongHopLe = TestContext.DataRow[1].ToString();
            // Dang nhp sai tk gồm : email vs pass
            DangNhap_39_Nam(emailKhongHopLe, matkhauKhongHopLe);
            Thread.Sleep(3000);
            IWebElement errorMessageElement = sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[3]/div/div/div/div[2]/div[1]/div[2]/form/div[1]"));
            string actualErrorMessage = errorMessageElement.Text.Trim();
            if (actualErrorMessage.Contains("Login was unsuccessful. Please correct the errors and try again.No customer account found"))
            {
                Assert.IsTrue(actualErrorMessage.Contains("Login was unsuccessful. Please correct the errors and try again.No customer account found"),
                    "Thông báo lỗi không chính xác khi nhập tài khoản không hợp lệ");
            }
            else if (actualErrorMessage.Contains("The credentials provided are incorrect"))
            {

                Assert.Fail("Đã nhận thông báo lỗi sai liên quan đến mật khẩu trong khi lỗi nằm ở tài khoản");
            }


          sele.dr_39_Nam.Quit();

        }




    }

}

