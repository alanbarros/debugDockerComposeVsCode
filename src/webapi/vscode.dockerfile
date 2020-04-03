FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS debug

ENV ASPNETCORE_URLS="http://*:5000"

WORKDIR /src/
COPY ["webapi/webapi.csproj", "webapi/"]
COPY ["domain/domain.csproj", "domain/"]
COPY ["infrastructure/infrastructure.csproj", "infrastructure/"]
COPY ["application/application.csproj", "application/"]
RUN dotnet restore "webapi/webapi.csproj"

#Change to project directory
WORKDIR /src/webapi
ENTRYPOINT ["dotnet", "run"]