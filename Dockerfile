FROM mcr.microsoft.com/dotnet/sdk:5.0

WORKDIR /webmvc

COPY *.csproj ./

RUN dotnet restore

EXPOSE 8084

COPY . ./

RUN dotnet publish -c Release -o out

## migrations 

ENTRYPOINT ["dotnet", "watch", "run", "no-restore", "--urls", "https://0.0.0:8084"]