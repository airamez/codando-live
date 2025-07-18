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

| **Location**       | **File/Directory**  | **Description**                                                                     |
| ------------------ | ------------------- | ----------------------------------------------------------------------------------- |
| `/my-app/`         | `angular.json`      | Workspace configuration file defining project settings, build, and test options.    |
| `/my-app/`         | `package.json`      | Defines project metadata, dependencies, and scripts for npm.                        |
| `/my-app/`         | `package-lock.json` | Locks exact versions of dependencies for consistent installs.                       |
| `/my-app/`         | `tsconfig.json`     | Root TypeScript configuration for the workspace, including compiler options.        |
| `/my-app/`         | `README.md`         | Introductory documentation with basic instructions for the project.                 |
| `/my-app/`         | `.gitignore`        | Specifies files and directories Git should ignore.                                  |
| `/my-app/`         | `.editorconfig`     | Standardizes code formatting across editors for consistent coding styl.             |
| `/my-app/`         | `node_modules/`     | Contains all npm dependencies installed for the project.                            |
| `/my-app/src/`     | `src/`              | Root directory for application source code, assets, and configurations.             |
| `/my-app/src/`     | `index.html`        | Main HTML file served by the app, with `<app-root>` as the root component selector. |
| `/my-app/src/`     | `main.ts`           | Entry point for the application, bootstrapping the standalone `AppComponent`.       |
| `/my-app/src/`     | `styles.css`        | Global styles applied across the entire application.                                |
| `/my-app/src/app/` | `app/`              | Contains the main application logic, including components and services              |
| `/my-app/src/app/` | `app.ts`            | Root component (standalone by default) defining the app's entry point.              |
| `/my-app/src/app/` | `app.html`          | Template for the root component, defining its HTML structure.                       |
| `/my-app/src/app/` | `app.css`           | Styles for the root component (CSS by default, based on CLI prompt).                |
| `/my-app/src/app/` | `app.spec.ts`       | Unit test file for the root component.                                              |
| `/my-app/src/app/` | `app.routes.ts`     | Defines application routes (included if routing is enabled during `ng new`).        |

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

## Angular Structural Directives

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

### `*ngIf` Directive

* The `*ngIf` directive conditionally adds or removes an element and its children from the DOM based on a boolean expression.
* Ideal for showing/hiding content dynamically, such as user authentication states or toggling UI elements.

* Syntax

  ```html
  <div *ngIf="condition">Content to show if condition is true</div>
  ```

  * `condition`: A boolean expression from the component.
  * If `true`, the element is rendered; if `false`, it’s removed from the DOM.

* Example: Component to show a login status message.

  ```typescript
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
  <div>
    <button (click)="toggleLogin()">{{ isLoggedIn ? 'Log Out' : 'Log In' }}</button>
    <p *ngIf="isLoggedIn">Welcome, you are logged in!</p>
  </div>
  ```

  ```css
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

### `*ngIf` with `else`

Use `else` to display alternative content when the condition is `false`.

```html
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

### `*ngFor` Directive

* The `*ngFor` directive iterates over a collection (e.g., an array) to render a template for each item.
* Perfect for displaying lists, tables, or any repeated UI elements.

* Syntax

```html
<div *ngFor="let item of items">{{ item }}</div>
```

* `items`: The collection to iterate over.
* `item`: A local variable for each item in the iteration.

* Example: Task List. Create a component to display and add tasks.

* Demo: Task List
  * [_10_Angular/my-app/src/app/task-list/task-list.css](../_10_Angular/my-app/src/app/task-list/task-list.css)
  * [_10_Angular/my-app/src/app/task-list/task-list.html](../_10_Angular/my-app/src/app/task-list/task-list.html)
  * [_10_Angular/my-app/src/app/task-list/task-list.ts](../_10_Angular/my-app/src/app/task-list/task-list.ts)
  * **Explanation**:
    * `*ngFor` renders an `<li>` for each task in the `tasks` array.
    * `let i = index` provides a numbered list.
    * `*ngIf` shows a message when the list is empty.

### Modern Control Flow: `@if` and `@for`

