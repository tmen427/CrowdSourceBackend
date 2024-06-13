Backend project for website the following website: https://weather.tonymdesigns.com/home <br>

To get the project running: <br>
- In your terminal type: git clone https://github.com/tmen427/CrowdSourceBackend.git
- This project uses Entity Framework with MS SQL.
- To create the first migration type in the CLi: dotnet ef migrations add InitialCreate
- To create the database and schema type : dotnet ef database update
- The database should now be running
- cd into the WeatherApi file and type: dotnet run 
- The server should now be running 
- On my pc it runs on this port http://localhost:5174/swagger/index.html. (Make sure to include /swagger to your url) <br>

- In memory cacheing and unit testing will soon
- The frontend was written in Angular.js-I will add the project to github in the near future

- This project is being hosted on an Amazon EC2 Ubuntu virtual machine with Nginx as a reverse proxy server. The database connection is established using Amazon Relational Database(RDS).  
