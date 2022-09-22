#FROM mcr.microsoft.com/dotnet/aspnet:6.0
#WORKDIR publishfolder
#COPY . .
#
#EXPOSE 9000
#ENTRYPOINT [ "dotnet", "Api.dll" ]

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Copy everything
COPY . .
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
COPY --from=build-env /out .

EXPOSE 9000
ENTRYPOINT ["dotnet", "Api.dll"]