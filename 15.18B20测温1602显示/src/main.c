/*-----------------------------------------------
名称：DS18b20温度检测1602显示
公司：南京爱思电子
编写：rantg	
日期：2012.3
内容：DS18b20检测温度送1602显示
------------------------------------------------*/

#include<reg52.h> 
#include<stdio.h>
#include "18b20.h"
#include "1602.h"
#include "delay.h"

bit ReadTempFlag;//定义读时间标志

void Init_Timer0(void);//定时器初始化

/*------------------------------------------------
                    主函数
------------------------------------------------*/
void main (void)
{                  
	unsigned int temp;
	float temperature;
	char displaytemp[16];//定义显示区域临时存储数组
	
	LCD_Init();           //初始化液晶
	DelayMs(20);          //延时有助于稳定
	LCD_Clear();          //清屏
	Init_Timer0();
	LCD_Write_String(0,0," www.nj-ices.com");
	LCD_Write_Char(14,1,'C'); 	//写入字符C

	while (1)         //主循环
	{
		if(ReadTempFlag==1)
		{
			ReadTempFlag = 0;
			temp = ReadTemperature();
			
			temperature = (float)temp*0.0625;
			sprintf(displaytemp,"Temp  % 7.3f",temperature);//打印温度值
			LCD_Write_String(0,1,displaytemp);//显示第二行
		}	
	}
}

/*------------------------------------------------
                    定时器初始化子程序
------------------------------------------------*/
void Init_Timer0(void)
{
	TMOD |= 0x01;	  //使用模式1，16位定时器，使用"|"符号可以在使用多个定时器时不受影响		     
	TH0 = (65536-2000)/256;		  
	TL0 = (65536-2000)%256;
	EA = 1;            //总中断打开
	ET0 = 1;           //定时器中断打开
	TR0 = 1;           //定时器开关打开
}
/*------------------------------------------------
                 定时器中断子程序
------------------------------------------------*/
void Timer0_isr(void) interrupt 1 
{
	static unsigned int num;
	TH0 = (65536-2000)/256;		  //重新赋值 2ms
	TL0 = (65536-2000)%256;	
	num++;
	if(300 == num)        
	{
		num = 0;
		ReadTempFlag = 1; //读标志位置1
	}
}


