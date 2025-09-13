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

* Start/Stop Docker

  ```bash
  # Start Docker
  sudo systemctl start docker

  # Start Docker Componer
  sudo docker-compose up

  # Stop
  sudo systemctl stop docker.socket
  sudo systemctl stop docker.service
  sudo docker-compose down
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
* This is a setup using **three containers(layers)** for full-stack application:

  | Layer      | Tech Stack           | Docker Image Used                                |
  | ---------- | -------------------- | ------------------------------------------------ |
  | Database   | PostgreSQL           | `postgres:latest`                                |
  | Server/API | ASP.NET Core Web API | `mcr.microsoft.com/dotnet/aspnet` + custom build |
  | Frontend   | Angular              | `node:20` for build + `nginx` to serve           |

>Note: We’ll define each container individually and orchestrate them using **Docker Compose** (Details Below).

#### Architecture Diagram

```
┌─────────────────────────────────────────────────────────────────┐
│                        HOST MACHINE                             │
│                                                                 │
│  ┌─────────────────┐    ┌─────────────────┐    ┌──────────────┐ │
│  │   Frontend      │    │      API        │    │  Database    │ │
│  │   Container     │    │   Container     │    │  Container   │ │
│  │                 │    │                 │    │              │ │
│  │  ┌───────────┐  │    │  ┌───────────┐  │    │ ┌──────────┐ │ │
│  │  │   nginx   │  │    │  │ ASP.NET   │  │    │ │PostgreSQL│ │ │
│  │  │  (Alpine) │  │---►│  │ Core API  │  │---►│ │          │ │ │
│  │  │           │  │    │  │   (.NET)  │  │    │ │          │ │ │
│  │  │  Angular  │  │◄---│  │           │  |◄---│ │          │ │ │
│  │  │    App    │  │    │  │           │  │    │ │          │ │ │
│  │  └───────────┘  │    │  └───────────┘  │    │ └──────────┘ │ │
│  │                 │    │                 │    │              │ │
│  │  Port: 80       │    │  Port: 5000     │    │ Port: 5432   │ │
│  │  Name:          │    │  Name:          │    │ Name:        │ │
│  │  todo-frontend  │    │  todo-api       │    │ todo-postgres│ │
│  └─────────────────┘    └─────────────────┘    └──────────────┘ │
│           │                       │                       │     │
│           │                       │                       │     │
│  ┌────────▼────────┐    ┌─────────▼────────┐    ┌─────────▼───┐ │
│  │ localhost:80    │    │ localhost:5000   │    │ Internal    │ │
│  │ (External)      │    │ (External)       │    │ Network     │ │
│  └─────────────────┘    └──────────────────┘    │ Only        │ │
│                                                 └─────────────┘ │
└─────────────────────────────────────────────────────────────────┘

                    ┌─────────────────┐
                    │     Browser     │
                    │  (User Access)  │
                    └─────────────────┘
                             │
                             │ HTTP Requests
                             ▼
                    ┌─────────────────┐
                    │ localhost:80    │
                    │  (Frontend)     │
                    └─────────────────┘
```

#### Frontend Container (todo-frontend)
- **Base Image**: nginx:alpine
- **Build Process**: Multi-stage (Node.js build → nginx serve)
- **Port Mapping**: 80:80
- **Purpose**: Serves Angular application via nginx
- **Dependencies**: Depends on API container

#### API Container (todo-api)
- **Base Image**: mcr.microsoft.com/dotnet/aspnet
- **Framework**: ASP.NET Core (.NET 9.0)
- **Port Mapping**: 5000:5000
- **Purpose**: REST API for todo operations
- **Dependencies**: Depends on PostgreSQL container

#### Database Container (todo-postgres)
- **Base Image**: postgres:latest
- **Port Mapping**: 5432:5432
- **Database Name**: todo_db
- **Credentials**: user/password
- **Purpose**: Data persistence for todo items

#### Dockerfiles

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
  ENV ASPNETCORE_URLS=http://+:5000
  ENTRYPOINT ["dotnet", "WebApi.dll"]
  ```

* Frontend - Angular App: `Dockerfile.frontend`

  ```dockerfile
  FROM node:latest AS build
  WORKDIR /app
  COPY package.json package-lock.json ./
  RUN npm install
  COPY . .
  RUN npm run build

  FROM nginx:alpine
  COPY --from=build /app/dist/frontend/browser /usr/share/nginx/html
  EXPOSE 80
  CMD ["nginx", "-g", "daemon off;"]
  ```

>Note: The name convention for docker files is to start with `Dockerfile.`

#### Build and Deployment

```
Command: sudo docker-compose up --build
```

