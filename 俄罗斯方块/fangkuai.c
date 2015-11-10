#include "t6963c.h"
#include "typedef.h"
#include "key.h"

#define X_START 5
#define Y_START 0
#define MIN_SLOW_SPEED  300
#define BX_START  30
#define BY_START  15
#define Nothing   100


//全局数据
code uchar Game_Char[]={0x27,0x41,0x4d,0x45};
code uchar Over_Char[]={0x2f,0x56,0x45,0x52};
				                            
static uchar xx,yy;         //方块的位置
static uint  Game_Score=0;
static uchar xdata Platform[14][21];    //游戏平台数据
static uchar This_shape;				//当前形状
static uchar Next_shape=0;
static uint  Game_Speed=MIN_SLOW_SPEED;	 //等级速度，正常情况，方块下降的速度
static uchar Game_Stop=1;
static uchar Game_Level=0;

/////////////////////////////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////
/////////方块形状的定义//////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////////////////////////////
struct POINT{
              uchar x;
              uchar y;
             };

struct SHAPE{
               struct POINT point[4];
			   uchar next;	//下一个形状
			 } 


xdata shape[19]={ 
  
                   { 1,0,0,1,1,1,2,1,1  },
				   { 1,0,1,1,2,1,1,2,2  },
				   { 0,0,1,0,2,0,1,1,3  },
				   { 1,0,0,1,1,1,1,2,0  },
				    
				   { 1,0,2,0,1,1,1,2,5  },
				   { 0,0,1,0,2,0,2,1,6  },
				   { 2,0,2,1,2,2,1,2,7  },
				   { 0,0,0,1,1,1,2,1,4  },

				   { 1,0,2,0,2,1,2,2,9  },
				   { 2,0,0,1,1,1,2,1,10 },
				   { 1,0,1,1,1,2,2,2,11 },
				   { 0,0,1,0,2,0,0,1,8  },

				   { 0,0,0,1,1,1,1,2,13 },
				   { 1,0,2,0,0,1,1,1,12 },

				   { 2,0,1,1,2,1,1,2,15 },
				   { 0,0,1,0,1,1,2,1,14 },

				   { 1,0,1,1,1,2,1,3,17 },
				   { 0,1,1,1,2,1,3,1,16 },

				   { 1,0,2,0,1,1,2,1,18 }, 	
				   	 
				};   

