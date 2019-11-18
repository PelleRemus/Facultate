from django.shortcuts import render
from django.views.generic import DetailView
from .models import Entry

# Create your views here.
class EntryDetailView(DetailView):
    queryset = Entry.objects.all

def weatherStation(request):
    return render(request, 'WeatherStation/index.html', {'entries': Entry.objects.all()})