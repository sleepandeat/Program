datas segment
   result 2
   data1 1 {6}
   data2 1 {4}
   data3 1 {7}
   data4 1 {2}    ; µœ÷£®£®data1+data2)^2 -(data3-data4)^2)*2
datas ends

codes segment
   mov ax,data1
   mov dx,data2
   add ax,dx
   mul ax
   push ax
   mov ax,data3
   sub ax,data4
   mov dx,ax
   mul dx
   mov dx,ax
   pop ax
   sub ax,dx
   mul 2
   mov result,ax
   mov dx,ax
   mov ah,2
   int 21
   mov ah,12
   int 21
codes ends