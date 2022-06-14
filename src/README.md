## Weather Forecast

Gives the live weather records.

## Weather Store

Gives the historic weather records.

## Basic docker commands:

Frequent commands:

- `docker ps` ➡️ Lists running containers.
- `docker ps -a` ➡️ Lists all containers.
- `docker start` ➡️ Starts the specified container.
- `docker stop` ➡️ Stops the specifies container.
- `docker run`
- `docker rm`
- `docker rmi`
- `docker tag`

## docker compose:

All the required services should be constructed using the docker-compose.yml file.

For eg:

```
version: '3.4'

services:
 weatherapp:
   build: .\weatherapi
   ports:
       - "80:80"
       - "443:443"
   environment:
     - ASPNETCORE_ENVIRONMENT=Development
     - ASPNETCORE_URLS=https://+:443;http://+:80
     - ASPNETCORE_Kestrel__Certificates__Default__Password=password
     - ASPNETCORE_Kestrel__Certificates__Default__Path=/https/aspnetapp.pfx
   volumes:
     - ~/.aspnet/https:/https:ro

```

- `docker-compose build` ➡️ Builds the targeting images mentioned in the docker compose file
- `docker-compose up` ➡️ Starts the services mentioned in the docker compose file.
- `docker-compose down` ➡️ Removes the services and teardown the network.

## k8s

kubectl get deployments --all-namespaces
kubectl get pods --all-namespaces

## k8s remove resources

kubectl delete --all deployments
kubectl delete --all pods

# Geo Server
Service that holds Geo information.

# Weather API Store
Service that holds historical weather information.

# Weather API
Service that holds current weather information.
