#ifndef _t6963c_h //防止在同一模块多次包含
  #define _t6963c_h 

#include "typedef.h"  


void hanzhi(uchar row,uchar col, uchar m,uchar n);		 //写入汉字
void Init_LCD_Graphic(void);			   //t6963c初始化
void ClrGraphic(void);		 //清显示RAM
void Point(uchar x,uchar y, bit Mode);	   //画点函数
void Wr_line(uchar type,uchar x1,uchar y1, uchar Long,uchar mode);	   // 画一条横线或竖线
void image(uchar x1,uchar y1,uchar x2,uchar y2,uchar *p,bit mode);	// 在设定的区域连续写入多个字节，作图形显示用
void negShow(uchar x1,uchar y1,uchar x2,uchar y2,bit mode) ; //= 功    能: 反显区域（x1,y1) (x2,y2)
void Show_num(uchar x1,uchar y1,uchar num);	 //在设定位置写入一个数字
void Show_Image(uchar x1,uchar y1,uchar x2,uchar y2,bit mode); //显示一个区域或删除一个区域
void Init_LCD();
void char_wr(uchar row,uchar col, uchar *p,uchar dataa,uchar n);   //写入字符

#endif
