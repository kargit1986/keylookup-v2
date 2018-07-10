FROM registry.access.redhat.com/dotnet/dotnet-20-runtime-rhel7
WORKDIR /App
COPY bin/Debug/netcoreapp2.0/publish /App
ENTRYPOINT [ "dotnet","keylookup.dll" ]