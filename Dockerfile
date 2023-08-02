# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

# copy csproj and restore as distinct layers

COPY .. /source
RUN dotnet restore

# copy everything else and build app
COPY . ./source
WORKDIR /source
RUN dotnet publish -c release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "TodoAPI.dll", "dotnet ef database update -c TodoDbContext -s TodoAPI -p Infrastructure"]