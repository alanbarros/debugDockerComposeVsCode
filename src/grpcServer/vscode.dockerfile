FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS debug

ENV ASPNETCORE_URLS="http://*:5000"

WORKDIR /src/
COPY ["grpcServer/grpcServer.csproj", "grpcServer/"]
COPY ["domain/domain.csproj", "domain/"]
COPY ["infrastructure/infrastructure.csproj", "infrastructure/"]
COPY ["application/application.csproj", "application/"]
RUN dotnet restore "grpcServer/grpcServer.csproj"

#Change to project directory
WORKDIR /src/grpcServer
ENTRYPOINT ["dotnet", "run"]