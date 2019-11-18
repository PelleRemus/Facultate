from django.contrib import admin
from .models import WeatherType, Location, Entry

# Register your models here.
admin.site.register(WeatherType)
admin.site.register(Location)
admin.site.register(Entry)