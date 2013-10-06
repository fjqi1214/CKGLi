using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using Model;
using DAL;
using System.Data.Entity;
using CKGL;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace UnitTest
{

    class Program
    {
        static string testFile = @".\test.txt";
        static CKGLContext context = new CKGLContext();
        static void Main(string[] args)
        {
            TestSplitPager();
            TestSplitePageQuery();

            TestHandleError();

            TestSqlHelp();
            //DataGridViewValidateLogic();
            Console.ReadKey();

        }

        private static void TestSplitePageQuery()
        {
             Console.WriteLine("测试SplitePageQuery<T, Key>类 -----------------------------------");
            SplitePageQuery<StorageLocation, string> query = new SplitePageQuery<StorageLocation, string>();
            query.Pagingquery = new Dictionary<Type, object>();
            query.Pagingquery.Add(typeof(StorageLocation), new StorageLocationCollection());
            query.Pager = new SplitPager(1, new StorageLocationCollection().Count());
            if (query.Pager.TotalPageCount == new StorageLocationCollection().Count() - 1)
            {
                Console.WriteLine("页数数量---------------------------------正确！");
            }
            else
            {
                Console.WriteLine("页数数量---------------------------------失败！");
            }
         

            query.MoveToPage(i => i.LocationName, query.Pager.TotalPageCount, null);
            query.MoveNextPage(i => i.LocationName, null);
            if (query.Pager.CurrentPageNum == query.Pager.TotalPageCount)
            {
                Console.WriteLine("跳转指定页------------------------------------正确！");
            }
            else
            {
                Console.WriteLine("跳转指定页------------------------------------失败！");
            }


            var currentPageNum = query.Pager.CurrentPageNum;
            query.MovePreviousPage(i => i.LocationName, null);
            int diff = query.Pager.CurrentPageNum - currentPageNum;
            if (diff == -1)
            {
                Console.WriteLine("上一页功能-----------------------------------正确！");
            }
            else
            {
                Console.WriteLine("上一页功能-----------------------------------正确！");
            }

            currentPageNum = query.Pager.CurrentPageNum;
            query.MoveNextPage(i => i.LocationName, null);
            diff = query.Pager.CurrentPageNum - currentPageNum;
            if (diff == 1)
            {
                Console.WriteLine("下一页功能-----------------------------------正确！");

            }
            else
            {
                Console.WriteLine("下一页功能-----------------------------------错误！");
            }

            query.MoveFirstPage(i => i.LocationName,null);
            query.MovePreviousPage(i => i.LocationName, null);
            if (query.Pager.CurrentPageNum == 0)
            {
                Console.WriteLine("首页功能-----------------------------------正确！");
            }
            else
            {
                Console.WriteLine("首页功能-----------------------------------错误！");
            }

            query.MoveLastPage(i => i.LocationName, null);
            query.MoveNextPage(i => i.LocationName, null);
            if (query.Pager.CurrentPageNum == query.Pager.TotalPageCount)
            {
                Console.WriteLine("尾页功能-----------------------------------正确！");
            }
            else
            {
                Console.WriteLine("尾页功能-----------------------------------错误！");
            }
           

        }

        private static void TestSplitPager()
        {
            Console.WriteLine("开始测试SplitPager类----------------------------------------------");

            StorageLocationCollection testList = new StorageLocationCollection();

            var pager = new SplitPager(7, 0);
            var num6 = pager.CurrentPageNum;
            var num7 = pager.TotalPageCount;
            pager.MoveToPage(10);

            pager.MoveNextPage();
            pager.MoveNextPage();
            pager.MovePreviousPage();
            if (pager.CurrentPageNum == num6 && num7 == pager.TotalPageCount)
            {
                Console.WriteLine("构造函数运行结果-----------------正确！");
            }
            else
            {
                Console.WriteLine("构造函数运行结果-----------------错误！");
            }
            pager = new SplitPager(1, testList.Count());


            var total = testList.Count();
            //到最后一页的前一页
            pager.MoveToPage(pager.TotalPageCount - 1);

            var num1 = total - (testList.GetEntities(pager.CurrentPageNum, pager.PageSize).Count() +
                pager.PageSize * pager.CurrentPageNum);

            //到最后一页
            pager.MoveToPage(pager.TotalPageCount);
            var num2 = (testList.GetEntities(pager.CurrentPageNum, pager.PageSize).Count() +
                pager.PageSize * pager.CurrentPageNum);
            var before = pager.CurrentPageNum;

            pager.MoveToPage(testList.Count() / pager.PageSize + 2);
            pager.MoveToPage(-1);
            if ((num1 == total % pager.PageSize || num1 == pager.PageSize) && num2 >= testList.Count() && before == pager.CurrentPageNum)
            {
                Console.WriteLine("MoveToPage方法运行结果-----------------正确！");
            }
            else
            {
                Console.WriteLine("MoveToPage方法运行结果-----------------错误！");
            }
            pager = new SplitPager(5, total);
            var bef = pager.CurrentPageNum;
            pager.MoveNextPage();
            pager.MoveNextPage();
            pager.MoveNextPage();
            pager.MoveNextPage();
            pager.MoveNextPage();
            var diff = pager.CurrentPageNum - bef;
            pager.MoveToPage(pager.TotalPageCount);
            int num3 = pager.CurrentPageNum;
            pager.MoveNextPage();
            pager.MoveNextPage();
            int num4 = pager.CurrentPageNum;

            if (diff == 5 && num3 == num4)
            {
                Console.WriteLine("MoveNextPage方法运行结果-----------------正确！");
            }
            else
            {
                Console.WriteLine("MoveNextPage方法运行结果-----------------错误！");
            }

            pager = new SplitPager(7, total);

            pager.MoveToPage(pager.TotalPageCount);
            var num5 = pager.CurrentPageNum;

            pager.MovePreviousPage();
            pager.MovePreviousPage();
            var diff2 = num5 - pager.CurrentPageNum;
            pager.MoveToPage(0);
            var berf = pager.CurrentPageNum;
            pager.MovePreviousPage();
            if (diff2 == 2 && berf == pager.CurrentPageNum)
            {
                Console.WriteLine("MovePreviousPage方法运行结果-----------------正确！");
            }
            else
            {
                Console.WriteLine("MovePreviousPage方法运行结果-----------------错误！");
            }

            pager = new SplitPager(5, 110);
            var num8 = pager.TotalPageCount;
            pager.MoveFirstPage(120);
            if (pager.TotalPageCount > num8 && pager.CurrentPageNum == 0)
            {
                Console.WriteLine("MoveFirstPage方法运行结果-----------------正确！");
            }
            else
            {
                Console.WriteLine("MoveFirstPage方法运行结果-----------------正确！");
            }
            pager = new SplitPager(5, 115);
            var num9 = pager.TotalPageCount;
            pager.MoveLastPage(((115 % 5) + 115 + 1));
            if (pager.TotalPageCount - num9 == 1)
            {
                Console.WriteLine("MoveLastPage方法运行结果-----------------正确！");
            }
            else
            {
                Console.WriteLine("MoveLastPage方法运行结果-----------------正确！");
            }
        }

        public static void TestHandleError()
        {
            string testFile = @".\test.txt";
            Console.WriteLine("开始测试ErrorHandle类......................");

            Product product = new Product { LocationName = "12345", CheckTime = DateTime.Now };
            ErrorHandle.HandleError(() =>
            {
                context.Products.Add(product);

                context.SaveChanges();

            }, () =>
            {
                Console.WriteLine("ErrorHandle类探测更改数据库错误-------------------------------成功");
                context = new CKGLContext();
            }
            , testFile);
            ErrorHandle.HandleError(() => { int i = Convert.ToInt32("1f"); },
                () => { Console.WriteLine("ErrorHandle类探测为未知错误------------------------------成功！"); },
               testFile);
            var errors = File.ReadLines(testFile);
            int count = errors.Count();
            if (count == 2)
            {
                Console.WriteLine("ErrorHandle类处理错误-----------------------------成功！");
            }
            else
            {
                Console.WriteLine("ErrorHandle类处理错误-----------------------------失败！");
            }

            File.Delete(testFile);
        }

        private static void TestSqlHelp()
        {
            Console.WriteLine("开始测试SqlHelp<T>类----------------------------------------------");

            List<Product> list = new List<Product>();
            ErrorHandle.HandleError(() =>
            {
                list = context.Products.OrderBy(i => i.Id).Take(10).ToList();
            }, () =>
            {
                Console.WriteLine("查询数据库时出错----------------------------------失败！");

            }, testFile);

            if (list.Count() > 0)
            {
                string name = list[0].LotNum;
                string name1 = list[1].LotNum;
                list[0].LotNum = "lot12345**56";
                list[1].LotNum = "lot12345*k6";
                SqlHelp<Product, int> help = new SqlHelp<Product, int>(context);
                int r = help.Update(list);
                if (r == 2)
                {
                    list[0].LotNum = name;
                    list[1].LotNum = name1;
                    int r2 = help.Update(list);
                    if (r2 == 2)
                    {
                        Console.WriteLine("测试Update 方法------------------------正确！");
                    }
                    else
                    {
                        Console.WriteLine("测试Update 方法------------------------错误！");
                    }

                }
                else
                {
                    Console.WriteLine("测试Update 方法------------------------错误！");
                }

            }
            else
            {
                Console.WriteLine("数据库表ProductTable没有足够的数据，请添加至少2条数据------------------------错误！");
            }

            Product product1 = new Product { LocationName = "12345", CheckTime = DateTime.Now };
            Product product2 = new Product { LocationName = "12345678", CheckTime = DateTime.Now };
            StorageLocation sl = new StorageLocation { LocationName = "A-111-111", CategoryName = "A" };
            ErrorHandle.HandleError(() =>
            {
                context.Products.Add(product1);

                context.SaveChanges();
            }, () =>
            {

            }, testFile);

            ErrorHandle.HandleError(() =>
            {
                context.StorageLocations.Add(sl);
                context.SaveChanges();
            }, () => { Console.WriteLine("测试添加错误后可以恢复Context---------------------------------"); }, testFile);

            SqlHelp<Product, int> sql = new SqlHelp<Product, int>(context);
            var errors = File.ReadLines(testFile);
            int count = errors.Count();
            if (count == 2)
            {
                Console.WriteLine("开始测试添加错误后恢复Context----------------------");
                context.Products.Remove(product1);
                context.StorageLocations.Remove(sl);
                List<Product> prods = new List<Product>();
                prods.Add(product1);
                prods.Add(product2);
                ErrorHandle.HandleError(() =>
                {
                    sql.Update(prods);

                }, () => { }, testFile);
                errors = File.ReadLines(testFile);
                count = errors.Count();
                if (count == 3)
                {
                    Console.WriteLine("错误恢复重新抛出错误----------------------成功！");
                }
                else
                {
                    Console.WriteLine("错误恢复重新抛出错误----------------------失败！");
                }

                ErrorHandle.HandleError(() =>
                {
                    List<StorageLocation> sls = new List<StorageLocation>();
                    sls.Add(new StorageLocation { LocationName = "A-12-1111", CategoryName = "A" });
                    SqlHelp<StorageLocation, string> sql2 = new SqlHelp<StorageLocation, string>(context);
                    sql2.Update(sls);
                    sql2.Delete(sls);

                }, () => { }, testFile);

                errors = File.ReadLines(testFile);
                count = errors.Count();
                if (count == 3)
                {
                    Console.WriteLine("测试添加发生错误时可以恢复Context----------------------成功！");
                }
                else
                {
                    Console.WriteLine("测试添加发生错误时可以恢复Context----------------------失败！");
                }


            }
            else
            {
                Console.WriteLine("测试添加出现错误后恢复Context----------------------失败！");
            }


            File.Delete(testFile);

        }


        //public static void DataGridViewValidateLogic()
        //{
        //    Console.WriteLine("测试DataGridView的bind操作--------------------------------------");

        //    ErrorHandle.HandleError(() =>
        //    {

        //        List<StorageLocation> locations = new List<StorageLocation>();
        //        List<Product> products = new List<Product>();
        //        List<ImportStorage> imports = new List<ImportStorage>();
        //        List<ExportStorage> exports = new List<ExportStorage>();
        //        List<CheckRecord> checks = new List<CheckRecord>();
        //        StorageLocation location = new StorageLocation();


        //        var l= context.StorageLocations.Where(i => i.LocationName == "H-1234-1234").FirstOrDefault();
        //        if (l !=null)
        //        {
        //            context.Entry<StorageLocation>(l).State = System.Data.EntityState.Deleted;
        //            context.SaveChanges();
        //        }
        //        location=new StorageLocation {LocationName = "H-1234-1234", CategoryName = "H" };
        //        context.StorageLocations.Add(location);
        //        context.SaveChanges();



        //        //Product product = new Product { CheckTime = DateTime.Now, LocationName = "H-1234-1234", Number = 11111111, ProductTime = DateTime.Now, UnitNum = 12345678 };
        //        //context.Products.Add(product);
        //        //ImportStorage import = new ImportStorage { ArrivalTime = DateTime.Now, LocationName = "H-1234-1234", Number = 12345678, ProductTime = DateTime.Now };
        //        //context.ImportStorages.Add(import);
        //        //ExportStorage export = new ExportStorage { ExpNum = 12345678, ExpTime = DateTime.Now, LocationName = "H-1234-1234", UnitNum = 1234567 };
        //        //context.ExportStorages.Add(export);
        //        //CheckRecord check = new CheckRecord { CheckTime = DateTime.Now, LocationName = "H-1234-1234", Number = 12345678 };
        //        //context.CheckRecords.Add(check);
        //        //context.SaveChanges();

        //        locations = context.StorageLocations.Where(i => i.LocationName == location.LocationName).Take(1).ToList();
        //        //products = context.Products.Where(i => i.Id == product.Id).Take(1).ToList();
        //        //imports = context.ImportStorages.Where(i => i.Id == import.Id).Take(1).ToList();
        //        //exports = context.ExportStorages.Where(i => i.Id == export.Id).Take(1).ToList();
        //        //checks = context.CheckRecords.Where(i => i.Id == check.Id).Take(1).ToList();

        //        bool r1 = true;
        //        DataGridView d = new DataGridView();

        //        d.Columns.Add(new DataGridViewColumn { DataPropertyName = "LocationName" });
        //        d.Columns.Add(new DataGridViewColumn { DataPropertyName = "ManufacturerName" });
        //        d.Columns.Add(new DataGridViewColumn { DataPropertyName = "ProductName" });
        //        d.Columns.Add(new DataGridViewColumn { DataPropertyName = "CategoryName" });
        //        d.Columns.Add(new DataGridViewColumn { DataPropertyName = "CanUse" });
        //        BindingSource s = new BindingSource();
        //        s.DataSource = locations;
        //        d.DataSource = s;


        //        Regex regex = new Regex(@"^[A-T]-\d+-\d+$");
        //        var row = d.Rows;
        //        var cell = d.Rows[0].Cells[0];
        //        var result = regex.IsMatch(d.Rows[0].Cells[0].Value.ToString());
        //        if (!result)
        //        {
        //            r1 = false;
        //        }
        //        Regex regex2 = new Regex(@"^[A-T]$");
        //        result = regex2.IsMatch(d.Rows[0].Cells[3].Value.ToString());
        //        if (!result)
        //        {
        //            r1 = false;
        //        }
        //        if (!r1)
        //        {
        //            Console.WriteLine("StorageLocation绑定界面时 列没有对齐--------------------------------失败");
        //        }
        //        else
        //        {
        //            Console.WriteLine("StorageLocation绑定界面--------------------------------成功");
        //        }


        //        context.Entry<StorageLocation>(location).State = System.Data.EntityState.Deleted;
        //        context.SaveChanges();




        //    }, () =>
        //    {

        //        Console.WriteLine("DataGridView测试 从数据库取得数据失败-------------------------------------失败！");

        //    }, testFile);
        //}

    }




}



