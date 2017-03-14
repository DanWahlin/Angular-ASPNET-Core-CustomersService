FROM microsoft/dotnet:1.1.1-sdk

MAINTAINER Dan Wahlin

ENV DOTNET_USE_POLLING_FILE_WATCHER=1
ENV ASPNETCORE_URLS=http://*:5000

COPY . /var/www/aspnetcoreapp

WORKDIR /var/www/aspnetcoreapp

CMD ["/bin/bash", "-c", "dotnet restore && dotnet run"]
