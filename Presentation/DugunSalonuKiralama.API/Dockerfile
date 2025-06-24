# Build aşaması
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Presentation/DugunSalonuKiralama.API/DugunSalonuKiralama.API.csproj", "Presentation/DugunSalonuKiralama.API/"]
COPY ["Core/DugunSalonuKiralama.Application/DugunSalonuKiralama.Application.csproj", "Core/DugunSalonuKiralama.Application/"]
COPY ["Core/DugunSalonuKiralama.Domain/DugunSalonuKiralama.Domain.csproj", "Core/DugunSalonuKiralama.Domain/"]
COPY ["Infrastructure/DugunSalonuKiralama.Persistence/DugunSalonuKiralama.Persistence.csproj", "Infrastructure/DugunSalonuKiralama.Persistence/"]

RUN dotnet restore "Presentation/DugunSalonuKiralama.API/DugunSalonuKiralama.API.csproj"

COPY . .

WORKDIR "/src/Presentation/DugunSalonuKiralama.API"
RUN dotnet publish "DugunSalonuKiralama.API.csproj" -c Release -o /app/publish

# Runtime aşaması
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENV ASPNETCORE_URLS=http://+:80

ENTRYPOINT ["dotnet", "DugunSalonuKiralama.API.dll"]