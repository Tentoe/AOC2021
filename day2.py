input_data = open("day2.input").read().split("\n")
input_data = [a.split(" ") for a in input_data]

horizontal = 0
depth = 0
aim = 0

for item in input_data:
    if item[0] == 'forward':
        horizontal += int(item[1])
        depth += aim * int(item[1])
    if item[0] == 'down':
        aim += int(item[1])
    if item[0] == 'up':
        aim -= int(item[1])



print(horizontal, depth, aim, horizontal * depth)