# Use the official .NET Core 8 image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MealPlanner-backend.csproj", "./"]
RUN dotnet restore "./MealPlanner-backend.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "MealPlanner-backend.csproj" -c Release -o /app/build


FROM build AS publish
RUN dotnet publish "MealPlanner-backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the environment variable for ASP.NET Core
ENV ASPNETCORE_ENVIRONMENT Development

ENTRYPOINT ["dotnet", "MealPlanner-backend.dll"]



