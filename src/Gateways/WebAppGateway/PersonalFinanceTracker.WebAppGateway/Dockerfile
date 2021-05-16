#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Gateways/WebAppGateway/PersonalFinanceTracker.WebAppGateway/PersonalFinanceTracker.WebAppGateway.csproj", "src/Gateways/WebAppGateway/PersonalFinanceTracker.WebAppGateway/"]
RUN dotnet restore "src/Gateways/WebAppGateway/PersonalFinanceTracker.WebAppGateway/PersonalFinanceTracker.WebAppGateway.csproj"
COPY . .
WORKDIR "/src/src/Gateways/WebAppGateway/PersonalFinanceTracker.WebAppGateway"
RUN dotnet build "PersonalFinanceTracker.WebAppGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PersonalFinanceTracker.WebAppGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonalFinanceTracker.WebAppGateway.dll"]