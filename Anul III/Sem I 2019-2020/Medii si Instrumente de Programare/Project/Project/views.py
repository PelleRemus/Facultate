from django.shortcuts import render, redirect
from django.views.generic import FormView, TemplateView
from django.urls import reverse_lazy
from django.contrib import messages

from .forms import ContactForm
from .models import ContactTest

# Create your views here.
def contactSimpleView(request):
    username = ''
    if('name' in request.session):
        username = request.session['name']

    myContactForm = ContactForm()
    if(request.method == 'POST'):
        myContactForm = ContactForm(request.POST)
        if(myContactForm.is_valid()):
            myContactForm.save()
            messages.success(request, 'Contact form saved!')
            return redirect(reverse_lazy('contact'))

    return render(request, 'project/simple.html', { 'form': myContactForm, 'name': username })

class ContactV1View(TemplateView):
    template_name = 'project/v1.html'

    def get(self, request):
        myContactForm = ContactForm();
        return render(request, self.template_name, { 'form': myContactForm })

    def post(self, request):
        myContactForm = ContactForm(request.POST, request.FILES)
        if (myContactForm.is_valid()):
            myContactForm.save()
            messages.success(request, 'Contact form saved!')
            return redirect(reverse_lazy('contact_v1'))
        return render(request, self.template_name, {'form': myContactForm})

class ContactV2View(FormView):
    template_name = 'project/v2.html'
    form_class = ContactForm
    success_url = reverse_lazy('contact_v2')

    def form_valid(self, form):
        form.save()
        messages.success(self.request, 'Contact form saved!')
        return redirect(reverse_lazy('contact_v2'))

class ContactView(FormView):
    template_name = 'project/contact.html'
    form_class = ContactForm
    success_url = '/contact'
    def post(self, request):
        print(self.form_class.cleaned_data['name'])