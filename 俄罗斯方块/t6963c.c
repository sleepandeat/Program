#include <AT89X52.h>	
#include "t6963c.h"
#include "fangkuai.h"
#include "typedef.h"

static uint txthome=0x0000;
static uint grshome=0x1000;

//LCD接口定义
sfr   PORTD = 0x90 ;
sbit  PCD = P2^7 ;
sbit  PWR = P2^5 ;
sbit  PRD = P2^6 ;

//常量数据
unsigned char code CCTable[] = {
/*冯   CB7EB */
0x00,0x47,0x20,0x29,0x09,0x09,0x11,0x13,0x21,0xE0,0x2F,0x20,0x20,0x20,0x20,0x20,
0x00,0xF8,0x08,0x08,0x10,0x10,0x10,0xFC,0x04,0x04,0xF4,0x04,0x04,0x04,0x28,0x10,

/*燕   CD1E0 */
0x04,0x04,0xFF,0x04,0x17,0x10,0xF7,0x14,0x34,0xD7,0x00,0x28,0x24,0x66,0xC2,0x00,
0x40,0x40,0xFE,0x40,0xC0,0x14,0xDE,0x50,0x52,0xCE,0x00,0x88,0x44,0x66,0x22,0x00,

/*辉   CBBD4 */
0x10,0x13,0x96,0x58,0x51,0xFE,0x28,0x28,0x29,0x28,0x28,0x2B,0x4C,0x48,0x80,0x00,
0x00,0xFE,0x44,0x40,0xFC,0x40,0xA0,0xA0,0xFC,0x20,0x20,0xFE,0x20,0x20,0x20,0x20,

/*制   CD6C6 */
0x24,0x34,0x24,0x3F,0x44,0x04,0x7F,0x04,0x3F,0x24,0x24,0x24,0x24,0x27,0x05,0x04,
0x04,0x04,0x24,0xA4,0x24,0x24,0xA4,0x24,0xA4,0xA4,0xA4,0xA4,0x84,0x84,0x14,0x08,

/*作   CD7F7 */
0x08,0x0C,0x09,0x13,0x12,0x34,0x50,0x90,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,
0x80,0x80,0x00,0xFE,0x80,0x88,0xFC,0x80,0x80,0x84,0xFE,0x80,0x80,0x80,0x80,0x80,

/*得   CB5C3 */
0x13,0x1A,0x23,0x4A,0x8B,0x10,0x13,0x30,0x50,0x97,0x10,0x11,0x11,0x11,0x10,0x10,
0xF8,0x08,0xF8,0x08,0xF8,0x00,0xFE,0x10,0x10,0xFE,0x10,0x10,0x10,0x10,0x50,0x20,

/*分   CB7D6 */
0x08,0x0C,0x08,0x10,0x10,0x20,0x40,0x9F,0x04,0x04,0x04,0x04,0x08,0x10,0x20,0x40,
0x80,0x80,0x40,0x20,0x30,0x18,0x0E,0xE4,0x20,0x20,0x20,0x20,0x20,0xA0,0x40,0x00,

/*等   CB5C8 */
0x20,0x3E,0x28,0x45,0x85,0x3F,0x01,0xFF,0x00,0x00,0x7F,0x04,0x02,0x02,0x00,0x00,
0x80,0xFC,0xA0,0x10,0x10,0xF8,0x00,0xFE,0x20,0x20,0xFC,0x20,0x20,0x20,0xA0,0x40,

/*级   CBCB6 */
0x10,0x13,0x20,0x24,0x44,0xF8,0x10,0x21,0x7D,0x41,0x02,0x1A,0xE4,0x08,0x11,0x06,
0x00,0xF8,0x88,0x88,0x90,0x90,0xBE,0x44,0x44,0x48,0x28,0x10,0x30,0x48,0x8E,0x04,

/*按   CB0B4 */
0x10,0x10,0x10,0x13,0xFE,0x10,0x14,0x1B,0x30,0xD1,0x11,0x10,0x10,0x11,0x56,0x20,
0x40,0x20,0x20,0xFE,0x04,0x40,0x40,0xFE,0x88,0x10,0x90,0x60,0x58,0x8E,0x04,0x00,

/*开   CBFAA */
0x00,0x7F,0x04,0x04,0x04,0x04,0xFF,0x04,0x04,0x04,0x08,0x08,0x10,0x20,0x40,0x00,
0x00,0xFE,0x20,0x20,0x20,0x20,0xFE,0x20,0x20,0x20,0x20,0x20,0x20,0x20,0x20,0x00,

/*始   CCABC */
0x10,0x18,0x10,0x10,0xFC,0x25,0x24,0x44,0x44,0x28,0x18,0x14,0x22,0x42,0x80,0x00,
0x20,0x30,0x20,0x48,0x84,0xFE,0x84,0x00,0xFC,0x84,0x84,0x84,0x84,0xFC,0x84,0x00,

/*太   CCCAB */
0x01,0x01,0x01,0x01,0x7F,0x01,0x01,0x01,0x02,0x02,0x04,0x05,0x08,0x10,0x20,0x40,
0x00,0x00,0x00,0x00,0xFE,0x00,0x00,0x00,0x80,0x40,0x20,0x10,0x98,0xCC,0x86,0x04,

/*棒   CB0F4 */
0x20,0x20,0x27,0x20,0xFB,0x20,0x77,0x69,0xA2,0xAD,0x20,0x27,0x20,0x20,0x20,0x20,
0x40,0x40,0xFC,0x40,0xF8,0x80,0xFE,0x20,0x58,0xF6,0x40,0xFC,0x40,0x40,0x40,0x40,

/*了   CC1CB */
0x00,0x7F,0x00,0x00,0x01,0x01,0x01,0x01,0x01,0x01,0x01,0x01,0x01,0x01,0x05,0x02,
0x00,0xFC,0x18,0x60,0x80,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,

/*！   CA3A1 */
0x00,0x00,0x00,0x00,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x10,0x00,0x10,0x00,
0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00,0x00

};


