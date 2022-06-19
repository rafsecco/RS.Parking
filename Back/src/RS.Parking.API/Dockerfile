#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Back/src/RS.Parking.API/RS.Parking.API.csproj", "Back/src/RS.Parking.API/"]
RUN dotnet restore "Back/src/RS.Parking.API/RS.Parking.API.csproj"
COPY . .
WORKDIR "/src/Back/src/RS.Parking.API"
RUN dotnet build "RS.Parking.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RS.Parking.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RS.Parking.API.dll"]