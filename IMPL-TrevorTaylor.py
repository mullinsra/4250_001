import os
import string
#using recursion take two numbers from input add them together and seperate the least sig digit and keep doing that recursively'
#until single digit as answer
def add(a, b):
    c = a + b
    if(c < 10):
        print(c)
        return c
    else:
        leastSig = c%10
        c=int(c/10)
    print(str(c) +"+" +str(leastSig))
    add(c, leastSig)


def ASCII(input):
    ASCIISET=list((''.join(chr(i) for i in range(128))).encode('ascii')) # store them in digit 0-127
    ASCIISET.sort() #sort
    inputAscii=list(input.encode('ascii'))    #store input in ascii
     #(set index, occurances)
    SetWithOccurances=[]
    for index, set in enumerate(ASCIISET):
        SetWithOccurances.append((set, 0))

    #convert 
    #find matches
    for index, char in enumerate(input): #loop through input
        for index2, set in enumerate(ASCIISET): #loop through ascii set
            if(inputAscii[index] == set):
                SetWithOccurances[index2] = (SetWithOccurances[index2][0], SetWithOccurances[index2][1]+1)

    #empty
    countEmpty = 0
    for index, set in enumerate(ASCIISET):
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