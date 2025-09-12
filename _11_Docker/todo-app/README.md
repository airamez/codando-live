# Todo App

This is a full-stack Todo application built using Angular for the front-end, ASP.NET Core Web API for the back-end, and PostgreSQL as the database. The application allows users to manage their Todo items with features for creating, reading, updating, and deleting tasks.

## Project Structure

The project is organized into the following directories:

- **api**: Contains the ASP.NET Core Web API for managing Todo items.
  - **Controllers**: Contains the `TodoController.cs` for handling HTTP requests.
  - **Models**: Contains the `TodoItem.cs` which defines the structure of a Todo item.
  - **Data**: Contains the `TodoContext.cs` for database context management.
  - **WebApi.csproj**: Project file for the ASP.NET Core Web API.
  - **Program.cs**: Entry point of the application.
  - **Startup.cs**: Configures services and the request pipeline.
  - **Dockerfile.api**: Dockerfile for building the API image.

- **frontend**: Contains the Angular front-end application.
  - **src/app/todo**: Contains the Todo component files.
    - `todo.component.ts`: Manages the Todo list UI.
    - `todo.component.html`: HTML template for the Todo component.
    - `todo.component.css`: Styles for the Todo component.
  - **app.module.ts**: Main application module.
  - **main.ts**: Entry point of the Angular application.
  - **Dockerfile.frontend**: Dockerfile for building the front-end image.
  - **angular.json**: Angular project configuration.
  - **package.json**: npm configuration file.

- **docker-compose.yml**: Defines the multi-container Docker application for the API, frontend, and PostgreSQL database.

## Setup Instructions

0. Start Docker

  ```
  sudo systemctl start docker
  ```

1. **Clone the repository**:
   ```
   git clone <repository-url>
   cd todo-app
   ```

2. **Build and run the application using Docker Compose**:
   ```
   sudo docker-compose up --build
   ```

3. **Access the application**:
   - Frontend: Open your browser and navigate to `http://localhost:80`
   - API: The API will be accessible at `http://localhost:5000`

## Usage

- You can create, read, update, and delete Todo items through the front-end interface.
- The API provides endpoints for managing Todo items, which can be tested using tools like Postman or directly through the front-end.

## Technologies Used

- **Frontend**: Angular (latest version)
- **Backend**: ASP.NET Core Web API
- **Database**: PostgreSQL
- **Containerization**: Docker and Docker Compose

