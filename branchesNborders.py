import math

graph = [[math.inf,12,22,28,32],
         [12,math.inf,10,40,20],
         [22,10,math.inf,50,10],
         [28,27,17,math.inf,27],
         [32,20,10,60,math.inf]]


def minline(graph):
    minl = []
    mins = []
    k = 0
    for line in graph:
        new_list = list(filter(lambda x: (x != None) , line))
        try:
            r = min(new_list)
            minl.append(r)
            for i in range(len(line)):
                if line[i] == None:
                    continue
                line[i] -= r
            graph[k] = line
            k += 1
        except:
            k += 1
            continue

    for i in range(len(graph)):
        z = []
        for j in range(len(graph)):
            if graph[j][i] != None:
                z.append(graph[j][i])
        try:
            r = min(z)
            mins.append(r)
            for j in range(len(graph)):
                if graph[j][i] != None:
                    graph[j][i] -= r
        except:
            continue

    bottom_line = sum(minl) + sum(mins)
    ret = (graph,bottom_line)
    return ret


def rate(graph):
    zeros = {}
    for i in range(len(graph)):
        for j in range(len(graph)):
            if graph[i][j] == 0:
                s = []
                for z in range(len(graph)):
                    if j == z:
                        continue
                    if graph[i][z] != None:
                        s.append(graph[i][z])
                minl = min(s)
                d = []
                for z in range(len(graph)):
                    if i == z:
                        continue
                    if graph[z][j] != None:
                        d.append(graph[z][j])
                mins = min(d)
                l = (i,j)
                zeros[l] = mins+minl
    r = ()
    fine = max(zeros.values())
    for i in zeros:
        if zeros[i] == fine:
            r = i
    graph[r[1]][r[0]] = math.inf
    for i in range(len(graph)):
        if i == r[0]:
                graph[i] = [None,None,None,None,None]
                continue
        for j in range(len(graph)):
            try:
                if j == r[1]:
                    graph[i][j] = None
            except:
                continue
    return (graph,fine)

    

bottom_line = 0
for i in range(2,len(graph)):
    r = minline(graph)
    bottom_line += r[1]
    graph = r[0]
    graph = rate(graph)[0]

print(bottom_line)
