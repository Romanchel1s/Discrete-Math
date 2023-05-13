from queue import Queue
MatA = [[0,1,0,0],
       [1,0,0,1],
       [0,0,0,0],
       [0,1,0,0]]

q = Queue()
q.put(0)
s = dict()
for l in range(len(MatA)):
  s[l] = {l}
for i in range(len(MatA)):
  vert = q.get()
  for j in range(len(MatA)):
    if MatA[vert][j] == 1:
      q.put(j)
      s[vert].add(j)
      s[vert] = s[vert].union(s[j])
      s[j] = s[j].union(s[vert])

print(s)


# output: {0: {0, 1, 3}, 1: {0, 1, 3}, 2: {2}, 3: {0, 1, 3}}
