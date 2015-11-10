#ifndef _KEY_H
  #define _KEY_H
  #include "typedef.h"
  #define  Nothing 100
  extern uchar Key;		   //键盘缓冲寄存器（公有数据）普通按键
  extern uchar Fn_Key;	   //功能键
  void KEY_Update();  
 
#endif