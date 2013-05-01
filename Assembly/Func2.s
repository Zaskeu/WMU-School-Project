.global Func2 ! "assembler directive"
Func2:    save  %sp,-800, %sp ! machine instruction
    
    .word 0xB0060018 ! add %i0, %i0, %i0  Doubles the value    
    
    ret  ! return is a "synthetic" 
         ! jmpl %i7, 8, %g0 
    restore
