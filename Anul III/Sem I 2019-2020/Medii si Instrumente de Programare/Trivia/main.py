import urllib.request
import json
from user import User

baseUrl = 'https://trivia-mpi.firebaseio.com/'


def initUsers(userDict):
    users = []
    #iterare pe dictionar (se poate face si doar cu index)
    for index, item in usersDict.items():
        user = User(index, item['name'], item['email'], item['score'])
        users.append(user)
        print(user)
    return users


def nameExistsInDB(users, name):
    for item in users:
        if item.name == name:
            return True
    return False


def postNewUser(name):
    email = input('Your name does not exist in the database. Please insert your mail: ')
    newUser = {'name': name, 'email': email, 'score': 0}
    #json.dumps transforma obiectul din paranteza in obiect json
    params = json.dumps(newUser).encode('utf8')
    postRequest = urllib.request.Request(baseUrl + "user.json", data = params, headers = {'content-type': 'application/json'})
    urllib.request.urlopen(postRequest)


if __name__ == '__main__':
    name = input('Please enter your name: ')

    #get request
    with urllib.request.urlopen(baseUrl + "user.json") as usersJson:
        usersDict = json.load(usersJson)
    print(usersDict)

    users = initUsers(usersDict)
    print(users)
    if not nameExistsInDB(users, name):
        postNewUser(name)

    print('Welcome, ' + name + '!')