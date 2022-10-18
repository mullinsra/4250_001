WCK- overall, it looks like you just jumped straight into coding the happy path without commenting the code, without any design, with any test case 
      scenarios or test data. And the result is a solution that will not work except in some specific cases so it is what is commonly referred to as 
      "Fragile Code". The whole point of the required reading was to avoid this exact scenario.

import os
import string
#using recursion take two numbers from input add them together and seperate the least sig digit and keep doing that recursively'
#until single digit as answer
def add(a, b):                   WCK-I think you could have a more descriptive name for this method and the variables you use within it
    c = a + b                    WCK- What happens if I entered maxInt for both a and b? 
    if(c < 10):                  WCK-What if I enter negative numbers for a and b such that c is negative but more than 1 digit? you'll print out c as the answer
        print(c)
        return c
    else:
        leastSig = c%10          WCK- this line and the next is a pretty efficient way to do this
        c=int(c/10)
    print(str(c) +"+" +str(leastSig))
    add(c, leastSig)

                                 WCK- ASCII has nothing to do with recursion but you don't have any comments for this.
                                      Oh, this is the second problem. I had to guess because there are no commments to explain what is happening
             
def ASCII(input):                WCK- why is the name all caps? 
    ASCIISET=list((''.join(chr(i) for i in range(128))).encode('ascii')) # store them in digit 0-127    WCK- why only 128?? Again, why all caps for variable
    ASCIISET.sort() #sort
    inputAscii=list(input.encode('ascii'))    #store input in ascii          WCK- but here you use camelCase for a variable name
     #(set index, occurances)
    SetWithOccurances=[]                                                     WCK- and here you use a third style for a variable name
    for index, set in enumerate(ASCIISET):
        SetWithOccurances.append((set, 0))                                   WCK- still not clear why only 128

    #convert 
    #find matches
    for index, char in enumerate(input): #loop through input
        
        WCK- instead of looping, why wouldn't you just get the ascii code for the char and use that as an index into the occurrence set
        for index2, set in enumerate(ASCIISET): #loop through ascii set
            if(inputAscii[index] == set):
                SetWithOccurances[index2] = (SetWithOccurances[index2][0], SetWithOccurances[index2][1]+1)

    #empty
    countEmpty = 0
    for index, set in enumerate(ASCIISET):          WCK- why are you counting empty cells?
        if(SetWithOccurances[index][1]==0):
            countEmpty = countEmpty + 1

    #for char in ASCIISET
    print(SetWithOccurances)
    print("\n\n")
    sortTemp = sorted(SetWithOccurances, key=lambda set: set[1],reverse=True)
    print(sortTemp)
    print("\nEmpty: ")
    print(countEmpty)
    print(inputAscii)
    print("reverse: ")
    txtReverse = input[::-1]
    print(txtReverse)

#MAIN
temp = str(input("\nenter a string: "))
ASCII(temp)

A = int(input("\nenter int A:"))
B = int(input("\nenter int B:"))
add(A, B)
