# Use the official .NET SDK image to build and test the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MealPlanner-backend.csproj", "./"]
RUN dotnet restore "./MealPlanner-backend.csproj"
COPY . .
RUN dotnet build "MealPlanner-backend.csproj" -c Release -o /app/build

ENV ASPNETCORE_ENVIRONMENT Development

ENTRYPOINT ["dotnet", "MealPlanner-backend.dll"]
