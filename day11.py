from itertools import permutations, combinations, product

near = list(product((0, 1, -1), (0, 1, -1)))
near.remove((0, 0))

input_data = open("day11.input").read().split("\n")

input_data = [[int(pos) for pos in line] for line in input_data]

points = list(product(range(len(input_data)), range(len(input_data[0]))))

flashes = 0
first_all = 0

for step in range(2000):
    for (x, y) in points:
        input_data[x][y] += 1

    flashed = []
    while True:
        toflash = []
        for (x, y) in points:
            if input_data[x][y] > 9 and (x, y) not in flashed:
                toflash.append((x, y))
        if len(toflash) == 0:
            break
        else:
            for (x, y) in toflash:
                for (x2, y2) in near:
                    if x+x2 >= 0 and x+x2 < len(input_data) and y+y2 >= 0 and y+y2 < len(input_data[0]):
                        input_data[x+x2][y+y2] += 1
                flashed.append((x, y))
    for (x, y) in points:
        if input_data[x][y] > 9:
            input_data[x][y] = 0
            flashes += 1

    if first_all == 0 and all(map(lambda xy: input_data[xy[0]][xy[1]] == 0, points)):
        first_all = step + 1

print(flashes)
print(first_all)
