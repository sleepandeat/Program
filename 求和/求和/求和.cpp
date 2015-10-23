// 求和.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"
#include <iostream>
#include <vector>
using namespace std;

int main() {
	int a, n;
	int sum = 0;
	vector<int> v;
	vector<int> temp;
	vector<int>::iterator it;
	int hight = 0; //存储进位
	while (cin >> a >> n) {
		v.clear();
		temp.clear();
		v.push_back(a);
		temp.push_back(a);
		for (int i = 2; i <= n; i++) {
			temp.push_back(a);
			int j = temp.size() - 1;
			int k = v.size() - 1;
			hight = 0;
			sum = 0;
			while (k >= 0 && j >= 0) { //从低位向高位相加
				sum = temp[j] + v[k] + hight;
				hight = 0;
				if (sum > 9) {
					hight = sum / 10; //求进位
				}
				v[k] = sum % 10;
				k--;
				j--;
			}

			//if(hight > 0){
			while (j >= 0) { //可能要加的数比总的位数还要多，比如 9  + 99;
				sum = temp[j] + hight;
				hight = 0;
				if (sum > 9) {
					hight = sum / 10;
				}
				v.insert(v.begin(), sum % 10);
				j--;
			}

			if (hight > 0) {//如果还有进位，那就放到最高位
				v.insert(v.begin(), hight);
			}
			//}
		}

		for (it = v.begin(); it != v.end(); it++) {
			cout << *it;
		}
		cout << endl;
	}
	return 0;
}