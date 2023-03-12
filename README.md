# DeliVeggieService
This ASP.NET core web API has been deveoped in .net 6. This service has following features:
1. Web API with Read Operations from two different Mongo DB collections which can be executed through swagger.<br />
2. Docker Container is running the MongoDB database. <br />
3. Clean Architecture is followed by separating domain and infrastructure concerns. <br />
4. Exception Handling is implemented using a custom global exception handler called Nlog. The internalLogFile path can be modified to log the stack trace exceptions or information in the nlog.onfig. <br />
5. Unit testing is implemented using Xunit and Moq. <br />
6. Generic Repository pattern is used to segregate and handle the MongoDB related changes. <br /><br />


This repository contains a controller 'Product 'which handles products in a vegetable store. You can perform GET/GETBYID/POST actions.<br />
There is a secondary controller 'PriceReductions' primarily used only to GET/POST data to MongoDB during local development.<br />
The price reduction logic is written in the GetByIdAsync which will return a result with discounted price of every product.<br /> <br /> 

Swagger URL: https://localhost:7164/swagger/index.html<br /><br />
![image](https://user-images.githubusercontent.com/127690033/224569718-a4f4af61-301d-48e0-b7f7-028eefd590ba.png)
<br /><br />
Get All Products: https://localhost:7164/v1/Product<br /><br />
![image](https://user-images.githubusercontent.com/127690033/224569772-faae6a1e-e55c-43bf-9faf-3c3afa5e42ab.png)
<br /><br />
Get Products y ID: https://localhost:7164/v1/Product/80abaa87-a2d1-4a36-a3b1-45de4454ce6d<br /><br />
![image](https://user-images.githubusercontent.com/127690033/224569795-c124c059-5667-491c-9f35-9165424ab651.png)
<br /><br />
Unit Test Implementation <br /><br />
![image](https://user-images.githubusercontent.com/127690033/224571531-9952df6c-df5c-4e54-b10c-0d38831fcddf.png)

<br /><br />
Mongo DB collections running on docker<br /><br />
<img width="948" alt="image" src="https://user-images.githubusercontent.com/127690033/224571612-8488d655-f886-4c6a-a0e5-abbaf2815c0b.png"><br /><br />

<img width="949" alt="image" src="https://user-images.githubusercontent.com/127690033/224571580-502126a7-9c37-4f75-ae1f-20972683a293.png">
<br /><br />

<br /><br />