/////////////////////////底层调用小函数/////////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////

//延时几微秒
void delay(void)
{
 uchar i=0;
 i++;
 i++;
 }
//读状态位0和1，sta0=1:指令读写状态准备好；sta1=1:数据读写状态准备好 
void ST01Read(void)
{
  
	PORTD=0XFF;
	while(1){
		PCD=1;		
		PRD=0;    	
	   	PRD=1;		
		if ((PORTD^0==1)&&(PORTD^1==1))  break;  //判断指令、数据读写状态是否准备好
	
	}
}

//读状态位sta2,    检测数据自动 读 状态是否准备好 
static void ST2Read(void)
{
  
	PORTD=0XFF;
	while(1){
		PCD=1;		 
		PRD=0;    	
		PRD=1;						 
		if (PORTD^2==1)  break;  
	}
}

//读状态位sta3,    sta3=1:数据自动 写 状态准备好 
static void ST3Read(void){
  
	PORTD=0XFF;
	while(1)
	{
		PCD=1;		
		PRD=0;    	
		PRD=1;		
		if (PORTD^3==1)  break; 
	}
}

//读状态位sta6,   检测屏读或屏拷贝出错状态：sta6=1:出错；sta6=0:正确 
static void ST6Read(void)
{
  
	PORTD=0XFF;
	while(1)
	{
		PCD=1;		
		PRD=0;    	
		PRD=1;			
		if (PORTD^6==0)  break;  
	}
}

//////////////////////////////////对T6963C进行读写数据/////////////////////////////////

//写数据
static void WRData(uchar DData)
{
	ST01Read();
	PCD=0;      		
	PORTD=DData;
	PWR=0;
	PWR=1;      		
} 

///读数据
static void RDData(void)
{
	ST01Read();             
	PCD=0;          		
	PRD=0;           		
	PRD=1;          	
}

//写命令
static void WRCommand(uchar command)
{
	ST01Read();	        
	PCD=1;           
	PWR=0;	        	
	PORTD=command;      
	PWR=1;		
}

