
input_data = open("day1a.input").read().split("\n")
input_data = [int(a) for a in input_data]


times1 = 0

for item in range(len(input_data)-1):
    if input_data[item] < input_data[item+1]:
        times1 = times1 + 1

times2 = 0
for item in range(len(input_data)-3):
    sum1 = input_data[item] + input_data[item+1] + input_data[item+2]
    sum2 = input_data[item+1] + input_data[item+2] + input_data[item+3]
    if sum1 < sum2:
        times2 = times2 + 1

print(times1)
print(times2)