Build Order:
1. PostgreSQL container starts first
2. API container builds and starts (waits for PostgreSQL)
3. Frontend container builds and starts (waits for API)

## Docker Compose Overview

[Docker Compose](https://docs.docker.com/compose/) is a powerful orchestration tool that simplifies multi-container application management through a single YAML configuration file.

**Key Benefits:**
- **Single Configuration**: Define entire application stack in one `docker-compose.yml` file
- **Service Orchestration**: Manage dependencies between containers automatically  
- **Environment Consistency**: Works across development, staging, and production
- **Simple Commands**: Control entire application lifecycle with basic commands
- **Network Management**: Automatic service discovery and communication
- **Volume Management**: Persistent data storage across container restarts

**Core Capabilities:**
- Start, stop, and rebuild services
- View real-time logs from all services
- Scale services up or down
- Run one-off commands on specific services
- Health checks and dependency management

#### Docker Compose Configuration

**File Structure: `docker-compose.yml`**

The compose file defines three main sections:
1. **Services**: Individual containers and their configurations
2. **Networks**: Communication channels between containers  
3. **Volumes**: Persistent storage for data

**Complete Configuration Example:**

```yaml
services:
  # Database Service
  postgres:
    container_name: todo-postgres
    image: postgres:latest
    environment:
      POSTGRES_USER: user
      POSTGRES_PASSWORD: password
      POSTGRES_DB: todo_db
    ports:
      - "5432:5432"
    volumes:
      - postgres_data:/var/lib/postgresql/data
    restart: unless-stopped
    healthcheck:
      test: ["CMD-SHELL", "pg_isready -U user -d todo_db"]
      interval: 30s
      timeout: 10s
      retries: 3

  # Backend API Service
  api:
    container_name: todo-api
    build:
      context: ./api
      dockerfile: Dockerfile.api
    ports:
      - "5000:5000"
    environment:
      - ASPNETCORE_URLS=http://+:5000
      - ConnectionStrings__DefaultConnection=Host=postgres;Database=todo_db;Username=user;Password=password
    depends_on:
      postgres:
        condition: service_healthy
    restart: unless-stopped
    healthcheck:
      test: ["CMD", "curl", "-f", "http://localhost:5000/health"]
      interval: 30s
      timeout: 10s
      retries: 3

  # Frontend Service
  frontend:
    container_name: todo-frontend
    build:
      context: ./frontend
      dockerfile: Dockerfile.frontend
    ports:
      - "80:80"
    environment:
      - API_URL=http://localhost:5000
    depends_on:
      api:
        condition: service_healthy
    restart: unless-stopped

# Named volumes for data persistence
volumes:
  postgres_data:
    driver: local

# Custom network (optional - Docker creates default network)
networks:
  todo-network:
    driver: bridge
```

#### Configuration Breakdown

**Service Definitions:**

1. **Database Service (`postgres`)**
   ```yaml
   postgres:
     container_name: todo-postgres     # Custom container name
     image: postgres:latest            # Official PostgreSQL image
     environment:                      # Database configuration
       POSTGRES_USER: user
       POSTGRES_PASSWORD: password
       POSTGRES_DB: todo_db
     ports:
       - "5432:5432"                  # Host:Container port mapping
     volumes:
       - postgres_data:/var/lib/postgresql/data  # Data persistence
     restart: unless-stopped          # Auto-restart policy
     healthcheck:                     # Container health monitoring
       test: ["CMD-SHELL", "pg_isready -U user -d todo_db"]
       interval: 30s
       timeout: 10s
       retries: 3
   ```

2. **API Service (`api`)**
   ```yaml
   api:
     container_name: todo-api
     build:                           # Build from Dockerfile
       context: ./api                 # Build context directory
       dockerfile: Dockerfile.api     # Dockerfile name
     ports:
       - "5000:5000"
     environment:                     # Runtime environment variables
       - ASPNETCORE_URLS=http://+:5000
       - ConnectionStrings__DefaultConnection=Host=postgres;Database=todo_db;Username=user;Password=password
     depends_on:                      # Service dependencies
       postgres:
         condition: service_healthy   # Wait for healthy database
     restart: unless-stopped
   ```

3. **Frontend Service (`frontend`)**
   ```yaml
   frontend:
     container_name: todo-frontend
     build:
       context: ./frontend
       dockerfile: Dockerfile.frontend
     ports:
       - "80:80"
     depends_on:
       api:
         condition: service_healthy   # Wait for healthy API
     restart: unless-stopped
   ```

#### Key Configuration Options

| Option | Purpose | Example |
|--------|---------|---------|
| `container_name` | Custom container identifier | `todo-postgres` |
| `image` | Pre-built image to use | `postgres:latest` |
| `build` | Build from Dockerfile | `context: ./api` |
| `ports` | Port mapping (host:container) | `"80:80"` |
| `environment` | Environment variables | `POSTGRES_USER: user` |
| `volumes` | Data persistence | `postgres_data:/var/lib/postgresql/data` |
| `depends_on` | Service startup order | `condition: service_healthy` |
| `restart` | Restart policy | `unless-stopped` |
| `healthcheck` | Container health monitoring | `pg_isready` command |

#### Advanced Features

**Volume Management:**
```yaml
volumes:
  postgres_data:        # Named volume for database
    driver: local
  api_logs:            # Volume for API logs
    driver: local
```

**Network Configuration:**
```yaml
networks:
  todo-network:        # Custom network
    driver: bridge
    ipam:
      config:
        - subnet: 172.20.0.0/16
```

**Environment Files:**
```yaml
services:
  api:
    env_file:
      - .env           # Load environment from file
      - .env.local     # Override with local settings
```

## Docker Commands Reference

### Prerequisites

Before running the application, ensure Docker is installed and running:

| Command | Description |
|---------|-------------|
| `sudo systemctl start docker` | Start Docker service (Linux) |
| `sudo systemctl status docker` | Check Docker service status |
| `docker --version` | Verify Docker installation |
| `docker-compose --version` | Verify Docker Compose installation |

### Application Lifecycle Commands

| Command | Description | Use Case |
|---------|-------------|----------|
| `sudo docker-compose up --build` | Build and start all services | Initial deployment or major changes |
| `sudo docker-compose up` | Start existing containers | Regular startup after containers exist |
| `sudo docker-compose up -d` | Start containers in background (detached) | Production deployment |
| `sudo docker-compose down` | Stop and remove all containers | Clean shutdown |
| `sudo docker-compose stop` | Stop containers without removing them | Temporary pause |
| `sudo docker-compose start` | Start stopped containers | Resume after stop |
| `sudo docker-compose restart` | Restart all services | Quick restart |

### Development Workflow Commands

| Scenario | Command | Description |
|----------|---------|-------------|
| **Frontend Code Changes** | `sudo docker-compose up --build frontend` | Rebuild only frontend container |
| **Backend Code Changes** | `sudo docker-compose up --build api` | Rebuild only API container |
| **Database Changes** | `sudo docker-compose down && sudo docker-compose up --build` | Full rebuild (recreates database) |
| **Configuration Changes** | `sudo docker-compose down && sudo docker-compose up --build` | Apply docker-compose.yml changes |

### Container Management Commands

| Command | Description |
|---------|-------------|
| `sudo docker ps` | List running containers |
| `sudo docker ps -a` | List all containers (including stopped) |
| `sudo docker logs todo-frontend` | View frontend container logs |
| `sudo docker logs todo-api` | View API container logs |
| `sudo docker logs todo-postgres` | View database container logs |
| `sudo docker exec -it todo-api bash` | Access API container shell |
| `sudo docker exec -it todo-postgres psql -U user -d todo_db` | Access database directly |

### Cleanup Commands

| Command | Description | Use Case |
|---------|-------------|----------|
| `sudo docker-compose down --volumes` | Remove containers and volumes | Complete cleanup including data |
| `sudo docker system prune` | Remove unused containers, networks, images | Free up disk space |
| `sudo docker image prune` | Remove unused images | Clean up old builds |
| `sudo docker volume prune` | Remove unused volumes | Clean up orphaned data |

### Quick Start Guide

1. **Start Docker service:**
   ```bash
   sudo systemctl start docker
   ```

2. **Navigate to project directory:**
   ```bash
   cd /path/to/todo-app
   ```

3. **Build and run the application:**
   ```bash
   sudo docker-compose up --build
   ```

4. **Access the application:**
   - Frontend: http://localhost
   - API: http://localhost:5000
   - Database: localhost:5432

5. **Stop the application:**
   ```bash
   sudo docker-compose down
   ```

### Troubleshooting Commands

| Issue | Command | Solution |
|-------|---------|----------|
| **Containers won't start** | `sudo docker-compose logs` | Check logs for errors |
| **Port conflicts** | `sudo docker-compose down && sudo docker-compose up` | Restart to release ports |
| **Database connection issues** | `sudo docker-compose restart postgres` | Restart database container |
| **Frontend not updating** | `sudo docker-compose up --build frontend` | Rebuild frontend with changes |
| **API errors** | `sudo docker logs todo-api --tail 50` | Check recent API logs |
