# Angular

* Angular is a robust, open-source web application framework developed by Google, designed for building dynamic, scalable, and maintainable single-page applications (SPAs).
* Built on TypeScript, it offers a structured, component-based architecture that promotes modularity, reusability, and testability.
* Angular 20, released in May 2025, brings cutting-edge features to enhance performance, developer experience, and modern web development capabilities, making it ideal for enterprise-grade applications.

> Note: Angular (version 2 and later) is a complete rewrite of AngularJS (version 1.x), transitioning from a JavaScript-based framework to a TypeScript-based, component-driven platform for better performance and scalability.

## Key Features

* **Component-Based Architecture**: Build encapsulated, reusable UI components to create complex, modular interfaces with ease.
* **TypeScript Integration**: Harnesses TypeScript’s type safety and tooling for better code maintainability and developer productivity.
* **Two-Way Data Binding**: Automatically synchronizes data between the model and view, simplifying UI updates.
* **Dependency Injection**: A powerful DI system for managing services, promoting modularity and easier testing.
* **Angular CLI**: A command-line interface that streamlines project setup, component generation, testing, and deployment.
* **Reactive Programming**: Supports reactive state management (e.g., via RxJS or Signals) for efficient, event-driven applications.
* **Routing and Navigation**: Built-in router for creating SPAs with client-side navigation and lazy loading for performance.
* **Forms Handling**: Robust support for template-driven and reactive forms with validation and dynamic controls.
* **Testing Support**: Integrated tools like Jasmine and Karma for unit and end-to-end testing to ensure code quality.
* **Cross-Platform Development**: Enables web, mobile (via Ionic), and desktop (via Electron) applications from a single codebase.

## Why Use Angular?

* **Enterprise Scalability**: Angular’s structured framework and tooling make it ideal for large, complex applications.
* **Performance Optimizations**: Zoneless change detection, improved SSR, and tree-shaking ensure fast, efficient apps.
* **Developer Productivity**: The Angular CLI, standalone components, and modern APIs reduce development time and complexity.
* **Cross-Platform**: Supports web, mobile (via Ionic), and desktop (via Electron) development.
* **Active Community**: Backed by Google with a thriving community, regular updates, and extensive documentation.

## Resources

* **Official Angular Website**: Explore Angular’s features, tutorials, and community resources.
  * (<https://angular.dev>)
* **Official Documentation**: Detailed guides, API references, and best practices for Angular 20.
  * (<https://angular.dev/docs>)
* **Angular Blog**: Latest news, release notes, and updates on Angular 20.
  * (<https://blog.angular.io>)
* **Oficial Tutorial**: You can learn Angular interactively with this tutorial from Angular team:
  * (<https://angular.dev/tutorials/learn-angular>)
  * (<https://angular.dev/tutorials>)

## Getting Started

* Install the Angular CLI globally:

  ```bash
  sudo npm install -g @angular/cli@20
  ```

* Create a new project:

  ```bash
  ng new my-app
  ```

* Run the development server:

  ```bash
  cd my-app
  ng serve
  ```

![Angular](./images/angular.png)

## File Structure

| **Location**       | **File/Directory**  | **Description**                                                                 |
|--------------------|---------------------|---------------------------------------------------------------------------------|
| `/my-app/`         | `angular.json`      | Workspace configuration file defining project settings, build, and test options.|
| `/my-app/`         | `package.json`      | Defines project metadata, dependencies, and scripts for npm.                    |
| `/my-app/`         | `package-lock.json` | Locks exact versions of dependencies for consistent installs.                   |
| `/my-app/`         | `tsconfig.json`     | Root TypeScript configuration for the workspace, including compiler options.    |
| `/my-app/`         | `README.md`         | Introductory documentation with basic instructions for the project.             |
| `/my-app/`         | `.gitignore`        | Specifies files and directories Git should ignore.                              |
| `/my-app/`         | `.editorconfig`     | Standardizes code formatting across editors for consistent coding styl.         |
| `/my-app/`         | `node_modules/`     | Contains all npm dependencies installed for the project.                        |
| `/my-app/src/`     | `src/`              | Root directory for application source code, assets, and configurations.         |
| `/my-app/src/`     | `index.html`        | Main HTML file served by the app, with `<app-root>` as the root component selector. |
| `/my-app/src/`     | `main.ts`           | Entry point for the application, bootstrapping the standalone `AppComponent`.   |
| `/my-app/src/`     | `styles.css`        | Global styles applied across the entire application.                            |
| `/my-app/src/app/` | `app/`              | Contains the main application logic, including components and services          |
| `/my-app/src/app/` | `app.ts`            | Root component (standalone by default) defining the app's entry point.          |
| `/my-app/src/app/` | `app.html`          | Template for the root component, defining its HTML structure.                   |
| `/my-app/src/app/` | `app.css`           | Styles for the root component (CSS by default, based on CLI prompt).            |
| `/my-app/src/app/` | `app.spec.ts`       | Unit test file for the root component.                                          |
| `/my-app/src/app/` | `app.routes.ts`     | Defines application routes (included if routing is enabled during `ng new`).    |
