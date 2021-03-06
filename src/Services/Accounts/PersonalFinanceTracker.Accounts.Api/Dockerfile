#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Services/Accounts/PersonalFinanceTracker.Accounts.Api/PersonalFinanceTracker.Accounts.Api.csproj", "src/Services/Accounts/PersonalFinanceTracker.Accounts.Api/"]
COPY ["src/Services/Accounts/PersonalFinanceTracker.Accounts.Infrastructure/PersonalFinanceTracker.Accounts.Infrastructure.csproj", "src/Services/Accounts/PersonalFinanceTracker.Accounts.Infrastructure/"]
COPY ["src/Services/Accounts/PersonalFinanceTracker.Accounts.Application/PersonalFinanceTracker.Accounts.Application.csproj", "src/Services/Accounts/PersonalFinanceTracker.Accounts.Application/"]
COPY ["src/Services/Accounts/PersonalFinanceTracker.Accounts.Domain/PersonalFinanceTracker.Accounts.Domain.csproj", "src/Services/Accounts/PersonalFinanceTracker.Accounts.Domain/"]
RUN dotnet restore "src/Services/Accounts/PersonalFinanceTracker.Accounts.Api/PersonalFinanceTracker.Accounts.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Accounts/PersonalFinanceTracker.Accounts.Api"
RUN dotnet build "PersonalFinanceTracker.Accounts.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PersonalFinanceTracker.Accounts.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PersonalFinanceTracker.Accounts.Api.dll"]
