# ---
# Image containing the code and sdk
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS src-env
WORKDIR /src/service

COPY VueHelloWorld.sln ./
COPY VueHelloWorld.Web/ ./VueHelloWorld.Web
COPY VueHelloWorld.Web.Test/ ./VueHelloWorld.Web.Test
RUN dotnet restore VueHelloWorld.sln

# ---
# Image for debugging
FROM src-env AS debug-env

RUN apt-get update && \
    apt-get install git
WORKDIR /src/service/VueHelloWorld.Web
ENTRYPOINT [ "dotnet", "watch", "run", "--urls", "http://0.0.0.0:80" ]

# ---
# Image to build and run tests
FROM src-env as test-env
WORKDIR /src/service
RUN dotnet test VueHelloWorld.sln

# ---
# Image to build and publish release files
FROM src-env as release-env
WORKDIR /src/service
RUN dotnet publish ./VueHelloWorld.Web/VueHelloWorld.Web.csproj -c Release -o /publish/web

# ---
# Image to serve the web app from the published files
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS prod-env
WORKDIR /publish
COPY --from=release-env /publish/web ./web
ENTRYPOINT ["dotnet", "./web/VueHelloWorld.Web.dll"]