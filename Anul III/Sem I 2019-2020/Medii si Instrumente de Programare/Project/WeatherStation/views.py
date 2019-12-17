from django.shortcuts import render
from django.views.generic import DetailView
from django.http import HttpResponse

from .models import Entry

# Create your views here.
class EntryDetailView(DetailView):
    model = Entry

    # def get(self, request, *args, **kwargs):
    #     print(args)
    #     print(kwargs)
    #     entry = Entry.objects.get(pk=kwargs['pk'])
    #     return super(EntryDetailView, self).get(self, request, args, kwargs)

def weatherStation(request):
    return render(request, 'WeatherStation/index.html', {'entries': Entry.objects.all()})

def homeContent(request):
    return HttpResponse('success')