/*--------------------------------------------------------------------
名称：矩阵键盘
公司：南京爱思电子
编写：rantg
日期：2012.3
内容: 矩阵键盘行列扫描并在数码管显示相应的键值，使用矩阵
      键盘时，开发板上P21复用端通过跳帽接到矩阵键盘端
--------------------------------------------------------------------*/

#include <reg52.h>

typedef unsigned char uchar;
typedef unsigned int  uint;

unsigned char code table[] = {0x3f,0x06,0x5b,0x4f,0x66,0x6d,0x7d,0x07,0x7f,0x6f,
		                  	 0x77,0x7c,0x39,0x5e,0x79,0x71};//0-F
 
uchar KeyScan(void);
void DelayMs(uint i);

void main(void)
{
	uchar key;
	P0 = 0x00;			//1数码管亮 按相应的按键，会显示按键上的字符
	P1 = 0xf7;
	while(1)
	{
		key=KeyScan();	//调用键盘扫描，
		switch(key)
		{		   
			case 0x7e:P0 = table[0];break;//0 按下相应的键显示相对应的码值
			case 0x7d:P0 = table[1];break;//1
			case 0x7b:P0 = table[2];break;//2
			case 0x77:P0 = table[3];break;//3
			case 0xbe:P0 = table[4];break;//4
			case 0xbd:P0 = table[5];break;//5
			case 0xbb:P0 = table[6];break;//6
			case 0xb7:P0 = table[7];break;//7
			case 0xde:P0 = table[8];break;//8
			case 0xdd:P0 = table[9];break;//9
			case 0xdb:P0 = table[10];break;//a
			case 0xd7:P0 = table[11];break;//b
			case 0xee:P0 = table[12];break;//c
			case 0xed:P0 = table[13];break;//d
			case 0xeb:P0 = table[14];break;//e
			case 0xe7:P0 = table[15];break;//f
		}
	}
}

uchar KeyScan(void)//键盘扫描函数，使用行列反转扫描法
{
	uchar cord_h,cord_l;	//行列值
	P3 = 0xf0;            //行线输出全为0
	cord_h = P3&0xf0;     //读入列线值
	if(cord_h != 0xf0)    //先检测有无按键按下
	{
		DelayMs(100);        //去抖
		if(cord_h != 0xf0)
		{
			cord_h = P3&0xf0;  //读入列线值
			P3 = cord_h|0x0f;  //输出当前列线值
			cord_l = P3&0x0f;  //读入行线值
			return(cord_h+cord_l);//键盘最后组合码值
		}
	}
	return(0xff);     //返回该值
}


/*------------------------------------------------
				 延时函数
------------------------------------------------*/
void DelayMs(unsigned int t)
{
	unsigned char i;
	for(;t > 0;t--)
		for(i = 110;i > 0;i--);
}