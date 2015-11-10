#ifndef _SCH51_H
   #define _SCH51_H
   #include "typedef.h"
//----------------------------操作系统子函数－－－－－－－－－－－－－－－
void SCH_Init_T2(void) ;
void SCH_Start(void)   ;
uchar SCH_Add_Task(void (code * pFunction)(),const uint DELAY,const uint PERIOD) ;
bit SCH_Delete_Task(const uchar TASK_INDEX); 
void SCH_Dispatch_Tasks(void) ;
void SCH_Update(void) ;

#endif			  