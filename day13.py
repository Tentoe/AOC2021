from collections import Counter
from itertools import permutations, combinations, product

input_data = open("day13.input").read().split("\n")

points = []
fold = []

for line in input_data:
    if len(line) == 0:
        continue
    if line.startswith('fold'):
        fo = line.split(' ')[2].split('=')
        fold.append((fo[0], int(fo[1])))
        continue
    p = line.split(',')
    points.append((int(p[0]), int(p[1])))

# part1 fold[:1]
for (f, h) in fold:
    if f == 'y':
        foldpoints = list(filter(lambda x: x[1] >= h, points))
        for (x, y) in foldpoints:
            points.remove((x, y))
            points.append((x, h - (y-h)))
    if f == 'x':
        foldpoints = list(filter(lambda x: x[0] >= h, points))
        for (x, y) in foldpoints:
            points.remove((x, y))
            points.append((h - (x-h), y))


maxx = max([x for (x, y) in points])
maxy = max([y for (x, y) in points])

grid = ["."*(maxx + 1) for x in range(maxy+1)]

for (x, y) in points:
    nline = list(grid[y])
    nline[x] = '#'
    grid[y] = ''.join(nline)

for line in grid:
    print(line)

print("points", len(set(points)))
