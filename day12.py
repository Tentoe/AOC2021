from collections import Counter

input_data = open("day12.input").read().split("\n")
input_data = [tuple(a.split("-")) for a in input_data]


connections = []

for (a, b) in input_data:
    if a != 'start':
        connections.append((b, a))

connections += input_data
connections.sort()

def part1(path, b):
    return b not in path

def part2(path, b):
    count = Counter(path + [b])
    lower2 = 0
    for key in count.keys():
        if key in ['start', 'end'] and count[key] > 1:
            return False
        if key.islower() and count[key] > 1:
            if count[key] < 3:
                lower2 += 1
            else:
                return False
        
    return lower2 <= 1

start_paths = [['start']]
end_paths = []

while True:
    new_paths = []
    for path in start_paths:
        for (a, b) in connections:
            if path[-1] == a and b == 'end':
                end_paths.append(path + [b])
            elif path[-1] == a and (b.isupper() or part2(path, b)):
                new_paths.append(path + [b])
    if len(new_paths) > 0:
        start_paths = new_paths
    else:
        break

print('Result')
for path in end_paths:
    print(path)
print(len(end_paths))
