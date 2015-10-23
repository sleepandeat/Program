/*
fox38与2013年1月19日编写
解决了在摄像头调试过程中，将摄像头拍的照片通过串口上传至串口助手保存时，
将jpg图片的字节流转换为十六进制字符了，直接更改文件后缀无法直接观看图片的问题。

本程序主要用于将从串口助手等软件中获取的JPG图片十六进制字符串转换为字节流，以便能够直接观看。

十六进制字符串文本存放到in.txt中，该程序将其转换成图片in.jpg

其中输入文档为“in.txt”，输出文件为“in.jpg”
1月22日修改，用户自行输入需要转换的文本文件名称，需要带上后缀名
*/
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
//十六进制字符串转换为字节流

int main() {
	FILE *fin, *fout;

	char *infile = "in.txt";
	char *outfile = "in.jpg";
	int temp, high, low, iloc[1] = { 10 };
	long lLen, i;
	char  cIn[81], cOut[81];

	printf("Please insert the name of the file:");
	scanf("%s", cIn);
	printf("%s\n", cIn);


	fin = fopen(cIn, "r"); // 读格式打开，默认为文本类型
	fout = fopen(outfile, "wb"); // 写格式打开，以二进制形式	
	if ((fin == NULL) || (fout == NULL)) {
		printf("打开文件失败!\n");
		exit(1);
	}

	fseek(fin, sizeof(char), SEEK_END);
	lLen = ftell(fin);
	printf("文件长度为%d\n", lLen);
	fseek(fin, sizeof(char), SEEK_SET);

	for (i = 0; i<lLen; i = i + 3)
	{
		fseek(fin, i, SEEK_SET);
		high = fgetc(fin);
		//printf("high is :%d\n",high);
		if (high > 0x39)
			high -= 0x37;
		else
			high -= 0x30;

		fseek(fin, i + 1, SEEK_SET);
		low = fgetc(fin);
		//printf("low is :%d\n",low);
		if (low > 0x39)
			low -= 0x37;
		else
			low -= 0x30;
		temp = ((high << 4) | low);
		//printf("temp is :%d\n",temp);
		//fputc(temp,fout);
		if (10 == temp)
		{
			fwrite(&iloc, 1, 1, fout);
		}
		else
		{
			fputc(temp, fout);
		}

	}

	fclose(fin);
	fclose(fout);
	return 0;
}


//字节流转换为十六进制字符串

void ByteToHexStr(const unsigned char* source, char* dest, int sourceLen)
{
	short i;
	unsigned char highByte, lowByte;
	for (i = 0; i < sourceLen; i++)
	{
		highByte = source[i] >> 4;
		lowByte = source[i] & 0x0f;
		highByte += 0x30;
		if (highByte > 0x39)
			dest[i * 2] = highByte + 0x07;
		else
			dest[i * 2] = highByte;
		lowByte += 0x30;
		if (lowByte > 0x39)
			dest[i * 2 + 1] = lowByte + 0x07;
		else
			dest[i * 2 + 1] = lowByte;
	}
	return;
}

//字节流转换为十六进制字符串的另一种实现方式

void Hex2Str(const char *sSrc, char *sDest, int nSrcLen)
{
	int  i;
	char szTmp[3];
	for (i = 0; i < nSrcLen; i++)
	{
		sprintf(szTmp, "%02X", (unsigned char)sSrc[i]);
		memcpy(&sDest[i * 2], szTmp, 2);
	}
	return;
}
//十六进制字符串转换为字节流
void HexStrToByte(const char* source, unsigned char* dest, int sourceLen)
{
	short i;
	unsigned char highByte, lowByte;
	for (i = 0; i < sourceLen; i += 2)
	{
		highByte = toupper(source[i]);
		lowByte = toupper(source[i + 1]);
		if (highByte > 0x39)
			highByte -= 0x37;
		else
			highByte -= 0x30;
		if (lowByte > 0x39)
			lowByte -= 0x37;
		else
			lowByte -= 0x30;
		dest[i / 2] = (highByte << 4) | lowByte;
	}
	return;
}