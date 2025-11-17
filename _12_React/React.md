# React

* React is a powerful, open-source JavaScript library developed by Meta, designed for building dynamic, interactive user interfaces and single-page applications (SPAs).
* Built with a component-based architecture, React promotes modularity, reusability, and maintainability through encapsulated components that manage their own state.
* React 19, released in April 2024, introduces revolutionary features like Server Components, Actions, and enhanced concurrent rendering, making it the most powerful version yet for modern web development.

## Table of Contents

This documentation has been organized into focused topics for easier navigation:

1. [**Components**](./01_Components.md) - Building blocks of React applications
2. [**JSX**](./02_JSX.md) - JavaScript XML syntax and patterns
3. [**Props**](./03_Props.md) - Passing data to components
4. [**Event Handling**](./04_EventHandling.md) - Handling user interactions
5. [**Parent/Child Communication**](./05_ParentChildCommunication.md) - Data flow between components
6. [**Controlled Components**](./06_ControlledComponents.md) - Form inputs controlled by React state
7. [**Dynamic Attributes**](./07_DynamicAttributes.md) - Dynamic className and style values
8. [**Spread Props**](./08_SpreadProps.md) - Forwarding props with spread operator
9. [**React Hooks**](./09_ReactHooks.md) - useState, useEffect, useContext, useMemo, and more
10. [**Routing**](./10_Routing.md) - Client-side routing with React Router
11. [**React Dev Tools**](./11_ReactDevTools.md) - Debugging and optimizing React apps
12. [**TSX**](./12_TSX.md) - TypeScript with React
13. [**Third Party Components**](./13_ThirdPartyComponents.md) - Popular component libraries

## Key Features

* **Component-Based Architecture**: Build encapsulated, reusable UI components that manage their own state and compose to create complex interfaces.
* **Virtual DOM**: Uses a virtual representation of the DOM for efficient updates and rendering, improving performance.
  * **What is the Virtual DOM?**: A JavaScript representation of the real DOM kept in memory. It's a lightweight copy of the actual DOM elements stored as JavaScript objects.
  * **How it Works**: When state changes occur, React creates a new virtual DOM tree representing the new state, then compares (diffs) it with the previous virtual DOM tree to identify what actually changed.
  * **Reconciliation Process**: React's diffing algorithm efficiently determines the minimum number of changes needed to update the real DOM, then applies only those specific changes.
  * **Performance Benefits**: Direct DOM manipulation is expensive because it triggers layout recalculations and repaints. The Virtual DOM minimizes these operations by batching updates and only touching the real DOM when necessary.
  * **Example**: If you update one item in a list of 1000 items, React will only update that single DOM element rather than re-rendering the entire list.
  * **Memory Trade-off**: Uses more memory to store the virtual representation, but this is typically insignificant compared to the performance gains from reduced DOM operations.
* **JSX Syntax**: Write HTML-like syntax within JavaScript, making component templates intuitive and readable.
* **Unidirectional Data Flow**: Data flows down from parent to child components, making applications predictable and easier to debug.
* **Hooks**: Modern functional approach to state management and lifecycle methods without class components.
* **Server Components**: Run components on the server for better performance and SEO.
* **Actions**: Built-in support for handling form submissions and data mutations.
* **Enhanced Concurrent Features**: Improved Suspense, automatic batching, and better error boundaries.
* **React Developer Tools**: Browser extensions for debugging and inspecting React component trees.
* **Rich Ecosystem**: Vast collection of third-party libraries, tools, and community resources.
* **Cross-Platform Development**: Build web apps, mobile apps (React Native), and desktop apps (Electron) with shared knowledge.

## Why Use React?

* **Developer Experience**: Excellent tooling, hot reloading, and debugging capabilities enhance productivity.
* **Performance**: Virtual DOM, Server Components, and enhanced concurrent features ensure fast, responsive user interfaces.
* **Flexibility**: Library approach allows choosing the best tools for routing, state management, and other concerns.
* **Community**: Large, active community with extensive documentation, tutorials, and third-party packages.
* **Industry Adoption**: Used by major companies like Meta, Netflix, Airbnb, and thousands of others.
* **Learning Path**: Skills transfer well to React Native for mobile development.

## Resources

