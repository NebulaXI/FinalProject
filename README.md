# SkiProject
## A final project for the course ASP.NET Advanced of SoftUni

### Introduction
ASP.NET 6.0 project about Bulgarian's winter resorts,which include information pages,forum,shop where user can add advertisments related to winter sports and message controller .For now the whole project is divided in 4 parts so it could be extended with Web API in the future,the parts are SkiProject,SkiProject.Infrastructure,SkiProject.Core and Ski.Project.Test. <br />
&nbsp; &nbsp; &nbsp; - The SkiProject is a ASP.NET MVC project which includes the controllers and the views. <br />
&nbsp; &nbsp; &nbsp; - The SkiProject.Core project includes all the services with their interfaces, the view models and custom attributes. <br />
&nbsp; &nbsp; &nbsp; - The SkiProject.Infrastructure is the project where with the help of EntityFrameworkCore we configure our database(MSSQL server),create our database models and seed the database with some information. <br />
&nbsp; &nbsp; &nbsp; - The Ski.Project.Test is an xUnit test project.

### Additional instructions how to use the project:
&nbsp; &nbsp; &nbsp; - Add appropriate connection string in SkiProject.appsettings.json <br />
&nbsp; &nbsp; &nbsp; - Create the database <br />
&nbsp; &nbsp; &nbsp; - In the SkiProject.Infrastructure.Configuration there are some entities to seed the data base with information about the Resort page and information about the Shop's categories and gender lists. <br />
&nbsp; &nbsp; &nbsp; - You need to register and login in order to use the the functionalities <br />

👷 The project is under construction yet,there's a lot of work to be done:
&nbsp; &nbsp; &nbsp; - Crete areas <br />
&nbsp; &nbsp; &nbsp; - Use SignalR for the messages <br />
&nbsp; &nbsp; &nbsp; - Extend the functionalities - edit user profile,account and advertisment confirmation <br />
&nbsp; &nbsp; &nbsp; - Make a responsive web design <br />
&nbsp; &nbsp; &nbsp; - Add bing interactive map <br />
