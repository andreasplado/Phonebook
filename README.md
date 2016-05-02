# restWebApp
A RESTful  Web service with ASP.NET Web API and client application


Used technologies:
* Entity Framework
* ASP.NET Web API
* WPF (Microsoft.AspNet.WebApi REST communication library )

## Database model diagram(ERD):
![alt tag](http://enos.itcollege.ee/~aplado/VR2/Telefoniraamat_erd.png)


## Server-side app
Services return JSON data.

An example of returned json using GET method:

```json
[
  {
    "$id": "1",
    "contactId": 8,
    "contactName": "Tester",
    "contactLastName": "Ester",
    "contactValue": "514231456",
    "contactTypeId": 0,
    "added": "2016-04-30T14:18:50.347",
    "deleted": null,
    "updated": null
  }
]
```

## Client-side app

Microsoft.AspNet.WebApi parses client-side JSON data.

A screenshot of an application:

![alt tag](http://enos.itcollege.ee/~aplado/VR2/konotraat_screenshot.png)
