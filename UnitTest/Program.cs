using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;
using Model;
using DAL;

namespace UnitTest
{
    
    class Program
    {
        static CKGLContext  context = new CKGLContext();
        static void Main(string[] args)
        {
           
            TestSplitPager();
            TestSqlHelp();
            Console.ReadKey();

        }

        private static void TestSqlHelp()
        {
            Console.WriteLine("开始测试SqlHelp<T>类----------------------------------------------");
            var list=context.Products.OrderBy(i => i.Id).Take(10).ToList();
            if (list.Count() > 0)
            {
                string name = list[0].ProductName;
                string name1 = list[1].ProductName;
                list[0].ProductName = "test3";
                list[1].ProductName = "test4";
                SqlHelp<Product,int> help=new SqlHelp<Product,int>(context);
                int r = help.Update(list);
                if(r==2)
                {
                    list[0].ProductName = name;
                    list[1].ProductName = name1;
                    int r2=help.Update(list);
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
            pager.MoveToPage(pager.TotalPageCount-1);

            var num1 = total - (testList.GetEntities(pager.CurrentPageNum, pager.PageSize).Count() + 
                pager.PageSize * pager.CurrentPageNum);

            //到最后一页
            pager.MoveToPage(pager.TotalPageCount);
            var num2 =(testList.GetEntities(pager.CurrentPageNum, pager.PageSize).Count() +
                pager.PageSize * pager.CurrentPageNum);
            var before = pager.CurrentPageNum;

            pager.MoveToPage(testList.Count() / pager.PageSize + 2);
            pager.MoveToPage(-1);
            if ((num1 == total % pager.PageSize||num1==pager.PageSize) && num2 >= testList.Count() && before == pager.CurrentPageNum)
            {
                Console.WriteLine("MoveToPage方法运行结果-----------------正确！");
            }
            else
            {
                Console.WriteLine("MoveToPage方法运行结果-----------------错误！");
            }

           
            pager = new SplitPager(5, total);
            var bef=pager.CurrentPageNum;
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

            pager.MoveToPage(pager.TotalPageCount );
            var num5 = pager.CurrentPageNum;
           
            pager.MovePreviousPage();
            pager.MovePreviousPage();
            var diff2=num5-pager.CurrentPageNum;
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

    }
}
