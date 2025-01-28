FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine
ENV DOTNET_USE_POLLING_FILE_WATCHER 1
WORKDIR /app
COPY app/. .

ENTRYPOINT [ "dotnet", "watch" ]
