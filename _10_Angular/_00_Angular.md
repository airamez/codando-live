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

## Binding Demo

* Demo 1: All binding types
  * [_10_Angular/my-app/src/app/binding-demo/binding-demo.css](../_10_Angular/my-app/src/app/binding-demo/binding-demo.css)
  * [_10_Angular/my-app/src/app/binding-demo/binding-demo.html](../_10_Angular/my-app/src/app/binding-demo/binding-demo.html)
  * [_10_Angular/my-app/src/app/binding-demo/binding-demo.ts](../_10_Angular/my-app/src/app/binding-demo/binding-demo.ts)

* Demo 2: Form demo
  * [_10_Angular/my-app/src/app/data-form-demo/data-form-demo.css](../_10_Angular/my-app/src/app/data-form-demo/data-form-demo.css)
  * [_10_Angular/my-app/src/app/data-form-demo/data-form-demo.html](../_10_Angular/my-app/src/app/data-form-demo/data-form-demo.html)
  * [_10_Angular/my-app/src/app/data-form-demo/data-form-demo.ts](../_10_Angular/my-app/src/app/data-form-demo/data-form-demo.ts)

## Structural Directives: `*ngIf` and `*ngFor`

* [Structural directives](https://angular.dev/guide/directives/structural-directives) in Angular modify the DOM by adding, removing, or manipulating elements based on conditions or data.
* They are prefixed with an asterisk (`*`), which is syntactic sugar for Angular’s template syntax.
* The two most commonly used structural directives are `*ngIf` and `*ngFor`, which control element visibility and iteration over collections, respectively.

### 1. `*ngIf` Directive

* The `*ngIf` directive conditionally includes or removes an element and its children from the DOM based on a boolean expression.
* It is useful for showing or hiding content dynamically, improving performance by avoiding unnecessary DOM rendering.

#### Syntax

```html
<div *ngIf="condition">Content to show if condition is true</div>
```

* `condition`: A boolean expression from the component that determines whether the element is rendered.
* If `condition` is `true`, the element is added to the DOM; if `false`, it is removed.

#### Example: Using `*ngIf`

Let’s create a component that shows a message only if a user is logged in.

```typescript
// Component (user-status.component.ts)
import { Component } from '@angular/core';

@Component({
  selector: 'app-user-status',
  templateUrl: './user-status.component.html',
  styleUrl: './user-status.component.css'
})
export class UserStatusComponent {
  isLoggedIn = false;

  toggleLogin() {
    this.isLoggedIn = !this.isLoggedIn;
  }
}
```

```html
<!-- Template (user-status.component.html) -->
<div>
  <button (click)="toggleLogin()">{{ isLoggedIn ? 'Log Out' : 'Log In' }}</button>
  <p *ngIf="isLoggedIn">Welcome, you are logged in!</p>
</div>
```

```css
/* Styles (user-status.component.css) */
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
  * The `<p>` element is only rendered when `isLoggedIn` is `true`.
  * Clicking the button toggles `isLoggedIn`, adding or removing the `<p>` from the DOM.
  * Unlike CSS `display: none`, `*ngIf` completely removes the element from the DOM, which is more performant for conditional content.

#### `*ngIf` with `else`

You can use `*ngIf` with an `else` clause to display alternative content when the condition is `false`.

```html
<!-- Template (user-status.component.html) -->
<div>
  <button (click)="toggleLogin()">{{ isLoggedIn ? 'Log Out' : 'Log In' }}</button>
  <p *ngIf="isLoggedIn; else notLoggedIn">Welcome, you are logged in!</p>
  <ng-template #notLoggedIn>
    <p>Please log in to continue.</p>
  </ng-template>
</div>
```

* **Explanation**:
  * If `isLoggedIn` is `true`, the welcome message is shown.
  * If `isLoggedIn` is `false`, the `<ng-template>` with the `#notLoggedIn` reference is rendered instead.
  * The `else` clause requires an `<ng-template>` to define the alternative content.

### 2. `*ngFor` Directive

* The `*ngFor` directive iterates over a collection (e.g., an array) and renders a template for each item.
* It is ideal for displaying lists, tables, or any repeated UI elements based on data.

#### Syntax

```html
<div *ngFor="let item of items">{{ item }}</div>
```

* `items`: The collection (e.g., array) to iterate over.
* `item`: A local variable representing the current item in each iteration.
* The `*ngFor` directive repeats the host element for each item in the collection.

#### Example: Using `*ngFor`

Let’s create a component that displays a list of tasks.

```typescript
// Component (task-list.component.ts)
import { Component } from '@angular/core';

@Component({
  selector: 'app-task-list',
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.css'
})
export class TaskListComponent {
  tasks = ['Write code', 'Test app', 'Deploy to production'];

  addTask(newTask: string) {
    if (newTask) {
      this.tasks.push(newTask);
    }
  }
}
```

```html
<!-- Template (task-list.component.html) -->
<div>
  <input #taskInput placeholder="Add a new task" (keyup.enter)="addTask(taskInput.value); taskInput.value=''">
  <ul>
    <li *ngFor="let task of tasks; let i = index">
      {{ i + 1 }}. {{ task }}
    </li>
  </ul>
</div>
```

```css
/* Styles (task-list.component.css) */
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
```

* **Explanation**:
  * The `*ngFor` directive iterates over the `tasks` array, rendering an `<li>` for each task.
  * The `let i = index` assigns the current iteration’s index to `i`, used to display a numbered list.
  * The input field allows adding new tasks, which updates the `tasks` array and triggers re-rendering of the list.

#### `*ngFor` Features

* **Index**: Use `let i = index` to access the loop index (0-based).
* **TrackBy**: Improves performance for large lists by tracking items with a unique identifier, reducing DOM updates.

```typescript
// Component (task-list.component.ts)
trackByTask(index: number, task: string): string {
  return task; // Use task as a unique identifier
}
```

```html
<!-- Template (task-list.component.html) -->
<li *ngFor="let task of tasks; trackBy: trackByTask">{{ task }}</li>
```

* **Explanation**:
  * The `trackBy` function helps Angular identify which items have changed, added, or removed, optimizing rendering for large datasets.

### Combining `*ngIf` and `*ngFor`

You can combine `*ngIf` and `*ngFor` for conditional rendering of lists.

```html
<!-- Template (task-list.component.html) -->
<div>
  <input #taskInput placeholder="Add a new task" (keyup.enter)="addTask(taskInput.value); taskInput.value=''">
  <p *ngIf="tasks.length === 0">No tasks available.</p>
  <ul *ngIf="tasks.length > 0">
    <li *ngFor="let task of tasks; let i = index">
      {{ i + 1 }}. {{ task }}
    </li>
  </ul>
</div>
```

* **Explanation**:
  * If `tasks` is empty, a "No tasks available" message is shown using `*ngIf`.
  * If `tasks` has items, the `<ul>` is rendered with `*ngIf`, and `*ngFor` generates the list items.

### Key Notes

* **Performance**:
  * `*ngIf` removes elements from the DOM, unlike CSS `display: none`, which keeps them in memory.
  * Use `trackBy` with `*ngFor` for large lists to minimize DOM manipulation.
* **Syntax**:
  * The asterisk (`*`) indicates a structural directive, which Angular expands into an `<ng-template>` internally.
* **Best Practices**:
  * Avoid complex logic in templates; move it to the component.
  * Use `*ngIf` for conditional rendering and `*ngFor` for lists to keep templates clean and maintainable.

### Directives Demo

* Demo: Combining `*ngIf` and `*ngFor`
  * Create a component to demonstrate both directives together, showing a dynamic task list with conditional messages.
  * **Files**:
    * `_10_Angular/my-app/src/app/task-manager/task-manager.css`
    * `_10_Angular/my-app/src/app/task-manager/task-manager.html`
    * `_10_Angular/my-app/src/app/task-manager/task-manager.ts`
  * **Steps**:
    1. Generate the component:
       ```bash
       ng generate component task-manager
       ```
    2. Implement the component with a task list, an input to add tasks, and conditional messages (e.g., "No tasks" when empty).
    3. Use `*ngFor` to render the task list and `*ngIf` to show/hide messages based on the list’s length.
    4. Add styles for a clean UI.
    5. Run `ng serve` and demonstrate adding tasks and toggling the list.

> **Class Note**: Walk through the demo live, showing how `*ngIf` toggles messages and `*ngFor` updates the list dynamically. Encourage students to experiment with adding/removing tasks.

## Binding and Directives Demo

* Demo 1: All binding types
  * [_10_Angular/my-app/src/app/binding-demo/binding-demo.css](../_10_Angular/my-app/src/app/binding-demo/binding-demo.css)
  * [_10_Angular/my-app/src/app/binding-demo/binding-demo.html](../_10_Angular/my-app/src/app/binding-demo/binding-demo.html)
  * [_10_Angular/my-app/src/app/binding-demo/binding-demo.ts](../_10_Angular/my-app/src/app/binding-demo/binding-demo.ts)

* Demo 2: Form demo
  * [_10_Angular/my-app/src/app/data-form-demo/data-form-demo.css](../_10_Angular/my-app/src/app/data-form-demo/data-form-demo.css)
  * [_10_Angular/my-app/src/app/data-form-demo/data-form-demo.html](../_10_Angular/my-app/src/app/data-form-demo/data-form-demo.html)
  * [_10_Angular/my-app/src/app/data-form-demo/data-form-demo.ts](../_10_Angular/my-app/src/app/data-form-demo/data-form-demo.ts)

* Demo 3: `*ngIf` and `*ngFor` directives
  * [_10_Angular/my-app/src/app/task-manager/task-manager.css](../_10_Angular/my-app/src/app/task-manager/task-manager.css)
  * [_10_Angular/my-app/src/app/task-manager/task-manager.html](../_10_Angular/my-app/src/app/task-manager/task-manager.html)
  * [_10_Angular/my-app/src/app/task-manager/task-manager.ts](../_10_Angular/my-app/src/app/task-manager/task-manager.ts)