//单参数指令
static void WRCommandOne(uchar data1,uchar command)
{
	WRData(data1);		//写数据
	WRCommand(command);	//写命令
}
//双参数指令
static void WRCommandTwo(uchar data1,uchar data2,uchar command)
{
	WRData(data1);		//写数据
	WRData(data2);		//写数据
	WRCommand(command);	//写命令
}

////////////////////////////////////////////////////////////////////////////////////

/////////////////////////////T6963C常用处理程序/////////////////////////////////////
////////////////////////////////////////////////////////////////////////////////////

//初始化T6963 LCD 显示
void Init_LCD_Graphic(void)
{
	
	//设置文本显示首地址
	
	WRCommandTwo(0x00,0x00,0x40);
	
	//设置文本显示区宽度 40字节
    
	WRCommandTwo(0x10,0x00,0x41);
	
	//设置图形显示区首地址
	
	WRCommandTwo(0x00,0x10,0x42);	 	//首地址0x0800
	
	//设置图形显示区宽度
	
	WRCommandTwo(0x10,0x00,0x43);	//40字节

    //设置CGRAM的首地址

	WRCommandTwo(0x03,0x00,0x22);		
		
	//设置显示方式	
		
	WRCommand(0x80);	 	//启用内部字符发生器，显示方式是文本与图形逻辑或
	
	//设置显示状态	
			
	WRCommand(0x9f);	//启用光标闪烁、光标显示、文本显示、图形显示
   
}

//清显示RAM
void ClrGraphic(void){
    uint i;
	//设置显示地址
			
	WRCommandTwo(0x00,0x00,0x24);
	
	//进入自动写方式
	
	WRCommand(0xb0);	
	//清8KRAM	
	
   	for(i=0;i<256;i++){
   	
   		WRData(0x00);
   	}   	
   	//退出自动写方式
   	
	WRCommand(0xb2);
}

/////////////////////////////////////////////////////////////////////////
//***********************************************************************
//= 函数原型: void char_addr_Pointer_Set(uchar x, uchar y)
//= 功    能: 根据字符的行列设置vram地址
//= 参    数: x行坐标，y列坐标
//= 返 回 值:
//= 函数性质：私有函数
//***********************************************************************

void char_addr_Pointer_Set(uchar x, uchar y)
{
    uint iPos;
	uint temp;
    iPos = y * 16 + x + txthome;
	temp=iPos;
	y=iPos>>8;
	x=temp&0x00ff;
    WRCommandTwo(x,y,0x24);
} 

//************************************************************************
//= 函数原型: void image_addr_Pointer_Set(uchar x, uchar y)
//= 功    能: 根据的行列设置图形字节的地址
//= 参    数:
//= 返 回 值:
//= 函数性质：私有函数
//************************************************************************
void image_addr_Pointer_Set(uchar x, uchar y)
{ 
    uint iPos;
	uint temp;
    iPos =y * 16 + x + grshome;
	temp=iPos;
	x=iPos>>8;
	y=temp&0x00ff;
    WRCommandTwo(y,x,0x24);
}

//**************************************************************************
//= 函数原型: void Point(uchar x,uchar y, bit Mode)
//= 功    能: 在指定坐标位置显示一个点
//= 参    数: 坐标,显示点或清除点				
//= 返 回 值:
//= 函数性质：私有函数
//= Mode 1:显示 0:清除该点
//**************************************************************************
void Point(uchar x,uchar y, bit Mode)
{
    uint Address;
	uint temp;
    uchar dat;
    Address=(uint)y*16 + (x>>3) + grshome;	  //地址转化
    dat=0xF0+7-x%8;        //产生位操作命令画点的数据
    if(Mode) dat=dat|0x08;
	temp=Address;
	x=Address>>8;
	y=temp&0x00ff;
	WRCommandTwo(y,x,0x24);  //设置该点所在单元地址
    WRCommand(dat);         // 利用位操作命令画点
}

//*****************************************************************************
//= 函数原型: void char_wr(uchar x,uchar y, uchar *p,uchar dataa,uchar n)
//= 功    能: 连续写入一个或多个字符
//= 参    数: 坐标,要显示的字符数组，显示的单个字符，要显示的字符个数				
//= 返 回 值:
//= 函数性质：私有函数
//当n=0一次性写入一个字符，否则一次性写入多个字符
//*****************************************************************************

