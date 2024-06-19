Backend project for website the following website: https://weather.tonymdesigns.com/home <br>

To get the project running: 
- In your terminal type: "git clone https://github.com/tmen427/CrowdSourceBackend.git"
- This project uses Entity Framework with MS SQL.
- To create the first migration type in the CLi: <b> dotnet ef migrations add InitialCreate </b>
- To create the database and schema type : <b> dotnet ef database update </b>
- The database should now be running
- cd into the WeatherApi file and type: <b> dotnet run </b>
- The server should now be running 
- On my pc it runs on this port http://localhost:5174/swagger/index.html. (Make sure to include /swagger to your url) 

- In memory cacheing and unit testing will soon
- The frontend was written in Angular.js-I will add the project to github in the near future

- This project is being hosted on an Amazon EC2 Ubuntu virtual machine with Nginx as a reverse proxy server. The database connection is established using Amazon Relational Database(RDS).  
