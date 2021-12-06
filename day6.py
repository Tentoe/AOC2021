input_data = open("day6.input").read().split("\n")


fishs = input_data[0].split(',')

fishs = list(map(lambda x: int(x), fishs))



fertility = 6

new_fertility = 8

#days = 80

days = 256

population = [0] * (new_fertility+1)


for fish in fishs:
    population[fish] += 1


for day in range(days):
    parents = population.pop(0)
    population[fertility] += parents
    population.append(parents)

print(sum(population))
        

# for day in range(days):
#     newfish = 0
#     for ix, fish in enumerate(fishs):
#         if fish > 0:
#             fishs[ix] -= 1
#         if fish == 0:
#             fishs[ix] = fertility
#             newfish += 1
#     fishs = fishs + [new_fertility] * newfish
# print(len(fishs))

