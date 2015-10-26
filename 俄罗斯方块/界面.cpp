#include "stdafx.h"
#include "all_include.h"
COORD coord;
void HideCursor()//隐藏控制台的光标 
{
	 CONSOLE_CURSOR_INFO cursor_info = {1, 0}; 
	 SetConsoleCursorInfo(GetStdHandle(STD_OUTPUT_HANDLE), &cursor_info);
}
void gotoxy(int x, int y)
{
	 coord.X = x,coord.Y=y;
	 SetConsoleCursorPosition(GetStdHandle(STD_OUTPUT_HANDLE), coord);
}
void chushihua()
{
	int i,j,x=36,y=1,sleep_time=10;
	system("mode con cols=52 lines=25");//改变dos窗口大小和去掉下拉条
	for(i=0;i<16;i++)
	{
		gotoxy(i*2,0);printf("□");
		gotoxy(0,i);printf("□");
		Sleep(sleep_time);
	}
	for(;i<23;i++)
	{
		gotoxy(0,i);printf("□");
		Sleep(sleep_time);
	}
	for(i=0;i<=16;i++)
	{
		gotoxy(i*2,23);printf("□");
		gotoxy(32,i);printf("□");
		Sleep(sleep_time);
	}
	for(;i<=23;i++)
	{
		gotoxy(32,i);printf("□");
		Sleep(sleep_time);
	}
	for(j=0;j<23;j+=6)
		for(i=16;i<26;i++)
		{
			gotoxy(i*2,j);printf("□");
			Sleep(sleep_time);
		}
	for(i=16;i<26;i++)
	{
		gotoxy(i*2,23);printf("□");
		Sleep(sleep_time);
	}
	for(i=23;i>=0;i--)
	{
		gotoxy(50,i);printf("□");
		Sleep(sleep_time);
	}
	gotoxy(x,y++);
	printf("【使用规则】");
	gotoxy(x-2,y++);Sleep(sleep_time);
	printf("↑:变形 +:速度加");
	gotoxy(x-2,y++);Sleep(sleep_time);
	printf("→:右移 -:速度减");
	gotoxy(x-2,y++);Sleep(sleep_time);
	printf("←:左移 ESC:退出");
	gotoxy(x,y++);Sleep(sleep_time);
	printf("空格:快速下降");
	Sleep(sleep_time);y++;
	gotoxy(x,y++);
	printf("【当前分数】");
	gotoxy(x,++y);Sleep(sleep_time);
	printf("     0分");
	Sleep(sleep_time);y+=4;
	gotoxy(x,y++);
	printf("【下个图形】");
	Sleep(sleep_time);y+=5;
	gotoxy(x+2,y++);
	printf("【作者】");
	gotoxy(x,++y);
	printf("sleepandeat");//+ 键可以加快速度，―键可减慢速度\n分数在两分以上分数会加倍！
	gotoxy(10,10);
	printf("  按任意键开始！");
	gotoxy(2,12);
	printf("（按被占用键外的任意键暂停！）");
	gotoxy(2,14);
	printf("   分数在两分以上分数会加倍！ ");
	gotoxy(2,15);
	printf("+键可以加快速度，-键可减慢速度");
	getch();
	gotoxy(10,10);
	printf("                ");
	gotoxy(2,12);
	printf("                              ");
	gotoxy(2,14);
	printf("                              ");
	gotoxy(2,15);
	printf("                              ");
}
void show_next(int (*now)[4])
{
	int i,j;
	POINT print_xy={20,14};
	for(i=0;i<4;i++,print_xy.x++)
		for(j=0,print_xy.y=14;j<4;j++,print_xy.y++)
			if(now[i][j]==1)
			{
				gotoxy(print_xy.x*2,print_xy.y);printf("■");
			}
}
void end_next(int (*now)[4])
{
	int i,j;
	POINT print_xy={20,14};
	for(i=0;i<4;i++,print_xy.x++)
		for(j=0,print_xy.y=14;j<4;j++,print_xy.y++)
			if(now[i][j]==1)
			{
				gotoxy(print_xy.x*2,print_xy.y);printf("  ");
			}
}
