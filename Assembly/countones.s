.global countones

countones:
          save %sp,-800, %sp

      clr %l0

loop: and %i0, 0x00000001, %l1
      cmp %l1,1
      be,a count
      inc %l0 

count:
      srl %i0,1,%i0
      cmp %i0,0
      bne,a loop
      nop

end:
     mov %l0, %i0       !Falls through
     ret
     restore
