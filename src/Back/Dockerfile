FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
# ARG BUILD_CONFIGURATION=Development
WORKDIR /src/Back
# Copia todos projetos e restaura pacotes
COPY ../*.sln /src/.
COPY ["RS.Core/RS.Core.csproj", "./RS.Core/"]
COPY ["RS.Parking.Domain/RS.Parking.Domain.csproj", "./RS.Parking.Domain/"]
COPY ["RS.Parking.Infrastructure/RS.Parking.Infrastructure.csproj", "./RS.Parking.Infrastructure/"]
COPY ["RS.Parking.Application/RS.Parking.Application.csproj", "./RS.Parking.Application/"]
COPY ["RS.Parking.API/RS.Parking.API.csproj", "./RS.Parking.API/"]
RUN dotnet restore "./RS.Parking.API/RS.Parking.API.csproj"
# Copia projeto restaurado compila
COPY ["RS.Core/.", "./RS.Core/"]
COPY ["RS.Parking.Domain/.", "./RS.Parking.Domain/"]
COPY ["RS.Parking.Infrastructure/.", "./RS.Parking.Infrastructure/"]
COPY ["RS.Parking.Application/.", "./RS.Parking.Application/"]
COPY ["RS.Parking.API/.", "./RS.Parking.API/"]
WORKDIR "/src/."
RUN dotnet build "./Back/RS.Parking.API/RS.Parking.API.csproj" -c ${BUILD_CONFIGURATION} -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
# ARG BUILD_CONFIGURATION=debug
RUN dotnet publish "./Back/RS.Parking.API/RS.Parking.API.csproj" -c ${BUILD_CONFIGURATION} -o /app/publish /p:UseAppHost=false

FROM base AS final
ENV ASPNETCORE_URLS="http://+:5000"
#ENV ASPNETCORE_ENVIRONMENT="Development"
ENV ASPNETCORE_ENVIRONMENT="Docker"
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RS.Parking.API.dll"]

# docker pull mcr.microsoft.com/dotnet/aspnet:8.0
# docker pull mcr.microsoft.com/dotnet/sdk:8.0
# docker build --tag rs-parking-api-image .
# docker run –d –p 5000:5000 -p 5001:5001 --name rs_parking_api rs-parking-api-image