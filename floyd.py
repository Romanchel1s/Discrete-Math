import math
        #1 2 3 4 5 6
MatW = [[0,3,1,3,0,0], #1
        [3,0,4,0,0,0], #2
        [1,4,0,0,7,5], #3
        [3,0,0,0,0,2], #4
        [0,0,7,0,0,4], #5
        [0,0,5,2,4,0]] #6

        #1 2 3 4 5 6
MatH = [[0,2,3,4,0,0], #1
        [1,0,3,0,0,0], #2
        [1,2,0,0,5,6], #3
        [1,0,0,0,0,6], #4
        [0,0,3,0,0,6], #5
        [0,0,3,4,5,0]] #6

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
                    MatH[A][C] = MatH[A][B]
print('Введите вершину')
i = int(input())-1
for c in range(len(MatW)):
    if i!=c:
        print(f'Расстояние от вершины {i+1} до {c+1} = {MatW[i][c]}')
                    

