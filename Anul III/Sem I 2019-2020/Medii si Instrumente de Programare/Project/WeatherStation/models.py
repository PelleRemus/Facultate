from django.db import models

# Create your models here.
class WeatherType(models.Model):
    name = models.CharField(max_length = 100)

class Location(models.Model):
    name = models.CharField(max_length = 255)
    longitude = models.DecimalField(max_digits = 20, decimal_places = 12)
    latitude = models.DecimalField(max_digits = 20, decimal_places = 12)

class Entry(models.Model):
    weatherType = models.ForeignKey(WeatherType, on_delete = models.CASCADE)
    location = models.ForeignKey(Location, on_delete = models.CASCADE)
    dateTime = models.DateTimeField()
    temperature = models.IntegerField()
    humidity = models.IntegerField()