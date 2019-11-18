from django.urls import path
from . import views

urlpatterns = [
    path('', views.weatherStation, name='weatherStation')
]