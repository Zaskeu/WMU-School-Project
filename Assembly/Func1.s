
    .global Func1 ! "assembler directive"
Func1:    save  %sp,-800, %sp ! machine instruction 
    
    mov %i0,%o0
    call Func2 ! A
    nop

    mov %o0,%i0 ! stores A

    mov %i1,%o0 ! stores B for Func2 call

    call Func2 ! B
    nop

    add %i0, %o0, %i0 ! Adds a doubled A and B together 
 
    ret  
    restore
