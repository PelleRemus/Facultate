from django.urls import path
from .views import ContactView, contactSimpleView, ContactV1View, ContactV2View

urlpatterns = [
    path('', contactSimpleView, name='contact'),
    path('v1/', ContactV1View.as_view(), name='contact_v1'),
    path('v2/', ContactV2View.as_view(), name='contact_v2'),
]