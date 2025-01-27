FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS base

FROM --platform=$BUILDPLATFORM base AS build

ARG TARGETARCH
WORKDIR /source

COPY app/*.csproj .
RUN dotnet restore -a $TARGETARCH

COPY app/. .
RUN dotnet publish -a $TARGETARCH --no-restore -o /app

FROM base AS runner
WORKDIR /app
COPY --from=build /app .
USER $APP_UID

EXPOSE 8080
EXPOSE 8081

ENTRYPOINT ["./app"]