void char_wr(uchar x,uchar y, uchar *p,uchar dataa,uchar n)
{
    uchar i;
  	char_addr_Pointer_Set(x,y);	//写入地址
	if(n==0)
	  WRCommandOne(dataa,0xc0);	  //一次写入数据
  	else
	  {
	    WRCommand(0xb0);//进入自动写
  		for(i=0;i<n;i++)
		  WRData(p[i]);	 
		  WRCommand(0xb2);   //退出自动写
	  }
}


//******************************************************************************
//= 函数原型: void hanzhi(uchar x,uchar y, uchar m,uchar n)
//= 功    能: 连续写入一个或多个汉字
//= 参    数: 坐标,要显示的第一个汉字的位置，连续显示汉字的个数。				
//= 返 回 值:
//= 函数性质：私有函数
//当n=1一次性写入一个字符，否则一次性写入多个字符
//*****************************************************************************

void hanzhi(uchar x,uchar y, uchar m,uchar n)
{
    uchar i;
    uchar CGRam;
	CGRam=0x80+4*m;	 //第m个字符
	for(i=0;i<n;i++)
	{
	  char_addr_Pointer_Set(x,y); //汉字左上角写入
	  WRCommandOne(CGRam,0xc0);	  //一次写入数据;
	  CGRam++;
	  y++;
	  char_addr_Pointer_Set(x,y); //汉字左下角写入
	  WRCommandOne(CGRam,0xc0);
	  CGRam++;
	  x++;
	  y--;
	  char_addr_Pointer_Set(x,y); //汉字右上角写入
	  WRCommandOne(CGRam,0xc0);
	  CGRam++;
	  y++;
	  char_addr_Pointer_Set(x,y); //汉字右下角写入
	  WRCommandOne(CGRam,0xc0);
	  CGRam++;
	  x++;
	  y--;
	  if(x==16)
	  {
	    x=0;		//写满一行，从第二行开始
		y++;
		y++;
	  }
	}
}

//******************************************************************************
//= 函数原型: void fill_CGRAM(uchar *p,uchar m,uinit n)
//= 功    能: 填充CGRAM数据
//= 参    数: 字符数组，写入第m个汉字，循环写入的汉字个数
//= 返 回 值:
//= 函数性质：私有函数
//*//**************************************************************************

void fill_CGRAM(uchar *p,uchar m,uint n)
{
  uchar xx;
  uchar yy;
  uint i;
  uint ADCGram;
  uint temp;
  ADCGram=0x1c00+32*m;	//确定CGRAM地址
  temp=ADCGram;
  xx=ADCGram>>8;
  yy=temp&0x00ff;
  WRCommandTwo(yy,xx,0x24);

  n=n*32;
  WRCommand(0xb0);
  for(i=0;i<n;i++)
	WRData(p[i]);
  WRCommand(0xb2);   //退出自动写
}

//*******************************************************************************
//= 函数原型: void Wr_line(uchar type,uchar x1,uchar y1, uchar Long,uchar mode)
//= 功    能: 画一条横线或一条竖线
//= 参    数: type=1为横线，否则为竖线，(x1,y1)为起始点，Long为长度，mode=1为显示				
//= 返 回 值:
//= 函数性质：公有函数
//*******************************************************************************  

void Wr_line(uchar type,uchar x1,uchar y1, uchar Long,uchar mode){
 uchar i;
if(type==1)
 {
   for(i=0;i<Long;i++)	 //画横线
	{ 
	   if(mode==1)
		  Point(x1+i,y1,1);
	   else  
		  Point(x1+i,y1,0);
	 }
	 return;
  }
  
else
 {
    for(i=0;i<Long;i++)		//画竖线
	{ 
	   if(mode==1)
		  Point(x1,y1+i,1);
	   else  
		  Point(x1,y1+i,0);
	}
	 return; 
  }
}

