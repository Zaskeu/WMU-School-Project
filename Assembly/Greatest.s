.global Greatest
Greatest: save %sp, -800, %sp
!Credit to Dan for this(Thanks!)
	cmp %i0, %i1
        bl,a cont
        mov %i1, %i0
cont: 
        cmp %i0, %i2
        bl,a end
        mov %i2, %i0
          
end:
        ret
        restore
		
