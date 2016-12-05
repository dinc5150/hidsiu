# How To Create An Ajax MVC form and save to UIOmatic

Nuget Requirements:
 - Umbraco
 - Nibble.Umbraco.UIOMatic
 - jQuery
 - jQuery.Validation
 - Microsoft.jQuery.Unobtrusive.Ajax
 - Microsoft.jQuery.Unobtrusive.Validation
 
 
 ## JS Library Setup
```
<script src="~/scripts/jquery.validate.min.js"></script>
<script src="~/scripts/jquery.validate.unobtrusive.min.js"></script>
<script src="~/scripts/jquery.unobtrusive-ajax.min.js"></script>
```
update the web.config file to enable unobtrusive validation and ajax. 
```
<add key="ClientValidationEnabled" value="true"/>
<add key="UnobtrusiveJavaScriptEnabled" value="true"/>
```

## Create the Model
Models/Contact.cs

## Create The Controller
Controllers/ContactController.cs

## Add the form To a Razor partial
/Views/Partials/Contact.cshtml


Thanks To Saurabh Nandu for the tutorial on which I based this: https://www.systenics.com/blog/creating-an-ajax-enabled-contact-form-in-umbraco-6-with-aspnet-mvc-4-and-twitter-bootstrap/?tag=Umbraco+6
