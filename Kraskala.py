R = [(13, 1, 2), (18, 1, 3), (17, 1, 4), (14, 1, 5), (22, 1, 6),
     (26, 2, 3), (22, 2, 5), (3, 3, 4), (19, 4, 6)]
U = set()
I = [1,2,3,4,5,6]
long = 0
Rs = sorted(R, key=lambda R: R[0])
D = {}

for r in Rs:
    if len(U) >= len(I):
        break
    elif r[1] not in U or r[2] not in U:
        if r[1] not in U and r[2] not in U:
            D[r[1]] = [r[1],r[2]]
            D[r[2]] = D[r[1]]
        else:
            if not D.get(r[1]):
                D[r[2]].append[r[1]]
                D[r[1]] = D[r[2]]
            else:
                D[r[1]].append(r[2])
                D[r[2]] = D[r[1]]      
        U.add(r[1])
        U.add(r[2])
        long += r[0]
for r in Rs:
    if r[2] not in D[r[1]]:
        long += r[0]
        k = D[r[1]]
        D[r[1]] += D[r[2]]
        D[r[2]] += k
        
print(long)                    