////////////////////////////////////////////////////////////////////////////
//**************************************************************************
//= 函数原型:void Init_GamePlatform()
//= 功    能: 初始化游戏平台
//= 参    数: 无			
//= 返 回 值: 无
//= 函数性质：公有函数
//= 注    意：
//*************************************************************************** 
void Show_score(uchar);
void Init_GamePlatform()
{
  uchar i;
  uchar j;
  uchar N_Hanzi;
  
  Wr_line(1,33,13,64,1 );	//初始化游戏平台边界	画游戏区域
  Wr_line(1,33,14,64,1 );   //画上横线
  Wr_line(0,33,15,100,1);
  Wr_line(0,34,15,100,1);  //画左竖线
  Wr_line(1,33,115,64,1);  
  Wr_line(1,33,116,64,1);  //画下横线
  Wr_line(0,95,15,100,1);
  Wr_line(0,96,15,100,1);  //画右竖线
//--------------------------------------------------------
  for(i=1;i<13;i++)		//游戏平台数据清零
  {
    for(j=0;j<20;j++)
	  {
	    Platform[i][j]=0;
	  }
   }
   for(i=1;i<13;i++)
   {
      Platform[i][20]=1;   //游戏平台最下面一行的每一个方块位置为１，作为下边界
	}
   
   for(j=0;j<20;j++)		//游戏平台左右方块位置置１，作为左右边界
   {
      Platform[0][j]=1;
	  Platform[13][j]=1;
   }
//--------------------------------------------------------- 
  N_Hanzi=0;             
  for(j=3;j<=12;j=j+2)	   //输入“冯燕辉制作”汉字
  {
     hanzhi(1,j,N_Hanzi,1);
	 N_Hanzi++;   //指向下一个汉字
  }
  
  hanzhi(13,3,6,1);	 //输入“分”汉字
  hanzhi(13,8,8,1);   //输入“级”汉字

  Show_score(0);        //显示初始分数
  Show_num(13,11,Game_Level);	 //显示初始等级水平
  Game_Speed=MIN_SLOW_SPEED/(Game_Level+1);  //根据水平确定速度

//------------------------------------------------------------------
  Game_Score=0;
  xx=X_START ;
  yy=Y_START ;
}
////////////////////////Init_Game/////////////////////
void Init_Game()
{
  Game_Stop=1;
  Init_GamePlatform();
  hanzhi(7,3,9,1);	 //输入“按”汉字
  Show_num(7,6,7);	 //显示7
  hanzhi(7,8,10,1);	 //输入“开”汉字
  hanzhi(7,10,11,1);	 //输入“始”汉字
}
//**************************************************************************
//= 函数原型:void XiaoFengKuai(uchar x,uchar y,uchar mode)
//= 功    能: 显示一个小方块
//= 参    数: 小方块的横x，坚坐标y,mode=1:显示小方块,mode=0:删除小方块			
//= 返 回 值:
//= 函数性质：私有函数
//= 注    意：
//*************************************************************************** 
void XiaoFengKuai(uchar x,uchar y,bit mode)
{
   uchar x1=5*x+BX_START;	//将方块在平台的位置转化成ＬＣＤ的点坐标(地址转换）
   uchar y1=5*y+BY_START;	  
   uchar i;

   if(mode==1)
   {

       for(i=0;i<5;i++)
       {
          Point(x1+i,y1,1); //画一条横线
       }


       	y1+=4;

        for(i=0;i<5;i++)
        {
           Point(x1+i,y1,1); //画第二条横线
         }

        for(i=0;i<5;i++)
        {
           Point(x1,y1-i,1); //画第1条坚线
         }

         x1+=4;

        for(i=0;i<5;i++)
        {
           Point(x1,y1-i,1); //画第2条坚线
         }

        y1-=4;
        for(i=0;i<5;i++)
        {
           Point(x1-i,y1+i,1); //画斜线
        }
   }

  else
  {
  	   for(i=0;i<5;i++)
        {
          Point(x1+i,y1,0); //画一条横线
      	}

       	y1+=4;
        for(i=0;i<5;i++)
         {
           Point(x1+i,y1,0); //画第二条横线
         }

         for(i=0;i<5;i++)
         {
            Point(x1,y1-i,0); //画第1条坚线
          }

         x1+=4;
        for(i=0;i<5;i++)
          {
             Point(x1,y1-i,0); //画第2条坚线
          }

        y1-=4;
        for(i=0;i<5;i++)
         {
           Point(x1-i,y1+i,0); //画斜线
         }
	}
}
//////////////////////////////////////////////////////////////////////////
////////////////左冲突检测//////////////////////////////////////////////
bit Left_Anti()
{
  uchar i;
  for(i=0;i<4;i++)
	{
	  if(Platform[xx+shape[This_shape].point[i].x-1][yy+shape[This_shape].point[i].y]==1) 
	    return 1;
	}
  return 0;
}	   

////////////////右冲突检测///////////////////////////////////////////
bit Right_Anti()
{
  uchar i;
  for(i=0;i<4;i++)
	{
	  if(Platform[xx+shape[This_shape].point[i].x+1][yy+shape[This_shape].point[i].y]==1)
	    return 1;
	}			   
  return 0;
  
}

////////////////////////////////////////下冲突检测//////////////////////////
bit Bottom_Anti()
{
   uchar i;
   for(i=0;i<4;i++)
	{
	  if(Platform[xx+shape[This_shape].point[i].x][yy+shape[This_shape].point[i].y+1]==1)
	    return 1;
    }
  return 0;			  
}
//////////////////////////////////改变形状时产生的冲突检测////////////////////
bit Change_Shape_Anti()
{
   uchar i;
   for(i=0;i<4;i++)
	{
	  if(Platform[xx+shape[shape[This_shape].next].point[i].x][yy+shape[shape[This_shape].next].point[i].y]==1)
	    return 1;	   //检测一个形状的冲突情况
    }
   return 0;
}
//////////////////////////////////产生一个随机数,返回一个随机数///////////////
uchar Random()
{
  static uchar m;
  m+=49;
  return (m%19);
}

//////////////计分函数,参数为 消行行数n///////////////////////////////////////

void Show_score(uchar n)
{
  Game_Score=Game_Score+10*n;

  if(Game_Score<10)
  {
     Show_num(13,6,Game_Score%10);		//显示个位
  }
  else if(Game_Score<100)
  {  
     Show_num(14,6,Game_Score%10);
	 Show_num(13,6,Game_Score/10%100);	//显示个位,十位
  }
  else if(Game_Score<1000)
  {
     Show_num(14,6,Game_Score%10);
	 Show_num(13,6,Game_Score/10%10);
	 Show_num(12,6,Game_Score/100%10);	//显示个位 ,十位,百位
  }
  else
  {  
	 Show_num(15,6,Game_Score%10);
	 Show_num(14,6,Game_Score/10%10);
	 Show_num(13,6,Game_Score/100%10);	//显示个位 ,十位,百位,千位
	 Show_num(12,6,Game_Score/1000);
  }
  
  if(Game_Score%1000==0)
  {
    if(Game_Score>0)
	{
       Game_Level++;
       if(Game_Level==10)
	   {
	      Game_Stop=1;
	      hanzhi(7,5,12,1);	 //	输出“太棒了"
          hanzhi(7,7,13,1);	 
		  hanzhi(7,9,14,1);
		  
	   }
       Show_num(13,11,Game_Level);	 //显示水平
	
    }
  }
}

