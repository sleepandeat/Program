#include "SCH51.h"
#include "fangkuai.h"
#include "t6963c.h"
#include "key.h"

void main(void)
{
  
      SCH_Init_T2();
      Init_LCD();
      Init_Game();

      SCH_Add_Task(Fangkuai_down, 0, 3);
      SCH_Add_Task(KEY_Update, 1, 3);
	  SCH_Add_Task(Fangkuai_Control, 2, 5);

      SCH_Start();

      while(1)
      {
        
		 SCH_Dispatch_Tasks();
	
	   }
	 
}