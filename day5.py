from math import sqrt
from joblib import Parallel, delayed

input_data = open("day5.input").read().split("\n")


def distance(a, b):
    return sqrt((a['x'] - b['x'])**2 + (a['y'] - b['y'])**2)


def is_between(a, c, b):
    return round(distance(a, c) + distance(c, b), 10) == round(distance(a, b), 10)


def is_hover(a, b):
    return a['x'] == b['x'] or a['y'] == b['y']


def is_diagonal(a, b):
    return (a['x'] == a['y'] and b['x'] == b['y']) or (a['x'] == b['y'] and b['x'] == a['y'])


def getLines(data):
    ret = []
    for line in data:
        line2 = line.split(' -> ')
        coordinates1 = line2[0].split(',')
        coordinates2 = line2[1].split(',')
        linepoints = [{'x': int(coordinates1[0]), 'y': int(coordinates1[1])},
                      {'x': int(coordinates2[0]), 'y': int(coordinates2[1])}]
        # if is_hover(linepoints[0], linepoints[1]) or is_diagonal(linepoints[0], linepoints[1]):
        ret.append(linepoints)
    return ret


lines = getLines(input_data)

grid = [[0 for x in range(0, 1000)] for y in range(0, 1000)]


for x in range(len(grid)):
    print(x)
    for y in range(len(grid[0])):
        point = {'x': x, 'y': y}
        for line in lines:
            if is_between(line[0], point, line[1]):
                grid[x][y] += 1

score = 0

for x in range(len(grid)):
    for y in range(len(grid[0])):
        if grid[x][y] >= 2:
            print(x, ",", y)
            score += 1

print(score)
