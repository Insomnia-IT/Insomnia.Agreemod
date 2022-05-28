#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Insomnia.Agreemod/Insomnia.Agreemod.API/Insomnia.Agreemod.API.csproj", "Insomnia.Agreemod/Insomnia.Agreemod.API/"]
COPY ["Insomnia.Agreemod/Insomnia.Agreemod.BI/Insomnia.Agreemod.BI.csproj", "Insomnia.Agreemod/Insomnia.Agreemod.BI/"]
COPY ["Insomnia.Agreemod/Insomnia.Agreemod.Data/Insomnia.Agreemod.Data.csproj", "Insomnia.Agreemod/Insomnia.Agreemod.Data/"]
COPY ["Insomnia.Agreemod/Insomnia.Agreemod.General/Insomnia.Agreemod.General.csproj", "Insomnia.Agreemod/Insomnia.Agreemod.General/"]
RUN dotnet restore "Insomnia.Agreemod/Insomnia.Agreemod.API/Insomnia.Agreemod.API.csproj"
COPY . .
WORKDIR "/src/Insomnia.Agreemod/Insomnia.Agreemod.API"
RUN dotnet build "Insomnia.Agreemod.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Insomnia.Agreemod.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Insomnia.Agreemod.API.dll"]