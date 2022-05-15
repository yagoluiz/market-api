# Market API

![](https://github.com/yagoluiz/market-api/workflows/Docker%20Image%20CI/badge.svg)

API responsible for managing markets.

## Instructions for run project

Run project via Docker, Kubernetes (minikube), via Visual Studio (F5 or CTRL + F5), Visual Studio Code (tasks project) or CLI.

### .NET CLI

- Run project

```bash
src/Market.API

dotnet watch run
```

- Run tests

```bash
dotnet test -t
```

### Docker

```bash
docker-compose up -d
```

### Kubernetes

- Run minikube

```bash
minikube start
```

```bash
minikube dashboard
```

- Run files

```bash
sh k8s/deploy.sh
```

## Endpoints

- Docker/.NET cli

Curl's file: [endpoints.http](endpoints.http).

For more information visit swagger: *http://localhost:5000/swagger/index.html* or *http://localhost:5001/swagger/index.html (Docker)*.

- Kubernetes (minikube)

**LoadBalancer**

Create access tunnel:

```bash
minikube tunnel
```

Find created external IP:

```bash
kubectl get svc -n market
```

## Tests

### Code Coverage

To run the coverage of the project tests, it is necessary to run the test command in coverage mode:

```bash
dotnet test /p:CollectCoverage=true /p:CoverletOutputFormat=opencover /p:Exclude="[xunit*]*" /p:ExcludeByFile="**/Migrations/*.cs"
```

Run the command in the **root** project.

### Coverage Report

Install [Report Generator](https://danielpalme.github.io/ReportGenerator) CLI tool:

```bash
dotnet tool install --global dotnet-reportgenerator-globaltool
```

- Main command

```bash
reportgenerator "-reports:test/*/*.opencover.xml" "-targetdir:coverage" "-reporttypes:Html"
```

Run the command in the **root** project.

- Coverage report

Find the folder **coverage** and open **index.html**.

## Database

When running the project the database migration is executed.

To run manually, follow these steps:

Install [Entity Framework](https://docs.microsoft.com/en-us/ef/core/cli/dotnet) CLI tool.

```bash
dotnet tool install --global dotnet-ef
```

- Main commands

```bash
dotnet ef migrations add [NAME_MIGRATION] -c EntityContext -s src/Market.API -p src/Market.Infra
```

```bash
dotnet ef database update -c EntityContext -s src/Market.API -p src/Market.Infra 
```

Run the commands in the **root** project.
