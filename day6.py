input_data = open("day6.input").read().split("\n")

fishs = list(map(lambda x: int(x), input_data[0].split(',')))

population = [0] * 9

for fish in fishs:
    population[fish] += 1

for day in range(256):
    parents = population.pop(0)
    population[6] += parents
    population.append(parents)

print(sum(population))
