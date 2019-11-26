from django.shortcuts import render
from django.views.generic import FormView
from .forms import ContactForm

# Create your views here.
class ContactView(FormView):
    template_name = 'project/contact.html'
    form_class = ContactForm
    success_url = '/contact'
    def post(self, request):
        print(self.form_class.cleaned_data['name'])