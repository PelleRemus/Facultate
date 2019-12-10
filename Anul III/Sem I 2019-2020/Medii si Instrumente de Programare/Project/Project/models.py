from django.db import models

# Create your models here.
class ContactTest(models.Model):
    name = models.CharField(max_length = 255)
    subject = models.CharField(max_length = 255)
    message = models.TextField()
    email = models.EmailField()
    attachment = models.FileField(upload_to='contact/', null = True)