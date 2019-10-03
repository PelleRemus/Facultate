'''Diferente intre C# si python:
1. nu se folosesc acolade pentru incapsulare, pur si simplu codul se indenteaza mai la dreapta
2. nu se pune ;
3. variabilele se definesc fara tip de date, se atribuie tipul necesar conform atribuirilor din cod
4. acest lucru este valabil si la metode si clase, care nu au tip de data la declaratie, doar cuv cheie def
5. C.WL = print, C.RL = input
6. if nu are argumente in paranteza, ci separat prin spatiu, si se finalizeaza cu :
'''
import math

#asa se defineste metoda Main:
if __name__ == '__main__':
    print('ax^2 + bx + c')
    a = int(input("a = "))
    b = int(input("b = "))
    c = int(input("c = "))

    delta = b*b - 4*a*c
    deltaStr = 'delta = b^2 - 4ac = {}'
    print(deltaStr.format(delta))

    if delta > 0:
        print('delta > 0')
        x1 = (-b + math.sqrt(delta)) / (2*a)
        x2 = (-b - math.sqrt(delta)) / (2 * a)
        print('x1 = ' + str(x1))
        print('x2 = ' + str(x2))
    if delta == 0:
        print('delta = 0')
        x = -b / (2 * a)
        print('x1 = x2 =', x)
    if delta < 0:
        print('delta < 0 \nx1 si x2 nu apartin multimii R')