* **Official React Website**: Comprehensive documentation, tutorials, and community resources.
  * (<https://react.dev>)
* **Official Documentation**: Detailed guides, API references, and best practices.
  * (<https://react.dev/learn>)
* **React Blog**: Latest news, release notes, and updates.
  * (<https://react.dev/blog>)
* **Interactive Tutorial**: Learn React step-by-step with hands-on examples.
  * (<https://react.dev/learn/tutorial-tic-tac-toe>)
  * Highly recommended

## Getting Started

* Install Node.js (version 18 or higher required for React 19)
  * React 19 requires Node.js 18+ for development tooling and package management.
  * Download from: <https://nodejs.org>

* Create a new React project using Create React App (CRA):
  * CRA is the traditional, official tool from Facebook/Meta for bootstrapping React applications.

  ```bash
  npx create-react-app my-react-app
  cd my-react-app
  npm start
  ```

* Alternative: Create a new React project with Vite (faster build tool):
  * Vite is a modern, fast build tool created by Evan You (Vue.js creator)

  ```bash
  npm create vite@latest my-react-app -- --template react
  cd my-react-app
  npm install
  npm run dev
  ```

### Key Differences Summary

| Feature | Create React App | Vite |
|---------|------------------|------|
| **Speed** | Slower | Much faster |
| **Bundle Size** | Larger | Smaller |
| **Configuration** | Limited (requires ejecting) | Highly flexible |
| **TypeScript** | Additional setup needed | Built-in support |
| **Hot Reload** | Slower | Near-instant |
| **Modern Standards** | Older approach | Modern, cutting-edge |
| **Learning Curve** | Easier for beginners | Slightly steeper but worth it |
| **Maintenance** | Reduced active development | Active development |

* For new projects in 2024/2025, Vite is generally the better choice because:
  * Significantly faster development experience
  * Better performance and smaller bundles
  * More modern tooling and better TypeScript support
  * Active development and growing ecosystem
  * Easy migration path if needed

>Class Note: Demo creating a new app using both options and exploring the file structure.

## File Structure

### Create React App Structure

| **Location**              | **File/Directory**    | **Description**                                                                 |
| ------------------------- | --------------------- | ------------------------------------------------------------------------------- |
| `/my-react-app/`          | `package.json`        | Project metadata, dependencies, and npm scripts configuration.                  |
| `/my-react-app/`          | `package-lock.json`   | Locks exact versions of dependencies for consistent installs.                   |
| `/my-react-app/`          | `README.md`           | Project documentation with setup and usage instructions.                       |
| `/my-react-app/`          | `.gitignore`          | Specifies files and directories Git should ignore.                             |
| `/my-react-app/`          | `node_modules/`       | Contains all npm dependencies installed for the project.                        |
| `/my-react-app/public/`   | `public/`             | Static assets served directly by the web server.                               |
| `/my-react-app/public/`   | `index.html`          | Main HTML file with root div where React app mounts.                          |
| `/my-react-app/public/`   | `favicon.ico`         | Website icon displayed in browser tabs.                                        |
| `/my-react-app/src/`      | `src/`                | Source code directory containing all React components and assets.               |
| `/my-react-app/src/`      | `index.js`            | Entry point that renders the App component into the DOM.                       |
| `/my-react-app/src/`      | `App.js`              | Main application component containing the app's root structure.                 |
| `/my-react-app/src/`      | `App.css`             | Styles for the main App component.                                              |
| `/my-react-app/src/`      | `index.css`           | Global styles applied to the entire application.                                |
| `/my-react-app/src/`      | `App.test.js`         | Unit tests for the App component using Jest testing framework.                  |

### Vite Structure

| **Location**              | **File/Directory**    | **Description**                                                                 |
| ------------------------- | --------------------- | ------------------------------------------------------------------------------- |
| `/my-react-app/`          | `package.json`        | Project metadata, dependencies, and npm scripts configuration.                  |
| `/my-react-app/`          | `package-lock.json`   | Locks exact versions of dependencies for consistent installs.                   |
| `/my-react-app/`          | `vite.config.js`      | Vite configuration file for build settings and plugins.                        |
| `/my-react-app/`          | `README.md`           | Project documentation with setup and usage instructions.                       |
| `/my-react-app/`          | `.gitignore`          | Specifies files and directories Git should ignore.                             |
| `/my-react-app/`          | `node_modules/`       | Contains all npm dependencies installed for the project.                        |
| `/my-react-app/`          | `index.html`          | Main HTML file (in root, not public/) with root div where React app mounts.   |
| `/my-react-app/public/`   | `public/`             | Static assets served directly by the web server.                               |
| `/my-react-app/public/`   | `vite.svg`            | Vite logo used in the default template.                                        |
| `/my-react-app/src/`      | `src/`                | Source code directory containing all React components and assets.               |
| `/my-react-app/src/`      | `main.jsx`            | Entry point that renders the App component into the DOM (JSX extension).       |
| `/my-react-app/src/`      | `App.jsx`             | Main application component containing the app's root structure (JSX extension). |
| `/my-react-app/src/`      | `App.css`             | Styles for the main App component.                                              |
| `/my-react-app/src/`      | `index.css`           | Global styles applied to the entire application.                                |
| `/my-react-app/src/assets/` | `assets/`           | Directory for static assets like images, fonts, etc.                           |
| `/my-react-app/src/assets/` | `react.svg`         | React logo used in the default template.                                       |

### Key Structural Differences

* **HTML Location**: CRA keeps `index.html` in `public/`, Vite keeps it in the root directory
* **File Extensions**: Vite uses `.jsx` extensions by default, CRA uses `.js`
* **Entry Point**: CRA uses `index.js`, Vite uses `main.jsx`
* **Configuration**: CRA has no config file (requires ejecting), Vite has `vite.config.js`
* **Assets**: Vite includes a dedicated `src/assets/` directory

## Our Demo Application

```bash
cd [YOUR_FOLDER]/codando-live/_12_React/

# Creating a react app called react-demo-app
npm create vite@latest react-demo-app -- --template react

# Running the app in development mode
cd react-demo-app
npm run dev
```

### Structural elements

| File | Description |
| --- | --- |
| `index.html` | The static HTML shell. Vite serves this and the `<script type="module" src="/src/main.jsx">` loads your app. Contains the DOM mount node (e.g. `<div id="root"></div>`). |
| `src/main.jsx` | Entry module. Imports React, ReactDOM and your root component, then mounts it into the DOM node from `index.html`. |
| `src/App.jsx` | Root React component (default export). Composes the app UI and child components. |

---

## Topics Overview

### 1. Components
→ **[See Components documentation](./01_Components.md)**

Components are the fundamental building blocks of React applications. Learn about functional and class components, component structure, and best practices.

### 2. JSX
→ **[See JSX documentation](./02_JSX.md)**

JSX (JavaScript XML) allows you to write HTML-like code within JavaScript. Discover common patterns for combining JSX and JavaScript effectively.

### 3. Props
→ **[See Props documentation](./03_Props.md)**

Props enable component composition and reusability. Understand how to pass data from parent to child components and follow React's unidirectional data flow.

### 4. Event Handling
→ **[See Event Handling documentation](./04_EventHandling.md)**

Learn how to handle user interactions like clicks, form submissions, and keyboard events in React components using proper event handling patterns.

### 5. Parent/Child Communication
→ **[See Parent/Child Communication documentation](./05_ParentChildCommunication.md)**

Understand how data and functions flow between components in React's unidirectional architecture through props and callbacks.

### 6. Controlled Components
→ **[See Controlled Components documentation](./06_ControlledComponents.md)**

Form inputs whose values are controlled by React state. Learn the single source of truth pattern for form management.

### 7. Dynamic Attributes
→ **[See Dynamic Attributes documentation](./07_DynamicAttributes.md)**

Discover how to compute `className` and inline `style` values based on props or state for dynamic, responsive UIs.

### 8. Spread Props
→ **[See Spread Props documentation](./08_SpreadProps.md)**

Learn how to forward all props from a parent component to a child element using the spread operator for flexible, reusable components.

### 9. React Hooks
→ **[See React Hooks documentation](./09_ReactHooks.md)**

Hooks let you use state and other React features in functional components. Explore useState, useEffect, useContext, useMemo, and more.

### 10. Routing
→ **[See Routing documentation](./10_Routing.md)**

React Router enables navigation between different views/pages without full page reloads. Learn about routes, navigation, parameters, and authentication.

### 11. React Development Tools
→ **[See React Dev Tools documentation](./11_ReactDevTools.md)**

Essential browser extension for debugging and optimizing React applications. Inspect components, analyze performance, and more.

### 12. TSX
→ **[See TSX documentation](./12_TSX.md)**

TSX (TypeScript XML) brings type safety to your React components. Learn how to write type-safe React components with TypeScript.

### 13. Third Party Components
→ **[See Third Party Components documentation](./13_ThirdPartyComponents.md)**

Explore popular third-party component libraries and tools that enhance React development.
