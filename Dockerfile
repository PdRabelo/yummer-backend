FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app
EXPOSE 80
EXPOSE 443

COPY *csproj ./
RUN dotnet restore
ENV ASPNETCORE_HTTP_PORTS=80
COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final-env
WORKDIR /app
COPY --from=build-env /app/out .
ENV ASPNETCORE_HTTP_PORTS=80
ENTRYPOINT [ "dotnet", "yummer-backend.dll" ]