FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["MODWebApiAdmin/MODWebApiAdmin.csproj", "MODWebApiAdmin/"]
RUN dotnet restore "MODWebApiAdmin/MODWebApiAdmin.csproj"
COPY . .
WORKDIR "/src/MODWebApiAdmin"
RUN dotnet build "MODWebApiAdmin.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MODWebApiAdmin.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MODWebApiAdmin.dll"]