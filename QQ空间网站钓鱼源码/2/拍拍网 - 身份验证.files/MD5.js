/**********************************************************
* md5.js
*
* A JavaScript implementation of the RSA Data Security, Inc. MD5
* Message-Digest Algorithm.
*
* Copyright (C) Paul Johnston 1999. Distributed under the LGPL.
***********************************************************/

/* to convert strings to a list of ascii values */
var sAscii = " !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ"
var sAscii = sAscii + "[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";

/* convert integer to hex string */
var sHex = "0123456789ABCDEF";
function hex(i)
{
h = "";
for(j = 0; j <= 3; j++)
{
h += sHex.charAt((i >> (j * 8 + 4)) & 0x0F) +
sHex.charAt((i >> (j * 8)) & 0x0F);
}
return h;
}

/* add, handling overflows correctly */
function add(x, y)
{
return ((x&0x7FFFFFFF) + (y&0x7FFFFFFF)) ^ (x&0x80000000) ^ (y&0x80000000);
}

/* MD5 rounds functions */
function R1(A, B, C, D, X, S, T)
{
q = add(add(A, (B & C) | (~B & D)), add(X, T));
return add((q << S) | ((q >> (32 - S)) & (Math.pow(2, S) - 1)), B);
}

function R2(A, B, C, D, X, S, T)
{
q = add(add(A, (B & D) | (C & ~D)), add(X, T));
return add((q << S) | ((q >> (32 - S)) & (Math.pow(2, S) - 1)), B);
}

function R3(A, B, C, D, X, S, T)
{
q = add(add(A, B ^ C ^ D), add(X, T));
return add((q << S) | ((q >> (32 - S)) & (Math.pow(2, S) - 1)), B);
}

function R4(A, B, C, D, X, S, T)
{
q = add(add(A, C ^ (B | ~D)), add(X, T));
return add((q << S) | ((q >> (32 - S)) & (Math.pow(2, S) - 1)), B);
}

/* main entry point */
function calcMD5(sInp) {

/* Calculate length in machine words, including padding */
wLen = (((sInp.length + 8) >> 6) + 1) << 4;
var X = new Array(wLen);

/* Convert string to array of words */
j = 4;
for (i = 0; (i * 4) < sInp.length; i++)
{
X[i] = 0;
for (j = 0; (j < 4) && ((j + i * 4) < sInp.length); j++)
{
X[i] += (sAscii.indexOf(sInp.charAt((i * 4) + j)) + 32) << (j * 8);
}
}

/* Append padding bits and length */
if (j == 4)
{
X[i++] = 0x80;
}
else
{
X[i - 1] += 0x80 << (j * 8);
}
for(; i < wLen; i++) { X[i] = 0; }
X[wLen - 2] = sInp.length * 8;

/* hard-coded initial values */
a = 0x67452301;
b = 0xefcdab89;
c = 0x98badcfe;
d = 0x10325476;

/* Process each 16-word block in turn */
for (i = 0; i < wLen; i += 16) {
aO = a;
bO = b;
cO = c;
dO = d;

a = R1(a, b, c, d, X[i+ 0], 7 , 0xd76aa478);
d = R1(d, a, b, c, X[i+ 1], 12, 0xe8c7b756);
c = R1(c, d, a, b, X[i+ 2], 17, 0x242070db);
b = R1(b, c, d, a, X[i+ 3], 22, 0xc1bdceee);
a = R1(a, b, c, d, X[i+ 4], 7 , 0xf57c0faf);
d = R1(d, a, b, c, X[i+ 5], 12, 0x4787c62a);
c = R1(c, d, a, b, X[i+ 6], 17, 0xa8304613);
b = R1(b, c, d, a, X[i+ 7], 22, 0xfd469501);
a = R1(a, b, c, d, X[i+ 8], 7 , 0x698098d8);
d = R1(d, a, b, c, X[i+ 9], 12, 0x8b44f7af);
c = R1(c, d, a, b, X[i+10], 17, 0xffff5bb1);
b = R1(b, c, d, a, X[i+11], 22, 0x895cd7be);
a = R1(a, b, 