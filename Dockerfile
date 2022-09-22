FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Copy everything
COPY Atheneum ./Atheneum
COPY Api ./Api
WORKDIR /Api
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o /publishfolder --no-restore

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /publishfolder
COPY --from=build /publishfolder .

ENTRYPOINT ["dotnet", "Api.dll"]

# docker build -t asu-api .   
# docker images | grep asu-api 
# docker run -it --rm -p 5002:80 -d 6ef9e3f1de79 --name asu-api  