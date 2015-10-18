datas segment
   m1 14 {A,i,s,b,e,t,t,e,r,t,h,a,n,B}
   m2 14 {B,i,s,b,e,t,t,e,r,t,h,a,n,A}
   A 1 {6}
   B 1 {7}
   temp 1  ;根据Data^3 -(Data-8)^2算式，判断这两个数好坏。
datas ends

codes segment
  mov ax,A
  call f1
  mov temp, dx
  mov ax,B
  call f1
  mov ax,temp
  cmp ax,dx
  js l2
  lea dx,m1
  mov  ah,09         
  INT 21
  jmp halt
l2:lea dx,m2
   mov ah,09
   int 21
halt:mov ah,12 
     int 21    


f1#mov dx,ax
   mul ax
   mul dx
   push ax
   mov ax,dx
   SUB ax,8
   muL ax
   pop dx
   sub dx,ax
   ret
codes ends