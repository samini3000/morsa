# .NET Core SDK
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

# Sets the working directory
WORKDIR /app

# Copy Projects
#COPY *.sln .
COPY API/API.csproj ./API/
COPY Domain/Domain.csproj ./Domain/
COPY Infrustructure/Infrustructure.csproj ./Infrustructure/
COPY Application/Application.csproj ./Application/

# .NET Core Restore
RUN dotnet restore ./API/API.csproj

# Copy All Files
COPY . ./

# .NET Core Build and Publish
RUN dotnet publish ./API/API.csproj -c Release -o /publish

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
WORKDIR /app
COPY --from=build /publish ./

EXPOSE 80 443 
# 5195 7066
#ENV ASPNETCORE_URLS=http://+:5195;https://+:7066

ENTRYPOINT ["dotnet", "API.dll"]