\ aoc2019 day 1
100 constant buf-size
create buf buf-size allot 

: fuel-for-module  ( n -- n )
 3 / 2 -
; 

: read-num-from-file ( wfileid -- n flag )
    \ reads int from wfileid, returns result and flag not eof
    buf buf-size rot read-line throw >r >r 
    0. buf r> >number 2drop d>s r> 
;

: calculate ( wfileid -- n )
    >r 0 begin
        r@ read-num-from-file
        while
        fuel-for-module +
    repeat
    drop r> drop
;

s" day1.in.txt" r/o open-file throw Value input
input calculate 