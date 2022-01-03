dotnet tool install --global dotnet-ef
cd DataAccess
dotnet ef migrations add init
dotnet ef database update
cd..
cd ConsoleUI
dotnet run
cd ..
start cmd.exe /k  call "UI.bat"
cd WebAPI
dotnet run
