#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/Services/PhoneBook/PhoneBook.API/PhoneBook.API.csproj", "src/Services/PhoneBook/PhoneBook.API/"]
COPY ["src/Services/PhoneBook/PhoneBook.Application/PhoneBook.Application.csproj", "src/Services/PhoneBook/PhoneBook.Application/"]
COPY ["src/Services/PhoneBook/PhoneBook.Domain/PhoneBook.Domain.csproj", "src/Services/PhoneBook/PhoneBook.Domain/"]
COPY ["src/Services/PhoneBook/PhoneBook.Infrastructure/PhoneBook.Infrastructure.csproj", "src/Services/PhoneBook/PhoneBook.Infrastructure/"]
COPY ["src/BuildingBlocks/EventBus.Messages/EventBus.Messages.csproj", "src/BuildingBlocks/EventBus.Messages/"]
RUN dotnet restore "src/Services/PhoneBook/PhoneBook.API/PhoneBook.API.csproj"
COPY . .
WORKDIR "/src/src/Services/PhoneBook/PhoneBook.API"
RUN dotnet build "PhoneBook.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PhoneBook.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PhoneBook.API.dll"]