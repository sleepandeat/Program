#include  "typedef.h"
#include  <AT89X52.h>
#define   SCH_MAX_TASKS    5

typedef data struct     //定义任务结构
{
   void (code * pTask)(void);  	 
   uint  Delay;       	
   uint  Period;       	
   uchar RunMe;       			  
}sTask;

sTask SCH_tasks_G[SCH_MAX_TASKS];	  //定义任务数据结构


//-----------------------任务开始－－－－－－－－－－－－－－－－－－－－－
void SCH_Start(void) 
{
     EA = 1;
}

//-----------------------系统进入空闲模式，等待下一次刷新－－－－－－－－－
void SCH_Go_To_Sleep()
{
   PCON |= 0x01;   
   
}
//------------------------任务添加－－－－－－－－－－－－－－－－－－－－－
 
uchar SCH_Add_Task(void (code * pFunction)(),const uint DELAY,const uint PERIOD)    
{
   uchar Index = 0;
   
   while ((SCH_tasks_G[Index].pTask != 0) && (Index < SCH_MAX_TASKS))
   {
      Index++;				 //查找空的任务指针
   } 
   
     
   if (Index == SCH_MAX_TASKS)
    {
       return 0;  
    }
      
   
   SCH_tasks_G[Index].pTask  = pFunction;
   SCH_tasks_G[Index].Delay  = DELAY;		 
   SCH_tasks_G[Index].Period = PERIOD;

   SCH_tasks_G[Index].RunMe  = 0;

   return Index; 
}


//-----------------------任务删除－－－－－－－－－－－－－－－－－－－－－－－

bit SCH_Delete_Task(const uchar TASK_INDEX) 
{
   
   if (SCH_tasks_G[TASK_INDEX].pTask == 0)
   {
        return 0;
    }
      
   SCH_tasks_G[TASK_INDEX].pTask   = 0x0000;
   SCH_tasks_G[TASK_INDEX].Delay   = 0;
   SCH_tasks_G[TASK_INDEX].Period  = 0;
   SCH_tasks_G[TASK_INDEX].RunMe   = 0;

   return 0;
}

//------------------------------任务调度－－－－－－－－－－－－－－－－－－－－－

void SCH_Dispatch_Tasks(void) 
{
	 
   uchar Index;

   
   for (Index = 0; Index < SCH_MAX_TASKS; Index++)
   {
      if (SCH_tasks_G[Index].RunMe > 0) 
       {
           (*SCH_tasks_G[Index].pTask)(); 
            SCH_tasks_G[Index].RunMe -= 1;   

        
        
         if (SCH_tasks_G[Index].Period == 0)   //删除只运行一次的任务
            {
                SCH_Delete_Task(Index);
            }
        }
   }
     
   SCH_Go_To_Sleep();    //单片机进入空闲模式      
}


//－－－－－－－－－－－－－－－－－任务中断刷新－－－－－－－－－－－－－－－－－－

void SCH_Update(void) interrupt 5 
{

   uchar Index;

   TF2 = 0; 

   
   for (Index = 0; Index < SCH_MAX_TASKS; Index++)
   {
     
      if (SCH_tasks_G[Index].pTask)
         {
         if (SCH_tasks_G[Index].Delay == 0)
            {
           
                SCH_tasks_G[Index].RunMe += 1;  

                if (SCH_tasks_G[Index].Period)
                {
                   SCH_tasks_G[Index].Delay = SCH_tasks_G[Index].Period;
                 }
            }
         else
          {
            
			SCH_tasks_G[Index].Delay -= 1;
           }
         }         
    }
}   


//－－－－－－－－－－－－－－－－系统初始化－－－－－－－－－－－－－－－－－－－
void SCH_Init_T2(void) 
{
    uchar i;

    for (i = 0; i < SCH_MAX_TASKS; i++) 
    {
      SCH_Delete_Task(i);
    }

     T2CON = 0x04;  
     T2MOD = 0x00;  

     TH2    = 0xFC; 
     RCAP2H = 0xFC; 
     TL2    = 0x18; 
     RCAP2L = 0x18;  
   
     ET2   = 1;  
     TR2   = 1;  
}

