#include "stdafx.h"
#include "resource.h"
#include "MainDlg.h"
#include <windows.h>
#include <windowsx.h>
#include <UrlMon.h>
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <conio.h>
#include <WININET.H>
#include <UrlMon.h>
#include "shellapi.h "
#pragma comment(lib, "urlmon.lib")
#pragma comment( lib, "Wininet.lib" )
#include <shlobj.h> 
DWORD WINAPI downThread(PVOID pMyPara);
void set_data(HWND hwnd,char *text,int x,int y);

extern char urlWithPrice[256];
extern char urlNoPrice[256];
extern char downlaodPath[100];
extern char downloadUrl[256];
extern char openUrl[100][256];
extern HWND mainHwnd;
extern HWND listHwnd;
extern int  urlLength;

