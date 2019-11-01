from django.db import models

# Create your models here.
class Contact(models.Model):
    name = models.CharField(max_length = 255)
    subject = models.CharField(max_length = 255)
    message = models.TextField()
    email = models.EmailField()