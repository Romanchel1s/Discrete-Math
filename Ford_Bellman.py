import math
        #1 2 3 4 5
MatW = [[0,1,0,0,3], #1
        [0,0,8,7,1], #2
        [0,0,0,1,-5], #3
        [0,0,2,0,0], #4
        [0,0,0,4,0]] #5


n = len(MatW)
MatK=[[0,math.inf,math.inf,math.inf,math.inf]]

for line in range(len(MatW)):
   for i in range(len(MatW[line])):
        if MatW[line][i] == 0:
            MatW[line][i] = math.inf

k = 1
while k < n:
    line = []
    for i in range(n):
        Ui = MatK[k-1][i]
        for j in range(n):
            if Ui > MatK[k-1][j] + MatW[j][i]:
                Ui = MatK[k-1][j] + MatW[j][i]
        line.append(Ui)
    MatK.append(line)
    k+=1

for i in range(n):
    print(f"shortest way to node {i+1} = {MatK[k-1][i]}")

