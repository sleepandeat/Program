#include "stdafx.h"
#include "all_include.h"
int fx[4][4]={ 0,0,0,0,
			   0,1,1,0,
			   0,1,1,0,
			   0,0,0,0};
//以上是方形
int lx1[4][4]={0,1,0,0,
			   0,1,0,0,
			   0,1,1,0,
			   0,0,0,0};

int lx2[4][4]={0,0,0,0,
			   0,1,1,1,
			   0,1,0,0,
			   0,0,0,0};

int lx3[4][4]={0,0,0,0,
			   0,1,1,0,
			   0,0,1,0,
			   0,0,1,0};

int lx4[4][4]={0,0,0,0,
			   0,0,1,0,
			   1,1,1,0,
			   0,0,0,0};
//以上是L形
int jx1[4][4]={0,0,0,0,
			   0,1,0,0,
			   0,1,1,1,
			   0,0,0,0};

int jx2[4][4]={0,0,0,0,
			   0,1,1,0,
			   0,1,0,0,
			   0,1,0,0};

int jx3[4][4]={0,0,0,0,
			   1,1,1,0,
			   0,0,1,0,
			   0,0,0,0};

int jx4[4][4]={0,0,1,0,
			   0,0,1,0,
			   0,1,1,0,
			   0,0,0,0};
//以上是J形
int sx1[4][4]={0,0,0,0,
			   0,0,1,1,
			   0,1,1,0,
			   0,0,0,0};

int sx2[4][4]={0,1,0,0,
			   0,1,1,0,
			   0,0,1,0,
			   0,0,0,0};
//以上是S形
int zx1[4][4]={0,0,0,0,
			   1,1,0,0,
			   0,1,1,0,
			   0,0,0,0};

int zx2[4][4]={0,0,1,0,
			   0,1,1,0,
			   0,1,0,0,
			   0,0,0,0};
//以上是Z形
int tx1[4][4]={1,1,1,0,
			   0,1,0,0,
			   0,0,0,0,
			   0,0,0,0};

int tx2[4][4]={0,0,1,0,
			   0,1,1,0,
			   0,0,1,0,
			   0,0,0,0};

int tx3[4][4]={0,0,0,0,
			   0,0,1,0,
			   0,1,1,1,
			   0,0,0,0};

int tx4[4][4]={0,1,0,0,
			   0,1,1,0,
			   0,1,0,0,
			   0,0,0,0};
//以上是T形
int ix1[4][4]={0,1,0,0,
			   0,1,0,0,
			   0,1,0,0,
			   0,1,0,0};

int ix2[4][4]={0,0,0,0,
			   1,1,1,1,
			   0,0,0,0,
			   0,0,0,0};
//以上是I形
int all_xy[35][60];
extern int fenshu;
void found_end()
{
	int i=21,j,k,how=0;
	BOOL yes=TRUE,end=TRUE;
	for(i=21;i>0;i--)
	{
		for(j=1,yes=TRUE;j<16;j++)
			if(all_xy[i][j*2]!=1)
			{
				yes=FALSE;break;
			}
		if(yes)
		{
			how++;fenshu++;
			for(k=i;k>1;k--)
			{
				for(j=1,end=TRUE;j<16;j++)
				{
					all_xy[k][j*2]=all_xy[k-1][j*2];
					if(all_xy[k-1][j*2]==1)end=FALSE;
				}
				if(end)break;//如果一行中一个方块都没有停止赋值
			}
			i=22;
		}
	}
	if(how!=0)
	{
		for(k=21;k>1;k--)
			for(j=1;j<16;j++)
				if(all_xy[k][j*2]==1)
				{
					gotoxy(j*2,k+1);printf("■");
				}
				else
				{
					gotoxy(j*2,k+1);printf(" ");
				}
		switch(how)
		{
			case 0:break;
			case 1:PlaySound((LPCTSTR)"resource\\shutdown.wav", NULL, SND_FILENAME | SND_ASYNC);break;
			case 2:PlaySound((LPCTSTR)"resource\\doublekill.wav", NULL, SND_FILENAME | SND_ASYNC);break;
			case 3:PlaySound((LPCTSTR)"resource\\triplekill.wav", NULL, SND_FILENAME | SND_ASYNC);break;
			default:PlaySound((LPCTSTR)"resource\\godlike.wav", NULL, SND_FILENAME | SND_ASYNC);break;
		}
		if(how>1)
			fenshu+=how;
		gotoxy(40,9);
		printf("%d分",fenshu);
	}
}
void set_data(POINT begin_xy,int (*now)[4])
{
	int i,j;
	POINT print_xy=begin_xy;
	for(i=0;i<4;i++,print_xy.x++)
		for(j=0,print_xy.y=begin_xy.y;j<4;j++,print_xy.y++)
			if(now[i][j]==1)
				all_xy[print_xy.y][print_xy.x*2]=1;
}
BOOL found_error(POINT begin_xy,int (*now)[4])
{
	int i,j;
	POINT print_xy=begin_xy;
	for(i=0;i<4;i++,print_xy.x++)
		for(j=0,print_xy.y=begin_xy.y;j<4;j++,print_xy.y++)
			if(now[i][j]==1)
				if(all_xy[print_xy.y][print_xy.x*2]==1)
					return FALSE;
	return TRUE;
}