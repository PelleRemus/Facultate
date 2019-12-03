from django import forms
from .models import ContactTest

class ContactForm(forms.ModelForm):
    class Meta:
        model = ContactTest
        exclude = []
