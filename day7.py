input_data = open("day7.input").read().split("\n")
input_data = list(map(lambda x: int(x), input_data[0].split(',')))

diff = 0
max_pos = max(input_data)
min_pos = min(input_data)


def getDiff(data, pos):
    diff = 0
    for crab in data:
        diff += sum(range(1, abs(crab - pos)+1))
    return diff


result = {}

for pos in range(min_pos, max_pos+1):

    print(pos, " von ", max_pos)
    result[pos] = getDiff(input_data, pos)

min_val = 9999999999999999999
target = 0

for key, item in result.items():
    if item < min_val:
        min_val = item
        target = key

print("POS:", target)
print("DIST:", result[target])
