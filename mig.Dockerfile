FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0-alpine AS build

ARG TARGETARCH
WORKDIR /source

COPY app/*.csproj .
RUN dotnet restore -a $TARGETARCH
COPY app/. .

FROM build as migrations
RUN dotnet tool install --global dotnet-ef
ENV PATH="$PATH:/root/.dotnet/tools"
ENTRYPOINT ["dotnet-ef", "database", "update"]