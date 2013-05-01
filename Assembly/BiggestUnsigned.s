	.global BiggestUnsigned
BiggestUnsigned: 
	save %sp, -800, %sp
	
loop: 
	addcc %i0,1,%i0
       	bcs,a away ! if done
        mov %i1, %i0
              
       	mov %i0, %i1

        ba loop
        nop

away:
       	ret
        restore
              
