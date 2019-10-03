'''Se dau doua stringuri citite de la tastatura. Sa se inlocuiasca
toate aparitiile stringului 2 in stringul 1 cu caracterul *
'''
#listele se deosebesc prin steluta scrisa inaintea numelui variabilei
def stringOperation(a, *lista):
    b = input('b = ')
    if b in a:
        print('ceva')
    else:
        print('altceva')

    #concatenare
    print(a + b)
    #al doilea caracter al stringului
    print(a[1])
    #lungimea stringului
    print(len(a))
    #substringul format din caracterele lui a de la 1 inclusiv la 3 exclusiv
    print(a[1:3])
    #substringul de la lungimea lui a -3 pana la lungimea lui a -1
    print(a[-3:-1])

    #metoda format adauga elementele din paranteza in acoladele din string
    c = 'Asta {} este {} viata {}'
    print(c.format(1, 2, 3))
    #putem da o alta ordine acestor acolade
    d = 'Asta {2} este {0} viata {1}'
    print(d.format(1, 2, 3))

    #rezolvarea problemei initiale:
    print(a.replace(b, '*'))
    #o mica introducere la cum functioneaza listele in python
    print(lista[0], lista[1])
    #se poate returna orice, sau nimic
    return 'return'


def listOperations(obj):
    myList = ['a', 'b', 'c', 'd']
    myList[0] = 'x'
    print(myList)
    for item in myList:
        print(item)

    #nu facem o noua referinta la aceeasi lista, ci facem o copie la lista myList
    myNewList = myList.copy()
    print(myNewList)
    #se creeaza o noua lista cu elementele ambelor liste in ordinea data
    print(myList + myNewList)

    #adaugam obj la finalul listei
    myList.append(obj)
    print(myList)
    #sterge prima aparitie a lui obj in lista
    myList.remove(obj)
    print(myList)
    #sterge ultimul element din lista
    myList.pop()
    print(myList)
    #sterge elemntul de pe pozitia 0
    del myList[0]
    print(myList)
    #sterge toate elementele listei si ramane goala
    myList.clear()
    print(myList)


def tuplesOperations():
    myTuple = ('a', 'b', 'c', 'd')
    print(myTuple)

    #nu putem scrie myTuple[0] = 'x'
    aux = list(myTuple)
    aux[0] = 'x'
    myTuple = tuple(aux)
    print(myTuple)
    #restul metodelor sunt similare cu cele ale listei


def setOperations():
    #seturile sunt o colectie de obiecte a caror ordine nu conteaza, este important doar sa existe toate obiectele dorite
    mySet = {'a', 'b', 'c', 'd'}
    print(mySet)
    mySet.add('e')
    print(mySet)
    #nu se poate adauga de doua ori aceeasi valoare
    mySet.add('e')
    print(mySet)
    #asa adaugam mai multe elemente deodata in set
    mySet.update(['x', 'y', 'z'])
    print(mySet)
    #se sterge elementul x. Daca nu exista, nu da eroare (spre deosebire de remove)
    mySet.discard('x')
    print(mySet)


def dictionaryOperatins():
    #dictionarul este o multime de perechi cheie-valoare. In loc sa apelam cu indecsi, vom apela valorile cheilor
    myDictionary = {'first': 1, 'second': 2, 'third': 3}
    print(myDictionary['first'])
    myDictionary['first'] = 4
    print(myDictionary['first'])

    #se afiseaza doar valorile dictionarului
    print(myDictionary.values())
    #se afiseaza perechile de cheie cu valoarea sa
    print(myDictionary.items())
    #asa se adauga simplu si dinamic un element in dictionar
    myDictionary['fourth'] = 4
    print(myDictionary.items())


if __name__ == '__main__':
    a = input('a = ')
    print(stringOperation(a, 'first', 'second'))
    listOperations(a)
    tuplesOperations()
    setOperations()
    dictionaryOperatins()