//*****************************************************************************
//= 函数原型: void Show_Image(uchar x1,uchar y1,uchar x2,uchar y2,bit mode)
//= 功    能: 填充区域（x1,y1) (x2,y2)
//= 参    数: (x1,y1)为起始点，（x2,y2)为终点  mode=1显示				
//= 返 回 值:
//= 函数性质：私有函数
//= 注    意：以点为单位
//*****************************************************************************  	 

void Show_Image(uchar x1,uchar y1,uchar x2,uchar y2,bit mode)
{
  char temp=x1;
  if(mode)   
   {
	 for(;y1<=y2;y1++)
	   for(x1=temp;x1<=x2;x1++)
	     Point(x1,y1,1);
   }
   else
   {
	 for(;y1<=y2;y1++)
	   for(x1=temp;x1<=x2;x1++)
	     Point(x1,y1,0);
   }
}

//**********************************************************************************
//= 函数原型: void image(uchar x1,uchar y1,uchar x2,uchar y2,uchar *p,bit mode)
//= 功    能: 在设定的区域连续写入多个字节，作图形显示用
//= 参    数: (x1,y1)为起始点，（x2,y2)为终点  *po为图形数组，mode=1显示 mode=0清除			
//= 返 回 值:
//= 函数性质：私有函数
//= 操作方法：当p=0,mode=1时，连续输入0xff,作反显用，当p=0,mode=0时，连续输入0x00,作 
//=            消除反显用,当p!=0时，作输入图像用，此时mode无效
//= 注    意：参数的数据范围
//**********************************************************************************  
void image(uchar x1,uchar y1,uchar x2,uchar y2,uchar *p,bit mode)
{
   uchar temp=x1;
   uint i=0;
   for(;y1<=y2;y1++)
   {
    x1=temp;	 
    image_addr_Pointer_Set(x1,y1);	//写入地址
	WRCommand(0xb0); //进入自动写
	for(;x1<=x2;x1++)
	{
	  if(p==0&&mode==1)
	  {
	     WRData(0xff);
	  }
	  else if(p==0&&mode==0)
	  {
	     WRData(0x00);
	  }
	  else 
	  {
	     WRData(p[i]);
	     i++;		 //下一个字节
	  }
	}
    WRCommand(0xb2);   //退出自动写 
    }
}

//******************************************************************************
//= 函数原型: void negShow(uchar x1,uchar y1,uchar x2,uchar y2,bit mode)
//= 功    能: 反显区域（x1,y1) (x2,y2)
//= 参    数: (x1,y1)为起始点，（x2,y2)为终点  mode=1反显				
//= 返 回 值:
//= 函数性质：私有函数
//= 注    意：以字节为单位
//******************************************************************************  	 
void negShow(uchar x1,uchar y1,uchar x2,uchar y2,bit mode)
{
   if(mode)
   {
     WRCommand(0x81);	 	//启用内部字符发生器，显示方式是文本与图形逻辑异或
  	 image(x1,y1,x2,y2,0,1);

	}
   else
    {
	  WRCommand(0x80);	 	//启用内部字符发生器，显示方式是文本与图形逻辑或
	  image(x1,y1,x2,y2,0,0);
	 }
}

//******************************************************************************
//= 函数原型: void Show_num(uchar x1,uchar y1,uchar num)
//= 功    能: 在设定的位置显示一个数字
//= 参    数: (x1,y1)为位置，num为数字			
//= 返 回 值:
//= 函数性质：公有函数
//= 注    意：以字节为单位
//*****************************************************************************  
void Show_num(uchar x1,uchar y1,uchar num)
{
   uchar number[10]={0x10,0x11,0x12,0x13,0x14,0x15,0x16,0x17,0x18,0x19};
   char_addr_Pointer_Set(x1,y1);
   WRCommandOne(number[num],0xc0);	  //一次写入数据
}

///////////////////////////初始化LCD////////////////////////////////////////////
void Init_LCD()
{
   Init_LCD_Graphic();
   ClrGraphic();
   fill_CGRAM(CCTable,0,22);	 //将汉字写入CGRAM
}

