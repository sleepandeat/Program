/*-----------------------------------------------
名称：继电器
公司：南京爱思电子
编写：rantg
日期：2012.3
内容：独立按键S3控制继电器开关，用杜邦线将ULN2003
	  的Relay输入端的P1.0连起来
------------------------------------------------*/

#include<reg52.h> 

sbit K1 = P3^0;
sbit RELAY = P1^0;	//继电器信号输出端

/*------------------------------------------------
                  函数声明
------------------------------------------------*/
void DelayMs(unsigned int t); //ms级延时

/*------------------------------------------------
                    主函数
------------------------------------------------*/
void main (void)
{                 
	while (1)         
	{
		if(0 == K1)
		{
			DelayMs(10);
			if(0 == K1)
			{
				RELAY = !RELAY;
				DelayMs(1000);
			}
			while(!K1);
		}
	}	
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