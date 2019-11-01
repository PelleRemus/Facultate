from django.shortcuts import render
from django.http import HttpResponse
from .models import Contact

# Create your views here.
def home(request):
    myContact = Contact();
    myContact.name = 'UnNume'
    myContact.save()
    return HttpResponse('<h1>Hello World!</h1>')