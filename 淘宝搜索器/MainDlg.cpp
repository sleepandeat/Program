#include "stdafx.h"
#include "allInclude.h"



char urlWithPrice[256] = {"http://s.taobao.com/search?q=%s&tab=all&filter=reserve_price%%5B%s%%2C%s%%5D"};
char urlNoPrice[256] = {"http://s.taobao.com/search?q=%s"};
char downloadUrl[256];
char openUrl[100][256];
char downlaodPath[100] = {"d:\\1.txt"};
int  urlLength = 0;
HWND mainHwnd;
HWND listHwnd;

BOOL WINAPI Main_Proc(HWND hWnd, UINT uMsg, WPARAM wParam, LPARAM lParam)
{
    switch(uMsg)
    {
        HANDLE_MSG(hWnd, WM_INITDIALOG, Main_OnInitDialog);
        HANDLE_MSG(hWnd, WM_COMMAND, Main_OnCommand);
		HANDLE_MSG(hWnd,WM_CLOSE, Main_OnClose);
		case WM_NOTIFY:
				{
					LPNMHDR lpnmh = (LPNMHDR)lParam;
					if(NM_DBLCLK == lpnmh->code){
						if(urlLength <= 0)
							break;
						int NUM=ListView_GetSelectionMark(listHwnd);
						ShellExecute(hWnd, "open",openUrl[NUM],NULL, NULL, SW_SHOW);
						//MessageBox(NULL,openUrl[urlLength],itoa(NUM,data,10),0);
					}
				}
			break;
    }

    return FALSE;
}

void in_it(HWND hwnd,int iSubItem,int cx,char *text,int cchTextMax,int len)
{
	LVCOLUMN ColInfo1 = {0};
	ColInfo1.mask = LVCF_TEXT | LVCF_WIDTH | LVCF_FMT;
	ColInfo1.iSubItem = iSubItem;
	ColInfo1.fmt = LVCFMT_CENTER;
	ColInfo1.cx = cx;
	ColInfo1.pszText=text;
	ColInfo1.cchTextMax = cchTextMax;
	SendMessage(hwnd, LVM_INSERTCOLUMN, WPARAM(len), LPARAM(&ColInfo1));
}
void set_data(HWND hwnd,char *text,int x,int y)
{
	LVITEM item;
	item.mask=LVIF_TEXT;
	item.pszText=text;
	item.iItem=x;
	item.iSubItem=y;
	if(y==0)
		SendMessage(hwnd, LVM_INSERTITEM, 0, LPARAM(&item));
	else
		SendMessage(hwnd, LVM_SETITEM, 0, LPARAM(&item));
}

BOOL Main_OnInitDialog(HWND hwnd, HWND hwndFocus, LPARAM lParam)
{
	mainHwnd = hwnd;
	listHwnd = GetDlgItem(hwnd, IDC_LIST1);
	SendMessage(listHwnd, LVM_SETEXTENDEDLISTVIEWSTYLE, 0,
		LVS_EX_FULLROWSELECT | LVS_EX_HEADERDRAGDROP | LVS_EX_GRIDLINES);
	in_it(listHwnd,0,40,"编号",50,0);
	in_it(listHwnd,0,400,"简介",50,1);
	in_it(listHwnd,0,80,"付款人数",50,2);
	in_it(listHwnd,0,50,"价格",50,3);

	SendMessage(hwnd, WM_SETICON, (WPARAM)TRUE, (LPARAM)LoadIcon(GetModuleHandle(NULL), (LPCTSTR)IDI_ICON1));
    return TRUE;
}

void Main_OnCommand(HWND hwnd, int id, HWND hwndCtl, UINT codeNotify)
{
    switch(id)
    {
		case IDC_OK:{
				char name[50],from[20],to[20];
				BOOL inputPrice = true;
				if(0 == GetDlgItemText(hwnd,IDC_name,name,50)){
					MessageBox(hwnd,"请输入商品名称","错误",MB_ICONERROR);
					return;
				}
				if(0 == GetDlgItemText(hwnd,IDC_from,from,20))
					inputPrice = false;
				if(0 == GetDlgItemText(hwnd,IDC_to,to,20))
					inputPrice = false;
				if(inputPrice)
					wsprintf(downloadUrl,urlWithPrice,name,from,to);
				else
					wsprintf(downloadUrl,urlNoPrice,name);
				CreateThread(NULL, 0, downThread, NULL, 0, NULL); // 启动线程
			}
			break;
		case IDC_code:
			MessageBox(hwnd,"想看吗，联系我啊！\nZminh@live.com\n(￣▽￣)","提示",0);
			break;
		case IDC_help:
			MessageBox(hwnd,"预留广告位","提示",0);
			break;
        default:
		break;
    }
}

void Main_OnClose(HWND hwnd)
{
    EndDialog(hwnd, 0);
}