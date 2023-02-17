import math

def mini(R,s):
    rm = (math.inf, 0 ,0)
    for p in s:
        rr = min(R, key=lambda x: x[0] if (x[1] == p or x[2] == p) and (x[1] not in s or x[2] not in s) else math.inf)
        if rm[0] > rr[0]:
            rm = rr
    return rm

R = [(math.inf, 0 ,0),(13, 1, 2), (18, 1, 3), (17, 1, 4), (14, 1, 5), (22, 1, 6),
     (26, 2, 3), (22, 2, 5), (3, 3, 4), (19, 4, 6)]
u = {1,2,3,4,5,6}
s = {1}
long = 0
T = []

while len(s) < len(u):
    r = mini(R,s)
    long += r[0]
    s.add(r[1])
    s.add(r[2])
    print(s)
    
print(long)    
    
      
                
                
                
                           
        
                
