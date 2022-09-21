FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR publishfolder
COPY . .

EXPOSE 9000
ENTRYPOINT [ "dotnet", "Api.dll" ]