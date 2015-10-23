// 五子棋胜负手.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"

using namespace std;
char ma[12][12];
char matmp[12][12];
int n, m;

//判断从x,y开始有没有匹配字串c
int Fit(int x, int y, string c)
{
	bool flag = true;
	int len = c.length();
	//右侧
	if (y + len - 1 <= m) {
		for (int i = 0; i<len; i++) {
			if (ma[x][y + i] != c[i]) {
				flag = false; break;
			}
		}
		if (flag)return 1;
		flag = true;
	}
	//下侧
	if (x + len - 1 <= n) {
		for (int i = 0; i<len; i++) {
			if (ma[x + i][y] != c[i]) {
				flag = false; break;
			}
		}
		if (flag)return 2;
		flag = true;
	}
	//右下侧
	if (x + len - 1 <= n && y + len - 1 <= m) {
		for (int i = 0; i<len; i++) {
			if (ma[x + i][y + i] != c[i]) {
				flag = false; break;
			}
		}
		if (flag)return 3;
		flag = true;
	}
	//右上侧
	if (x - len + 1>0 && y + len - 1 <= m) {
		for (int i = 0; i<len; i++) {
			if (ma[x - i][y + i] != c[i]) {
				flag = false; break;
			}
		}
		if (flag)return 4;
		flag = true;
	}
	return 0;
}

//匹配并设置
int SetFit(int x, int y, string c, string setC)
{
	bool flag = true;
	int len = c.length();
	//右侧
	if (y + len - 1 <= m) {
		for (int i = 0; i<len; i++) {
			if (ma[x][y + i] != c[i]) {
				flag = false; break;
			}
		}
		if (flag) {
			for (int i = 0; i<len; i++) {
				ma[x][y + i] = setC[i];
			}
			return 1;
		}
		flag = true;
	}
	//下侧
	if (x + len - 1 <= n) {
		for (int i = 0; i<len; i++) {
			if (ma[x + i][y] != c[i]) {
				flag = false; break;
			}
		}
		if (flag) {
			for (int i = 0; i<len; i++) {
				ma[x + i][y] = setC[i];
			}
			return 2;
		}
		flag = true;
	}
	//右下侧
	if (x + len - 1 <= n && y + len - 1 <= m) {
		for (int i = 0; i<len; i++) {
			if (ma[x + i][y + i] != c[i]) {
				flag = false; break;
			}
		}
		if (flag) {
			for (int i = 0; i<len; i++) {
				ma[x + i][y + i] = setC[i];
			}
			return 3;
		}
		flag = true;
	}
	//右上侧
	if (x - len + 1>0 && y + len - 1 <= m) {
		for (int i = 0; i<len; i++) {
			if (ma[x - i][y + i] != c[i]) {
				flag = false; break;
			}
		}
		if (flag) {
			for (int i = 0; i<len; i++) {
				ma[x - i][y + i] = setC[i];
			}
			return 4;
		}
		flag = true;
	}
	return 0;
}

bool OneStepWin(char side)//side='1'=>white side='0'=>black
{
	string cmpBlackStr[] = { " 0000", "0 000", "00 00", "000 0", "0000 " };
	string cmpWhiteStr[] = { " 1111", "1 111", "11 11", "111 1", "1111 " };
	for (int i = 1; i <= n; i++)
	{
		for (int j = 1; j <= m; j++)
		{
			if (side == '1') {
				for (int k = 0; k<5; k++) {
					if (Fit(i, j, cmpWhiteStr[k]))return true;
				}
			}
			else {
				for (int k = 0; k<5; k++) {
					if (Fit(i, j, cmpBlackStr[k]))return true;
				}
			}
		}
	}
	return false;
}


//若成功封住，x,y为封住的地点
bool Feng(char side)
{
	string notPossibleBlack = " 0000 ";
	string notPossibleWhite = " 1111 ";
	string PossibleBlack[] = { "0 000", "00 00", "000 0", " 0000", "0000 " };
	string SetBlack[] = { "01000", "00100", "00010", "10000", "00001" };
	string PossibleWhite[] = { "1 111", "11 11", "111 1", " 1111", "1111 " };
	string SetWhite[] = { "10111", "11011", "11101", "01111", "11110" };

	int pNum = 0;
	for (int i = 1; i <= n; i++)
	{
		for (int j = 1; j <= m; j++)
		{
			//如果封不住 返回false
			if (side == '1') {
				if (Fit(i, j, notPossibleWhite)) {
					return false;
				}
			}
			else {
				if (Fit(i, j, notPossibleBlack))return false;
			}
		}
	}

	for (int i = 1; i <= n; i++)
	{
		for (int j = 1; j <= m; j++)
		{
			//Possible
			if (side == '1') {
				for (int k = 0; k<5; k++)
				{
					if (SetFit(i, j, PossibleWhite[k], SetWhite[k])) {
						pNum++;
						if (pNum > 1)return false;
					}
				}
			}
			else
			{
				for (int k = 0; k<5; k++)
				{
					if (SetFit(i, j, PossibleBlack[k], SetBlack[k])) {
						pNum++;
						if (pNum > 1)return false;
					}
				}
			}
		}
	}
	return true;
}

void printM()
{
	for (int i = 0; i <= n + 1; i++)
	{
		for (int j = 0; j <= m + 1; j++)
			if (ma[i][j] == ' ')cout << '_';
			else cout << ma[i][j];
			cout << endl;
	}
}

int main()
{
	while (cin >> n >> m)
	{
		int i = 1, j = 1;
		getchar();
		for (int x = 0; x<12; x++)
			for (int y = 0; y<12; y++)
				ma[x][y] = '*';
		while (true)
		{
			ma[i][j] = getchar();
			j++;
			if (j>m) { i++; j = 1; getchar(); }
			if (i>n)break;
		}

		if (OneStepWin('1')) {
			cout << "YES" << endl;
		}
		else
		{
			if (OneStepWin('0'))
			{
				if (!Feng('0')) {
					cout << "NO" << endl;
				}
				else
				{
					if (!Feng('1')) {
						cout << "YES" << endl;
					}
					else
					{
						cout << "NO" << endl;
					}
				}
			}
			else
			{
				bool one = false;
				for (int i = 1; i <= n; i++)
				{
					for (int j = 0; j <= m; j++)
					{
						for (int a = 0; a<12; a++)
							for (int b = 0; b<12; b++)
								matmp[a][b] = ma[a][b];

						if (ma[i][j] == ' ') {
							ma[i][j] = '1';
							if (!Feng('1')) {
								one = true;
							}
							ma[i][j] = ' ';
						}

						for (int a = 0; a<12; a++)
							for (int b = 0; b<12; b++)
								ma[a][b] = matmp[a][b];
					}
				}
				if (one)cout << "YES" << endl;
				else cout << "NO" << endl;
			}
		}

		//printM();
	}
}
