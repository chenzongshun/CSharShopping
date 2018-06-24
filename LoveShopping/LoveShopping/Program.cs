using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using love_DAL;

namespace LoveShopping
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main() 
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                /**
                 * 当前用户是管理员的时候，直接启动应用程序
                 * 如果不是管理员，则使用启动对象启动程序，以确保使用管理员身份运行
                 */
                //获得当前登录的Windows用户标示
                System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
                System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
                //判断当前登录用户是否为管理员
                if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
                {
                    //如果是管理员，则直接运行 

                    string n1 = Application.StartupPath + "\\LoveShopping.mdf";
                    string n2 = Application.StartupPath + "\\LoveShopping.ldf";
                    love.fujiadatabase(n1, n2);

                Exit: Application.Run(new Frm_Login());
                    if (love.denglu_IsSelldeOrBuyde == "卖" && love.user_orther != false)
                    {   //运行的卖家集成窗体
                        Application.Run(new Frm_Main_Sellde());
                        love.clear();//记得等窗体运行后再清空用完就清空
                    }
                    if (love.denglu_IsSelldeOrBuyde == "买" && love.user_orther != false)
                    {   //运行的买家集成窗体
                        Application.Run(new Frm_Main_Buyde());
                        love.clear();//记得等窗体运行后再清空用完就清空
                    }
                    if (love.WindowsIsExit || love.isorupdatepwd)
                    {
                        love.WindowsIsExit = love.isorupdatepwd = false;//记得改回去，不然下次再按就会出错
                        goto Exit;//因为是在集成窗口按下退出按钮所以要goto到开头从头运行到尾
                    }


                }
                else
                {
                    //创建启动对象
                    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                    startInfo.UseShellExecute = true;
                    startInfo.WorkingDirectory = Environment.CurrentDirectory;
                    startInfo.FileName = Application.ExecutablePath;
                    //设置启动动作,确保以管理员身份运行
                    startInfo.Verb = "runas";
                    try
                    {
                        System.Diagnostics.Process.Start(startInfo);
                    }
                    catch
                    {
                        return;
                    }
                    //退出
                    Application.Exit();
                }
            }
            catch               //万一管理员权限获取失败则使用原main方法进行
            { 
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                string n1 = Application.StartupPath + "\\LoveShopping.mdf";
                string n2 = Application.StartupPath + "\\LoveShopping.ldf";
                love.fujiadatabase(n1, n2);

            Exit: Application.Run(new Frm_Login());
                if (love.denglu_IsSelldeOrBuyde == "卖" && love.user_orther != false)
                {   //运行的卖家集成窗体
                    Application.Run(new Frm_Main_Sellde());
                    love.clear();//记得等窗体运行后再清空用完就清空
                }
                if (love.denglu_IsSelldeOrBuyde == "买" && love.user_orther != false)
                {   //运行的买家集成窗体
                    Application.Run(new Frm_Main_Buyde());
                    love.clear();//记得等窗体运行后再清空用完就清空
                }
                if (love.WindowsIsExit || love.isorupdatepwd)
                {
                    love.WindowsIsExit = love.isorupdatepwd = false;//记得改回去，不然下次再按就会出错
                    goto Exit;//因为是在集成窗口按下退出按钮所以要goto到开头从头运行到尾
                } 
            }
        }
    }
}