//**************************************************************************
//= 函数原型:void Undisplay_line()
//= 功    能: 消除行
//= 参    数: 无			
//= 返 回 值: 无
//= 函数性质：私有函数
//= 注    意：
//***************************************************************************   
void UnDisplay_line()
{
   uchar Del_Line;      //标识要删除的行
   uchar Del_Line_Num=0;     //标识删除的行数
   uchar i,j,k;
   bit HavePoint;		    //标识一行中是否有空白点

   for(i=0;i<4;i++)
   {
      for(j=1;j<13;j++)
	  {
	     if(Platform[j][yy+i]==0) 
		    break;                   //如果这一行中有一个为空，则退出这一行的循环
		 else if(j==12)
		 {
		    Del_Line=yy+i;  	       //确定要删除的行
			if(Del_Line<20)
			{
			   Del_Line_Num++;	           //计算共删除的行数
			for(k=1;k<13;k++)
			{
			    XiaoFengKuai(k,Del_Line,0);   	//删除行
				Platform[k][Del_Line]=0;         //平台数据清零
			}
			while(1)     //下移
			{
			   HavePoint=0;
			   for(k=1;k<13;k++)
			   {
			      if(Platform[k][Del_Line-1]==1)
				  {
				     HavePoint=1;            //标识这一行有要下移的点
				     XiaoFengKuai(k,Del_Line-1,0);   	//删除小方块
					 Platform[k][Del_Line-1]=0;         //平台数据清零
					 XiaoFengKuai(k,Del_Line,1) ;  	//将小方块下移
					 Platform[k][Del_Line]=1;         //平台数据置1,表明此位置已被占用
				   }
			   }
			   if(HavePoint==0) break;  //没有要下移的行，退出本循环
			   Del_Line--;   //下移上一行
			}
			}
		 }
      }		
   }
   if(Del_Line_Num)
	 {
	    Show_score(Del_Line_Num);	  //刷新分数显示
	 }
}			    
			   
//**************************************************************************
//= 函数原型:void Show_shape(uchar x1,uchar y1,uchar Tshape,bit mode)
//= 功    能: 显示一个方块形状或删除一个方块形状
//= 参    数: (x1,y1)为显示位置,Tshape为显示的形状,mode=1为显示,mode=0不显示			
//= 返 回 值:
//= 函数性质：私有函数
//= 注    意：
//*************************************************************************** 
void Show_shape(uchar x1,uchar y1,uchar Tshape,bit mode)
{
  if(mode==1)
  {

     XiaoFengKuai(x1+shape[Tshape].point[0].x,y1+shape[Tshape].point[0].y,1);	 //显示形状
	 XiaoFengKuai(x1+shape[Tshape].point[1].x,y1+shape[Tshape].point[1].y,1);
	 XiaoFengKuai(x1+shape[Tshape].point[2].x,y1+shape[Tshape].point[2].y,1);
	 XiaoFengKuai(x1+shape[Tshape].point[3].x,y1+shape[Tshape].point[3].y,1);
  }
  else
  {
     XiaoFengKuai(x1+shape[Tshape].point[0].x,y1+shape[Tshape].point[0].y,0);  //删除形状
	 XiaoFengKuai(x1+shape[Tshape].point[1].x,y1+shape[Tshape].point[1].y,0);
	 XiaoFengKuai(x1+shape[Tshape].point[2].x,y1+shape[Tshape].point[2].y,0);
	 XiaoFengKuai(x1+shape[Tshape].point[3].x,y1+shape[Tshape].point[3].y,0);
  }
}

