#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LoseCoupledMonolithic.Server/LoseCoupledMonolithic.Server.csproj", "LoseCoupledMonolithic.Server/"]
COPY ["LoseCoupledMonolithic.PaymentService/LoseCoupledMonolithic.PaymentService.csproj", "LoseCoupledMonolithic.PaymentService/"]
COPY ["LoseCoupledMonolithic.OrderService/LoseCoupledMonolithic.OrderService.csproj", "LoseCoupledMonolithic.OrderService/"]
RUN dotnet restore "LoseCoupledMonolithic.Server/LoseCoupledMonolithic.Server.csproj"
COPY . .
WORKDIR "/src/LoseCoupledMonolithic.Server"
RUN dotnet build "LoseCoupledMonolithic.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoseCoupledMonolithic.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoseCoupledMonolithic.Server.dll"]
