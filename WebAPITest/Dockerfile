FROM mcr.microsoft.com/dotnet/aspnet:3.1-focal AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:3.1-focal AS build
WORKDIR /src
COPY ["WebAPITest/WebAPITest.csproj", "WebAPITest/"]
RUN dotnet restore "WebAPITest/WebAPITest.csproj"
COPY . .
WORKDIR "/src/WebAPITest"
RUN dotnet build "WebAPITest.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebAPITest.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebAPITest.dll"]
