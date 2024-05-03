using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using System;
using System.Threading;
using System.Runtime.Remoting.Channels;

namespace _39_Nam_N2_TestWebnopCommerce
{
    [TestClass]
    public class _39_Nam_WishList
    {
        public TestContext TestContext { get; set; }
        public Selenium_39_Nam sele = new Selenium_39_Nam();  


        
        public void _39_Nam_AddWishList(string SearchKey) 
        {

            //nhan vao thanh search va tra cuu  STT:39 - Nguyễn Hoàng Nam
            IWebElement searching = sele.dr_39_Nam.FindElement(By.Id("small-searchterms"));
            searching.SendKeys(SearchKey);
            Thread.Sleep(2000);
            //hành động là nhấn phím "Enter", tương ứng với việc nhấn Enter trên bàn phím để thực hiện tìm kiếm  STT:39 - Nguyễn Hoàng Nam
            new Actions(sele.dr_39_Nam).KeyDown(Keys.Enter).Build().Perform();
            Thread.Sleep(3000);

            // click vào mục sản phẩm để xem chi tiết  STT:39 - Nguyễn Hoàng Nam
            sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[3]/div/div[2]/div/div[2]/div[3]/div/div[2]/div/div/div[1]/div")).Click();

            Thread.Sleep(2000);
            // phần add to wishlist trong trang xem sp STT:39 - Nguyễn Hoàng Nam
            IWebElement dsach = sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[3]/div/div[2]/div/div/form/div/div[1]/div[2]/div[8]/div[1]/button"));
            dsach.Click();
            Thread.Sleep(2000);

        }


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\TestDataWishList\ThemSPThanhCong_39_Nam.csv",
           "ThemSPThanhCong_39_Nam#csv", DataAccessMethod.Sequential)]
        [TestMethod]
        public void ThemSPThanhCong_39_Nam() // Test case 1
        {

            // ThemSp STT:39 - Nguyễn Hoàng Nam
            sele.SetUp();
            var sp = TestContext.DataRow[0].ToString();
            _39_Nam_AddWishList(sp);
            Thread.Sleep(2000);
            // Thông báo add thành công màu xanh  trên trang
            IWebElement dsachResult = sele.dr_39_Nam.FindElement(By.XPath("//*[@id=\"bar-notification\"]/div/p"));
            Assert.AreEqual("The product has been added to your wishlist", dsachResult.Text, "Add to cart failed");
            sele.dr_39_Nam.Quit();
        }


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\TestDataWishList\Xoa1SP_ChiCo_1SpTrongDanhSach_39_Nam.csv",
           "Xoa1SP_ChiCo_1SpTrongDanhSach_39_Nam#csv", DataAccessMethod.Sequential)]

        [TestMethod]
        public void Xoa1SP_ChiCo_1SpTrongDS_39_Nam() // Test case 2
        {
            // STT:39 - Nguyễn Hoàng Nam
             sele.SetUp();
            var sp1 = TestContext.DataRow[0].ToString();
            _39_Nam_AddWishList(sp1);
            Thread.Sleep(2000);
            //Click vao nut wishlist STT:39 - Nguyễn Hoàng Nam
                sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[1]/div[1]/div[2]/div[1]/ul/li[3]/a")).Click();

            //Click button nut xoa của sp đó STT:39 - Nguyễn Hoàng Nam
            Thread.Sleep(2000);
            sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[3]/div/div/div/div[2]/div[1]/form/div[1]/table/tbody/tr/td[8]/button")).Click();
            // sau khi xóa thì trong cart sẽ thong báo giỏ hàng đang trống
            IWebElement noDataElement = sele.dr_39_Nam.FindElement(By.CssSelector("body > div.master-wrapper-page > div.master-wrapper-content > div > div > div > div.page-body > div"));
            Assert.AreEqual("The wishlist is empty!", noDataElement.Text, "Remove a failed product");
           
            sele.dr_39_Nam.Quit();
        }
       


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\TestDataWishList\Xoa1SP_CoNhieuSpTrongDS_39_Nam.csv",
          "Xoa1SP_CoNhieuSpTrongDS_39_Nam#csv", DataAccessMethod.Sequential)]

        [TestMethod]
        public void Xoa1SP_CoNhieuSpTrongDS_39_Nam() //Test case 3
        {
            // STT:39 - Nguyễn Hoàng Nam
            sele.SetUp();
            string sp1 = TestContext.DataRow[0].ToString();
            string sp2 = TestContext.DataRow[1].ToString();
            string sp3 = TestContext.DataRow[2].ToString();   

            _39_Nam_AddWishList(sp1);
            // click vào chữ wishlist trên thanh thông báo thành công màu xanh  STT:39 - Nguyễn Hoàng Nam
            sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[5]/div/p/a")).Click();
            _39_Nam_AddWishList(sp2);
            sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[5]/div/p/a")).Click();
            _39_Nam_AddWishList(sp3);
            sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[5]/div/p/a")).Click();



            // Lấy Xpath của thanh số lượng  so sánh nếu xóa sp thì số lượng cũng thay đổi theo  STT:39 - Nguyễn Hoàng Nam

            IWebElement soLuongDSTruocKhiXoa = sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[1]/div[1]/div[2]/div[1]/ul/li[3]/a/span[2]"));
            string slTruocKhiXoa = soLuongDSTruocKhiXoa.Text.ToString();
            Thread.Sleep(3000);

            // lấy nút button xóa ( x ) của phone để xóa sp STT:39 - Nguyễn Hoàng Nam
            sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[3]/div/div/div/div[2]/div[1]/form/div[1]/table/tbody/tr[2]/td[8]/button")).Click();
            Thread.Sleep(3000);

            // Xóa xong bấm vào nút updatecart để cập nhật lại giá tiền STT:39 - Nguyễn Hoàng Nam
            sele.dr_39_Nam.FindElement(By.Id("updatecart")).Click();
            Thread.Sleep(2000);

            // Lấy Xpath của thanh số lượng  so sánh lại số lượng trong danh sách STT:39 - Nguyễn Hoàng Nam
            IWebElement soLuongDSsauKhiXoa = sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[6]/div[1]/div[1]/div[2]/div[1]/ul/li[3]/a/span[2]"));
            string slSauKhiXoa = soLuongDSsauKhiXoa.Text.ToString();
            Thread.Sleep(3000);
            Assert.AreNotEqual(slTruocKhiXoa, slSauKhiXoa, "Xoá danh sách không thành công");


            sele.dr_39_Nam.Quit();
        }


        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\TestDataWishList\ThemSPThatbai_39_Nam.csv",
         "ThemSPThatbai_39_Nam#csv", DataAccessMethod.Sequential)]

        [TestMethod]
        public void ThemSPThatbai_39_Nam() // Test case 4
        {
            // STT:39 - Nguyễn Hoàng Nam
            sele.SetUp();
            string failadd = TestContext.DataRow[0].ToString();
            _39_Nam_AddWishList(failadd);
            // Thông báo add thất bại màu đỏ bên trang 
            IWebElement dsachResult = sele.dr_39_Nam.FindElement(By.XPath("/html/body/div[5]/div"));
            Assert.AreEqual("Enter valid recipient name\r\nEnter valid recipient email\r\nEnter valid sender name\r\nEnter valid sender email", dsachResult.Text, "Add to cart failed");
            sele.dr_39_Nam.Quit();

        }



        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV", @".\TestDataWishList\TimSPThaiBai_39_Nam.csv",
         "TimSPThaiBai_39_Nam#csv", DataAccessMethod.Sequential)]

        [TestMethod]
        public void TimSPThaiBai_39_Nam()  //Test case 5
        {
            // STT:39 - Nguyễn Hoàng Nam

            sele.SetUp();
            string failsearch = TestContext.DataRow[0].ToString();
            IWebElement searching = sele.dr_39_Nam.FindElement(By.Id("small-searchterms"));
            searching.SendKeys(failsearch);
            Thread.Sleep(2000);
            //hành động là nhấn phím "Enter", tương ứng với việc nhấn Enter trên bàn phím để thực hiện tìm kiếm  STT:39 - Nguyễn Hoàng Nam
            new Actions(sele.dr_39_Nam).KeyDown(Keys.Enter).Build().Perform();
            Thread.Sleep(3000);
         

            // Thông báo tìm thât bại
            IWebElement notfoundsp = sele.dr_39_Nam.FindElement(By.CssSelector("body > div.master-wrapper-page > div.master-wrapper-content > div > div.center-2 " +
                                                                            "> div > div.page-body > div.search-results > div > div.products-wrapper > div"));
            Assert.AreEqual("No products were found that matched your criteria.", notfoundsp.Text, "Search to product not found");
            sele.dr_39_Nam.Quit();

        }


    }
   

}

