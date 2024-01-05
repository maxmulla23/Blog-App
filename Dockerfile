FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /BlogApp

#copy everything
COPY . ./
# restore as distinct layers
RUN dotnet restore
# Build and publish a Release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /BlogApp
COPY --from=build-env /BlogApp/out .
ENTRYPOINT [ "dotnet", "Dotnet.Docker.dll" ]