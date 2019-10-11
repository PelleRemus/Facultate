class User:
    #constructorul
    def __init__(self, id, name, email, score):
        self.id = id
        self.name = name
        self.email = email
        self.score = score

    #echivalentul metodei ToString()
    def __str__(self):
        return self.name + ': ' + str(self.score)

    #metoda pentru afisarea valorilor campurilor obiectului
    def __repr__(self):
        return self.id + ', ' + self.name + ', ' + self.email + ', ' + str(self.score)