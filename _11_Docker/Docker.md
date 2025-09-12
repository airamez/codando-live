# 🐳 Docker

[Docker](https://www.docker.com) is an open-source platform used to develop, ship, and run applications inside containers.

## Documentation

- Docker Documentation: [https://docs.docker.com](https://docs.docker.com)
- Play with Docker: [https://labs.play-with-docker.com](https://labs.play-with-docker.com)
- DockerHub: [https://hub.docker.com](https://hub.docker.com)


## Key Concepts:
- **Containers**: Lightweight, portable environments to run apps
- **Images**: Snapshots of containers
- **Docker Engine**: Core part of Docker, runs and manages containers

---

## Why Use Docker?

- Consistent environments across development, staging, and production
- Lightweight and fast startup
- Simplified dependency management

---

## Installation

* On Windows/Mac:
  * Download from [Docker Official Site](https://www.docker.com/products/docker-desktop/)
  * Follow the installation wizard

* On Ubuntu/Federa Linux:

  ```bash
  # Update your system first
  sudo apt-get update
  # Install Docker package
  sudo apt-get install docker-ce docker-ce-cli containerd.io
  ```

* On Arch Linux

  ```bash
  # Update your system first
  sudo pacman -Syu     
  
  # Install Docker package     
  sudo pacman -S docker
  
  # Install Docker Composer
  sudo pacman -S docker-compose

  # Intall Docker BuildX
  sudo pacman -S docker-buildx

  ```

* Confirm installation

  ```shell
  docker --version
  docker-compose --version

  ```

```bash
# Start Docker
sudo systemctl start docker

# Start Docker Componer
sudo docker-compose up

# Stop
sudo systemctl stop docker.socket
sudo systemctl stop docker.service
sudo docker-compose down

# Confirm
docker ps
```

* Basic Commands

  | Command                     | Description                      |
  | --------------------------- | -------------------------------- |
  | `docker run hello-world`    | Test Docker installation         |
  | `docker ps`                 | List running containers          |
  | `docker images`             | List downloaded images           |
  | `docker build -t appname .` | Build image from Dockerfile      |
  | `docker exec -it <id> bash` | Access running container's shell |

## Dockerfile

* A [**Dockerfile**](https://docs.docker.com/reference/dockerfile/) is a plain text file that defines how to build a Docker image.
* It’s essentially a blueprint containing instructions like which base image to use, what dependencies to install, and how to configure your app.

### Why Use a Dockerfile?

- Ensures consistent environment across machines and teams
- Automates the setup of apps and dependencies
- Makes it easy to share and deploy your app using images

### Multi-Container Setup

* For a full-stack web app, we often split responsibilities across containers for modularity and scalability.
* Here’s a setup using **three containers(layers)**:

| Layer      | Tech Stack           | Docker Image Used                                |
| ---------- | -------------------- | ------------------------------------------------ |
| Database   | PostgreSQL           | `postgres:latest`                                |
| Server/API | ASP.NET Core Web API | `mcr.microsoft.com/dotnet/aspnet` + custom build |
| Frontend   | Angular              | `node:20` for build + `nginx` to serve           |

>Note: We’ll define each container individually and orchestrate them using **Docker Compose**.

### Dockerfiles (Summarized)

* Database - PostgreSQL (No Dockerfile needed)
  * Use the official image directly in Docker Compose.
* Backend - ASP.NET Core Web API: `Dockerfile.api`

  ```dockerfile
  FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
  WORKDIR /src
  COPY . .
  RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish

  FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
  WORKDIR /app
  COPY --from=build /app/publish .
  EXPOSE 5000
  ENTRYPOINT ["dotnet", "WebApi.dll"]
  ```

* Frontend - Angular App: `Dockerfile.frontend`

  ```dockerfile
  # Use latest compatible Node.js for Angular 20
  FROM node:20.19.0 AS build
  WORKDIR /app
  COPY . .
  RUN npm ci && npm run build --prod

  # Use lightweight, production-ready Nginx base
  FROM nginx:stable-alpine
  COPY --from=build /app/dist/my-angular-app /usr/share/nginx/html
  EXPOSE 80
  ```

>Note: The name convention for docker files is to start with `Dockerfile.`

#### Docker Compose File

* [Docker Compose](https://docs.docker.com/compose/) is a tool for defining and managing multi-container Docker applications.
* It allows developers to describe an entire application stack—including services, networks, and volumes—in a single declarative YAML file (docker-compose.yml).
* With just one command, you can spin up all the containers and their dependencies, streamlining both development and deployment workflows.
* Compose simplifies the control of your entire application stack, making it easy to manage services, networks, and volumes in a single YAML configuration file
* Then, with a single command, you create and start all the services from your configuration file.
* Compose works in all environments - production, staging, development, testing, as well as CI workflows. It also has commands for managing the whole lifecycle of your application:
  * Start, stop, and rebuild services
  * View the status of running services
  * Stream the log output of running services
  * Run a one-off command on a service

* Docker Componser file: `docker-compose.yml`

  ```yaml
  services:

    postgres:
      image: postgres:latest
      environment:
        POSTGRES_USER: user
        POSTGRES_PASSWORD: password
        POSTGRES_DB: mydb
      ports:
        - "5432:5432"

    api:
      build:
        context: ./api
        dockerfile: Dockerfile.api
      ports:
        - "5000:5000"
      depends_on:
        - postgres # Wait for postgress

    frontend:
      build:
        context: ./frontend
        dockerfile: Dockerfile.frontend
      ports:
        - "80:80"
      depends_on:
        - api # Wait for api
  ```
