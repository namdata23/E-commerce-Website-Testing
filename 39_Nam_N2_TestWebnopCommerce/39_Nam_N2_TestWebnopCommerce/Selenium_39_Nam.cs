using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Threading;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;


namespace _39_Nam_N2_TestWebnopCommerce
{
    [TestClass]
    public class Selenium_39_Nam
    { 
        
        public IWebDriver dr_39_Nam;
        //Cai dat bien cuc bo
        public void SetUp()
        {
            //  STT:39 - Nguyễn Hoàng Nam
            dr_39_Nam = new ChromeDriver();
            dr_39_Nam.Navigate().GoToUrl("https://demo.nopcommerce.com/");
            Thread.Sleep(3000);
        }

       // [TestMethod]
        // Dang nhap
        public void DangNhap_39_Nam()
        {
            //  STT:39 - Nguyễn Hoàng Nam
            SetUp();
            // Click vào Log in trên trang chủ STT:39 - Nguyễn Hoàng Nam
            dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[1]/div[1]/div[2]/div[1]/ul/li[2]/a")).Click();
            Thread.Sleep(2000);
            // Điền lần lượt mail với pass đã đăng ký
            dr_39_Nam.FindElement(By.Id("Email")).SendKeys("nam@gmail.com");
            dr_39_Nam.FindElement(By.Id("Password")).SendKeys("123456");

            //Nhan nut dang nhap
            dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[3]/div/div/div/div[2]/div[1]/div[2]/form/div[3]/button")).Click();
            Thread.Sleep(2000);
            dr_39_Nam.Quit();
        }
        



        [TestMethod]
        //Dang ky
        public void DangKyTaiKhoan_39_Nam()
        {

            //  STT:39 - Nguyễn Hoàng Nam
            SetUp();
            // bấm register trên trang chủ 
            dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[1]/div[1]/div[2]/div[1]/ul/li[1]/a")).Click();
          

            //check gioi tinh
            dr_39_Nam.FindElement(By.Id("gender-male")).Click();
            Thread.Sleep(2000);

            //nhap firstname
            dr_39_Nam.FindElement(By.Id("FirstName")).SendKeys("nam");

            Thread.Sleep(2000);
            //nhap lastname
            dr_39_Nam.FindElement(By.Id("LastName")).SendKeys("nguyen");
            Thread.Sleep(2000);

            //chọn ngay sinh (day of birth)
            IWebElement _day = dr_39_Nam.FindElement(By.Name("DateOfBirthDay"));
            _day.Click();
            // lay du lieu dau tien khi thanh đổ xuống 
            _day.SendKeys(Keys.ArrowDown);
            _day.SendKeys(Keys.Enter);

            //chon thang (day of birth)
            IWebElement _month = dr_39_Nam.FindElement(By.Name("DateOfBirthMonth"));
            _month.Click();
            _month.SendKeys(Keys.ArrowDown);
            _month.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            //chon năm (day of birth)
            IWebElement _year = dr_39_Nam.FindElement(By.Name("DateOfBirthYear"));
            _year.Click();
            _year.SendKeys(Keys.ArrowDown);
            _year.SendKeys(Keys.Enter);
            Thread.Sleep(2000);
            //  STT:39 - Nguyễn Hoàng Nam
            //nhap email
            dr_39_Nam.FindElement(By.Id("Email")).SendKeys("namth@gmail.com");
            Thread.Sleep(2000);

            //nhap company 
            dr_39_Nam.FindElement(By.Id("Company")).SendKeys("ou");
            Thread.Sleep(2000);

            //Nhap password va confirmpassword
            dr_39_Nam.FindElement(By.Name("Password")).SendKeys("123456");
            Thread.Sleep(2000);

            dr_39_Nam.FindElement(By.CssSelector("#ConfirmPassword")).SendKeys("123456");
            Thread.Sleep(2000);

            // nhấn button register sau cùng để thuc hien dang ky
            dr_39_Nam.FindElement(By.Name("register-button")).Click();
            Thread.Sleep(3000);
            dr_39_Nam.Quit();
        }






        // Add 1Wishlist
        [TestMethod]
        public void Them1WishList_39_Nam()
        {
           SetUp();
            //nhan vao thanh search va tra cuu  STT:39 - Nguyễn Hoàng Nam
            IWebElement searching = dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[1]/div[2]/div[2]/form/input"));
            searching.SendKeys("desktops");
           
            //hành động là nhấn phím "Enter", tương ứng với việc nhấn Enter trên bàn phím để thực hiện tìm kiếm  STT:39 - Nguyễn Hoàng Nam
            new Actions(dr_39_Nam).KeyDown(Keys.Enter).Build().Perform();
            Thread.Sleep(2000);

            // click vào mục sản phẩm để xem chi tiết  STT:39 - Nguyễn Hoàng Nam
            dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[3]/div/div[2]/div/div[2]/div[3]/div/div[2]/div/div/div[2]/div")).Click();

            Thread.Sleep(3000);
            // phần add to wishlist trong trang xem sp STT:39 - Nguyễn Hoàng Nam
            IWebElement giohang = dr_39_Nam.FindElement(By.CssSelector("#add-to-wishlist-button-2"));
            giohang.Click();
            Thread.Sleep(2000);
           dr_39_Nam.Quit();
        }

    }
}
              