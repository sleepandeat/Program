#ifndef __DS18B20_H__
#define __DS18B20_H__

#include<reg52.h>    
 
/*------------------------------------------------
                    端口定义
------------------------------------------------*/
sbit DQ=P3^5;//ds18b20 端口

/*------------------------------------------------
                  函数声明
------------------------------------------------*/
extern unsigned int ReadTemperature(void);
extern bit Init_DS18B20(void);
extern unsigned char ReadOneChar(void);
extern void WriteOneChar(unsigned char dat);

#endif
