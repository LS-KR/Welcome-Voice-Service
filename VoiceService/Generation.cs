using System;
using System.IO;
using System.ServiceProcess;
using System.Linq;

namespace VoiceService
{
    internal enum Time
    {
        None = 0,
        Wakeup = 1,
        Morning = 2,
        Noon = 3,
        Afternoon = 4,
        Evening = 5,
        Midnight = 6
    }
    internal enum Festival
    {
        None = 0,
        NewYear = 1,
        LunarEve = 2,
        LunarNew = 3,
        LunarMid = 4,
        Chingming = 5,
        Dragonboat = 6,
        Labor = 7,
        MidAutumn = 8,
        National = 9,
        Chistmas = 10,
        Spring = 11,
        Summer = 12,
        Autumn = 13,
        Winter = 14
    }
    internal enum Weather
    {
        Clear = 0,
        Sunny = 1,
        Cloudy = 2,
        Rainy = 3,
        Thunder = 4,
        Snowy = 5,
        Foggy = 6
    }
    internal class Generate
    {
        public static Festival GenFestival()
        {
            DateTime dt = DateTime.Now;
            Lunar.LunarDate ld = Lunar.GetLunarDate(dt.Year, dt.Month, dt.Day);
            if ((dt.Month == 1) && (dt.Day == 1))
                return Festival.NewYear;
            else if ((ld.Month == 12) && (ld.Day == 30))
                return Festival.LunarEve;
            else if ((ld.Month == 12) && (ld.Day == 29))
            {
                Lunar.LunarDate lunarDate = new Lunar.LunarDate();
                DateTime dateTime = DateTime.Now.AddDays(1);
                lunarDate = Lunar.GetLunarDate(dateTime.Year, dateTime.Month, dateTime.Day);
                if (lunarDate.Month == 1)
                    return Festival.LunarEve;
            }
            else if ((ld.Month == 1) && (ld.Day == 1))
                return Festival.LunarNew;
            else if ((ld.Month == 1) && (ld.Day == 15))
                return Festival.LunarMid;
            else if ((ld.Month == 5) && (ld.Day == 5))
                return Festival.Dragonboat;
            else if ((dt.Month == 5) && (dt.Day == 1))
                return Festival.Labor;
            else if ((ld.Month == 8) && (ld.Day == 15))
                return Festival.MidAutumn;
            else if ((dt.Month == 10) && (dt.Day == 1))
                return Festival.National;
            else if ((dt.Month == 12) && (dt.Day == 25))
                return Festival.Chistmas;
            else
            {
                SolarTerm.SolarDate[] sd = new SolarTerm.SolarDate[5];
                sd[0] = SolarTerm.GetSolarTermDate(SolarTerm.SolarTerms.Beginning_Of_Spring, dt.Year);
                sd[1] = SolarTerm.GetSolarTermDate(SolarTerm.SolarTerms.Beginning_Of_Summer, dt.Year);
                sd[2] = SolarTerm.GetSolarTermDate(SolarTerm.SolarTerms.Beginning_Of_Autumn, dt.Year);
                sd[3] = SolarTerm.GetSolarTermDate(SolarTerm.SolarTerms.Beginning_Of_Winter, dt.Year);
                sd[4] = SolarTerm.GetSolarTermDate(SolarTerm.SolarTerms.QingMing, dt.Year);
                if ((sd[0].Month == dt.Month) && (sd[0].Day == dt.Day))
                    return Festival.Spring;
                else if ((sd[1].Month == dt.Month) && (sd[1].Day == dt.Day))
                    return Festival.Summer;
                else if ((sd[2].Month == dt.Month) && (sd[2].Day == dt.Day))
                    return Festival.Autumn;
                else if ((sd[3].Month == dt.Month) && (sd[3].Day == dt.Day))
                    return Festival.Winter;
                else if ((sd[4].Month == dt.Month) && (sd[4].Day == dt.Day))
                    return Festival.Chingming;
                else
                    return Festival.None;
            }
            return Festival.None;
        }
        public static Time GenTime()
        {
            DateTime dt = DateTime.Now;
            if ((dt.Hour >= 5) && (dt.Hour < 11))
                if ((dt.Hour >= 5) && (dt.Hour < 8))
                    return Time.Wakeup;
                else
                    return Time.Morning;
            else if ((dt.Hour >= 11) && (dt.Hour < 14))
                return Time.Noon;
            else if ((dt.Hour >= 14) && (dt.Hour < 20))
                return Time.Afternoon;
            else if ((dt.Hour >= 20) && (dt.Hour < 24))
                return Time.Evening;
            else if ((dt.Hour < 5))
                return Time.Midnight;
            else
                return Time.None;
        }
        public static Weather GenWeather()
        {
            if (File.Exists("C:\\Windows\\Temp\\wapi.html"))
                File.Delete("C:\\Windows\\Temp\\wapi.html");
            if (File.Exists("C:\\Windows\\Temp\\lapi.html"))
                File.Delete("C:\\Windows\\Temp\\lapi.html");
            Syscmd.ExecutePwsh("wget ip.tool.lu -o C:\\Windows\\Temp\\lapi.html", 0);
            string[] lapi = File.ReadAllLines("C:\\Windows\\Temp\\lapi.html");
            string[] json = File.ReadAllLines("C:\\IDS\\Dev\\citycode.json");
            char[] delimiterChar = { '\"', ':' };
            string ret = "";
            bool isend = false;
            for (int i = 0; i < 1952; i++)
            {
                if (json[i].Contains("\"Province\""))
                {
                    string[] words = json[i].Split(delimiterChar);
                    for (int j = 0; j < words.Length; j++)
                    {
                        if ((lapi[1].Contains(words[j])) && (words[j] != "") && (words[j] != " ") && (words[j] != ","))
                        {
                            for (int k = i + 1; k < 1952; k++)
                            {
                                if (json[k].Contains("\"city\""))
                                {
                                    string[] ct = json[k].Split(delimiterChar);
                                    for (int l = 0; l < ct.Length; l++)
                                    {
                                        if ((lapi[1].Contains(ct[l])) && (ct[l] != "") && (ct[l] != " ") && (ct[l] != ","))
                                        {
                                            isend = true;
                                            string[] words2 = json[k + 1].Split(delimiterChar);
                                            for (int m = 0; m < words2.Length; m++)
                                            {
                                                if (words2[m].Contains("10"))
                                                    ret = words2[m];
                                            }
                                            break;
                                        }
                                    }
                                }
                                if (isend)
                                    break;
                            }
                        }
                        if (isend)
                            break;
                    }
                }
                if (isend)
                    break;
            }
            Console.WriteLine(ret);
            string weauri = "http://www.weather.com.cn/weather1d/" + ret + ".shtml";
            Syscmd.ExecutePwsh("wget " + weauri + " -o C:\\Windows\\Temp\\wapi.html", 1000);
            string[] awp = File.ReadAllLines("C:\\Windows\\Temp\\wapi.html");
            int target;
            for (target = 0; target < awp.Length; target++)
            {
                if (awp[target].Contains("hour3data"))
                    break;
            }
            string wapi = awp[target];
            Console.WriteLine(wapi);
            string[] vs = wapi.Split('\"');
            int sn, cl, rn, th, sw, fg;//sunny, cloudy, rainy, thunder, snow and foggy
            sn = cl = rn = th = sw = fg = 2147483647;
            for (int i = 0; i < vs.Length; i++)
            {
                if (vs[i].Contains("晴") || vs[i].Contains("少云"))
                {
                    sn = i;
                    break;
                }
            }
            for (int i = 0; i < vs.Length; i++)
            {
                if (vs[i].Contains("阴") || vs[i].Contains("多云"))
                {
                    cl = i;
                    break;
                }
            }
            for (int i = 0; i < vs.Length; i++)
            {
                if (vs[i].Contains("雷"))
                {
                    th = i;
                    break;
                }
            }
            for (int i = 0; i < vs.Length; i++)
            {
                if (vs[i].Contains("雨"))
                {
                    rn = i;
                    break;
                }
            }
            for (int i = 0; i < vs.Length; i++)
            {
                if (vs[i].Contains("雪"))
                {
                    sw = i;
                    break;
                }
            }
            for (int i = 0; i < vs.Length; i++)
            {
                if (vs[i].Contains("雾"))
                {
                    fg = i;
                    break;
                }
            }
            Weather w = Weather.Clear;
            int[] arr = new int[] { sn, cl, th, rn, sw, fg };
            if (arr.Min() == sn)
                w = Weather.Sunny;
            if (arr.Min() == cl)
                w = Weather.Cloudy;
            if (arr.Min() == rn)
                w = Weather.Rainy;
            if (arr.Min() == th)
                w = Weather.Thunder;
            if (arr.Min() == sw)
                w = Weather.Snowy;
            if (arr.Min() == fg)
                w = Weather.Foggy;
            return w;
        }
    }
}