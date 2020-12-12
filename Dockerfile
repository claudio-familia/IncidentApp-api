FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS base
WORKDIR /app
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["IncidentApp/IncidentApp.csproj", "IncidentApp/"]
RUN dotnet restore "IncidentApp/IncidentApp.csproj"
COPY . .
WORKDIR "/src/IncidentApp"
RUN dotnet build "IncidentApp.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "IncidentApp.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet IncidentApp.dll