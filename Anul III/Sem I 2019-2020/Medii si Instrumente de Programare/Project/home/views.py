from django.shortcuts import render
from .models import Contact

# Create your views here.
def home(request):
    return render(request, 'home/index.html', {'foo': Contact.objects.all()})