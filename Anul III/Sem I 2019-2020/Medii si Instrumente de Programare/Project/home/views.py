from django.shortcuts import render, redirect
from django.views.generic import FormView
from django.urls import reverse_lazy
from django.contrib import messages

from .forms import ContactForm

# Create your views here.
def home(request):
    return render(request, 'home/index.html',)

class AboutView(FormView):
    template_name = 'home/about.html'
    form_class = ContactForm
    success_url = '/about'

    def form_valid(self, form):
        form.save()
        messages.success(self.request, 'Contact form saved!')
        return redirect(reverse_lazy('about'))