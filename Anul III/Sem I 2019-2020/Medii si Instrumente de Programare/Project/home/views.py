from django.shortcuts import render
from django.views.generic import FormView
from .forms import ContactForm

# Create your views here.
def home(request):
    return render(request, 'home/index.html',)

class AboutView(FormView):
    template_name = 'home/about.html'
    form_class = ContactForm
    success_url = '/about'
    def post(self, request):
        print(self.form_class.cleaned_data['name'])
