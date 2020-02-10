FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["MODWebApiAuthentication/MODWebApiAuthentication.csproj", "MODWebApiAuthentication/"]
RUN dotnet restore "MODWebApiAuthentication/MODWebApiAuthentication.csproj"
COPY . .
WORKDIR "/src/MODWebApiAuthentication"
RUN dotnet build "MODWebApiAuthentication.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MODWebApiAuthentication.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MODWebApiAuthentication.dll"]