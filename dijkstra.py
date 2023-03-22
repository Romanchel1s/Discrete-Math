import math
import time
        #1 2 3 4 5
MatW = [[0,10,0,30,100], #1
        [0,0,50,0,0,], #2
        [0,0,0,0,10], #3
        [0,0,20,0,60], #4
        [0,0,0,0,0]] #5

def get_key(d, value):
    for k, v in d.items():
        if v == value:
            return k      
iters = {}
result = {}
for i in range(len(MatW)):
    iters[i] = math.inf
start = int(input())-1
final = int(input())-1
iters[start] = 0
vertex = set()
count = 0
helps = [{}]
while True:
    for i in range(len(MatW)):
        if MatW[start][i] !=0 and iters[i] > MatW[start][i] + iters[start]:
            iters[i] = MatW[start][i] + iters[start]
    vertex.add(start)
    keys = []
    for key in iters.keys():
        if key not in vertex:
            keys.append(key)
    m = math.inf
    if len(keys) == 0:
        #print('final')
        #print(iters)
        #print(result)
        break
    #print(start) 
    for k in keys:
        if iters[k] < m:
            m = iters[k]
    start = get_key(iters,m)
    result[start] = m
    #print(iters)
    #print(result)
    if result == helps[count]:
        break
    helps.append(result)
    count += 1
    if count > len(MatW):
        print('Путь не найден')
        sys.exit('Путь не найден')
        break


print(iters[final])
    

    
            
        
    
    



            
