FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["testcontainerexample/testcontainerexample.csproj", "testcontainerexample/"]
RUN dotnet restore "testcontainerexample/testcontainerexample.csproj"
COPY . .
WORKDIR "/src/testcontainerexample"
RUN dotnet build "testcontainerexample.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "testcontainerexample.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "testcontainerexample.dll"]
