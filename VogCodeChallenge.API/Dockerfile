
FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-nanoserver-1903 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-nanoserver-1903 AS build
WORKDIR /src
COPY ["VogCodeChallenge.API/VogCodeChallenge.API.csproj", "VogCodeChallenge.API/"]
RUN dotnet restore "VogCodeChallenge.API/VogCodeChallenge.API.csproj"
COPY . .
WORKDIR "/src/VogCodeChallenge.API"
RUN dotnet build "VogCodeChallenge.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VogCodeChallenge.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "VogCodeChallenge.API.dll"]