* Angular 17 introduces [`@if`](https://blog.angular-university.io/angular-if/) and [`@for`](https://blog.angular-university.io/angular-for/) as built-in control flow syntax, offering a concise alternative to `*ngIf` and `*ngFor`.
* No `CommonModule` import is needed, and they integrate directly into templates.

#### `@if`

* Conditionally renders content without `<ng-template>`.

  ```html
  @if (condition) {
    <div>Content to show if condition is true.</div>
  } @else {
    <div>Content to show if condition is false.</div>
  }
  ```

* Example: Login Status with `@if`

  ```typescript
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

#### `@for`

* Iterates over collections with a mandatory `track` expression for performance.

  ```html
  @for (item of items; track item) {
    <div>{{ item }}</div>
  } @empty {
    <div>No items available.</div>
  }
  ```

  * Example: Task List with `@for`
    * [user-profile.html](./my-app/src/app/task-list-modern/task-list-modern.html)
    * [user-profile.css](./my-app/src/app/task-list-modern/task-list-modern.css)
    * [user-profile.ts](./my-app/src/app/task-list-modern/task-list-modern.ts)

  * **Explanation**:
    * `@for` iterates over `tasks`, with `track task` optimizing updates.
    * `@empty` replaces the need for a separate `*ngIf` check.
    * No `CommonModule` import is required.

* Demo: `@if` and `@for` Modern Task List
  * [_10_Angular/dynamic-content-app/src/app/task-list-modern/task-list-modern.css](../_10_Angular/dynamic-content-app/src/app/task-list-modern/task-list-modern.css)
  * [_10_Angular/dynamic-content-app/src/app/task-list-modern/task-list-modern.html](../_10_Angular/dynamic-content-app/src/app/task-list-modern/task-list-modern.html)
  * [_10_Angular/dynamic-content-app/src/app/task-list-modern/task-list-modern.ts](../_10_Angular/dynamic-content-app/src/app/task-list-modern/task-list-modern.ts)

## ng-container

`ng-container` is a logical container in Angular that allows you to group elements or apply structural directives without adding extra DOM elements. It’s a lightweight utility for managing template structure, especially useful when you need to apply directives like `*ngIf` or `*ngFor` but don’t want to wrap content in a `<div>` or other HTML element that affects styling or layout.

* Key Characteristics
  * **No DOM Output**: `ng-container` is a template-only construct and does not render as an HTML element in the DOM.
  * **Use Cases**: Apply structural directives, group elements for conditional rendering, or manage multiple directives without cluttering the DOM.
  * **Common Scenarios**: Combine with `*ngIf`, `*ngFor` to keep templates clean.

* Syntax

  ```html
  <ng-container *ngDirective>
    <!-- Content here -->
  </ng-container>
  ```

* Example: Conditional Grouping with `ng-container`
  * Component to display a user profile conditionally without adding extra DOM elements.

* Example
  * [user-profile.html](./my-app/src/app/user-profile/user-profile.html)
  * [user-profile.css](./my-app/src/app/user-profile/user-profile.css)
  * [user-profile.ts](./my-app/src/app/user-profile/user-profile.ts)

* Explanation
  * The `<ng-container *ngIf="user.isPremium">` groups two `<p>` elements without adding a wrapper `<div>` to the DOM.
  * If `user.isPremium` is `true`, both premium messages are shown; if `false`, only the standard user message appears.
  * Inspecting the DOM shows no extra elements from `ng-container`, keeping the structure clean.
* Demo
  * [_10_Angular/my-app/src/app/user-profile/user-profile.css](../_10_Angular/src/app/user-profile/user-profile.css)
  * [_10_Angular/src/app/user-profile/user-profile.html](../_10_Angular/src/app/user-profile/user-profile.html)
  * [_10_Angular/src/app/user-profile/user-profile.ts](../_10_Angular/src/app/user-profile/user-profile.ts)

## ViewChild

* [`@ViewChild`](https://angular.dev/api/core/ViewChild) is an Angular decorator that allows a component to access and interact with a child element, directive, or component in its template.
* It’s ideal for dynamic DOM manipulation, calling methods on child components, or accessing directive properties.

* Key Features
  * **Purpose**: Query a single child element, directive, or component.
  * **Selector**: Use a component class, element reference, or template reference variable (e.g., `#myRef`).
  * **Static Option**: `{ static: true }` for queries in `ngOnInit`, `{ static: false }` for dynamic queries in `ngAfterViewInit`.
  * **Use Cases**: Focus inputs, manipulate child component state, interact with third-party libraries, or control DOM properties.

* Syntax

  ```typescript
  @ViewChild(selector, { static: boolean }) propertyName: Type;
  ```

  * **`selector`**: Specifies what to query:
    * A component class (e.g., `ChildComponent`).
    * A string (e.g., `'#myElement'`) for a template reference variable.
    * A directive (e.g., `NgModel`).
  * **`{ static: boolean }`**: Optional configuration:
    * `static: true`: Query resolves before view initialization (`ngOnInit`), for always-present elements.
    * `static: false`: Query resolves after view initialization (`ngAfterViewInit`), for conditional or dynamic elements.
    * Defaults to `false` if omitted.
  * **`propertyName`**: The parent component’s property storing the child reference.
  * **`Type`**: TypeScript type of the child (e.g., `ChildComponent`, `ElementRef`, `NgModel`) for type safety.

* Example
  * [text-editor.html](./my-app/src/app/text-editor/text-editor.html)
  * [text-editor.css](./my-app/src/app/text-editor/text-editor.css)
  * [text-editor.ts](./my-app/src/app/text-editor/text-editor.ts)

## Component Lifecycle

* The [Angular component lifecycle](https://v17.angular.io/guide/lifecycle-hooks) consists of a series of stages that a component goes through from creation to destruction.
* Angular provides **lifecycle hooks**—methods that allow developers to tap into these stages and execute custom logic.
* Understanding the lifecycle is crucial for managing component initialization, updates, and cleanup effectively.

### Key Lifecycle Hooks

* Each lifecycle hook corresponds to a specific phase in a component’s lifecycle.
* Below is a comprehensive list of the primary hooks, their purposes, and common use cases.

1. **`ngOnChanges`**
   * **Purpose**: Called when Angular detects changes to **input properties** of a component or directive (before `ngOnInit` and whenever inputs change).
   * **When**: Invoked before the first rendering and after each change to input-bound properties.
   * **Use Cases**:
     * Respond to changes in `@Input` properties.
     * Perform calculations or updates based on new input values.
   * **Parameters**: Receives a `SimpleChanges` object containing current and previous values of changed inputs.
   * **Example**:
     ```typescript
     ngOnChanges(changes: SimpleChanges) {
       let logMessage = 'ngOnChanges: Changes detected\n';
       for (const propName of Object.keys(changes)) {
         const change = changes[propName];
         const from = JSON.stringify(change.previousValue);
         const to = JSON.stringify(change.currentValue);
         logMessage += `  ${propName}: Previous = ${from}, Current = ${to}\n`;
       }
       this.logs.push(logMessage);
       console.log(logMessage.trim());
     }
     ```

2. **`ngOnInit`**
   * **Purpose**: Called **once** after the component’s inputs are set and the component is initialized.
   * **When**: After the first `ngOnChanges` and before the view is rendered.
   * **Use Cases**:
     * Initialize component data, fetch initial data from services, or set up subscriptions.
     * Perform setup that depends on input properties or component state.
   * **Example**:

     ```typescript
     ngOnInit() {
       this.loadData();
     }
     ```

3. **`ngDoCheck`**
   * **Purpose**: Called during every **change detection cycle**, allowing custom change detection logic.
   * **When**: After `ngOnChanges` and `ngOnInit`, and on every change detection run.
   * **Use Cases**:
     * Implement custom change detection for complex objects or non-input properties.
     * Rarely used due to performance implications; prefer Angular’s default change detection or `ngOnChanges`.
   * **Example**:

     ```typescript
     ngDoCheck() {
       if (this.customConditionChanged()) {
         this.updateComponent();
       }
     }
     ```

4. **`ngAfterContentInit`**
   * **Purpose**: Called **once** after Angular finishes projecting external content into the component’s view (via `<ng-content>`).
   * **When**: After `ngDoCheck` and content projection is complete.
   * **Use Cases**:
     * Initialize logic that depends on projected content.
     * Access queried content using `@ContentChild` or `@ContentChildren`.
   * **Example**:

     ```typescript
     ngAfterContentInit() {
       console.log('Projected content initialized');
     }
     ```

5. **`ngAfterContentChecked`**
   * **Purpose**: Called after every change detection cycle for projected content.
   * **When**: After `ngAfterContentInit` and during every change detection run.
   * **Use Cases**:
     * Update state or perform checks on projected content after changes.
   * **Example**:

     ```typescript
     ngAfterContentChecked() {
       this.validateContent();
     }
     ```

6. **`ngAfterViewInit`**
   * **Purpose**: Called **once** after Angular fully initializes the component’s view and all child views.
   * **When**: After `ngAfterContentChecked` and view initialization.
   * **Use Cases**:
     * Access or manipulate DOM elements or child components via `@ViewChild` or `@ViewChildren`.
     * Perform initialization that requires the view to be fully rendered.
   * **Example**:

     ```typescript
     ngAfterViewInit() {
       this.textArea.nativeElement.focus();
     }
     ```

7. **`ngAfterViewChecked`**
   * **Purpose**: Called after every change detection cycle for the component’s view and child views.
   * **When**: After `ngAfterViewInit` and during every change detection run.
   * **Use Cases**:
     * Perform checks or updates after the view and child views are updated.
   * **Example**:

     ```typescript
     ngAfterViewChecked() {
       this.checkViewState();
     }
     ```

8. **`ngOnDestroy`**
   * **Purpose**: Called **once** just before Angular destroys the component or directive.
   * **When**: When the component is removed from the DOM.
   * **Use Cases**:
     * Clean up subscriptions, timers, or event listeners to prevent memory leaks.
     * Perform final logging or state persistence.
   * **Example**:

     ```typescript
     ngOnDestroy() {
       this.subscription.unsubscribe();
     }
     ```

### Lifecycle Sequence

The lifecycle hooks are executed in the following order during a component’s lifecycle:

1. `ngOnChanges` (if inputs change)
2. `ngOnInit`
3. `ngDoCheck`
4. `ngAfterContentInit`
5. `ngAfterContentChecked`
6. `ngAfterViewInit`
7. `ngAfterViewChecked`
8. `ngOnChanges` (if inputs change again), `ngDoCheck`, `ngAfterContentChecked`, `ngAfterViewChecked` (repeated for each change detection cycle)
9. `ngOnDestroy` (when component is destroyed)

## Nested Components

* In Angular, **Nested components** refer to scenarios where one component (the parent) contains or depends on another component (the child) within its template.
* This parent-child relationship enables **component composition**, allowing reusable, modular, and maintainable UI structures.
* Nested components communicate through **input properties** (`@Input`), **output events** (`@Output`), or **services**, facilitating data flow and interaction.

### Key Concepts of Nested Components

* **Parent-Child Relationship**: A parent component includes a child component in its template using the child’s selector (e.g., `<child><child>`).
* **Component Communication**:
  * **Inputs**: Pass data from parent to child using `@Input` bindings.
  * **Outputs**: Emit events from child to parent using `@Output` and `EventEmitter`.
  * **ViewChild/ContentChild**: Access child component instances for direct interaction.
* **Lifecycle Interaction**: Child components have their own lifecycle hooks, which are triggered within the context of the parent’s lifecycle.
* Understanding Nested components is essential for building complex UIs with reusable, encapsulated functionality.

### Mechanisms for Nested Components

1. **Using `@Input` for Parent-to-Child Communication**
   * **Purpose**: Allows a parent component to pass data to a child component’s input properties.
   * **When**: Used when the child needs data or configuration from the parent.
   * **Use Cases**:
     * Displaying data provided by the parent (e.g., a list of items).
     * Configuring child component behavior (e.g., setting a default color).
   * **Example**:

    ```typescript
     // Child Component
     @Component({
       selector: 'app-child',
       template: '<p>Received: {{ data }}</p>'
     })
     export class ChildComponent {
       @Input() data: string = '';
     }

     // Parent Template
     <app-child [data]="parentData"></app-child>
     ```

2. **Using `@Output` for Child-to-Parent Communication**
   * **Purpose**: Enables a child component to emit events to notify the parent of changes or actions.
   * **When**: Triggered when the child performs an action (e.g., button click) that the parent needs to handle.
   * **Use Cases**:
     * Notifying the parent of user interactions (e.g., form submission).
     * Sending updated data back to the parent.

   * **Example**:

     ```typescript
     // Child Component
     @Component({
       selector: 'app-child',
       template: '<button (click)="emitEvent()">Click</button>'
     })
     export class ChildComponent {
       @Output() action = new EventEmitter<string>();
       emitEvent() {
         this.action.emit('Child clicked');
       }
     }

     // Parent Template
     <app-child (action)="handleChildEvent($event)"></app-child>
     ```

3. **Using `@ViewChild` to Access Child Components**
   * **Purpose**: Allows the parent to directly access and interact with a child component’s properties or methods.
   * **When**: After the view is initialized (`ngAfterViewInit`), when direct manipulation of the child is needed.
   * **Use Cases**:
     * Calling a child’s method (e.g., reset a form).
     * Reading or updating a child’s state programmatically.
   * **Example**:

     ```typescript
     // Parent Component
     @Component({
       selector: 'app-parent',
       template: '<child #childRef></child><button (click)="callChild()">Call Child</button>'
     })
     export class ParentComponent {
       @ViewChild('childRef') child!: ChildComponent;
       callChild() {
         this.child.someMethod();
       }
     }
     ```

4. **Using `<ng-content>` for Content Projection**
   * **Purpose**: Allows the parent to project content (HTML or components) into the child’s template.
   * **When**: When the child component acts as a container or wrapper for custom content.
   * **Use Cases**:
     * Creating reusable layouts (e.g., modals) with customizable content.
     * Embedding dynamic content in a child component.
   * **Example**:

     ```typescript
     // Child Component
     @Component({
       selector: 'child',
       template: '<div class="container"><ng-content></ng-content></div>'
     })
     export class ChildComponent {}

     // Parent Template
     <child><p>Projected content</p></child>
     ```

### Nested Component Lifecycle Interaction

* **Child Lifecycle**: Each child component has its own lifecycle hooks (`ngOnInit`, `ngAfterViewInit`, etc.), which run independently but are triggered within the parent’s lifecycle.
* **Order**:
  * Parent’s `ngOnInit` runs before child’s `ngOnInit`.
  * Child’s view initialization (`ngAfterViewInit`) completes before the parent’s `ngAfterViewInit`.
  * When the parent is destroyed, all children are destroyed, triggering their `ngOnDestroy` before the parent’s.
* **Use Case**: Use child lifecycle hooks to initialize child-specific data or clean up child resources, while coordinating with the parent’s lifecycle for overall control.

* Example: Parent-Child Component Demo
  * [color-selector.html](./my-app/src/app/color-selector/color-selector.html)
  * [color-selector.css](./my-app/src/app/color-selector/color-selector.css)
  * [color-selector.ts](./my-app/src/app/color-selector/color-selector.ts)
  * [parent-editor.html](./my-app/src/app/parent-editor/parent-editor.html)
  * [parent-editor.css](./my-app/src/app/parent-editor/parent-editor.css)
  * [parent-editor.ts](./my-app/src/app/parent-editor/parent-editor.ts)

## Pipes in Angular

* [Pipes](https://angular.dev/guide/templates/pipes) are a powerful feature for transforming and formatting data directly in templates.
* They allow developers to display data in a user-friendly way without modifying the underlying data source.
* Pipes are commonly used for tasks like formatting dates, numbers, or strings, and can be chained or customized to meet specific needs.
* Key Concepts of Pipes
  * **Purpose**: Pipes transform data in templates for display purposes, keeping the original data unchanged.
  * **Syntax**: In templates, pipes are applied using the `|` operator, e.g., `{{ value | pipeName }}`.
  * **Types**:
    * **Built-in Pipes**: Provided by Angular for common transformations (e.g., `date`, `uppercase`, `currency`).
    * **Custom Pipes**: Developer-defined pipes for specific transformation logic.
  * **Chaining**: Multiple pipes can be applied sequentially, e.g., `{{ value | pipe1 | pipe2 }}`.
  * **Use Cases**:
    * Formatting data (e.g., dates, currencies, percentages).
    * Filtering or sorting lists.
    * Custom transformations (e.g., truncating text, formatting phone numbers).

### Bash Example

```bash
find ./src -name "*.ts" | sed 's|.*/||' | sort
```

* `find ./src -name "*.ts"`: Recursively finds all .ts files starting from the ./src
* `sed 's|.*/||'`: Uses sed (stream editor) to replace the path prefix (matched by .*/, meaning any characters followed by a /) with nothing, leaving just the file name
* `sort`: Sorts the resulting file names alphabetically.

### Built-in Pipes

Angular provides a set of built-in pipes in the `@angular/common` package.

| Pipe Name      | Description                                                                |
| -------------- | -------------------------------------------------------------------------- |
| AsyncPipe      | Reads the value from a Promise or RxJS Observable.                         |
| CurrencyPipe   | Transforms a number to a currency string, formatted according to locale.   |
| DatePipe       | Formats a Date value according to locale rules.                            |
| DecimalPipe    | Transforms a number into a decimal string, formatted according to locale.  |
| I18nPluralPipe | Maps a value to a string that pluralizes the value according to locale.    |
| I18nSelectPipe | Maps a key to a custom selector that returns a desired value.              |
| JsonPipe       | Transforms an object to a JSON string via JSON.stringify, for debugging.   |
| KeyValuePipe   | Transforms Object or Map into an array of key-value pairs.                 |
| LowerCasePipe  | Transforms text to all lowercase.                                          |
| PercentPipe    | Transforms a number to a percentage string, formatted according to locale. |
| SlicePipe      | Creates a new Array or String containing a subset of elements.             |
| TitleCasePipe  | Transforms text to title case.                                             |
| UpperCasePipe  | Transforms text to all uppercase.                                          |

___

>Note: Which `pipe` has to be imported from `@angular/common`

```typescript
import { CurrencyPipe, DatePipe, TitleCasePipe } from '@angular/common';
```

#### LowerCasePipe

* **Purpose**: Converts a string to lowercase.
* **Usage**: `{{ text | lowercase }}`
* **Example**:

  ```html
  {{ 'Angular' | lowercase }} <!-- Output: angular -->
  ```

#### UpperCasePipe

* **Purpose**: Converts a string to uppercase.
* **Usage**: `{{ text | uppercase }}`
* **Example**:

  ```html
  {{ 'Angular' | uppercase }} <!-- Output: ANGULAR -->
  ```

#### TitleCasePipe

* **Purpose**: Converts a string to title case (capitalizes the first letter of each word).
* **Usage**: `{{ text | titlecase }}`
* **Example**:

  ```html
  {{ 'angular framework' | titlecase }} <!-- Output: Angular Framework -->
  ```

#### CurrencyPipe

* **Purpose**: Formats a number as currency with a currency code and symbol.
* **Usage**: `{{ number | currency:'code':'symbol':'digitsInfo' }}`
* **Example**:

  ```html
  {{ 1234.56 | currency:'USD' }} <!-- Output: $1,234.56 -->
  {{ 1234.56 | currency:'EUR':'symbol' }} <!-- Output: €1,234.56 -->
  ```

#### DatePipe

* **Purpose**: Formats a date value into a string based on a specified format or locale.
* **Usage**: `{{ dateValue | date:'format' }}`
* **Example**:

  ```html
  {{ today | date:'fullDate' }} <!-- Output: Saturday, July 12, 2025 -->
  {{ today | date:'short' }} <!-- Output: 7/12/25, 10:23 AM -->
  ```

#### DecimalPipe

* **Purpose**: Formats a number into a decimal string, with customizable digits.
* **Usage**: `{{ number | number:'digitsInfo' }}`
* **Example**:

  ```html
  {{ 1234.5678 | number:'1.2-2' }} <!-- Output: 1,234.57 -->
  {{ 1234 | number:'1.0-0' }} <!-- Output: 1,234 -->
  ```

#### PercentPipe

* **Purpose**: Formats a number as a percentage.
* **Usage**: `{{ number | percent:'digitsInfo' }}`
* **Example**:

  ```html
  {{ 0.75 | percent }} <!-- Output: 75% -->
  {{ 0.75 | percent:'1.1-1' }} <!-- Output: 75.0% -->
  ```

#### I18nPluralPipe

* **Purpose**: Maps a numeric value to a string based on pluralization rules.
* **Usage**: `{{ value | i18nPlural:mapping }}`
* **Example**:

  ```html
  {{ count | i18nPlural: pluralMap }}
  <!-- Component -->
  count = 2;
  pluralMap = { '=0': 'No items', '=1': 'One item', 'other': '# items' };
  <!-- Output: 2 items -->
  ```

#### I18nSelectPipe

* **Purpose**: Maps a value to a string based on a predefined key-value mapping.
* **Usage**: `{{ value | i18nSelect:mapping }}`
* **Example**:

  ```html
  {{ status | i18nSelect: statusMap }}
  <!-- Component -->
  status = 'active';
  statusMap = { active: 'User is active', inactive: 'User is inactive', other: 'Unknown' };
  <!-- Output: User is active -->
  ```

#### JsonPipe

* **Purpose**: Converts an object to a JSON string for debugging or display.
* **Usage**: `{{ object | json }}`
* **Example**:

  ```html
  {{ { name: 'John', age: 30 } | json }}
  <!-- Output: { "name": "John", "age": 30 } -->
  ```

#### KeyValuePipe

* **Purpose**: Transforms an Object or Map into an array of key-value pairs.
* **Usage**: `{{ object | keyvalue }}`
* **Example**:

  ```html
  <div *ngFor="let item of user | keyvalue">
    {{ item.key }}: {{ item.value }}
  </div>
  <!-- Component -->
  user = { name: 'John', age: 30 };
  <!-- Output:
    name: John
    age: 30 -->
  ```

#### SlicePipe

* **Purpose**: Extracts a subset of an array or string.
* **Usage**: `{{ array | slice:start:end }}`
* **Example**:

  ```html
  {{ [1, 2, 3, 4, 5] | slice:1:4 }} <!-- Output: [2, 3, 4] -->
  {{ 'Angular' | slice:0:3 }} <!-- Output: Ang -->
  ```

### Creating Custom Pipes

Custom pipes are used when built-in pipes don’t meet specific requirements. They are simple to create and integrate into Angular applications.

* **Purpose**: Implement custom transformation logic for unique formatting or data manipulation.
* **When**: When you need reusable transformations not covered by built-in pipes (e.g., formatting phone numbers, truncating text).
* **How It Works**:
  * Create a class implementing the `PipeTransform` interface.
  * Use the `@Pipe` decorator with `standalone: true` to define the pipe’s metadata.
  * Import the pipe directly in standalone components that use it.

#### Example: Custom Pipe for Truncating Text

* This example demonstrates a custom pipe (`TruncatePipe`) that shortens a string to a specified length and appends an ellipsis if truncated.
* The pipe is used in a standalone component to display a list of descriptions, ensuring they don’t exceed a certain length.

##### Step 1: Create the Custom Pipe

```typescript
import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'truncate',
  standalone: true
})
export class TruncatePipe implements PipeTransform {
  transform(value: string, limit: number = 20, ellipsis: string = '...'): string {
    if (!value) return '';
    return value.length > limit ? value.substring(0, limit) + ellipsis : value;
  }
}
```

* **Parameters**:
  * `value`: The input string to truncate.
  * `limit`: Maximum length (default: 20).
  * `ellipsis`: Suffix to append if truncated (default: '...').
* **Logic**: If the string exceeds the limit, it’s truncated and appended with the ellipsis; otherwise, it’s returned unchanged.

##### Step 2: Component Using the Pipe

The standalone component displays a list of product descriptions, applying the `truncate` pipe to keep them concise.

```typescript
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TruncatePipe } from './truncate.pipe';

@Component({
  selector: 'product-list',
  standalone: true,
  imports: [CommonModule, TruncatePipe],
  template: `
    <h1>Product List</h1>
    <ul>
      <li *ngFor="let product of products">
        {{ product.name }}: {{ product.description | truncate:30 }}
      </li>
    </ul>
    <h3>Example with Custom Limit</h3>
    <p>{{ sampleText | truncate:15:'***' }}</p>
  `
})
export class ProductListComponent {
  today: Date = new Date();
  sampleText: string = 'This is a long description that needs truncation for display purposes.';
  products = [
    { name: 'Laptop', description: 'A high-performance laptop for professionals and gamers.' },
    { name: 'Phone', description: 'A sleek smartphone with advanced camera features.' },
    { name: 'Tablet', description: 'A lightweight tablet for productivity and entertainment.' }
  ];
}
```

> **Note**: The `CommonModule` is imported to provide directives like `*ngFor`, and `TruncatePipe` is imported to use the custom pipe.

* Files
  * [truncate.pipe.ts](./my-app/src/app/truncate.pipe.ts)
  * [product-list.ts](./my-app/src/app/product-list.ts)

##### How It Works

* The `TruncatePipe` is applied in the template using `| truncate:30` or `| truncate:15:'...'`.
* For each product description, the pipe checks if the string exceeds the specified limit (e.g., 30 characters).
* If truncated, it appends the ellipsis; otherwise, it displays the full string.
* The pipe is reusable across the application and can accept custom parameters for flexibility.

### Chaining Pipes

Pipes can be chained to apply multiple transformations in sequence. The output of one pipe becomes the input for the next.

* **Example**:

  ```html
  {{ 'angular framework' | uppercase | truncate:10 }} <!-- Output: ANGULAR FR... -->
  ```

> **Explanation**: The string is first converted to uppercase (`ANGULAR FRAMEWORK`), then truncated to 10 characters with an ellipsis.

### Best Practices for Pipes

* **Use Built-in Pipes First**: Leverage Angular’s built-in pipes for common tasks to avoid reinventing the wheel.
* **Keep Pipes Simple**: Pipes should focus on transformation logic, not complex business logic.
* **Make Pipes Reusable**: Design custom pipes with parameters for flexibility (e.g., configurable limits).
* **Document Parameters**: Clearly document pipe parameters for team collaboration.

### When to Use Pipes

* **Built-in Pipes**: For quick formatting of dates, numbers, strings, or arrays.
* **Custom Pipes**: For specific transformations not covered by built-in pipes.
* **Alternatives**: If transformation logic is complex or requires side effects, consider using component methods or services instead.

### Example: Combining Built-in and Custom Pipes

* This example shows a template using both the `date` pipe and the `truncate` pipe:

  ```html
  <p>Today: {{ today | date:'medium' | truncate:20 }}</p>
  <!-- Output: Jul 12, 2025, 10:01... -->
  ```

  * The `date` pipe formats the date, and the `truncate` pipe shortens the result to 20 characters.

## Routing and Navigation in Angular

* Angular's routing system is a powerful feature that enables developers to build **Single Page Applications (SPAs)** with multiple views, allowing seamless navigation without full page reloads.
* The `@angular/router` package provides a robust toolkit for managing client-side navigation, mapping URLs to components, and handling dynamic data through route parameters, query parameters, and more.
* Routing in Angular enhances user experience by enabling fast, fluid transitions between views while maintaining modularity and scalability in applications.
* Documentation
  * [Overview](https://v17.angular.io/guide/routing-overview)
  * [Guide](https://angular.dev/guide/routing)

### Key Components of Angular Routing

* **Routes**: Define mappings between URL paths and components.
* **RouterOutlet**: A directive (`<router-outlet>`) that acts as a placeholder where components are dynamically loaded based on the current route.
* **RouterLink**: A directive for declarative navigation in templates (e.g., `<a routerLink="/path">`).
* **Router Service**: Enables programmatic navigation using methods like `navigate()` and `navigateByUrl()`.
* **Route Guards**: Control access to routes for authentication or authorization.
* **Route Parameters and Query Parameters**: Allow dynamic data passing through URLs.

### Benefits of Angular Routing

* **Seamless User Experience**: Routing enables smooth transitions between views without reloading the entire page, mimicking native app behavior.
* **Faster Page Transitions**: Only the necessary components and data are loaded, reducing load times.
* **Modularity and Maintainability**: Routes organize the application into distinct views, making code easier to manage and scale.
* **Dynamic Content Loading**: Route parameters and query parameters allow dynamic rendering of content based on URL data.[](https://medium.com/%40jaydeepvpatil225/routing-in-angular-924066bde43)
* **Security with Route Guards**: Control access to routes, ensuring users only access authorized views.
* **Nested Routes**: Support hierarchical navigation for complex applications, such as dashboards with sub-sections.
* **Lazy Loading**: Load modules only when needed, improving performance for large applications.

### Syntax for Declaring Routes

Routes are defined as an array of `Route` objects in a separate file, typically `app.routes.ts`, and provided to the application using the `provideRouter` function in a standalone setup.

#### Basic Route Declaration

* Define routes in `src/app/app.routes.ts`:

  ```typescript
  import { Routes } from '@angular/router';
  import { Home } from './home/home';
  import { About } from './about/about';

  export const routes: Routes = [
    { path: '', component: Home }, // Default route
    { path: 'about', component: About }, // Static route
    { path: '**', redirectTo: '', pathMatch: 'full' } // Wildcard route for 404
  ];
  ```

#### Using RouterOutlet and RouterLink

* In your root component (e.g., app.html), include the `<router-outlet>` to render routed components and `<a routerLink>` for navigation:

  ```html
  <nav>
    <a routerLink="/">Home</a>
    <a routerLink="/about">About</a>
  </nav>
  <router-outlet></router-outlet>
  ```

#### Route with Parameters

* To handle dynamic data, include parameters in the path:

  ```typesecript
  { path: 'user/:id', component: UserComponent }
  ```

* Access the parameter in the component using `ActivatedRoute`

  ```typescript
  import { Component, OnInit } from '@angular/core';
  import { ActivatedRoute } from '@angular/router';

  @Component({
    selector: 'app-user',
    template: `<p>User ID: {{ userId }}</p>`
  })
  export class UserComponent implements OnInit {
    userId: string | null = null;

    constructor(private route: ActivatedRoute) {}

    ngOnInit(): void {
      this.route.paramMap.subscribe(params => {
        this.userId = params.get('id');
      });
    }
  }
  ```

### Setting Up Routing in Angular

* To use routing, you need to configure the `RouterModule` in your Angular application.
* The Angular CLI simplifies this process.

### Example 1: Basic Routing Setup

This example creates an Angular application with two components (`HomeComponent` and `AboutComponent`) and configures routing to navigate between them.

#### Step 1: Create a New Angular Project

* Command to create a new application with routing enabled:

  ```bash
  ng new my-routing-app --routing
  ```

* Command to add routing to an existing aplication

  ```bash
  ng add @angular/router
  ```

#### Step 2: Generate Components

* Create two components:

  ```bash
  ng generate component home
  ng generate component about
  ```

#### Step 3: Configure Routes

* Edit `src/app/app.routes.ts` to define the routes:

  ```typescript
  import { Routes } from '@angular/router';
  import { HomeComponent } from './home/home.component';
  import { AboutComponent } from './about/about.component';

  export const routes: Routes = [
    { path: '', component: HomeComponent }, // Default route
    { path: 'about', component: AboutComponent }, // About route
    { path: '**', redirectTo: '', pathMatch: 'full' } // Wildcard route for 404
  ];
  ```

#### Step 4: Update the App Component

* Edit `src/app/app.ts` to include `RouterLink`

  ```typescript
  import { Component } from '@angular/core';
  import { RouterOutlet, RouterLink } from '@angular/router';

  @Component({
    selector: 'app-root',
    imports: [
      RouterOutlet,
      RouterLink,
    ],
    templateUrl: './app.html',
    styleUrl: './app.css'
  })
  export class App {
    protected title = 'my-app';
  }

  ```

* Edit `src/app/app.html` to include navigation links and the router outlet:

  ```html
  <h1>Angular Routing Example</h1>
  <nav>
    <ul>
      <li><a routerLink="/">Home</a></li>
      <li><a routerLink="/about">About</a></li>
    </ul>
  </nav>
  <router-outlet></router-outlet>
  ```

#### Step 5: Run the Application

* Start the development server:

  ```bash
  ng serve
  ```

* Navigate to `http://localhost:4200` to see the app.
* Clicking "Home" or "About" will load the respective components without a full page reload.

>Note: Pay attention to the browser URL

### Example 2: Route Parameters

This example demonstrates passing and retrieving a dynamic parameter (e.g., a user ID) through the URL.

#### Step 1: Create a User Component

  Generate a new component:

  ```bash
  ng generate component user
  ```

#### Step 2: Update Routes

* Add a route with a parameter in `src/app/app.routes.ts`:

  ```typescript
  import { Routes } from '@angular/router';
  import { HomeComponent } from './home/home.component';
  import { AboutComponent } from './about/about.component';
  import { UserComponent } from './user/user.component';

  export const routes: Routes = [
    { path: '', component: HomeComponent },
    { path: 'about', component: AboutComponent },
    { path: 'user/:id', component: UserComponent }, // Route with parameter
    { path: '**', redirectTo: '', pathMatch: 'full' }
  ];
  ```

#### Step 3: Retrieve the Parameter

* Edit `src/app/user/user.ts` to access the `id` parameter:

  ```typescript
  import { Component, OnInit } from '@angular/core';
  import { ActivatedRoute } from '@angular/router';

  @Component({
    selector: 'app-user',
    imports: [],
    templateUrl: './user.html',
    styleUrl: './user.css'
  })
  export class User {
      userId: string | null = null;

      constructor(private route: ActivatedRoute) {}

      ngOnInit(): void {
        this.route.paramMap.subscribe(params => {
          this.userId = params.get('id');
        });
      }
  }
  ```

#### Step 4: Add Navigation

* Update `src/app/app.html` to include a link to the user route:

```html
<h1>Angular Routing Example</h1>
<nav>
  <ul>
    <li><a routerLink="/">Home</a></li>
    <li><a routerLink="/about">About</a></li>
    <li><a [routerLink]="['/user', '123']">User 123</a></li>
  </ul>
</nav>
<router-outlet></router-outlet>
```

#### Step 5: Test the Route

* Run `ng serve` and navigate to `/user/123`
* The `UserComponent` will display "User ID: 123"
* Try changing the ID in the URL (e.g., `/user/456`) to see dynamic updates

* For more on route parameters, check:
  * [Dynamic Route Parameters](https://angular.dev/guide/routing/router-reference#route-parameters).
  * [Code Academy](https://www.codecademy.com/learn/angular-routing-and-navigation/modules/angular-routing-and-navigation-next-steps/cheatsheet)

### Example 3: Programmatic Navigation

This example shows how to navigate programmatically using the `Router` service.

#### Step 1: Update the Home Component

* Edit `src/app/home/home.ts` to include a button that navigates to the User page passing the User ID field:

  ```html
  <h2>Home Page</h2>
  <p>Welcome to the Home page!</p>
  <div>
    <input type="text" [(ngModel)]="userId" placeholder="Enter User ID">
    <button (click)="navigateToUser()">Go to User</button>
  </div>
  ```

  ```typescript
  import { Component } from '@angular/core';
  import { Router } from '@angular/router';
  import { FormsModule } from '@angular/forms';

  @Component({
    selector: 'app-home',
    imports: [FormsModule],
    templateUrl: './home.html',
    styleUrl: './home.css'
  })
  export class Home {

    userId: string = '';
    
    constructor(private router: Router) {}

    navigateToUser() {
      if (this.userId) {
        this.router.navigate(['/user', this.userId]);
      }
    }
  }
  ```

* Mode Details
  * [Navigate to routes](https://angular.dev/guide/routing/navigate-to-routes)

## Best Practices

* **Use Descriptive Route Paths**: Choose clear, meaningful paths (e.g., `/products` instead of `/p`).
* **Handle 404s**: Always include a wildcard route (`**`) to redirect invalid URLs to a default route or a "Not Found" component.
* **Use Relative URLs**: Prefer relative URLs for maintainability, as they adapt to the application's root domain.[](https://angular.dev/guide/routing/navigate-to-routes)
* **Test Navigation**: Ensure routes work as expected, including edge cases like invalid parameters or unauthorized access.

## HTTP Requests

* HTTP (Hypertext Transfer Protocol) is the foundation of data communication on the web.
* HTTP requests allow your application to communicate with servers to fetch or send data, such as retrieving JSON from an API or submitting form data.
* In Angular, HTTP requests are typically handled using the `HttpClient` module, which provides a powerful, observable-based API for making requests.
* Understanding HTTP Requests
  * HTTP requests are how clients (like browsers) communicate with servers.
  * HTTP methods include:
    * **GET**: Retrieve data from a server (e.g., fetching a list of users).
    * **POST**: Send data to a server (e.g., submitting a form).
    * **PUT**: Update existing data on a server.
    * **DELETE**: Remove data from a server.
  * Status Codes
    * **200 OK**: Request succeeded.
    * **404 Not Found**: Resource not found.
    * **500 Internal Server Error**: Server-side error.
* Web APIs
  * A Web API (Web Application Programming Interface) is a server endpoint that provides data or services.
  * This is a public API used for tests and demos:
    * `https://jsonplaceholder.typicode.com`
* Official Angular Documentation
  * [HTTP Client Guide](https://angular.dev/guide/http)
  * [Observables Guide](https://angular.dev/guide/observables)

### Angular's HttpClient

* The [`HttpClient`](https://angular.dev/api/common/http/HttpClient) is Angular's built-in module for making HTTP requests.
* It is part of `@angular/common/http` and returns Observables by default, making it easy to handle asynchronous data streams.
* It replaces older methods like XMLHttpRequest or the Fetch API in vanilla JavaScript, offering features like interceptors, typed responses, and progress events.
* The nature of `HttpClient` requests is **Async**, leveraging RxJS Observables for handling responses.
* Setup: In standalone applications (default since Angular v17), provide `HttpClient` in `app.config.ts`:

  ```typescript
  import { ApplicationConfig } from '@angular/core';
  import { provideHttpClient } from '@angular/common/http';

  export const appConfig: ApplicationConfig = {
    providers: [provideHttpClient()]
  };
  ```

* Note: In older NgModule-based apps, import `HttpClientModule` in `app.module.ts` instead.

* Note: For GET requests, the `body` is not needed.
* GET Request

  ```typescript
  this.http.get('https://jsonplaceholder.typicode.com/users').subscribe({
    next: (data) => console.log(data),
    error: (error) => console.error('Error:', error)
  });
  ```

* Get Request with Type (RECOMMENTED)

  ```typescript
  /*
   * Using Type: Recommended
   */
  interface User {
    id: number;
    name: string;
    username: string;
    email: string;
  }

  this.http.get<User[]>('https://jsonplaceholder.typicode.com/users').subscribe({
    next: (data: User[]) => console.log(data),
    error: (error) => console.error('Error:', error)
  });
  ```

* POST Request

  ```typescript
  const data = {
    title: 'New Post',
    body: 'This is a new post.',
    userId: 1
  };
  this.http.post('https://jsonplaceholder.typicode.com/posts', data).subscribe({
    next: (response) => console.log(response),
    error: (error) => console.error('Error:', error)
  });
  ```

* Post Request with Type (RECOMMENTED)

    ```typescript
    import { HttpHeaders } from '@angular/common/http';

    interface Post {
      id?: number;
      title: string;
      body: string;
      userId: number;
    }

    const data: Post = {
      title: 'New Post',
      body: 'This is a new post.',
      userId: 1
    };

    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      // Add other headers if needed, e.g., 'Authorization': 'Bearer your-token-here'
    });

    this.http.post<Post>('https://jsonplaceholder.typicode.com/posts', data, { headers }).subscribe({
      next: (response: Post) => console.log(response),
      error: (error) => console.error('Error:', error)
    });
    ```

* Post Request with headers

  ```typescript
    import { HttpHeaders } from '@angular/common/http';

    const data = {
      title: 'New Post',
      body: 'This is a new post.',
      userId: 1
    };

    const headers = new HttpHeaders({
      'Content-Type': 'application/json',
      // Add other headers if needed, e.g., 'Authorization': 'Bearer your-token-here'
    });

    this.http.post('https://jsonplaceholder.typicode.com/posts', data, { headers }).subscribe({
      next: (response) => console.log(response),
      error: (error) => console.error('Error:', error)
    });
    ```

#### Promises vs Observables in HTTP Requests

##### Promises

* [Promises](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Promise) are a way to handle asynchronous operations in JavaScript.
* They represent a single value that will be available in the future (or an error).
* Promises are eager (execution starts immediately) and can only emit one value.

  * Definition: A Promise is an object that may produce a single value some time in the future: either a resolved value or a reason that it’s not resolved (e.g., a network error occurred). It has three states: **Pending** (initial), **Fulfilled** (success), or **Rejected** (failure).
  * In Angular: `HttpClient` can return Promises if needed by calling `.toPromise()` (deprecated in newer versions; use `lastValueFrom` from RxJS instead).
  * Example with Promise (converting Observable):

    ```typescript
    import { lastValueFrom } from 'rxjs';

    async getDataAsPromise() {
      const observable = this.http.get('https://jsonplaceholder.typicode.com/users');
      const data = await lastValueFrom(observable);
      console.log(data);
    }
    ```

##### Observables

* [Observables](https://v17.angular.io/guide/observables-in-angular) (from RxJS) are more powerful than Promises.
* An Observable is a collection of future values or events.
* It's like a stream that can push multiple items, complete, or error.
* Observers subscribe to it to receive notifications.
* States include: emitting values, completing, or erroring. Unlike Promises, Observables can be canceled and handle sequences of data.
* They can emit multiple values over time, are lazy (execution starts on subscription), and support cancellation, operators for transformation (e.g., map, filter), and multicasting.
* In Angular: `HttpClient` natively returns Observables, ideal for HTTP as they handle async data flows efficiently.
* Example with Observable:

  ```typescript
  this.http.get('https://jsonplaceholder.typicode.com/users').subscribe({
    next: (data) => console.log(data),
    error: (error) => console.error(error),
    complete: () => console.log('Request complete')
  });
  ```

* Key Differences

  | Feature | Promise | Observable |
  |---------|---------|------------|
  | Values Emitted | Single value | Multiple values over time |
  | Execution | Eager (starts immediately) | Lazy (starts on subscribe) |
  | Cancellation | Not cancellable | Cancellable (unsubscribe) |
  | Error Handling | .catch() | error callback in subscribe or catchError operator |
  | Use in Angular HTTP | Possible via conversion | Native and recommended |

* Best Practices
  * Prefer Observables in Angular for HTTP as they integrate with RxJS operators (e.g., `pipe(map(...))` for data transformation, `retry()` for error recovery).
  * Use `subscribe` sparingly; favor `async` pipe in templates: `@if (data$ | async; as data) {<div>{{ data }}</div>}`.
  * Handle errors globally with interceptors or locally with `catchError`.
  * Avoid mixing Promises and Observables; stick to Observables for consistency.
  * For concurrent requests, use `forkJoin` (similar to Promise.all):

    ```typescript
    import { forkJoin } from 'rxjs';

    forkJoin([
      this.http.get('https://jsonplaceholder.typicode.com/posts?userId=1'),
      this.http.get('https://jsonplaceholder.typicode.com/posts?userId=2'),
      this.http.get('https://jsonplaceholder.typicode.com/posts?userId=3')
    ]).subscribe(results => console.log(results));

    // With error handling

    forkJoin([
      this.http.get('https://jsonplaceholder.typicode.com/posts?userId=1'),
      this.http.get('https://jsonplaceholder.typicode.com/posts?userId=2'),
      this.http.get('https://jsonplaceholder.typicode.com/posts?userId=3')

    ]).subscribe({
      next: (results) => console.log(results),
      error: (error) => console.error('Error:', error)
    });    
    ```

##### Chaining with Observables

* Use RxJS operators for chaining, similar to Promise chaining.

  ```typescript
  import { switchMap } from 'rxjs/operators';

  this.http.get<User[]>('https://jsonplaceholder.typicode.com/users')
    .pipe(
      switchMap(users => this.http.get(`https://jsonplaceholder.typicode.com/posts?userId=${users[0].id}`))
    )
    .subscribe(posts => console.log(posts));
  ```

##### Async/Await with Observables

* Convert Observables to Promises for async/await if needed, but prefer Observables.

  ```typescript
  import { lastValueFrom } from 'rxjs';

  async function getUserAndPosts() {
    try {
      const users = await lastValueFrom(this.http.get('https://jsonplaceholder.typicode.com/users'));
      const posts = await lastValueFrom(this.http.get(`https://jsonplaceholder.typicode.com/posts?userId=${users[0].id}`));
      console.log(users, posts);
    } catch (error) {
      console.error('Error:', error);
    }
  }
  ```

### Example: Getting Posts from a user

* [user-posts/user-posts.html](./my-app/src/app/user-posts/user-posts.html)
* [user-posts/user-posts.css](./my-app/src/app/user-posts/user-posts.css)
* [user-posts/user-posts.ts](./my-app/src/app/user-posts/user-posts.ts)

```html
<div>
  <label for="userId">User ID:</label>
  <input type="number" id="userId" [(ngModel)]="userId">
  <button (click)="getPosts()">Get Posts</button>
</div>

@if (posts$ | async; as posts) {
  @if (posts.length > 0) {
    <table class="posts-table">
      <thead>
        <tr>
          <th>ID</th>
          <th>Title</th>
          <th>Body</th>
        </tr>
      </thead>
      <tbody>
        @for (post of posts; track post.id) {
          <tr>
            <td>{{ post.id }}</td>
            <td>{{ post.title }}</td>
            <td>{{ post.body }}</td>
          </tr>
        }
      </tbody>
    </table>
  } @else {
    <p>No posts found for User ID: {{ userId }}</p>
  }
}
```

```typescript
// post-list.component.ts
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, of } from 'rxjs';

interface Post {
  userId: number;
  id: number;
  title: string;
  body: string;
}

@Component({
  selector: 'user-posts',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user-posts.html',
  styleUrls: ['./user-posts.css']
})
export class UserPosts {
  userId: number | null = null;
  posts$: Observable<Post[]> | null = null;
  errorMessage: string | null = null;

  constructor(private http: HttpClient) {}

  getPosts() {
    if (this.userId === null || this.userId <= 0) {
      this.errorMessage = 'Please enter a valid User ID.';
      this.posts$ = null;
      return;
    }

    this.errorMessage = null;
    this.posts$ = this.http.get<Post[]>(`https://jsonplaceholder.typicode.com/posts?userId=${this.userId}`).pipe(
      catchError(err => {
        this.errorMessage = 'An error occurred while fetching posts.';
        return of([]);
      })
    );
  }
}
```

## Additional Content

* Reactive Forms
* Services and Dependency Injection
