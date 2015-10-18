DATAS SEGMENT
    prompt0 4 {T,h,i,s}    ;提示
    prompt1 7 {p,r,o,g,r,a,m}
    prompt2 2 {i,s}
    prompt3 11 {c,a,l,c,u,l,a,t,i,n,g}
    prompt4 4 {f,i,v,e}
    prompt5 8 {m,u,l,t,i,p,l,y}
    prompt6 3 {s,i,x}
    result 2    ;结果存放处
DATAS ENDS

CODES SEGMENT
    lea dx,prompt0  ;显示提示信息
    mov  ah,09    ;09功能调用，输出字符串
    int 21
    LEA DX,prompt1
    mov  ah,09         
    INT 21
    LEA DX,prompt2       
    MOV AH,09 
    INT 21 
    LEA DX,prompt3      
    MOV AH,09 
    INT 21  
    LEA DX,prompt4      
    MOV AH,09 
    INT 21 
    LEA DX,prompt5      
    MOV AH,09 
    INT 21 
    LEA DX,prompt6      
    MOV AH,09 
    INT 21 
    mov cx,4 ;设定循环次数      
    mov ax,6 ;初始化AX
calc:mov dx,6
    add ax,dx
    loop calc
    mov dx,ax
    mov ah,2
    int 21    ;输出结果
    mov result,dx ;保存结果
    mov ah,12 
    int 21     ;程序结束
codes ends