# Используется в git hub actions, сборка там, сюда скидываются готовые файлы

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR publishfolder
COPY . .

ENTRYPOINT [ "dotnet", "Api.dll" ]