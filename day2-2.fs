\ aoc day 2 part 2

128 constant memsize 
19690720 constant target 

create program 
    1 , 0 , 0 , 3 , 1 , 1 , 2 , 3 , 1 , 3 , 4 , 3 , 1 , 5 , 0 , 3 , 2 , 13 , 1 , 19 , 1 ,
    10 , 19 , 23 , 1 , 6 , 23 , 27 , 1 , 5 , 27 , 31 , 1 , 10 , 31 , 35 , 2 , 10 , 35 ,
    39 , 1 , 39 , 5 , 43 , 2 , 43 , 6 , 47 , 2 , 9 , 47 , 51 , 1 , 51 , 5 , 55 , 1 ,
    5 , 55 , 59 , 2 , 10 , 59 , 63 , 1 , 5 , 63 , 67 , 1 , 67 , 10 , 71 , 2 , 6 , 71 ,
    75 , 2 , 6 , 75 , 79 , 1 , 5 , 79 , 83 , 2 , 6 , 83 , 87 , 2 , 13 , 87 , 91 , 1 ,
    91 , 6 , 95 , 2 , 13 , 95 , 99 , 1 , 99 , 5 , 103 , 2 , 103 , 10 , 107 , 1 , 9 ,
    107 , 111 , 1 , 111 , 6 , 115 , 1 , 115 , 2 , 119 , 1 , 119 , 10 , 0 , 99 , 2 , 14 ,
    0 , 0 , 

create memory memsize cells allot

: pc { n -- addr }
    memory n cells + 
;

: indirect { n -- addr }
    n pc @ pc
;

: 2next { n -- n n }
    n 1 + indirect @
    n 2 + indirect @
;

: load-program ( -- )
    memsize 0 do 
        program i cells + @ memory i cells + !
    loop
;

: run-program recursive { n -- } 
    n pc @
    case
        1 of 
            n 2next +
            n 3 + indirect !
            n 4 + run-program
            endof
        2 of 
            n 2next *
            n 3 + indirect !
            n 4 + run-program 
            endof
        99 of 
            exit 
            endof
        ." invalid opcode " n pc @ ." at " n . cr 
    endcase
;

: find-program
    99 0 do
        99 0 do
            load-program
            i memory 1 cells + !    \ set noun
            j memory 2 cells + !    \ set verb
            0 run-program
            memory @ target = if 
                ." found noun " i . ." verb " j . 
            then
        loop
    loop
;


find-program

           
