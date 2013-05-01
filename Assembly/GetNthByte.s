.global GetNthByte


GetNthByte:
            save %sp,-800, %sp

            sll %i1, 3, %i1

            srl %i0, %i1, %i0

            and %i0, 0x000000FF, %i0

          ret
          restore
