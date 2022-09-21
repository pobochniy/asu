FROM mcr.microsoft.com/dotnet/aspnet:6.0
ENV DOTNET_TieredPGO=1 DOTNET_TC_QuickJitForLoops=1 DOTNET_ReadyToRun=0

COPY . .

EXPOSE 80
ENTRYPOINT [ "dotnet", "Api.dll" ]