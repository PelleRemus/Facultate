from django.shortcuts import render
from django.views.generic import DetailView
from .models import Entry

# Create your views here.
class EntryDetailView(DetailView):
    model = Entry

    def get(self, request):
        entry = Entry.objects.get(pk=1)
        return

def weatherStation(request):
    return render(request, 'WeatherStation/index.html', {'entries': Entry.objects.all()})