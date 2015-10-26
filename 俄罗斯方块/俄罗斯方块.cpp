// 俄罗斯方块.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"
#include "all_include.h"
extern int fx[4][4];
extern int all_xy[35][60];
extern int lx1[4][4],lx2[4][4],lx3[4][4],lx4[4][4];
extern int sx1[4][4],sx2[4][4],zx1[4][4],zx2[4][4];
extern int tx1[4][4],tx2[4][4],tx3[4][4],tx4[4][4];
extern int jx1[4][4],jx2[4][4],jx3[4][4],jx4[4][4];
extern int ix1[4][4],ix2[4][4];
int (*now)[4],(*next)[4],rand_data=0,olde_rand=0;
int ll=0,ss=0,zz=0,tt=0,ii=0,jj=0,fenshu=0;
POINT begin_xy,print_xy;
int key,i,j,sleep_time=10,end_hand=0,in_time=0;
int main()
{
	BOOL push=FALSE;
	HWND hwnd = FindWindow("ConsoleWindowClass", NULL);
	HideCursor();
	SetWindowText(hwnd,"俄罗斯方块  sleepandeat");
	while(1)
	{
		begin_xy.x=7,begin_xy.y=1,fenshu=0,sleep_time=30;
		srand(time(NULL));next=&fx[0];
		chushihua();
		memset(all_xy,0,sizeof(all_xy));
		my_switch();
		show_next(next);
		for(i=0;i<24;i++)//初始化二维数组
		{
			all_xy[i][0]=1;all_xy[22][i*2]=1;all_xy[i][32]=1;
		}
		while(1)
		{
			while(kbhit())			//如果有输入
				{
					end_e();
					key=get_key();		//得到输入的按键码
					if(push)push=!push;
					switch(key)			//匹配按键码
					{
						case KEY_PUSH:
							while(found_error(begin_xy,now))
							{
								begin_xy.y++;end_hand++;
							}break;
						case 115:
						case KEY_DOWN:end_hand++;
							if(begin_xy.y>=20)break;
							begin_xy.y++;if(!found_error(begin_xy,now))begin_xy.y--;break;
						case 119:
						case KEY_UP:change_tx();break;
						case 97:
						case KEY_LEFT :begin_xy.y--;begin_xy.x--;if(!found_error(begin_xy,now))begin_xy.x++;begin_xy.y++;break;
						case 100:
						case KEY_RIGHT:
							begin_xy.x++;begin_xy.y--;
							if(!found_error(begin_xy,now))begin_xy.x--;
							begin_xy.y++;break;
						case KEY_ESC:  if(6==MessageBox(hwnd,"是否退出？","询问",MB_YESNO|MB_ICONQUESTION))return 0;break;
						case KEY_ADD:if(sleep_time>=10)sleep_time-=10;break;
						case KEY_NADD:if(sleep_time<1000)sleep_time+=10;break;
						default:push=!push;break;//printf("%d",key);getch();
					}
					print_e();
				}
			Sleep(sleep_time);
			if(!found_error(begin_xy,now))
			{
				if(end_hand==0)
				{
					PlaySound((LPCTSTR)"resource\\aced.wav", NULL, SND_FILENAME | SND_ASYNC);
					if(6==MessageBox(hwnd,"\t游戏结束！是否重新开始？\n游戏简介：\n\t这是一个用C语言写的俄罗斯方块\n\tBUG反馈：Zminh@live.com\n\t\t\tmade by:sleepandeat","你挂啦！",MB_YESNO|MB_ICONQUESTION))
						break;
					else
						return 0;
				}
				begin_xy.y-=1;
				set_data(begin_xy,now);
				found_end();
				begin_xy.x=7,begin_xy.y=1,end_hand=0;
				ll=0,ss=0,zz=0,tt=0,ii=0,jj=0;
				end_next(next);
				my_switch();
				show_next(next);
				continue;
			}
			if(!push&&in_time++==20)
			{
				end_e();
				begin_xy.y++;in_time=0;
				print_e();
			}
		}
	}
	return 0;
}

int get_key()
{ 
  int c1,c2;
  if((c1=getch())!=224)return c1;
  c2=getch();
  return c2; 
} 
void print_e()
{
	print_xy=begin_xy;
	for(i=0;i<4;i++,print_xy.x++)
		for(j=0,print_xy.y=begin_xy.y;j<4;j++,print_xy.y++)
			if(now[i][j]==1)
			{
				gotoxy(print_xy.x*2,print_xy.y);printf("■");
			}
}
void end_e()
{
	print_xy=begin_xy;end_hand++;
	for(i=0;i<4;i++,print_xy.x++)
		for(j=0,print_xy.y=begin_xy.y;j<4;j++,print_xy.y++)
			if(now[i][j]==1)
			{
				gotoxy(print_xy.x*2,print_xy.y);printf(" ");
			}
}
void my_switch()
{
	now=next;olde_rand=rand_data;
	rand_data=rand()%7;
	switch(rand_data)
	{
		case 0:next=&fx[0];break;
		case 1:next=&lx1[0];break;
		case 2:next=&sx1[0];break;
		case 3:next=&zx1[0];break;
		case 4:next=&tx1[0];break;
		case 5:next=&ix1[0];break;
		case 6:next=&jx1[0];break;
	}
}
void change_tx()
{
	int (*olde)[4]=now;
	switch(olde_rand)
	{
		case 0:break;
		case 1:
			if(++ll==4)ll=0;
			switch(ll)
			{
				case 0:now=&lx1[0];break;
				case 1:now=&lx2[0];break;
				case 2:now=&lx3[0];break;
				case 3:now=&lx4[0];break;
			}break;
		case 2:
			if(++ss==2)ss=0;
			switch(ss)
			{
				case 0:now=&sx1[0];break;
				case 1:now=&sx2[0];break;
			}break;
		case 3:
			if(++zz==2)zz=0;
			switch(zz)
			{
				case 0:now=&zx1[0];break;
				case 1:now=&zx2[0];break;
			}break;
		case 4:
			if(++tt==4)tt=0;
			switch(tt)
			{
				case 0:now=&tx1[0];break;
				case 1:now=&tx2[0];break;
				case 2:now=&tx3[0];break;
				case 3:now=&tx4[0];break;
			}break;
		case 5:
			if(++ii==2)ii=0;
			switch(ii)
			{
				case 0:now=&ix1[0];break;
				case 1:now=&ix2[0];break;
			}break;
		case 6:
			if(++jj==4)jj=0;
			switch(jj)
			{
				case 0:now=&jx1[0];break;
				case 1:now=&jx2[0];break;
				case 2:now=&jx3[0];break;
				case 3:now=&jx4[0];break;
			}break;
	}
	if(!found_error(begin_xy,now))now=olde;
}