FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

ARG TARGETARCH
WORKDIR /source

COPY app/*.csproj .
RUN dotnet restore -a $TARGETARCH

COPY app/. .
RUN dotnet publish -a $TARGETARCH --no-restore -o /app

FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS final
WORKDIR /app
COPY --from=build /app .
USER $APP_UID

EXPOSE 8080

ENTRYPOINT ["./app"]