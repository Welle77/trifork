# Trifork

To Run this Application:
Download the Repo

Make sure the following requirements are installed:
- Docker
- Node < 17
- NPM


***BACKEND***

In Powershell, run 

docker compose up

Open the Project in Visual Studio and Rebuild/Restore the neccesary packages. 

In visual studio go to Tools -> NuGet Package Manager -> Package Manager Console. Run: 

Update-Database

Now you can run both projects, either from terminal or from Visual Studio (Without debugging)

***FRONTEND***

npm install

npm start
