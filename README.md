# WebAppMvc

### System Overview

Architecture MVC - Two api - diagram if time - Yes

Containers Docker compose - One compose to rule them all

### Developer Setup
Refer to docs for setup of Api and MVC

Add Models - Product, CartItem 

Add Controller - Product, CartItem

Add View -  Product, CartItem

Add Docker 
Change localhost to docker container names in api calls

### packages to add
dotnet add package Newtonsoft.Json

### Troubleshoot

DBCreate - Fix
dev-cert issue
Service Issue - Could not work - Refactor
 This issue
 httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };

Port 1433 issue for db connection
Routing in MVC
Presentation (View layer) - Much work