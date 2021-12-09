input_data = open("day9.input").read().split("\n")


adj_m = [[0,1],[1,0],[0,-1],[-1,0]]

sol = 0

basins = []

for ix, line in enumerate(input_data):
    for iy, col in enumerate(line):
        adj = []
        for a in adj_m:
            realx= ix+a[0]
            realy = iy+a[1]
            if realx >= 0 and realy >= 0 and realx < len(input_data) and realy < len(line):
                adj.append(int(input_data[realx][realy]))

           
        if int(col) < min(adj):
            sol += int(col) + 1
            basins.append([(ix,iy)])

print(sol)

for bx, basin in enumerate(basins):
    print(basin)
    while True:
        check = []
        for point in basin:
            for a in adj_m:
                realx= point[0]+a[0]
                realy = point[1]+a[1]
                if realx >= 0 and realy >= 0 and realx < len(input_data) and realy < len(line):
                    check.append((realx, realy))
        check = list(filter(lambda x: x not in basins[bx], check))
        print(check)
        break


