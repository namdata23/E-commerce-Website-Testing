using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Interactions;

namespace test
{
    public partial class Selenium_39_Nam : Form
    {
        public Selenium_39_Nam()
        {
            InitializeComponent();
        }

        public void DangKyTaiKhoan_39_Nam()
        {
            ChromeDriverService ch_39_Nam = ChromeDriverService.CreateDefaultService();
            ch_39_Nam.HideCommandPromptWindow = true;
            IWebDriver dr_39_Nam = new ChromeDriver(ch_39_Nam);

            dr_39_Nam.Navigate().GoToUrl("https://demo.nopcommerce.com/");
            Thread.Sleep(2000);

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
            _day.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
            _day.SendKeys(OpenQA.Selenium.Keys.Enter);

            //chon thang (day of birth)
            IWebElement _month = dr_39_Nam.FindElement(By.Name("DateOfBirthMonth"));
            _month.Click();
            _month.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
            _month.SendKeys(OpenQA.Selenium.Keys.Enter);
            Thread.Sleep(2000);
            //chon năm (day of birth)
            IWebElement _year = dr_39_Nam.FindElement(By.Name("DateOfBirthYear"));
            _year.Click();
            _year.SendKeys(OpenQA.Selenium.Keys.ArrowDown);
            _year.SendKeys(OpenQA.Selenium.Keys.Enter);
            Thread.Sleep(2000);
            //  STT:39 - Nguyễn Hoàng Nam
            //nhap email
            dr_39_Nam.FindElement(By.Id("Email")).SendKeys("namth@gmail.com");
            Thread.Sleep(2000);

            //nhap company 
            dr_39_Nam.FindElement(By.Id("Company")).SendKeys("ou");
            Thread.Sleep(2000);

            //Nhap password va confirmpassword
            dr_39_Nam.FindElement(By.Id("Password")).SendKeys("123456");
            Thread.Sleep(2000);

            dr_39_Nam.FindElement(By.Id("ConfirmPassword")).SendKeys("123456");
            Thread.Sleep(2000);

            // nhấn button register sau cùng để thuc hien dang ky
            dr_39_Nam.FindElement(By.Name("register-button")).Click();
            Thread.Sleep(3000);
            dr_39_Nam.Quit();
        }

        private void btnDKy_39_Nam_Click(object sender, EventArgs e)
        {
            DangKyTaiKhoan_39_Nam();
        }




        public void Them1WishList_39_Nam()
        {
            ChromeDriverService ch_39_Nam = ChromeDriverService.CreateDefaultService();
            ch_39_Nam.HideCommandPromptWindow = true;
            IWebDriver dr_39_Nam = new ChromeDriver(ch_39_Nam);

            dr_39_Nam.Navigate().GoToUrl("https://demo.nopcommerce.com/");
            Thread.Sleep(2000);

            //nhan vao thanh search va tra cuu  STT:39 - Nguyễn Hoàng Nam
            IWebElement searching = dr_39_Nam.FindElement(By.Id("small-searchterms"));
            searching.SendKeys("desktops");

            //hành động là nhấn phím "Enter", tương ứng với việc nhấn Enter trên bàn phím để thực hiện tìm kiếm  STT:39 - Nguyễn Hoàng Nam
            new Actions(dr_39_Nam).KeyDown(OpenQA.Selenium.Keys.Enter).Build().Perform();
            Thread.Sleep(3000);

            // click vào mục sản phẩm để xem chi tiết  STT:39 - Nguyễn Hoàng Nam
            dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[3]/div/div[2]/div/div[2]/div[3]/div/div[2]/div/div/div[2]/div")).Click();

            Thread.Sleep(2000);
            // phần add to wishlist trong trang xem sp STT:39 - Nguyễn Hoàng Nam
            IWebElement giohang = dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[3]/div/div[2]/div/div/form/div[2]/div[1]/div[2]/div[8]/div[1]/button"));
            giohang.Click();
            Thread.Sleep(2000);
            dr_39_Nam.Quit();
        }
        private void btnAdd1SP_Click(object sender, EventArgs e)
        {
            Them1WishList_39_Nam(); 
        }
    }
}
