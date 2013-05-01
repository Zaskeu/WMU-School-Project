.global MyStrCmp

MyStrCmp: save %sp, -800, %sp
	  clr %l7
	  clr %l6

loop:
      ldub[%i0 + %l7], %i0 !Load First bit into regester + offset
      ldub[%i1 + %l7], %i1 !Load first bit into regester + offset

      cmp %i0, %g0         !Is it Null?
      be,a check           !If it is check 2nd

      nop

      call next
      nop


check: 
      cmp %i0, %i1         !is string2 null?
      be,a exit            !if so lets exit
      nop

      inc %l7              !if not call exit
      call exit
      mov %l7, %l6        
      
next:
     cmp %i0, %i1          !is it equal?
     be,  loop             !if so loop
     inc %l7

     call exit
     mov %l7, %l6
       
       
exit:

      mov %l6, %i0
      ret
      restore
