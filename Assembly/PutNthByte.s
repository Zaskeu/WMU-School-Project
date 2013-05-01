.global PutNthByte


PutNthByte:
            save %sp,-800, %sp

	sll %i2,3,%l0	!# of bits to shift
	add %l0,8,%l0	!one more byte

	mov %i0,%l1	!save a copy of %i0 in %l1
	srl %i0,%l0,%i0	!clear out the right half 
	sll %i0,%l0,%i0	!shift back

	sub %l0,8,%l0	!one less byte
	sll %l1,%l0,%l1 !clear out the left half
	srl %l1,%l0,%l1 !shift back
	
	sll %i1,%l0,%i1	!shift desired bit into place

	or %i0,%i1,%i0	!add on the extra bit
	or %i0,%l1,%i0	!add on the right half

           ! sll %i2, 3, %l0

           ! and %i0, %l0, %i0

           ! and %i0, %i1, %i0

                        
            ret
            restore            
                         

