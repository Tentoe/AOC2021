input_data = open("day10.input").read().split("\n")

chunk_dict= {
    '(':')',
    '[':']',
    '{':'}',
    '<':'>'
}

points= {
    ')':3,
    ']':57,
    '}':1197,
    '>':25137
}

points2= {
    '(':1,
    '[':2,
    '{':3,
    '<':4
}

score = 0
linescores = []


for linenum, line in enumerate(input_data):
    stack = []
    error = False
    for i, pos in enumerate(line):
        if pos in chunk_dict.keys():
            stack.append(pos)
        else:
            if pos == chunk_dict[stack[-1]]:
                stack.pop()
            else:
                score += points[pos]
                # error.append(linenum)
                error = True
                break
    if not error:
        linescore = 0
        stack.reverse()
        for s in stack:
            linescore *= 5
            linescore += points2[s]
        linescores.append(linescore)

print(score)



print("aufgabe 2")
linescores.sort()
middle = int(len(linescores)/2)
print(linescores[middle])