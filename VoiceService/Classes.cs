using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace VoiceService
{
    public class Syscmd
    {
        public static string ExecuteCMD(string CmdCommand)
        {
            return ExecuteCMD(CmdCommand, 10);
        }
        /// <summary>
        /// 执行cmd命令，返回cmd命令的输出
        /// </summary>
        /// <param name="command">cmd命令</param>
        /// <param name="seconds">等待命令执行的时间（单位：毫秒），<br/>
        /// 如果设定为0，则无限等待</param>
        /// <returns>返回CMD命令的输出</returns>
        public static string ExecuteCMD(string command, int seconds)
        {
            string output = ""; //输出字符串
            if (command != null && !command.Equals(""))
            {
                Process process = new Process();//创建进程对象
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";//设定需要执行的命令
                startInfo.Arguments = "/C " + command;//“/C”表示执行完命令后马上退出
                startInfo.UseShellExecute = false;//不使用系统外壳程序启动
                startInfo.RedirectStandardInput = false;//不重定向输入
                startInfo.RedirectStandardOutput = true; //重定向输出
                startInfo.CreateNoWindow = true;//不创建窗口
                process.StartInfo = startInfo;
                try
                {
                    if (process.Start())//开始进程
                    {
                        if (seconds == 0)
                        {
                            process.WaitForExit();//这里无限等待进程结束
                        }
                        else
                        {
                            process.WaitForExit(seconds); //等待进程结束，等待时间为指定的毫秒
                        }
                        output = process.StandardOutput.ReadToEnd();//读取进程的输出
                    }
                }
                catch
                {
                }
                finally
                {
                    if (process != null)
                        process.Close();
                }
            }
            return output;
        }
        /// <summary>
        /// 执行powershell指令
        /// </summary>
        /// <param name="commands">指令</param>
        /// <param name="mseconds">等待时间(毫秒)</param>
        /// <returns></returns>
        public static string ExecutePwsh(string commands, int mseconds)
        {
            string output = ""; //输出字符串
            if (commands != null && !commands.Equals(""))
            {
                Process process = new Process();//创建进程对象
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "powershell.exe";//设定需要执行的命令
                startInfo.Arguments = "-Command " + commands;//“/C”表示执行完命令后马上退出
                startInfo.UseShellExecute = false;//不使用系统外壳程序启动
                startInfo.RedirectStandardInput = false;//不重定向输入
                startInfo.RedirectStandardOutput = true; //重定向输出
                startInfo.CreateNoWindow = true;//不创建窗口
                process.StartInfo = startInfo;
                try
                {
                    if (process.Start())//开始进程
                    {
                        if (mseconds == 0)
                        {
                            process.WaitForExit();//这里无限等待进程结束
                        }
                        else
                        {
                            process.WaitForExit(mseconds); //等待进程结束，等待时间为指定的毫秒
                        }
                        output = process.StandardOutput.ReadToEnd();//读取进程的输出
                    }
                }
                catch
                {
                }
                finally
                {
                    if (process != null)
                        process.Close();
                }
            }
            return output;
        }
        public const int SW_HIDE = 0;
        public const int SW_SHOWNORMAL = 1;
        public const int SW_NORMAL = 1;
        public const int SW_SHOWMINIMIZED = 2;
        public const int SW_SHOWMAXIMIZED = 3;
        public const int SW_MAXIMIZE = 3;
        public const int SW_SHOWNOACTIVATE = 4;
        public const int SW_SHOW = 5;
        public const int SW_MINIMIZE = 6;
        public const int SW_SHOWMINNOACTIVE = 7;
        public const int SW_SHOWNA = 8;
        public const int SW_RESTORE = 9;
        public const int SW_SHOWDEFAULT = 10;
        public const int SW_FORCEMINIMIZE = 11;
        public const int SW_MAX = 11;
        [DllImport("shell32.dll")]
        public static extern IntPtr ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirectory, int nShowCmd);
    }
    /// <summary>
    /// API信息窗口
    /// </summary>
    public class WinMessage
    {
        [DllImport("User32.dll", SetLastError = true, ThrowOnUnmappableChar = true, CharSet = CharSet.Auto)]
        public static extern int MessageBox(IntPtr handle, string message, string title, int type);//MessageBox函数导入
        public const int MB_OK = 0;//只有一个确定按钮
        public const int MB_YESNO = 0x01;//带有两个按钮：是，否
        public const int MB_RAF = 0x02;//带有3个按钮：重试，跳过，取消
        public const int MB_YESNOCANCEL = 0x03;//带有3个按钮：是，否，取消
        public const int MB_RETRYCANCEL = 0x05;//带有2个按钮：重试，取消
        public const int MB_CRC = 0x06;//带有3个按钮：取消，重试，继续
        public const int ICON_ERROR = 0x10;//错误图标
        public const int ICON_QUESTION = 0x20;//询问图标
        public const int ICON_WARNING = 0x30;//警告(惊叹号)图标
        public const int ICON_INFORMATION = 0x40;//信息图标
        public const int SOUND_NORMAL = 0x50;//这是啥来着……
    }
    /// <summary>
    /// 音频处理相关
    /// </summary>
    public class Media
    {
        [DllImport("winmm.dll")]
        public static extern int PlaySound(string pszSound, IntPtr hmod, uint fdwSound);
        public const uint SND_SYNC = 0x0000;//同步播放
        public const uint SND_ASYNC = 0x0001;//异步播放
        public const uint SND_NODEFAULT = 0x0002;//不播放缺省默认音效
        public const uint SND_MEMORY = 0x0004;//内存地址
        public const uint SND_LOOP = 0x0008;//循环播放
        public const uint SND_NOSTOP = 0x0010;
        public const uint SND_NOWAIT = 0x00002000;
        public const uint SND_ALIAS = 0x00010000;
        public const uint SND_ALIAS_ID = 0x00110000;
        public const uint SND_FILENAME = 0x00020000;//从文件播放
        public const uint SND_RESOURCE = 0x00040004;//资源文件
    }
    /// <summary>
    /// 系统配置
    /// </summary>
    public class WSystemd
    {
        public class Systemctl
        {
            [DllImport("kernel32.dll", EntryPoint = "SetComputerNameEx")]
            public static extern int apiSetComputerNameEx(int type, string lpComputerName);//有bug,别用
            public const int ASC_NORMAL_TYPE = 5;
            /// <summary>
            /// 获取系统计算机名
            /// </summary>
            /// <returns></returns>
            public static string GetComputerName()
            {
                try
                {
                    return Environment.GetEnvironmentVariable("ComputerName");
                }
                catch
                {
                    return "";
                }
            }
            /// <summary>
            /// 修改计算机名(通过注册表)
            /// </summary>
            /// <param name="newname">新名称</param>
            public static void SetComputerName(string newname)
            {
                RegistryKey pregkey;
                pregkey = Registry.LocalMachine.OpenSubKey("SYSTEM\\ControlSet001\\Control\\ComputerName\\ComputerName", true);
                pregkey.SetValue("ComputerName", newname);
                pregkey = Registry.LocalMachine.OpenSubKey("SYSTEM\\ControlSet001\\Services\\Tcpip\\Parameters", true);
                pregkey.SetValue("NV Hostname", newname);
                pregkey.SetValue("Hostname", newname);
                pregkey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\ComputerName\\ComputerName", true);
                pregkey.SetValue("ComputerName", newname);
                pregkey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Services\\Tcpip\\Parameters", true);
                pregkey.SetValue("NV Hostname", newname);
                pregkey.SetValue("Hostname", newname);
            }
        }
        public class Users
        {
            /// <summary>
            /// 修改Administrator的密码
            /// </summary>
            /// <param name="NewPass">新密码</param>
            public static void ResetAdminPass(string NewPass)
            {
                //Create New Process
                System.Diagnostics.Process QProc = new System.Diagnostics.Process();
                //Do Something To hide Command(cmd) Window
                QProc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                QProc.StartInfo.CreateNoWindow = true;
                //Call Net.exe
                QProc.StartInfo.WorkingDirectory = "C://Windows//SYSTEM32";
                QProc.StartInfo.FileName = "net.exe";
                QProc.StartInfo.UseShellExecute = false;
                QProc.StartInfo.RedirectStandardError = true;
                QProc.StartInfo.RedirectStandardInput = true;
                QProc.StartInfo.RedirectStandardOutput = true;
                //Prepare Command for Exec
                QProc.StartInfo.Arguments = @" user Administrator " + NewPass;
                QProc.Start();
                //MyProc.WaitForExit();
                QProc.Close();
            }
        }
    }
    public class RegistK
    {
        public const int HKEY_LOCAL_MACHINE = 0;
        public const int HKEY_CURRENT_USER = 1;
        public const int HKEY_CURRENT_CONFIG = 2;
        public const int HKEY_CLASSES_ROOT = 3;
        public const int HKEY_USERS = 4;
        /// <summary>
        /// 更改注册表项
        /// </summary>
        /// <param name="registryKey">已打开的注册表</param>
        /// <param name="target">目标项</param>
        /// <param name="_string">修改后的字符串</param>
        public static void ChangeReg(RegistryKey registryKey, string target, string _string)
        {
            RegistryKey pregkey = registryKey;
            pregkey.SetValue(target, _string);
        }
        /// <summary>
        /// 更改注册表项
        /// </summary>
        /// <param name="registryKey">注册表路径</param>
        /// <param name="target">目标项</param>
        /// <param name="_string">修改后的字符串</param>
        /// <param name="root">根目录</param>
        public static void ChangeReg(string registryKey, string target, string _string, int root)
        {
            RegistryKey pregkey = null;
            switch (root)
            {
                case 0:
                    pregkey = Registry.LocalMachine.OpenSubKey(registryKey, true);
                    break;
                case 1:
                    pregkey = Registry.CurrentUser.OpenSubKey(registryKey, true);
                    break;
                case 2:
                    pregkey = Registry.CurrentConfig.OpenSubKey(registryKey, true);
                    break;
                case 3:
                    pregkey = Registry.ClassesRoot.OpenSubKey(registryKey, true);
                    break;
                case 4:
                    pregkey = Registry.Users.OpenSubKey(registryKey, true);
                    break;
                default:
                    return;
            }
            pregkey.SetValue(target, _string);
        }
        /// <summary>
        /// 修改注册表项
        /// </summary>
        /// <param name="registryKey">已打开的注册表</param>
        /// <param name="target">目标项</param>
        /// <param name="DWORD">修改后的值</param>
        public static void ChangeReg(RegistryKey registryKey, string target, int DWORD)
        {
            RegistryKey pregkey = registryKey;
            pregkey.SetValue(target, DWORD);
        }
        /// <summary>
        /// 修改注册表项
        /// </summary>
        /// <param name="registryKey">注册表路径</param>
        /// <param name="target">目标项</param>
        /// <param name="DWORD">修改后的值</param>
        /// <param name="root">根目录</param>
        public static void ChangeReg(string registryKey, string target, int DWORD, int root)
        {
            RegistryKey pregkey = null;
            switch (root)
            {
                case 0:
                    pregkey = Registry.LocalMachine.OpenSubKey(registryKey, true);
                    break;
                case 1:
                    pregkey = Registry.CurrentUser.OpenSubKey(registryKey, true);
                    break;
                case 2:
                    pregkey = Registry.CurrentConfig.OpenSubKey(registryKey, true);
                    break;
                case 3:
                    pregkey = Registry.ClassesRoot.OpenSubKey(registryKey, true);
                    break;
                case 4:
                    pregkey = Registry.Users.OpenSubKey(registryKey, true);
                    break;
                default:
                    return;
            }
            pregkey.SetValue(target, DWORD);
        }
        /// <summary>
        /// 修改注册表项
        /// </summary>
        /// <param name="registryKey">已打开的注册表</param>
        /// <param name="target">目标项</param>
        /// <param name="BOOL">修改后的值</param>
        public static void ChangeReg(RegistryKey registryKey, string target, bool BOOL)
        {
            RegistryKey pregkey = registryKey;
            pregkey.SetValue(target, BOOL);
        }
        /// <summary>
        /// 修改注册表项
        /// </summary>
        /// <param name="registryKey">注册表路径</param>
        /// <param name="target">目标项</param>
        /// <param name="BOOL">修改后的值</param>
        /// <param name="root">根目录</param>
        public static void ChangeReg(string registryKey, string target, bool BOOL, int root)
        {
            RegistryKey pregkey = null;
            switch (root)
            {
                case 0:
                    pregkey = Registry.LocalMachine.OpenSubKey(registryKey, true);
                    break;
                case 1:
                    pregkey = Registry.CurrentUser.OpenSubKey(registryKey, true);
                    break;
                case 2:
                    pregkey = Registry.CurrentConfig.OpenSubKey(registryKey, true);
                    break;
                case 3:
                    pregkey = Registry.ClassesRoot.OpenSubKey(registryKey, true);
                    break;
                case 4:
                    pregkey = Registry.Users.OpenSubKey(registryKey, true);
                    break;
                default:
                    return;
            }
            pregkey.SetValue(target, BOOL);
        }
    }
    public static class EMAth
    {
        public static int GetRandom(int from, int to)
        {
            Int32 vol = Convert.ToInt32(Environment.TickCount) / 1000000;
            Random r = new Random();
            for (Int32 i = 0; i < vol; i++)
            {
                r.Next(from, to);
            }
            return r.Next(from, to);
        }
    }
}
