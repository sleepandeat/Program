datas segment
   
datas ends

codes segment
   mov ax,1
   mov dx,2
   add ax,dx
   mov dx,ax
   mov ah,2
   int 21
   mul dx
   sub ax,dx
   dec ax
   inc dx
   mul dx
   mov dx,ax
   mov ah,2
   int 21
   mov ah,12
   int 21
codes ends