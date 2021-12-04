
input_data = open("day4.input").read().split("\n")

draw = input_data.pop(0).split(',')

input_data.pop(0)

size = 5


def getCards(data):
    ret = []

    for start in range(0, int(len(input_data)), size+1):
        card = []
        for line in range(size):
            newline = []
            text = input_data[start+line]
            for num in range(0, len(text), 3):
                newline.append(int(text[num:num+2]))
            card.append(newline)
            

        ret.append(card)

    return ret


def getWinner(data):
    ret = []
    for idx, card in enumerate(data):
        for line in range(size):
            if all(map(lambda x: x == -1, card[line])):
                return idx
            column = [line2[line] for line2 in card]
            if all(map(lambda x: x == -1, column)):
                return idx
    return -1

def getWinners(data):
    ret = []
    for idx, card in enumerate(data):
        for line in range(size):
            if all(map(lambda x: x == -1, card[line])):
                ret.append(idx)
                break
            column = [line2[line] for line2 in card]
            if all(map(lambda x: x == -1, column)):
                ret.append(idx)
    return ret

def markCards(cards, drawn):
    for card in cards:
        for idx, line in enumerate(card):
            card[idx] = [ -1 if digit == drawn else digit for digit in line ]
        test = card

cards = getCards(input_data)

for drawn in draw:
    markCards(cards, int(drawn))
    winner = getWinner(cards)
    if winner >= 0:
        print("Winning:",winner, cards[winner])
        score = 0
        for line in cards[winner]:
            for digit in line:
                if digit > 0:
                    score += digit
        print(int(drawn) * score)
        break

cards = getCards(input_data)

for drawn in draw:
    
    markCards(cards, int(drawn))
    winners = getWinners(cards)
    winners.reverse()
    for winner in winners:
        last = cards.pop(winner)
        print(len(cards))
        if len(cards) == 0:
            score = 0
            for line in last:
                for digit in line:
                    if digit > 0:
                        score += digit
            print(int(drawn) * score)
            print(drawn,score)
            print(last)
            break
        