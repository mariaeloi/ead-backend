FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

# Copy everything
COPY . .
# Restore as distinct layers
RUN dotnet restore

RUN dotnet dev-certs https
RUN dotnet dev-certs https --trust

# Build and publish a release
WORKDIR /App/Api
RUN dotnet publish --no-restore -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /App/Api/out .
ENTRYPOINT ["dotnet", "Api.dll", "--launch-profile", "Api-Production"]