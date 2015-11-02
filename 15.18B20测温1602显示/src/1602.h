#ifndef __1602_H__
#define __1602_H__

#include<reg52.h> 

extern void LCD_Write_Com(unsigned char com) ;
extern void LCD_Write_Data(unsigned char Data) ;
extern void LCD_Clear(void) ;
extern void LCD_Write_String(unsigned char x,unsigned char y,unsigned char *s) ;
extern void LCD_Write_Char(unsigned char x,unsigned char y,unsigned char Data) ;
extern void LCD_Init(void) ;

#endif
