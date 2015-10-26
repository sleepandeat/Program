#include "stdafx.h"
#include <windows.h> 
#include <stdlib.h> 
#include <stdio.h> 
#include <time.h> 
#include <conio.h> 
#include <shellapi.h>
#include <mmsystem.h>
#pragma comment(lib, "Winmm.lib")
#define KEY_DOWN    80   /* 向下箭头键 */
#define KEY_UP      72   /* 向上箭头键 */
#define KEY_RIGHT   77   /* 向右箭头键 */
#define KEY_LEFT    75   /* 向左箭头键 */
#define KEY_ESC     27   /* ESC键 */
#define KEY_PUSH    32   /* 空格键 */
#define KEY_ADD     43   /* ESC键 */
#define KEY_NADD    45   /* 空格键 */
void gotoxy(int x, int y);		//gotoxy语句 
void HideCursor();				//隐藏控制台的光标，无参数，无返回
int get_key();
void chushihua();
void show_next(int (*now)[4]);
void end_next(int (*now)[4]);
void my_switch();
BOOL found_error(POINT begin_xy,int (*now)[4]);
void set_data(POINT begin_xy,int (*now)[4]);
void change_tx();
void found_end(); 
void print_e();
void end_e();