//**************************************************************************
//= 函数原型:void Fangkuai_down()
//= 功    能: 方块下降处理
//= 参    数: 			
//= 返 回 值:
//= 函数性质：公有函数
//= 注    意：
//***************************************************************************   
static uint DSpeed=MIN_SLOW_SPEED;		   //标识下降速度
static uint Now_Speed=MIN_SLOW_SPEED;         //当前速度
void Fangkuai_down()
{ 
  uchar i;
  static bit New_shape=1;		 //标识是否要产生新形状
  if(Game_Stop==1) return;
  if(New_shape==1)
  {
    New_shape=0;
    xx=X_START;
	yy=Y_START;
    This_shape=Next_shape;			    //当前方块等于预方块
	Show_shape(15,18,Next_shape,0);	    // 产生一下个方块前，将预方块删除
	Next_shape=Random();		        //产生下一个方块
	Show_shape(xx,yy,This_shape,1);		 //显示当前方块
	Show_shape(15,18,Next_shape,1);		 //预显示下一个方块
	if(Bottom_Anti())
	{
	   Game_Stop=1;
       Show_Image(35,15,94,114,0); 	  //清屏
	   char_wr(6,6,Game_Char,0,4); //显示Game 
	   char_wr(6,8,Over_Char,0,4); //显示over
	   return;
	} 
  }
  else
  {
      if(DSpeed==0)
	    {
	       DSpeed=Now_Speed;	//确定方块下落的速度
	       if(Bottom_Anti())
	         {
	             New_shape=1;//产生新的形状
	            for(i=0;i<4;i++)
	             {
	               Platform[xx+shape[This_shape].point[i].x][yy+shape[This_shape].point[i].y]=1;//写入平台
		          
		         }
				 UnDisplay_line();//消行计分
				 return;
              }
	       else
	         {
	           Show_shape(xx,yy,This_shape,0); //删除当前形状
	           yy++;
               Show_shape(xx,yy,This_shape,1); //显示形状(形状下移一个位置)
	           return;
	          }
       	}
      else
       {
          DSpeed--;
	      
        }
	
    }
}

//**************************************************************************
//= 函数原型:void Fangkuai_Control()
//= 功    能: 方块游戏控制
//= 参    数: 			
//= 返 回 值:
//= 函数性质：公有函数
//= 注    意：
//*************************************************************************** 
#define Move_Left    4
#define Move_Right 	 6
#define Add_Speed    5
#define Change_Shape 8
#define Game_Star    7
#define Game_Pause   9

void Fangkuai_Control()
{
   	
	 switch(Key)    //消息处理
	 {
	     case  Move_Left: 
		       {
			      Key=Nothing;  //信息已被处理，抛弃它
	              if(!Left_Anti())
	              {
	   	             Show_shape(xx,yy,This_shape,0); //删除当前形状
	                 xx--;
		             Show_shape(xx,yy,This_shape,1); //显示移动后的形状
	              }
			   }break;
	     case  Move_Right:
		      {
			     Key=Nothing;  //信息已被处理，抛弃它
	             if(!Right_Anti())
	             {
	   	            Show_shape(xx,yy,This_shape,0); //删除当前形状
	                xx++;
		            Show_shape(xx,yy,This_shape,1); //显示移动后的形状
	             }
			  }break;
	     case  Add_Speed:
		       {
			       Key=Nothing;		  //信息已被处理，抛弃它
				   if(Game_Stop==1)
					{
					   if(Game_Level==0)
					   {
					      Game_Level=9;
						  Show_num(13,11,9);	 //显示等级水平
						  Game_Speed=MIN_SLOW_SPEED/(Game_Level+1);  //根据水平确定速度
						}
						else
						{
						   Game_Level--;
						   Show_num(13,11,Game_Level);	 //显示等级水平
						   Game_Speed=MIN_SLOW_SPEED/(Game_Level+1);  //根据水平确定速度
						}
					 }
					else
					{
				      Now_Speed=1;			   //调整位置后，加速下降
				      DSpeed=Now_Speed;
					}
			   }break;
	     case  Change_Shape:
		        {
				    Key=Nothing;	   //信息已被处理，抛弃它
					if(Game_Stop==1)
					{
					   if(Game_Level==9)
					   {
					      Game_Level=0;
						  Show_num(13,11,0);	 //显示等级水平
						  Game_Speed=MIN_SLOW_SPEED/(Game_Level+1);  //根据水平确定速度
						}
						else
						{
						   Game_Level++;
						   Show_num(13,11,Game_Level);	 //显示等级水平
						   Game_Speed=MIN_SLOW_SPEED/(Game_Level+1);  //根据水平确定速度
						}
					 }
					else
					{

				       if(!Change_Shape_Anti())
				       {
				          Show_shape(xx,yy,This_shape,0); //删除当前形状
			              This_shape=shape[This_shape].next;
				          Show_shape(xx,yy,This_shape,1); //显示变化后的形状
				        }
					}
			    }break;
		case  Game_Star:
		      {
			     Key=Nothing;		  //信息已被处理，抛弃它
				 ClrGraphic();
				 Show_Image(35,15,94,114,0);
			     Init_GamePlatform();
				 Game_Stop=0;
			  }break;
		case  Game_Pause:
		      {
			     Key=Nothing;		  //信息已被处理，抛弃它
			     Game_Stop=!Game_Stop;
			  }
		default:Now_Speed=Game_Speed;
	  }
}



