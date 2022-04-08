using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace VoiceService
{
    internal class Achieve
    {
        public static void AchFestival()
        {
            Festival det = Generate.GenFestival();
            switch (det)
            {
                case Festival.None:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\welc.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Festival.NewYear:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\f01.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Festival.LunarEve:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\f02.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Festival.LunarNew:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\f03.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Festival.LunarMid:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\f04.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Festival.Chingming:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\f05.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Festival.Dragonboat:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\f06.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Festival.Labor:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\f07.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Festival.MidAutumn:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\f08.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Festival.National:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\f09.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Festival.Chistmas:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\f10.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Festival.Spring:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\f11.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    Media.PlaySound("C:\\IDS\\Dev\\media\\d1.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Festival.Summer:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\f12.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    Media.PlaySound("C:\\IDS\\Dev\\media\\d2.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Festival.Autumn:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\f13.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    Media.PlaySound("C:\\IDS\\Dev\\media\\d3.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Festival.Winter:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\f14.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    Media.PlaySound("C:\\IDS\\Dev\\media\\d4.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                default:
                    break;
            }
        }
        public static void AchTime()
        {
            Time det = Generate.GenTime();
            switch (det)
            {
                case Time.None:
                    break;
                case Time.Wakeup:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\t1.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Time.Morning:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\t2.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Time.Noon:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\t3.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Time.Afternoon:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\t4.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Time.Evening:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\t5.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Time.Midnight:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\t6.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                default:
                    break;
            }
        }
        public static void AchWeather()
        {
            Weather det = Generate.GenWeather();
            switch (det)
            {
                case Weather.Clear:
                    break;
                case Weather.Sunny:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\w1.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Weather.Cloudy:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\w2.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Weather.Rainy:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\w3.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Weather.Thunder:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\w4.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Weather.Snowy:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\w5.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                case Weather.Foggy:
                    Media.PlaySound("C:\\IDS\\Dev\\media\\w6.wav", IntPtr.Zero, Media.SND_FILENAME | Media.SND_SYNC | Media.SND_NODEFAULT);
                    break;
                default:
                    break;
            }
        }
    }
}