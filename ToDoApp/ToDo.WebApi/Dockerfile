FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

#Usar la imagen SDK para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["./", "ToDo.WebApi/"]
RUN dotnet restore "ToDo.WebApi/ToDo.WebApi.csproj"
COPY . .
WORKDIR "/src/ToDo.WebApi"
RUN dotnet build "ToDo.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ToDo.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ToDo.WebApi.dll"]