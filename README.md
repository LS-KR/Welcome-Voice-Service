
# Welcome-Voice-Service
For Windows; 让你的系统在启动时问候你~

## 安装
在根目录中(或Release中压缩包的根目录中)运行`install.bat`即可  

安装主程序后, 还需要安装一个多个语音包, 后安装的语音包会覆盖前面的语音包.  
语音包可以在Release中找到.  

## 启动
在系统启动时, 语音服务会自动启动.  

## 自制语音包
语音文件的格式为: `*.wav`, 存档在`C:\IDS\Dev\media\`中.  
每个语音文件的名字和内容对应如下:  
| 名字 | 内容 |
| ---- | ---- |
|welc.wav|标准欢迎语(非节日)|
|f01.wav|元旦|
|f02.wav|除夕|
|f03.wav|新年(阴历)|
|f04.wav|元宵节|
|f05.wav|清明节|
|f06.wav|端午节|
|f07.wav|劳动节|
|f08.wav|中秋节|
|f09.wav|国庆节|
|f10.wav|圣诞节|
|f11.wav|立春|
|f12.wav|立夏|
|f13.wav|立秋|
|f14.wav|立冬|
|d1.wav|立春 - 在`f11.wav`后播放|
|d2.wav|立夏 - 在`f12.wav`后播放|
|d3.wav|立秋 - 在`f13.wav`后播放|
|d4.wav|立冬 - 在`f14.wav`后播放|
|t1.wav|早上好|
|t2.wav|上午好|
|t3.wav|中午好|
|t4.wav|下午好|
|t5.wav|晚上好|
|t6.wav|凌晨(半夜)好|
|w1.wav|晴天|
|w2.wav|多云(阴天)|
|w3.wav|下雨|
|w4.wav|雷阵雨|
|w5.wav|(雨夹)雪|
|w6.wav|雾霾|

安装语音包仅需运行语音包中的`install.bat`即可.  
可以在Release中的任何一个语音包中找到.  

除此以外, 您还可以发布语音包: 您可以将语音包用邮件发送给我(联系方式见下).审核后会在Release中添加.  

## 关于
Made by Elihuso.  

天气API来自[https://github.com/LS-KR/China-Citycode](https://github.com/LS-KR/China-Citycode);  
农历算法来自[https://github.com/LS-KR/LunarMonthCalender](https://github.com/LS-KR/LunarMonthCalender).  

均为我一个人的开发, 如有任何问题, 请联系我.  
email:[Elihuso@outlook.com](mailto:Elihuso@outlook.com)

由于某些原因, 可能不会在第一时间回复, 请谅解.
