import pandas as pd
import numpy as np


input_data = open("day8.input").read().split("\n")

sure = {2:1,
        3:7,
        4:4,
        7:8}

data = []

for item in input_data:
    s = item.split(' | ')
    data.append((s[0].split(' '),s[1].split(' ')))

counter = 0

for first, second in data:
    for item in second:
        if len(item) in sure.keys():
            counter += 1

print(counter)

out_sum = 0

for first, second in data:
    wire_map = {}
    map_wire = {}
    for item in first:
        if len(item) in sure.keys():
            wire_map[item] = sure[len(item)]
            map_wire[sure[len(item)]] = item

    for key in wire_map.keys():
        first.remove(key)
    #3+
    for item in first:
        if len(set(item + map_wire[1] + map_wire[7])) == 5:
            wire_map[item] = 3
            map_wire[3] = item
            first.remove(item)
            break
    #6+
    for item in first:
        if len(set(item + map_wire[1])) == 7:
            wire_map[item] = 6
            map_wire[6] = item
            first.remove(item)
            break
    #9+
    for item in first:
        if len(item) == 6 and len(set(item+map_wire[4])) == 6:
            wire_map[item] = 9
            map_wire[9] = item
            first.remove(item)
            break
    #0+
    for item in first:
        if len(item) == 6:
            wire_map[item] = 0
            map_wire[0] = item
            first.remove(item)
            break

    #2
    for item in first:
        if len(set(item+map_wire[4])) == 7:
            wire_map[item] = 2
            map_wire[2] = item
            first.remove(item)
            break

    #5
    wire_map[first[0]] = 5
    map_wire[5] = first[0]

    number = ''
    for item in second:
        for digit in wire_map.keys():
            if set(item) == set(digit):
                number += str(wire_map[digit])
    print(number)
    out_sum += int(number)
    

print(out_sum)