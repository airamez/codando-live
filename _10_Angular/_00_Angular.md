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
* **Cross-Platform Development**: Enables web, mobile (via [Ionic](https://ionicframework.com/)), and desktop (via [Electron](https://www.electronjs.org/)) applications from a single codebase.

## Why Use Angular?

* **Enterprise Scalability**: Angular’s structured framework and tooling make it ideal for large, complex applications.
* **Performance Optimizations**: Zoneless change detection, improved SSR, and tree-shaking ensure fast, efficient apps.
* **Developer Productivity**: The Angular CLI, standalone components, and modern APIs reduce development time and complexity.
* **Cross-Platform**: Supports web, mobile (via Ionic), and desktop (via Electron) development.
* **Active Community**: Backed by Google with a thriving community, regular updates, and extensive documentation.

## Resources

* **Official Angular Website**: Explore Angular’s features, tutorials, and community resources.
  * (<https://angular.dev>)
* **Official Documentation**: Detailed guides, API references, and best practices.
  * (<https://angular.dev/docs>)
* **Angular Blog**: Latest news, release notes, and updates on Angular.
  * (<https://blog.angular.io>)
* **Oficial Tutorial**: You can learn Angular interactively with this tutorial from Angular team:
  * (<https://angular.dev/tutorials/learn-angular>)
  * (<https://angular.dev/tutorials>)

## Getting Started

* Install the Angular and [CLI](https://angular.dev/tools/cli) globally
  * The Angular CLI is a command-line interface tool which allows you to scaffold, develop, test, deploy, and maintain Angular applications directly from a command shell.
  * It provides the ng (short for a*ng*ular) command and tools for scaffolding, building, and managing Angular projects.

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

>Class Note: Do a demo creating a new app :)

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

## Components

* A [**component**](https://angular.dev/api/core/Component) is a fundamental building block in Angular applications.
* Components are modular, reusable, and encapsulate their functionality, making it easier to build and maintain complex applications.
* It represents a reusable piece of the user interface (UI) that combines:
  * **HTML Template**: Defines the structure and layout of the UI.
  * **TypeScript Class**: Contains the logic and data for the component.
  * **CSS Styles**: Specifies the component's appearance.
  * **Metadata**: Configures the component using Angular decorators like `@Component`.

### Key Characteristics of Components

* **Encapsulation**: Each component manages its own template, styles, and logic, isolated from others.
* **Reusability**: Components can be reused across different parts of the app.
* **Hierarchy**: Components form a tree-like structure, with parent and child components communicating through inputs and outputs.
* **Data Binding**: Connects the component’s data to the template for dynamic rendering.

### Creating a Component

Let’s create a simple component called `hello-world` to display a welcome message in your Angular app.

* Step 1: Generate a Component
  * Use the Angular CLI to create a new component.
  * Run the following command in your project’s root directory:

  ```bash
  ng generate component hello-world
  ```

  * This command:
  * Creates a `hello-world` folder under `src/app/hello-world`.
  * Generates four files:
    * `hello-world.css`: The component’s styles.
    * `hello-world.html`: The HTML template.
    * `hello-world.spec.ts`: The unit test file.
    * `hello-world.ts`: The TypeScript class with component logic.
  * Updates the `app.module.ts` to declare the new component.

* Step 2: Component Structure

  ```typescript
  import { Component } from '@angular/core';

  @Component({
    selector: 'hello-world',
    imports: [],
    templateUrl: './hello-world.html',
    styleUrl: './hello-world.css'
  })
  export class HelloWorld {

  }
  ```

  * **@Component Decorator**: Configures the component with:
    * `selector`: The custom HTML tag (`<hello-world>`) used to include the component in templates.
    * `imports`: Imported components.
    * `templateUrl`: Path to the HTML template.
    * `styleUrls`: Array of paths to CSS files.
  * **Class**: Defines the component’s properties and methods.

* Step 3: Customize the Component
  * Update the Template (`hello-world.html`):

  ```html
  <h2>Welcome to Our Angular App!</h2>
  <p>{{ message }}</p>
  ```

  * Update the Component Class (`hello-world.ts`):

  ```typescript
  import { Component } from '@angular/core';

  @Component({
    selector: 'hello-world',
    imports: [],
    templateUrl: './hello-world.html',
    styleUrl: './hello-world.css'
  })
  export class HelloWorld {
    message: string = 'Hello Angular World!';
  }
  ```

  * The `message` property is bound to the template using Angular’s interpolation (`{{ message }}`).

* Style the Component (`hello-world.css`):

  ```css
  h2 {
    color: #007bff;
    text-align: center;
  }
  p {
    font-size: 1.2em;
    color: #333;
  }
  ```

* Step 4: Add the Component to Your App
  * Add the the component to the App `imports`

  ```typescript
  import { Component } from '@angular/core';
  import { RouterOutlet } from '@angular/router';
  import { HelloWorld } from './hello-world/hello-world';

  @Component({
    selector: 'app-root',
    imports: [RouterOutlet, HelloWorld],
    templateUrl: './app.html',
    styleUrl: './app.css'
  })
  export class App {
    protected title = 'my-app';
  }
  ```

  * Add the component `selector` to the App HTML `app.html` template:

  ```html
  ...
  <hello-world></hello-world>
  ...
  ```

* Step 5: Run the Application
  * Run the development server:

  ```bash
  ng serve
  ```

  * Open your browser at `http://localhost:4200`

## Component Data Binding

* [Data binding](https://v17.angular.io/guide/binding-syntax) in Angular allows seamless interaction between a component's code and its HTML template.
* It enables dynamic updates to the UI when data changes in the component and vice versa.

### Key Binding Concepts

* **Interpolation (`{{ }}`)**: Displays component data in the template as text.
* **Property Binding (`[property]="value"`)**: Binds a component variable to an HTML element's property.
* **Event Binding (`(event)="handler()"`)**: Listens for user actions (e.g., clicks) and triggers component methods.
* **Two-Way Binding (`[(ngModel)]="value"`)**: Combines property and event binding for bidirectional data flow, typically used with form inputs.

### Binding from Component to HTML

#### 1. Interpolation

Interpolation uses double curly braces `{{ }}` to display component variable values in the template.

```html
<!-- Template (app.component.html) -->
<h1>{{ title }}</h1>
```

```typescript
// Component (app.component.ts)
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'Welcome to Angular!';
}
```

* Explanation
  * Renders "Welcome to Angular!" in the `<h1>` tag.
  * When `title` changes, the UI updates automatically.

#### 2. Property Binding

Property binding sets an HTML element's property to a component variable using square brackets `[ ]`.

```html
<!-- Template (component.html) -->
<button [disabled]="isDisabled">Click Me</button>
```

```typescript
// Component (component.ts)
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  isDisabled = true;
}
```

* Explanation
  * The `disabled` property of the button is bound to `isDisabled`. If `isDisabled` is `true`, the button is disabled.
  * The `src` attribute of the `<img>` tag is bound to `imageUrl`, dynamically setting the image source.

#### 3. Event Binding

Event binding listens for DOM events (e.g., `click`, `input`) and calls a component method using parentheses `( )`.

```html
<!-- Template (component.html) -->
<p>Counter: {{ counter }}</p>
<button (click)="increment()">Increment</button>
```

```typescript
// Component (component.ts)
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  counter = 0;

  increment() {
    this.counter++;
  }
}
```

* Explanation
  * Clicking the button triggers the `increment()` method, updating `counter`, which is reflected in the UI via interpolation.

### 4. Two-Way Binding

* Two-way binding syncs data between the component and template using `[(ngModel)]`.
* Requires the `FormsModule` to be imported in the module.

```html
<!-- Template (app.component.html) -->
<input [(ngModel)]="userName" placeholder="Enter your name">
<p>Hello, {{ userName }}!</p>
```

```typescript
// Module (app.module.ts)
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';

@NgModule({
  declarations: [AppComponent],
  imports: [FormsModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
```

>Note: Add the FormsModule to the `imports

```typescript
// Component (app.component.ts)
import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  userName = '';
}
```

* Explanation
  * As the user types in the input, `name` updates in the component, and the updated value is displayed in the `<p>` tag.

### Summary

* **Interpolation**: Display component data in the template (`{{ variable }}`).
* **Property Binding**: Bind component variables to element properties (`[property]="variable"`).
* **Event Binding**: Handle user events to trigger component methods (`(event)="method()"`).
* **Two-Way Binding**: Sync data bidirectionally with `[(ngModel)]` (requires `FormsModule`).

>Note: These binding techniques allow you to create dynamic, interactive Angular applications by connecting component logic to the UI.

### Binding Demo

* Demo 1: All binding types
  * [_10_Angular/my-app/src/app/binding-demo/binding-demo.css](../_10_Angular/my-app/src/app/binding-demo/binding-demo.css)
  * [_10_Angular/my-app/src/app/binding-demo/binding-demo.html](../_10_Angular/my-app/src/app/binding-demo/binding-demo.html)
  * [_10_Angular/my-app/src/app/binding-demo/binding-demo.ts](../_10_Angular/my-app/src/app/binding-demo/binding-demo.ts)

* Demo 2: Form demo
  * [_10_Angular/my-app/src/app/data-form-demo/data-form-demo.css](../_10_Angular/my-app/src/app/data-form-demo/data-form-demo.css)
  * [_10_Angular/my-app/src/app/data-form-demo/data-form-demo.html](../_10_Angular/my-app/src/app/data-form-demo/data-form-demo.html)
  * [_10_Angular/my-app/src/app/data-form-demo/data-form-demo.ts](../_10_Angular/my-app/src/app/data-form-demo/data-form-demo.ts)

### Angular Structural Directives

* Structural directives in Angular are powerful tools for dynamically modifying the DOM by adding, removing, or repeating elements based on data or conditions.
* Built into Angular’s template syntax, they use an asterisk (`*`) to indicate structural changes, such as conditionally rendering elements or iterating over collections.
* In Angular 20 (released May 2025), structural directives like `*ngIf` and `*ngFor` remain core features, with new built-in control flow syntax (`@if`, `@for`) introduced as modern alternatives.

* Key Concepts
  * **Structural Directives**: Directives that alter the DOM structure by adding, removing, or repeating elements.
    * Prefixed with `*` (e.g., `*ngIf`, `*ngFor`), which Angular expands into `<ng-template>` internally.
  * **Dynamic HTML**: Structural directives enable dynamic UI updates by binding to component data, making apps interactive and responsive.
  * **CommonModule**: Provides `*ngIf` and `*ngFor` for standalone components; not needed for `@if` and `@for`.
  * **New Control Flow**: Angular 20’s `@if` and `@for` offer a concise, built-in alternative to directives, with improved performance and readability.

* Resources
  * **Official Documentation**:
    * `*ngIf`: [https://angular.dev/api/common/NgIf](https://angular.dev/api/common/NgIf)
    * `*ngFor`: [https://angular.dev/api/common/NgFor](https://angular.dev/api/common/NgFor)
    * Control Flow (`@if`, `@for`): [https://angular.dev/guide/templates/control-flow](https://angular.dev/guide/templates/control-flow)
  * **Angular Tutorials**: Interactive guides for learning directives and control flow.
    * [https://angular.dev/tutorials](https://angular.dev/tutorials)

#### `*ngIf` Directive

* The `*ngIf` directive conditionally adds or removes an element and its children from the DOM based on a boolean expression.
* Ideal for showing/hiding content dynamically, such as user authentication states or toggling UI elements.

* Syntax

  ```html
  <div *ngIf="condition">Content to show if condition is true</div>
  ```

  * `condition`: A boolean expression from the component.
  * If `true`, the element is rendered; if `false`, it’s removed from the DOM.

* Example: Create a component to show a login status message.

  ```typescript
  // src/app/login-status/login-status.ts
  import { Component } from '@angular/core';
  import { CommonModule } from '@angular/common';

  @Component({
    selector: 'app-login-status',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './login-status.html',
    styleUrl: './login-status.css'
  })
  export class LoginStatusComponent {
    isLoggedIn = false;

    toggleLogin() {
      this.isLoggedIn = !this.isLoggedIn;
    }
  }
  ```

  ```html
  <!-- src/app/login-status/login-status.html -->
  <div>
    <button (click)="toggleLogin()">{{ isLoggedIn ? 'Log Out' : 'Log In' }}</button>
    <p *ngIf="isLoggedIn">Welcome, you are logged in!</p>
  </div>
  ```

  ```css
  /* src/app/login-status/login-status.css */
  p {
    color: green;
    font-weight: bold;
  }
  button {
    padding: 8px 16px;
    margin-bottom: 10px;
  }
  ```

  * **Explanation**:
    * The `<p>` is rendered only when `isLoggedIn` is `true`.
    * Clicking the button toggles `isLoggedIn`, dynamically updating the DOM.
    * `*ngIf` removes the element entirely, unlike CSS `display: none`.

#### `*ngIf` with `else`

Use `else` to display alternative content when the condition is `false`.

```html
<!-- src/app/login-status/login-status.html -->
<div>
  <button (click)="toggleLogin()">{{ isLoggedIn ? 'Log Out' : 'Log In' }}</button>
  <p *ngIf="isLoggedIn; else notLoggedIn">Welcome, you are logged in!</p>
  <ng-template #notLoggedIn>
    <p>Please log in to continue.</p>
  </ng-template>
</div>
```

* **Explanation**:
  * Shows the welcome message if `isLoggedIn` is `true`; otherwise, renders the `<ng-template>` content.

#### `*ngFor` Directive

* The `*ngFor` directive iterates over a collection (e.g., an array) to render a template for each item.
* Perfect for displaying lists, tables, or any repeated UI elements.

* Syntax

```html
<div *ngFor="let item of items">{{ item }}</div>
```

* `items`: The collection to iterate over.
* `item`: A local variable for each item in the iteration.

* Example: Task List. Create a component to display and add tasks.

```html
<div>
  <input [(ngModel)]="task" placeholder="Add a new task">
  <button (click)="addTask()">Add</button>
  <p *ngIf="tasks.length === 0">No tasks available.</p>
  <ul *ngIf="tasks.length > 0">
    <li *ngFor="let task of tasks; let i = index;">
      {{ i + 1 }}. {{ task }}
    </li>
  </ul>
</div>
```

```typescript
import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'task-list',
  imports: [FormsModule, CommonModule],
  templateUrl: './task-list.html',
  styleUrl: './task-list.css'
})
export class TaskList {
  task = "";
  tasks: string[] = [];

  addTask() {
    if (this.task.length > 0) {
      this.tasks.push(this.task);
    }
    this.task = "";
  }
}
```

```css
ul {
  list-style-type: none;
  padding: 0;
}
li {
  padding: 8px;
  border-bottom: 1px solid #ddd;
}
input {
  padding: 8px;
  margin-bottom: 10px;
  width: 200px;
  border: 1px solid #ccc;
  border-radius: 4px;
}
p {
  color: #888;
  text-align: left;
}
button {
  padding: 8px 16px;
  margin-left: 10px;
  background-color: #007bff;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}
button:hover {
  background-color: #0056b3;
}
```

* **Explanation**:
  * `*ngFor` renders an `<li>` for each task in the `tasks` array.
  * `let i = index` provides a numbered list.
  * `*ngIf` shows a message when the list is empty.

* Example: Task List
  * [_10_Angular/my-app/src/app/task-list/task-list.css](../_10_Angular/my-app/src/app/task-list/task-list.css)
  * [_10_Angular/my-app/src/app/task-list/task-list.html](../_10_Angular/my-app/src/app/task-list/task-list.html)
  * [_10_Angular/my-app/src/app/task-list/task-list.ts](../_10_Angular/my-app/src/app/task-list/task-list.ts)


#### Modern Control Flow: `@if` and `@for`

* Angular 20 introduces `@if` and `@for` as built-in control flow syntax, offering a concise alternative to `*ngIf` and `*ngFor`.
* No `CommonModule` import is needed, and they integrate directly into templates.

##### `@if`

* Conditionally renders content without `<ng-template>`.

```html
@if (condition) {
  <div>Content to show if condition is true.</div>
} @else {
  <div>Content to show if condition is false.</div>
}
```

##### Example: Login Status with `@if`

```typescript
// src/app/login-status-modern/login-status-modern.ts
import { Component } from '@angular/core';

@Component({
  selector: 'app-login-status-modern',
  standalone: true,
  templateUrl: './login-status-modern.html',
  styleUrl: './login-status-modern.css'
})
export class LoginStatusModernComponent {
  isLoggedIn = false;

  toggleLogin() {
    this.isLoggedIn = !this.isLoggedIn;
  }
}
```

```html
<!-- src/app/login-status-modern/login-status-modern.html -->
<div>
  <button (click)="toggleLogin()">{{ isLoggedIn ? 'Log Out' : 'Log In' }}</button>
  @if (isLoggedIn) {
    <p>Welcome, you are logged in!</p>
  } @else {
    <p>Please log in to continue.</p>
  }
</div>
```

```css
/* src/app/login-status-modern/login-status-modern.css */
p {
  color: green;
  font-weight: bold;
}
button {
  padding: 8px 16px;
  margin-bottom: 10px;
}
```

* **Explanation**:
  * `@if` is more concise than `*ngIf` and doesn’t require `CommonModule`.
  * Achieves the same conditional rendering.

##### `@for`

* Iterates over collections with a mandatory `track` expression for performance.

```html
@for (item of items; track item) {
  <div>{{ item }}</div>
} @empty {
  <div>No items available.</div>
}
```

##### Example: Task List with `@for`

```bash
ng generate component task-list-modern
```

```typescript
// src/app/task-list-modern/task-list-modern.ts
import { Component } from '@angular/core';

@Component({
  selector: 'app-task-list-modern',
  standalone: true,
  templateUrl: './task-list-modern.html',
  styleUrl: './task-list-modern.css'
})
export class TaskListModernComponent {
  tasks = ['Write code', 'Test app', 'Deploy to production'];

  addTask(newTask: string) {
    if (newTask.trim()) {
      this.tasks.push(newTask.trim());
    }
  }
}
```

```html
<!-- src/app/task-list-modern/task-list-modern.html -->
<div>
  <input #taskInput placeholder="Add a new task" (keyup.enter)="addTask(taskInput.value); taskInput.value=''">
  @for (task of tasks; track task; let i = $index) {
    <li>{{ i + 1 }}. {{ task }}</li>
  } @empty {
    <p>No tasks available.</p>
  }
</div>
```

```css
/* src/app/task-list-modern/task-list-modern.css */
ul {
  list-style-type: none;
  padding: 0;
}
li {
  padding: 8px;
  border-bottom: 1px solid #ddd;
}
input {
  padding: 8px;
  margin-bottom: 10px;
  width: 200px;
}
p {
  color: #888;
  text-align: center;
}
```

* **Explanation**:
  * `@for` iterates over `tasks`, with `track task` optimizing updates.
  * `@empty` replaces the need for a separate `*ngIf` check.
  * No `CommonModule` import is required.

#### Key Notes

* **Performance**:
  * `*ngIf` and `@if` remove elements from the DOM for efficiency.
  * Use `trackBy` with `*ngFor` or `track` with `@for` for large lists.
* **Best Practices**:
  * Move complex logic to the component, keeping templates simple.
  * Use `@if` and `@for` for new projects; `*ngIf` and `*ngFor` for compatibility.
* **Compatibility**:
  * `*ngIf` and `*ngFor` are unchanged since Angular 10 and remain widely used.
  * `@if` and `@for` are Angular 20 innovations, optional but recommended.

### Demos

* Demo 1: `*ngIf` Login Status
  * [_10_Angular/dynamic-content-app/src/app/login-status/login-status.css](../_10_Angular/dynamic-content-app/src/app/login-status/login-status.css)
  * [_10_Angular/dynamic-content-app/src/app/login-status/login-status.html](../_10_Angular/dynamic-content-app/src/app/login-status/login-status.html)
  * [_10_Angular/dynamic-content-app/src/app/login-status/login-status.ts](../_10_Angular/dynamic-content-app/src/app/login-status/login-status.ts)

* Demo 2: `*ngFor` Task List
  * [_10_Angular/dynamic-content-app/src/app/task-list/task-list.css](../_10_Angular/dynamic-content-app/src/app/task-list/task-list.css)
  * [_10_Angular/dynamic-content-app/src/app/task-list/task-list.html](../_10_Angular/dynamic-content-app/src/app/task-list/task-list.html)
  * [_10_Angular/dynamic-content-app/src/app/task-list/task-list.ts](../_10_Angular/dynamic-content-app/src/app/task-list/task-list.ts)

* Demo 3: `@if` and `@for` Modern Task List
  * [_10_Angular/dynamic-content-app/src/app/task-list-modern/task-list-modern.css](../_10_Angular/dynamic-content-app/src/app/task-list-modern/task-list-modern.css)
  * [_10_Angular/dynamic-content-app/src/app/task-list-modern/task-list-modern.html](../_10_Angular/dynamic-content-app/src/app/task-list-modern/task-list-modern.html)
  * [_10_Angular/dynamic-content-app/src/app/task-list-modern/task-list-modern.ts](../_10_Angular/dynamic-content-app/src/app/task-list-modern/task-list-modern.ts)

> **Class Note**: Walk through each demo, showing how to add tasks and toggle login status. Compare `*ngIf`/`@if` and `*ngFor`/`@for` syntax. Encourage students to modify the demos (e.g., add a remove task button).