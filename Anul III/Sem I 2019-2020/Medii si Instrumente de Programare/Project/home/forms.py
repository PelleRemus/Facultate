from django import forms

class ContactForm(forms.Form):
    name = forms.CharField(max_length=255)
    subject = forms.CharField(max_length=255)
    message = forms.CharField(widget=forms.Textarea(attrs={"rows":5}))
    email = forms.EmailField()
