.global PrintIDS

PrintIDS:
	save %sp, -800, %sp

	clr %l7
	
	mov 72, %l5
	
	st %i1, [%fp + 72]
	st %i2, [%fp + 76]
	st %i3, [%fp + 80]
	st %i4, [%fp + 84]
	st %i5, [%fp + 88]
	
loop:
	ldub[%i0 + %l7], %l0

	cmp %l0, %g0
	be next
	nop

	cmp %l0,37	   
	!bne loop
	bne,a loop
	inc %l7

next:
	mov %l7, %o1 !Move counter
	call output
	mov %i0 , %o0 ! Move address

	cmp %l0, %g0 !Null?
	be exit
	nop

	inc %l7
	ldub[%i0 + %l7], %l0
	
	cmp %l0, 'x'
	bne overHex
	nop
	
	call hexOut
	ld [%fp + %l5], %o0
	
	ba continue
	nop
	
overHex:
	cmp %l0, 'd'
	bne overDec
	nop
	
	call decOut
	ld [%fp + %l5], %o0
	
	ba continue
	nop
	
overDec:
	cmp %l0, 'u'
	bne overU
	nop
	
	call uOut
	ld [%fp + %l5], %o0
	
	ba continue
	nop
	
overU:
	cmp %l0, 'c'
	bne overChar
	nop
	
	call charOut
	ld [%fp + %l5], %o0
	
	ba continue
	nop
	
overChar:
	cmp %l0, 's'
	bne overStr
	nop
	
	call strOut
	ld [%fp + %l5], %o0
	
	ba continue
	nop
	
overStr:
	! don't forget about me!!!
	
hexOut:
    save %sp, -800, %sp 
	
	set table, %i5 ! base for table lookup 
    set Hex, %i4 ! base for 'empty'     
    mov 7 , %l0 ! counter for loop 
   
loop2:    
	and %i0, 0xF, %l2   ! get low nibble of data 
    srl %i0, 4, %i0     ! shift right 4 bits for 
                        !next mask 
    ldub [%i5+%l2], %l2 ! asciify the nibble 
    stb %l2, [%i4 + %l0 ] 
    cmp %l0, %g0        ! have we run the 0th ? 
    bne loop2           ! if not loop 
    dec %l0             ! and dec 
    mov 4, %g1          ! 4 is write 
    mov 1, %o0          ! 1 is STDOUT 
    mov %i4, %o1      ! address of ascii data 
    mov 8 , %o2         ! 8 nibbles in an int 
    ta 0 

    ret 
    restore 
 

decOut:
	save %sp, -800, %sp
	
	clr %l6 ! holds remainder
	mov 15, %l7 ! l7 is the index of where we are in %i4
	set table, %i5 !ascii lookup table
	set Un, %i4 ! what hold our result
	
	cmp %i0, %g0
	bg loop5
	nop
	
	sub %g0, %i0, %i0
	mov 1, %l1 ! to check if it was negative for later
	
loop5:
    !Find Remainder
    mov %i0, %o0
    call .urem
	mov 10, %o1
	mov %o0, %l6
	
	!Divide by base
    mov %i0, %o0
    call .udiv
    mov 10, %o1
    mov %o0, %i0	
	
	ldub [%i5 + %l6], %l2 ! asciify nibble
	stb %l2, [%i4 + %l7] !fill Un
	
	cmp %i0, %g0 ! does the value = 0?
	bne,a loop5 !if not loop
	dec %l7 !decrement counter
	
	cmp %l1,1 ! was it negative before?
	be, addNeg
	nop
	
addNeg:
    
	dec %l7 !move counter back to place "-" in front of number
	mov 45, %l2 ! copy 45(ascii value of '-') into %l2
	stb %l2, [%i4 + %l7] ! fill byte in empty(Un)
	
	
	
	mov 4, %g1
	mov 1, %o0
	add %i4, %l7, %o1 !address to start 
	
	add %i4, 16, %o2 !go to the end of Un
	sub %o2, %o1, %o2 ! subtract end from beginning
	
	ta 0
	
	ret
	restore
	
uOut:
	save %sp, -800, %sp	
	
	clr %l6 ! holds remainder
	mov 15, %l7 ! l7 is the index of where we are in %i4
	set table, %i5 !ascii lookup table
	set Un, %i4 ! what hold our result
	
loop4:
    !Find Remainder
    mov %i0, %o0
    call .urem
	mov 10, %o1
	mov %o0, %l6
	
	!Divide by base
    mov %i0, %o0
    call .udiv
    mov 10, %o1
    mov %o0, %i0	
	
	ldub [%i5 + %l6], %l2 ! asciify nibble
	stb %l2, [%i4 + %l7] !fill Un
	
	cmp %i0, %g0 ! does the value = 0?
	bne,a loop4 !if not loop
	dec %l7 !decrement counter
	
	mov 4, %g1
	mov 1, %o0
	add %i4, %l7, %o1 !address to start 
	
	add %i4, 16, %o2 !go to the end of Un
	sub %o2, %o1, %o2 ! subtract end from beginning
	
	ta 0
	ret
	restore
	
charOut:
	save %sp, -800, %sp
	
    set char, %l5
	stb %i0,[%l5]
	
	mov 4, %g1
	mov 1, %o0
	mov %l5, %o1
	mov 1, %o2 
	ta 0
	
	ret
	restore
	
strOut:
	save %sp, -800, %sp
    clr %l7
loop3:	
	   ldub[%i0 + %l7], %i1
       
       cmp %i1, %g0
       bne loop3
       inc %l7     
	   
	   
	   mov 4, %g1
	   mov 1, %o0
	   mov %i0, %o1
	   mov %l7, %o2
	   
	   ta 0
       ret
	   restore

continue:        
       inc %l7    
       add %i0, %l7, %i0        
	   !now worry about whatever goes here
	   add %l5, 4, %l5
	   ba loop
	   clr %l7	
	
output:
	save %sp, -800, %sp

	mov 4,%g1 !Write
	mov 1,%o0 !Write to standard output
	mov %i0, %o1 ! copy address

	add %i0, %i1, %i1  !calculating length of literal

	sub %i1, %i0, %i1

	mov %i1, %o2

	ta 0

	!Write NewLine

	mov 4, %g1
	mov 1, %o0
	set NL, %o1

	mov 1, %o2 !How many bytes to write

	ta 0

	ret
	restore

exit:
	ret
	restore

	.section ".data"
NL:
	.ascii '\n'
	.align 4
	
hexStr:
	.ascii "I'm a x."
	
decStr:
	.ascii "I'm a d."
	
uStr:
	.ascii "I'm a u."
	
charStr:
	.ascii "I'm a c."
	
sigStr:
	.ascii "I'm a s."
	
IAMNOTHING:
    .byte 2,3
	.align 4	
	
ERROR:
	.ascii "could not compute..."

Hex:    .skip 8 
Un:     .skip 16
table:    .ascii "0123456789ABCDEF"
char: .skip 1