from django.urls import path
from .views import weatherStation, EntryDetailView

urlpatterns = [
    path('', weatherStation, name='weatherStation'),
    path('entry/<int:index>', EntryDetailView.as_view(), name='entry')
]