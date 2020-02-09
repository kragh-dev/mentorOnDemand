FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MODWebApi/MODWebApi.csproj", "MODWebApi/"]
RUN dotnet restore "MODWebApi/MODWebApi.csproj"
COPY . .
WORKDIR "/src/MODWebApi"
RUN dotnet build "MODWebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MODWebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MODWebApi.dll"]