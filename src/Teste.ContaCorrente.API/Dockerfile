FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Teste.ContaCorrente.API/Teste.ContaCorrente.API.csproj", "Teste.ContaCorrente.API/"]
RUN dotnet restore "Teste.ContaCorrente.API/Teste.ContaCorrente.API.csproj"
COPY . .
WORKDIR "/src/Teste.ContaCorrente.API"
RUN dotnet build "Teste.ContaCorrente.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Teste.ContaCorrente.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Teste.ContaCorrente.API.dll"]