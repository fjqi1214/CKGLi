using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Data.Entity.Infrastructure;
using System.Data;

namespace CKGL
{
    public class ErrorHandle
    {
        //public  void HandleError(Action done,Action action,string fileName)
        //{
        //    try
        //    {
        //        done();
        //    }
        //    catch (ProviderIncompatibleException ex)
        //    {
        //        //MessageBox.Show("数据库连接出现错误 可能是网络问题或配置文件出现错误！", "提示！");
        //        action();
        //        LogEx(ex, fileName);
        //    }
        //    catch (DbUpdateException ex)
        //    {
        //        //MessageBox.Show("程序更新数据库时出现错误可能是添加的数据有重复或者出现非法的相关数据！", "提示！");
        //        action();
        //        LogEx(ex, fileName);
        //    }
        //    catch (Exception ex)
        //    {
        //        //MessageBox.Show("程序发生未知错误！","提示！");
        //        action();
        //        LogEx(ex, fileName);

        //    }

        //}

        public static void HandleError(Action done, Action action, string fileName)
        {
            try
            {
                done();

            }
            catch (DbUpdateConcurrencyException ex)
            {
                action();
                LogEx(ex, fileName);
              
            }
            catch (ProviderIncompatibleException ex)
            {
                action();
                LogEx(ex, fileName);
               
            }
            catch (DbUpdateException ex)
            {
                action();
                LogEx(ex, fileName);
                
            }
            catch (InvalidOperationException ex)
            {
                action();
                LogEx(ex, fileName);
            }

            catch (Exception ex)
            {
                action();
                LogEx(ex, fileName);

            }
        }

        public static void HandleError(Action done, string fileName)
        {
            try
            {
                done();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                MessageBox.Show("未监控到实体 不能执行此操作！", "提示！");
                LogEx(ex, fileName);
            }
            catch (ProviderIncompatibleException ex)
            {
                MessageBox.Show("数据库连接出现错误 可能是网络问题或配置文件出现错误！", "提示！");
                LogEx(ex, fileName);
              
            }
            catch (DbUpdateException ex)
            {
                MessageBox.Show("程序更新数据库时出现错误可能是添加的数据有重复或者出现非法的相关数据！", "提示！");
                LogEx(ex, fileName);
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show("非法的操作", "提示！");
                LogEx(ex, fileName);
            }

            catch (Exception ex)
            {
                MessageBox.Show("程序发生未知错误！", "提示！");
                LogEx(ex, fileName);
            }
        }

       private static  void LogEx(Exception ex, string fileName)
        {
            var writer = File.AppendText(fileName);
            writer.WriteLine(DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")+" "+ ex.Message);
            writer.Close();

        }
    }
}
