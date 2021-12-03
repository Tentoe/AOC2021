import math


input_data = open("day3.input").read().split("\n")

gamma_times = [0]*len(input_data[0])


for item in input_data:
    for digit in range(len(item)):
        if item[digit] == "1":
            gamma_times[digit] += 1


gamma = ""

for digit in gamma_times:
    if int(digit) > len(input_data)/2:
        gamma += "1"
    else:
        gamma += "0"

epsilon = ""

for digit in gamma:
    if digit == "1":
        epsilon += "0"
    else:
        epsilon += "1"


print(int(gamma,2) * int(epsilon,2))

def timesOne(data, digit):
    times = 0
    for item in data:
        if item[digit] == "1":
            times += 1
    return times
        

oxygen_data = open("day3.input").read().split("\n")

for digit in range(len(oxygen_data[0])):

    if timesOne(oxygen_data, digit) >= len(oxygen_data)/2:
        oxygen_data = list(filter(lambda x: x[digit] == "1", oxygen_data))
    else:
        oxygen_data = list(filter(lambda x: x[digit] == "0", oxygen_data))
        
    if len(oxygen_data) == 1:
        break

print(oxygen_data[0])
oxygen = int(oxygen_data[0],2)

oxygen_data = open("day3.input").read().split("\n")

for digit in range(len(oxygen_data[0])):

    if timesOne(oxygen_data, digit) < len(oxygen_data)/2:
        oxygen_data = list(filter(lambda x: x[digit] == "1", oxygen_data))
    else:
        oxygen_data = list(filter(lambda x: x[digit] == "0", oxygen_data))
        
    if len(oxygen_data) == 1:
        break

print(oxygen_data[0])
co2 = int(oxygen_data[0],2)

print(oxygen * co2)