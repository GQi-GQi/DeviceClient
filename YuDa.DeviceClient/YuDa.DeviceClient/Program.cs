using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace YuDa.DeviceClient
{
    static class Program
    {
        public static log4net.ILog LOG = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region 必须以管理员身份启动
            //获得当前登录的Windows用户标示 
            if (!new System.Security.Principal.WindowsPrincipal(System.Security.Principal.WindowsIdentity.GetCurrent()).IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            {
                //创建启动对象 
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                //设置运行文件 
                startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
                //设置启动动作,确保以管理员身份运行 
                startInfo.Verb = "runas";
                try
                {
                    //如果不是管理员，则启动UAC 
                    System.Diagnostics.Process.Start(startInfo);
                }
                catch { }
                //退出 
                System.Windows.Forms.Application.Exit();
                return;
            }
            #endregion


            //捕获未处理异常
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());

            //Login login = new Login();
            //login.ShowDialog();
            //if (login.DialogResult == DialogResult.OK)
            //{
            //    Application.Run(new Main());
            //}
            //else
            //{
            //    return;
            //}
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            LOG.Error(e.Exception);
            //throw new Exception("线程未知异常", e.Exception);
            MessageBox.Show(e.Exception.Message, "线程异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Exception ex = e.ExceptionObject as Exception;
            LOG.Error(ex);
            MessageBox.Show(ex.Message, "应用程序异常", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Application.Exit();
        }
    }
}
