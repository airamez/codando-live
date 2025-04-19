# Introduction to Docker Containers

## [What is Docker](https://www.docker.com/resources/what-container/)?
[Docker](https://www.docker.com/) is a platform for developing, shipping, and running applications in lightweight, portable containers. Containers bundle the application, along with all its dependencies and environment configurations, into a single package. This ensures consistency across development, testing, and production environments.

### Key Concepts
- **Containers**: Isolated environments for running applications, sharing the host OS kernel, but with dedicated resources.
- **Images**: Immutable templates for creating containers, containing the application and its dependencies.
- **Docker Engine**: The runtime that builds, runs, and manages containers.
- **Docker Hub**: A repository for sharing and downloading container images.

### Why Use Docker?
- **Consistency**: Applications run the same way across different environments.
- **Resource Efficiency**: Containers are lightweight compared to traditional virtual machines.
- **Scalability**: Easily replicate and deploy containers to meet demand.

## Virtual Machines vs Containers

### Virtual Machines (VMs)
- **Definition**: VMs emulate an entire physical machine, including its operating system, on top of a hypervisor.
- **Structure**: Each VM includes a full guest operating system, application, and required dependencies.
- **Resource Usage**: VMs are heavyweight due to the need for individual OS instances, consuming significant system resources.
- **Isolation**: Strong isolation between VMs since each runs its own OS.
- **Startup Time**: VMs typically have slower startup times as they boot the guest OS.

### Containers
- **Definition**: Containers virtualize the operating system, allowing multiple applications to run in isolated environments on the same OS kernel.
- **Structure**: Containers share the host OS kernel, bundling only applications and their dependencies.
- **Resource Usage**: Containers are lightweight and use fewer resources compared to VMs.
- **Isolation**: Process-level isolation; less isolated than VMs but sufficient for most use cases.
- **Startup Time**: Containers start almost instantly due to their lightweight structure.

### Key Takeaway
Virtual machines are best suited for applications requiring strong isolation and compatibility with multiple OS types. Containers, on the other hand, are ideal for lightweight, scalable, and resource-efficient applications.

---

## Using Docker on Linux
Most Linux distributions include all necessary tools to run Docker containers.
Make sure Docker is installed and configured before proceeding.

## Creating a SQL Server Container

### Step-by-Step Demo
1. **Install Docker**:
    - Open a terminal and update the package repository:
      ```bash
      sudo dnf update
      ```
    - Install Docker:
      ```bash
      sudo dnf install docker
      ```
    - Start the Docker service:
      ```bash
      sudo systemctl start docker
      sudo systemctl enable docker
      ```

2. **Pull the SQL Server Image**:
    - Search for the official SQL Server image:
      ```bash
      sudo docker search mssql-server
      ```
    - Pull the image (e.g., `mcr.microsoft.com/mssql/server`):
      ```bash
      sudo docker pull mcr.microsoft.com/mssql/server
      ```

3. **Run the Container**:
    - Start a container with SQL Server:
      ```bash
      docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=YourPassword123' -p 1433:1433 --name sqlserver -d mcr.microsoft.com/mssql/server
      ```
    - Replace `YourPassword123` with a strong password for the SQL Server `sa` user.

4. **Access SQL Server**:
    - Use a SQL client to connect to the server at `localhost,1433`.
    - Verify it's running with:
      ```bash
      docker ps
      ```

5. **Stop and Remove the Container**:
    - Stop the container:
      ```bash
      docker stop sqlserver
      ```
    - Remove the container:
      ```bash
      docker rm sqlserver
      ```

6. **Accessing the database using VSCode**

7. **Create the NorthWind database**

  ```sql
  CREATE DATABASE NorthWind;

  SELECT name 
  FROM sys.databases
  WHERE name = 'NorthWind';

  USE NorthWind

  ```

### Advantages of Using SQL Server Containers
- Rapid setup of SQL Server instances for development and testing.
- Easy removal and recreation of containers for clean environments.
- Simplified dependency management.