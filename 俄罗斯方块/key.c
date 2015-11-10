#include <AT89X52.h>
#include "typedef.h"

#define Nothing 100
//端口定义
sbit C1 = P2^3;
sbit C2 = P2^4;
sbit C3 = P3^2;
sbit C4 = P3^3;

sbit R1 = P3^4;
sbit R2 = P3^5;
sbit R3 = P3^0;
sbit R4 = P3^1;

uchar Key=Nothing;		  //键盘缓冲寄存器（公有数据）
uchar Fn_Key;			 //功能键

//*********************************************************************
//= 函数原型: void KEYPAD_Scan(char* const Key, char* const Fn_Key)
//= 功    能: 扫描键盘
//= 参    数: 普通键New_Key，功能键New_FuncKey,缓存器的指针
//= 返 回 值:
//= 函数性质：私有函数
//**********************************************************************

void KEYPAD_Scan(char* const Key, char* const Fn_Key)
{

   C1 = 0; 
      if (R1 == 0) *Fn_Key = 'o'; //ON键
      if (R2 == 0) *Key    =  0;
      if (R3 == 0) *Fn_Key = '=';
      if (R4 == 0) *Key    = '+';
   C1 = 1;

   C2 = 0; 
      if (R1 == 0) *Key = 1;
      if (R2 == 0) *Key = 2;
      if (R3 == 0) *Key = 3;
      if (R4 == 0) *Key = '-';
   C2 = 1;

   C3 = 0; 
      if (R1 == 0) *Key = 4;
      if (R2 == 0) *Key = 5;
      if (R3 == 0) *Key = 6;
      if (R4 == 0) *Key = '*';
   C3 = 1;

   C4 = 0; 
      if (R1 == 0) *Key = 7;
      if (R2 == 0) *Key = 8;
      if (R3 == 0) *Key = 9;
      if (R4 == 0) *Key = '/';   

   C4 = 1;

}
//*********************************************************************
//= 函数原型: void KEY_Update()
//= 功    能: 键盘缓冲寄存器更新程序. 普通键Key, 功能键Fn_Key
//= 参    数: 
//= 返 回 值:
//= 函数性质：公有函数
//**********************************************************************
void KEY_Update() 
{
   static uchar delay=20;		//去抖动延时
   static bit delaying=0;		//标识是否正在延时

   if(delaying==0)
   {
       if(Key==Nothing)		   //如果Key缓存器中的数据未被读取，则不扫描键盘
	   {
	      KEYPAD_Scan(&Key,&Fn_Key);	   //扫描键盘
		  if(Key!=Nothing)
		  {
		     delaying=1; 
			 Key=Nothing; 

		   }
		}
   }
   else
   {
      if(delay==0)				 //延时结束
	  {
	     KEYPAD_Scan(&Key,&Fn_Key);	   //读取键盘
		 delay=20;
		 delaying=0;
	  }
	  else   delay--;			//延时减一
   }
}						   


  


    
