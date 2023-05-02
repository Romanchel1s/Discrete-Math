import math

finish = 0
MatW = []

with open('test.txt') as f:
    lines = f.readlines()
    l = lines[0].split()
    finish = int(l[0])
    for i in range(finish):
        line = [0]*finish
        MatW.append(line)
    for i in range(1,len(lines)):
        line = lines[i].split()
        MatW[int(line[0])-1][int(line[1])-1] = -(int(line[2]))
        
for line in range(len(MatW)):
   for i in range(len(MatW[line])):
        if MatW[line][i] == 0:
            MatW[line][i] = math.inf

for A in range(len(MatW)):
    for B in range(len(MatW)):
        if MatW[A][B] != math.inf:
            for C in range(len(MatW)):
                if MatW[A][C] > MatW[A][B] + MatW[B][C]:
                    MatW[A][C] = MatW[A][B] + MatW[B][C]


if MatW[0][finish-1] == math.inf:
    print('Лабиринт пройти нельзя')
else:
    print(-MatW[0][finish-1])
