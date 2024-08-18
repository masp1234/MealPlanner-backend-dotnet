# Use the official .NET SDK image to build and test the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MealPlanner-backend.csproj", "./"]
RUN dotnet restore "./MealPlanner-backend.csproj"
COPY . .
RUN dotnet build "MealPlanner-backend.csproj" -c Release -o /app/build
RUN dotnet publish "MealPlanner-backend.csproj" -c Release -o /app/publish

# Use the official ASP.NET Core runtime image for the final container
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Set the environment variable for ASP.NET Core
ENV ASPNETCORE_ENVIRONMENT Development

ENTRYPOINT ["dotnet", "MealPlanner-backend.dll"]
