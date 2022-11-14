# WebApp_Angular

Backend 
 
.NET Core 5
PosgreSQL database

Launch Guide.

Open the application via visual studio. In the “appsettings.json” file, change the "ConnectionStrings" of Host, Username and Password to connect to the database. In the package manager console type "update-database". The application is ready to run.

Frontend

Angular CLI version 14.2.9.
Open the location of the main folder, in the terminal type the commands "npm install" and "ng serve". The application should run on port http://localhost:4200/.
If the server started on a port other than https://localhost:44348, change the "baseApiUrl" in the "environments" folder of the "environment.ts" file to the one under which the backend is currently running.

