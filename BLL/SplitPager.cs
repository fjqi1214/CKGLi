using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public class SplitPager
    {

        /// <summary>
        /// 当前页 (页数从零开始)
        /// </summary>
        private int currentPageNum;

      
        /// <summary>
        /// 当前总页数
        /// </summary>
        private int currentTotalPageNum;

        /// <summary>
        /// 页大小
        /// </summary>
        private int pageSize;


        public SplitPager(int pageSize,int total)
        {
            if (total < 0 || pageSize <= 0)
            {
                throw new ArgumentException("页码,记录数不能小于0");
            }
            
            this.pageSize = pageSize;
            this.currentPageNum = 0; 
            this.currentTotalPageNum = GetTotalPageNum(total);
        }

        public int PageSize
        {
            get
            {
                return pageSize;
            }
        }

        /// <summary>
        /// 当前的页总数（从0开始）
        /// </summary>
        public int TotalPageCount
        {
            get
            {
                return this.currentTotalPageNum ;
            }
        }

        /// <summary>
        /// 当前页号
        /// </summary>
        public int CurrentPageNum
        {
            get
            {
                return currentPageNum;
            }
        }

        public int FormatPageNum
        {
            get {
                int i = currentPageNum + 1;
                return i;
            }
        }

        public int FormatTotalPageNum
        {
            get {
                int i = currentTotalPageNum + 1;
                   return i;
            }
        }

        public void MoveNextPage()
        {
            if (currentPageNum < currentTotalPageNum)
                currentPageNum++;
        }

        public void MovePreviousPage()
        {
            if (currentPageNum > 0)
            {
                currentPageNum--;
            }
        }

        public void MoveFirstPage(int total)
        {
            this.currentTotalPageNum = GetTotalPageNum(total);
            this.currentPageNum = 0;
        }


        public void MoveLastPage(int total)
        {
            this.currentTotalPageNum = GetTotalPageNum(total);
            this.currentPageNum = this.currentTotalPageNum;
        }

        public void MoveToPage(int num)
        {
            if (currentTotalPageNum >= num && num >= 0)
            {
                currentPageNum = num;
            }
        }

        private int GetTotalPageNum(int total)
        {
            int currentTotalPageNum = 0;
            if (total != 0)
            {
                int k = total / pageSize;
                currentTotalPageNum = total % pageSize == 0 ? k - 1 : k;
            }
            return currentTotalPageNum;
        }

    }
}
