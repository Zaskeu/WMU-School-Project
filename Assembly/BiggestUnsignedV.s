           .global BiggestUnsignedV
BiggestUnsignedV:
           save %sp, -800, %sp
 loop:     
	   subcc %i0, 1, %i0
           bvs,a away ! if done
           mov %i1,%i0
	   
	   mov %i0, %i1
           ba loop
           nop
 away:
           ret
           restore
 
