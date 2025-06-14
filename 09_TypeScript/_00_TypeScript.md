# TypeScript

* TypeScript is a statically typed superset of JavaScript that adds type definitions to enhance code reliability and maintainability.
* It compiles to plain JavaScript, making it compatible with any JavaScript environment, including browsers and Node.js.
* TypeScript is widely used in Angular development due to its strong typing, which improves tooling, debugging, and scalability in large applications.

* Documentation
  * [TypeScript](https://www.typescriptlang.org/)
  * [Oficial Documentation](https://www.typescriptlang.org/docs/)
  * [Handbook](https://www.typescriptlang.org/docs/handbook/intro.html)
  * [OnLine Editor](https://www.typescriptlang.org/play/)

## Introduction to TypeScript

TypeScript extends JavaScript by adding static types, interfaces, and advanced object-oriented features.

* Key benefits include:
  * **Type Safety**: Catch errors during development rather than runtime.
  * **Improved Tooling**: Better autocompletion, refactoring, and error detection in IDEs.
  * **Scalability**: Ideal for large codebases, like those in Angular applications.
  * **Interoperability**: Works seamlessly with existing JavaScript code.

## Setting Up VS Code for TypeScript

* Ensure you have the following installed:
  * **Node.js and npm**: Download from [nodejs.org](https://nodejs.org/) (LTS version recommended).
    * `Node.js`: Node.js is an open-source, cross-platform JavaScript runtime environment built on Chrome’s V8 engine, enabling developers to execute JavaScript code outside web browsers for server-side and command-line applications. It supports event-driven, scalable development, making it ideal for web servers, APIs, and tools like Angular CLI, as used in your TypeScript module for running TypeScript and Angular projects.
    * `npm`: [npm (Node Package Manager)](https://www.npmjs.com/) is the default command-line package manager included with Node.js, used to install, manage, and share JavaScript and TypeScript libraries and dependencies. It simplifies project setup by allowing commands like npm install typescript or npm install -g @angular/cli, essential for configuring TypeScript environments and Angular development in VS Code, as outlined in your module.

    ```bash
    node -v
    npm -v
    ```

* **TypeScript**: Install globally or in a project via npm:

  ```bash
  sudo npm install -g typescript
  
  tsc -v
  ```

  >Note: the `-g` means globally

* Create or Open a TypeScript Project

  * Initialize a new project:

  ```bash
  mkdir my-typescript-project
  cd my-typescript-project
  npm init -y
  tsc --init
  ```

* Open the project in VS Code:

  ```bash
  code .
  ```

* Configure TypeScript with `tsconfig.json`
  * The `tsconfig.json` file configures TypeScript compilation. A basic setup suitable for learning TypeScript (and compatible with Angular):

  ```json
  {
    "compilerOptions": {
      "target": "es2020",
      "module": "commonjs",
      "strict": true,
      "esModuleInterop": true,
      "outDir": "./dist",
      "rootDir": "./src",
      "sourceMap": true
    },
    "include": ["src/**/*"],
    "exclude": ["node_modules"]
  }
  ```

* Create a `src` folder and add a sample TypeScript file (e.g., `src/index.ts`):

  ```typescript
  let message: string = "Hello, TypeScript!";
  console.log(message);
  ```

* Install Essential VS Code Extensions
  * Enhance TypeScript development with these extensions:
    * **ESLint** (`dbaeumer.vscode-eslint`): Lints TypeScript code for errors and style.
    * **Prettier** (`esbenp.prettier-vscode`): Formats TypeScript code automatically.
    * **Code Runner** (`formulahendry.code-runner`): Runs TypeScript files directly in VS Code.
* **Linting**: Set up ESLint for TypeScript by installing dependencies:

  ```bash
  npm install eslint @typescript-eslint/parser @typescript-eslint/eslint-plugin --save-dev
  ```

  * Initialize ESLint:

    ```bash
    npx eslint --init
    ```

  * Install ts-none

    ```shell
    npm install -g ts-node
    ```

* Running TypeScript Runner**:
  * With the Code Runner extension, right-click a `.ts` file and select “Run Code” (requires `ts-node` installed).

* Debugging TypeScript in VS Code

  * **Enable Source Maps**: Ensure `"sourceMap": true` in `tsconfig.json` to map compiled JavaScript to TypeScript for debugging.

## Variables and Basic Types

* TypeScript introduces type annotations to define variable types explicitly.
* Unlike JavaScript, TypeScript enforces these types at compile time.

### Declaring Variables

Use `let identifier: type` to declare a variable:

```typescript
let firstName: string = "Leila"; // String type
let age: number = 25; // Number type
let isStudent: boolean = true; // Boolean type
let id: any = 123; // Any type (avoid when possible)
```

### Type Inference

TypeScript can infer types when not explicitly declared:

```typescript
let score = 95; // Inferred as number
score = "95"; // Error: Type 'string' is not assignable to type 'number'
```

### Common Types

* **Primitive Types**:
  * `string`
  * `number`
  * `boolean`
  * `null`
  * `undefined`
  * `symbol`
  * `bigint`
* **Union Types**: Allow multiple types for a variable:

  ```typescript
  let value: string | number;
  value = "Hello"; // Valid
  value = 42; // Valid
  value = true; // Error
  ```

* **Type Aliases**: Create reusable type definitions:

  ```typescript
  type ID = string | number;
  let userId: ID = "abc123";
  ```

## Flow Control in TypeScript

Flow control statements in TypeScript, such as `if-else`, `while`, `do-while`, `for`, `switch`, and `try-catch`, allow you to control the execution flow of your program, building on your vanilla JavaScript knowledge. TypeScript enhances these constructs with its type system, ensuring type-safe conditions and iterations, which is crucial for writing robust Angular applications. This section covers these statements with examples, demonstrating how TypeScript’s static typing improves reliability.

### `if-else` Statements

The `if-else` statement executes code based on a condition, with TypeScript ensuring the condition evaluates to a `boolean`.

```typescript
let age: number = 20;

if (age >= 18) {
  console.log("Adult");
} else if (age >= 13) {
  console.log("Teen");
} else {
  console.log("Child");
}
// Output: Adult

// Type safety example
let value: string | number = "test";
if (typeof value === "string") {
  console.log(value.toUpperCase()); // TypeScript knows value is a string here
}
```

>Note: **TypeScript Benefit**: Type narrowing (e.g., `typeof value === "string"`) ensures type-safe operations within the block, preventing errors like `value.toUpperCase()` on a number.

### `switch` Statements

The `switch` statement evaluates an expression and executes code based on matching cases, with TypeScript enforcing type consistency.

```typescript
let day: string = "Monday";

switch (day) {
  case "Monday":
    console.log("Start of the week");
    break;
  case "Friday":
    console.log("End of the week");
    break;
  default:
    console.log("Midweek");
}
// Output: Start of the week

// Type-safe enum example
enum Role { Admin, User, Guest }
let userRole: Role = Role.Admin;
switch (userRole) {
  case Role.Admin:
    console.log("Full access");
    break;
  case Role.User:
    console.log("Limited access");
    break;
  default:
    console.log("No access");
}
// Output: Full access
```

>Note: **TypeScript Benefit**: Enums (like `Role`) ensure type-safe case values, and the compiler can warn about unhandled cases if `strict` mode is enabled.

### `while` Loop

The `while` loop executes as long as a condition is true, with TypeScript ensuring the condition is boolean-typed.

```typescript
let count: number = 5;

while (count > 0) {
  console.log(`Count: ${count}`);
  count--;
}
// Output: Count: 5, Count: 4, Count: 3, Count: 2, Count: 1

// Type safety example
let input: string | null = "data";
while (input !== null) {
  console.log(input.toUpperCase()); // TypeScript knows input is string
  input = Math.random() > 0.5 ? "next" : null;
}
```

Note: **TypeScript Benefit**: Type narrowing ensures safe access to properties (e.g., `toUpperCase`) within the loop.

### `do-while` Loop

The `do-while` loop executes at least once before checking the condition, with TypeScript enforcing type-safe conditions.

```typescript
let i: number = 0;

do {
  console.log(`Iteration: ${i}`);
  i++;
} while (i < 3);
// Output: Iteration: 0, Iteration: 1, Iteration: 2
```

>Note: **TypeScript Benefit**: Similar to `while`, type checking ensures the condition is valid, and variables are properly typed.

### `for` Loops

TypeScript supports traditional `for`, `for...of`, and `for...in` loops, with type safety for iterators and collections.

#### Traditional `for` Loop

```typescript
for (let i: number = 0; i < 5; i++) {
  console.log(`Index: ${i}`);
}
// Output: Index: 0, Index: 1, Index: 2, Index: 3, Index: 4
```

#### `for...of` Loop

Iterates over iterable objects (e.g., arrays, strings), with TypeScript inferring element types.

```typescript
let numbers: number[] = [1, 2, 3, 4, 5];
for (let num of numbers) {
  console.log(num * 2); // TypeScript knows num is number
}
// Output: 2, 4, 6, 8, 10
```

#### `for...in` Loop

Iterates over object keys, with TypeScript ensuring key type safety.

```typescript
interface User {
  name: string;
  age: number;
}
let user: User = { name: "Leila", age: 25 };
for (let key in user) {
  console.log(`${key}: ${user[key as keyof User]}`); // Type-safe key access
}
// Output: name: Leila, age: 25
```

>Note: **TypeScript Benefit**: `keyof` ensures only valid object keys are accessed, preventing runtime errors.

### `try-catch` for Error Handling

The `try-catch` statement handles exceptions, with TypeScript supporting typed errors.

```typescript
try {
  let data: string = JSON.parse('{"invalid": }'); // Throws SyntaxError
} catch (error: unknown) {
  if (error instanceof Error) {
    console.log(`Error: ${error.message}`); // TypeScript narrows error to Error
  } else {
    console.log("Unknown error");
  }
}
// Output: Error: Unexpected token } in JSON at position 9
```

Note: **TypeScript Benefit**: Type narrowing with `instanceof` ensures safe access to error properties, enhancing robustness.

## Strings

[Strings](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/String) in TypeScript represent text and are enclosed in single quotes (`'`), double quotes (`"`), or backticks (`` ` ``) for template literals. TypeScript provides a rich set of built-in methods for string manipulation, inherited from JavaScript's `String` object. Below are common string methods with examples.

## Declaring Strings

Strings can be declared using single quotes, double quotes, or template literals:

```typescript
let singleQuote: string = 'Hello, TypeScript!';
let doubleQuote: string = "Hello, TypeScript!";
let templateLiteral: string = `Hello, TypeScript!`;
```

* **Notes**
  * All string methods return a new string and do not modify the original.
  * TypeScript's type system ensures type safety when working with strings.
  * Template literals are useful for dynamic string creation with embedded variables.

### Common String Methods

```typescript
/*
 * String common methods
 */

// === length: Returns the length of the string ===
const strLength: string = "TypeScript";
console.log(`Length of "${strLength}": ${strLength.length}`); // Output: 10

// === toUpperCase() and toLowerCase(): Converts the string to uppercase or lowercase ===
const text: string = "TypeScript";
console.log(`Uppercase of "${text}": ${text.toUpperCase()}`); // Output: TYPESCRIPT
console.log(`Lowercase of "${text}": ${text.toLowerCase()}`); // Output: typescript

// === charAt(index): Returns the character at the specified index ===
const strCharAt: string = "Hello";
console.log(`Character at index 1 in "${strCharAt}": ${strCharAt.charAt(1)}`); // Output: e

// === substring(start, end?): Extracts a portion of the string from start to end (end not included) ===
const strSubstring: string = "TypeScript";
console.log(`Substring (0, 4) of "${strSubstring}": ${strSubstring.substring(0, 4)}`); // Output: Type

// === slice(start, end?): Similar to substring, but supports negative indices ===
const strSlice: string = "TypeScript";
console.log(`Slice (4, 10) of "${strSlice}": ${strSlice.slice(4, 10)}`); // Output: Script
console.log(`Slice (-6) of "${strSlice}": ${strSlice.slice(-6)}`); // Output: Script
console.log(`Slice (-1) of "${strSlice}": ${strSlice.slice(-1)}`); // Output: t

// === indexOf(substring, fromIndex?): Returns the index of the first occurrence of a substring ===
const strIndexOf: string = "Hello, TypeScript!";
console.log(`Index of "Type" in "${strIndexOf}": ${strIndexOf.indexOf("Type")}`); // Output: 7
console.log(`Index of "Java" in "${strIndexOf}": ${strIndexOf.indexOf("Java")}`); // Output: -1

// === replace(searchValue, newValue): Replaces the first occurrence of a substring ===
const strReplace: string = "Hello, Java!";
console.log(`Replacing "Java" with "TypeScript" in "${strReplace}": ${strReplace.replace("Java", "TypeScript")}`); // Output: Hello, TypeScript!

// === split(separator, limit?): Splits the string into an array based on a separator ===
const strSplit: string = "apple,banana,orange";
console.log(`Split "${strSplit}" by ",": ${JSON.stringify(strSplit.split(","))}`); // Output: ["apple", "banana", "orange"]
console.log(`Split "${strSplit}" by "," with limit 2: ${JSON.stringify(strSplit.split(",", 2))}`); // Output: ["apple", "banana"]

// === trim(): Removes leading and trailing whitespace ===
const strTrim: string = "  TypeScript  ";
console.log(`Trimmed "${strTrim}": "${strTrim.trim()}"`); // Output: TypeScript

// === includes(substring, fromIndex?): Checks if a string contains a specified substring ===
const strIncludes: string = "Hello, TypeScript!";
console.log(`Does "${strIncludes}" include "Type"? ${strIncludes.includes("Type")}`); // Output: true
console.log(`Does "${strIncludes}" include "Java"? ${strIncludes.includes("Java")}`); // Output: false

// === startsWith(substring) and endsWith(substring): Checks if a string starts or ends with a substring ===
const strStartEnd: string = "TypeScript";
console.log(`Does "${strStartEnd}" start with "Type"? ${strStartEnd.startsWith("Type")}`); // Output: true
console.log(`Does "${strStartEnd}" end with "Script"? ${strStartEnd.endsWith("Script")}`); // Output: true

// === concat(...strings): Combines the string with one or more strings ===
const str1: string = "Hello";
const str2: string = "TypeScript";
console.log(`Concatenating "${str1}" and "${str2}": ${str1.concat(", ", str2, "!")}`); // Output: Hello, TypeScript!

// === Template Literals: Allow embedded expressions and multi-line strings ===
const wife: string = "Leila";
const greeting: string =
`Hello, ${wife}!
Welcome to TypeScript!`;
console.log(`Template Literal Example:\n${greeting}`);
// Output:
// Hello, Leila!
// Welcome to TypeScript!
```

## Functions

TypeScript allows typing function parameters and return values to ensure correctness.

* Function Types

  ```typescript
  function add(a: number, b: number): number {
    return a + b;
  }

  let multiply: (x: number, y: number) => number = (x, y) => x * y;
  ```

* Optional and Default Parameters

  ```typescript
  function greet(name: string, greeting: string = "Hello"): string {
    return `${greeting}, ${name}!`;
  }

  console.log(greet("Leila")); // Hello, Leila!
  console.log(greet("Jose", "Hi")); // Hi, Jose!
  ```

## Data Structures

TypeScript enhances JavaScript’s built-in data structures (like objects, arrays, and newer constructs like `Map` and `Set`) with static typing, making them more robust for large-scale applications like those built with Angular.

### Arrays

Arrays in TypeScript are typed to ensure all elements conform to a specific type.

* Typed Arrays

  ```typescript
  let scores: number[] = [90, 85, 88];
  scores.push("95"); // Error: Argument of type 'string' is not assignable to type 'number'

  let names: Array<string> = ["Leila", "Jose"]; // Alternative syntax
  ```

* Readonly Arrays: Prevent modifications to arrays:

  ```typescript
  let readonlyScores: readonly number[] = [90, 85, 88];
  readonlyScores.push(95); // Error: Property 'push' does not exist on type 'readonly number[]'
  ```

* Multi-Type Arrays (Union Types): Allow arrays to hold multiple types:

  ```typescript
  let mixed: (string | number)[] = ["Leila", 25, "Jose", 30];
  mixed.push(true); // Error: Argument of type 'boolean' is not assignable to type 'string | number'
  ```

### Lists (Tuples)

Tuples are fixed-length arrays with specific types for each element, useful for structured data:

```typescript
let user: [string, number, boolean] = ["Leila", 25, true];
user[0] = 42; // Error: Type 'number' is not assignable to type 'string'

let coordinates: [number, number] = [10, 20];
coordinates.push(30); // Allowed, but use readonly for strictness
let readonlyCoordinates: readonly [number, number] = [10, 20];
coordinates.push(30); // Error: Property 'push' does not exist on type 'readonly [number, number]'
```

### Set

TypeScript’s `Set` stores unique values with type safety:

```typescript
let uniqueIds = new Set<number>();
uniqueIds.add(1);
uniqueIds.add(2);
uniqueIds.add("3"); // Error: Argument of type 'string' is not assignable to type 'number'

console.log(uniqueIds.has(1)); // true
console.log(uniqueIds.has(3)); // false
```

### Dictionaries (Map)

TypeScript’s `Map` is a modern alternative to objects for key-value storage, offering better performance for frequent additions/removals and support for non-string keys.

```typescript
let userMap = new Map<string, number>();
userMap.set("Jose", 25); // Key: string, Value: number
userMap.set("Leila", 30);

console.log(userMap.get("Jose")); // 25
userMap.set("Jose", "30"); // Error: Argument of type 'string' is not assignable to type 'number'

console.log("Leila" in userMap); // true
console.log("Artur" in userMap); // false

const myDict: { [key: string]: number } = {
  "apple": 1,
  "banana": 2,
  "cherry": 3,
};
```

### Objects

In JavaScript, objects are often used as dictionaries to store key-value pairs. TypeScript adds type safety to ensure keys and values adhere to specific types.

* Typed Objects: Use interfaces or type aliases to define the structure of an object:

  ```typescript
  interface UserDictionary {
    [key: string]: string; // Index signature for dynamic keys
  }

  let users: UserDictionary = {
    Leila: "Leila Smith",
    Jose: "Jose Johnson",
  };

  users["charlie"] = "Charlie Brown"; // Valid
  users["david"] = 123; // Error: Type 'number' is not assignable to type 'string'
  ```

* Specific Key-Value Types: For more control, define exact keys and their types:

  ```typescript
  interface Config {
    apiUrl: string;
    timeout: number;
  }

  let config: Config = {
    apiUrl: "https://api.example.com",
    timeout: 5000,
  };

  config.apiUrl = 42; // Error: Type 'number' is not assignable to type 'string'
  ```

* Readonly Objects: Prevent modifications to object properties:

  ```typescript
  interface ReadonlyConfig {
    readonly apiUrl: string;
    readonly timeout: number;
  }

  let readonlyConfig: ReadonlyConfig = {
    apiUrl: "https://api.example.com",
    timeout: 5000,
  };

  readonlyConfig.apiUrl = "new-url"; // Error: Cannot assign to 'apiUrl' because it is a read-only property
  ```

### Practical Example: Combining Data Structures

Here’s an example combining dictionaries and lists for a simple Angular-like scenario:

```typescript
interface Product {
  id: number;
  name: string;
  price: number;
}

let productMap = new Map<number, Product>();
let productList: Product[] = [
  { id: 1, name: "Laptop", price: 999 },
  { id: 2, name: "Phone", price: 499 },
];

productList.forEach(product => productMap.set(product.id, product));

console.log(productMap.get(1)?.name); // Laptop
```

## Modules and Namespaces

TypeScript’s support for [modules](https://www.typescriptlang.org/docs/handbook/2/modules.html) and [namespaces](https://www.typescriptlang.org/docs/handbook/namespaces.html) enables developers to organize code effectively, promoting modularity, reusability, and maintainability.

### Namespaces

Namespaces (previously called "internal modules") provide a way to group related code within a single file or across multiple files. They help prevent naming collisions in the global scope by encapsulating functionality under a named container. While namespaces were common in earlier TypeScript versions, ES modules are now preferred in modern projects due to better interoperability with JavaScript ecosystems.

#### Defining a Namespace
  
  A namespace groups related functionality, such as functions, classes, or interfaces, under a single name.Only items marked with `export` are accessible outside the namespace, ensuring controlled visibility.

  ```typescript
  namespace Utilities {
    export function log(message: string): void {
      privateLog(message);
    }

    export function error(message: string): void {
      privateLog(message);
    }

    // Private function (not exported, inaccessible outside)
    function privateLog(message: string): void {
      console.log(`[Private]: ${message}`);
    }
  }

  Utilities.log("Hello, TypeScript!"); // Hello, TypeScript!
  Utilities.error("Something went wrong!"); // Something went wrong!
  // Utilities.privateLog("Test"); // Error: 'privateLog' is not exported
  ```

#### Nested Namespaces

Namespaces can be nested to create hierarchical organization:

```typescript
namespace App {
  export namespace Logging {
    export function log(message: string): void {
      console.log(`[App]: ${message}`);
    }

    export function warn(message: string): void {
      console.warn(`[Warning]: ${message}`);
    }
  }

  export function getVersion(): string {
    return "1.0.0";
  }
}

App.Logging.log("Application started"); // [App]: Application started
App.Logging.warn("Low memory"); // [Warning]: Low memory
console.log(App.getVersion()); // 1.0.0
```

#### Best Practices for Namespaces

* **Avoid in New Projects**: Use ES modules unless required for legacy compatibility.
* **Use Descriptive Names**: Choose clear, unique namespace names (e.g., `App.Utilities` instead of `Utils`).
* **Export Only What’s Needed**: Only export items intended for external use to maintain encapsulation.
* **Combine with Modules**: If using namespaces, consider wrapping them in modules to limit global scope exposure:

```typescript
// utilities.ts
export namespace Utilities {
  export function log(message: string): void {
    console.log(message);
  }
}
```

```typescript
// main.ts
import { Utilities } from './utilities';
Utilities.log("Hello"); // Hello
```

### Modules

TypeScript uses ES modules (ECMAScript modules) to organize code into reusable units. Modules allow you to split your codebase across multiple files, each encapsulating related functionality. This modularity improves code organization, reduces global scope pollution, and supports tree-shaking for optimized builds.

#### Export and Import

Modules use `export` to expose functions, classes, interfaces, or variables, and `import` to consume them in other files. **Only items explicitly marked with `export` can be used outside the module.** Anything not exported remains private, ensuring encapsulation. TypeScript supports named exports and default exports for flexible code organization.

##### Named Exports

* You can export multiple items from a module using named exports, which are imported explicitly by name.

  ```typescript
  // math.ts
  export function add(a: number, b: number): number {
    return a + b;
  }

  export function subtract(a: number, b: number): number {
    return a - b;
  }

  export const PI: number = 3.14159;

  export class Calculator {
    multiply(a: number, b: number): number {
      return a * b;
    }
  }

  // Private function (not exported, inaccessible outside)
  function privateHelper(): void {
    console.log("This is private");
  }
  ```

* To use these exports:

  ```typescript
  // main.ts
  import { add, PI, Calculator } from './math';

  console.log(add(2, 3)); // 5
  console.log(PI); // 3.14159
  const calc = new Calculator();
  console.log(calc.multiply(4, 5)); // 20
  // Cannot access privateHelper because it's not exported
  ```

  You can define alias imports to avoid naming conflicts:

  ```typescript
  // main.ts
  import { add as sum, PI as circleConstant, Calculator as MathCalc } from './math';

  console.log(sum(2, 3)); // 5
  console.log(circleConstant); // 3.14159
  const calc = new MathCalc();
  console.log(calc.multiply(4, 5)); // 20
  ```

##### Importing All Exports

* To import everything from a module as a single object, use `import * as`:

  ```typescript
  // main2.ts
  import * as math from './math';

  console.log(math.add(2, 3)); // 5
  console.log(math.subtract(5, 3)); // 2
  console.log(math.PI); // 3.14159
  const calc = new math.Calculator();
  console.log(calc.multiply(4, 5)); // 20
  ```

> This is useful for modules with many exports but can reduce code clarity.

##### Default Exports

A module can have one default export, often used for the primary functionality. Default exports don’t require curly braces during import and can be given any name.

```typescript
// calculator.ts
export default class Calculator {
  multiply(a: number, b: number): number {
    return a * b;
  }
}
```

```typescript
// main.ts
import Calculator from './calculator';
const calc = new Calculator();
console.log(calc.multiply(4, 5)); // 20
```

You can combine default and named exports:

```typescript
// math.ts
export default function add(a: number, b: number): number {
  return a + b;
}
export function subtract(a: number, b: number): number {
  return a - b;
}
export class Calculator {
  multiply(a: number, b: number): number {
    return a * b;
  }
}
```

```typescript
// main.ts
import add, { subtract, Calculator } from './math';
console.log(add(2, 3)); // 5
console.log(subtract(5, 3)); // 2
const calc = new Calculator();
console.log(calc.multiply(4, 5)); // 20
```

#### Best Practices for Modules

* **Use ES Modules**: Prefer ES modules over namespaces for modern projects.
* **Explicit Imports**: Favor named imports over `import * as` for clarity and tree-shaking.
* **Organize by Feature**: Group related files into feature folders (e.g., `src/app/feature/math/`).
* **Export Only What’s Needed**: Only export items intended for external use to maintain encapsulation.

### Namespaces vs. Modules

* **Namespaces**: Best for grouping code in scripts without a module system (e.g., `<script>` tags). They don’t require a module loader but can pollute the global scope.
* **Modules**: Preferred for modern applications, integrating with bundlers (Webpack, Rollup) and supporting lazy loading, tree-shaking, and encapsulation.

### Conclusion

Namespaces provide a way to group related code, with exported functions and other members accessible outside the namespace. However, ES modules are the cornerstone of modern TypeScript development, offering superior modularity and ecosystem compatibility. By explicitly exporting only necessary items (functions, classes, variables, etc.), you maintain encapsulation and clarity, enabling scalable, maintainable codebases.

## Object-Oriented Programming

TypeScript enhances JavaScript’s [object-oriented capabilities](https://www.typescriptlang.org/docs/handbook/classes.html) with features like interfaces, classes, and access modifiers, which are critical for Angular’s component-based structure.

### Classes

TypeScript supports classes with access modifiers (`public`, `private`, `protected`) and other OOP features:

```typescript
class BankAccount {
  protected balance: number;
  public readonly id: string;
  private _customerName: string;

  constructor(id: string, customerName: string, initialBalance: number = 0) {
    this.id = id;
    this._customerName = customerName;
    this.balance = initialBalance;
  }

  get customerName(): string {
    return this._customerName;
  }

  set customerName(name: string) {
    if (name.trim().length > 0) {
      this._customerName = name;
      console.log(`Customer name updated to: ${name}`);
    } else {
      throw new Error("Customer name cannot be empty.");
    }
  }

  deposit(amount: number): void {
    if (amount <= 0) {
      throw new Error("Deposit amount must be positive.");
    }
    this.balance += amount;
    console.log(`Deposited $${amount}. New balance: $${this.balance}`);
  }

  withdraw(amount: number): void {
    if (amount <= 0) {
      throw new Error("Withdrawal amount must be positive.");
    }
    if (amount > this.balance) {
      throw new Error("Insufficient funds.");
    }
    this.balance -= amount;
    console.log(`Withdrawn $${amount}. New balance: $${this.balance}`);
  }

  getBalance(): number {
    return this.balance;
  }
}

// Demonstration
const account = new BankAccount("12345", "José", 1000);
console.log(`Account ID: ${account.id}`);
console.log(`Customer Name: ${account.customerName}`);
account.customerName = "José Santos";
console.log(`Updated Customer Name: ${account.customerName}`);
account.deposit(500);
account.withdraw(200);
console.log(`Final balance: $${account.getBalance()}`);

try {
  account.withdraw(2000);
} catch (error) {
  console.error(`Error: ${(error as Error).message}`);
}
```

### Inheritance

Extend classes to reuse and specialize behavior:

```typescript
class SpecialAccount extends BankAccount {
  withdraw(amount: number): void {
    if (amount > 0) {
      this.balance -= amount; // Allows overdraft (negative balance)
      console.log(`Withdrawn $${amount}. New balance: $${this.getBalance()}`);
    } else {
      console.log("Withdrawal amount must be positive.");
    }
  }
}

// Special Account Demonstration
const specialAccount = new SpecialAccount("67890", "Leila VIP", 500);
console.log(`Special Account ID: ${specialAccount.id}`);
console.log(`Customer Name: ${specialAccount.customerName}`);

specialAccount.deposit(300);
specialAccount.withdraw(1000); // Overdraft allowed
console.log(`Final balance: $${specialAccount.getBalance()}`);

```

>Note: In TypeScript, method overriding works differently from C#. Unlike C#, TypeScript does not require virtual or override keywords. Instead, any method in a subclass automatically overrides a method with the same name in the parent class.

### Abstract Classes

Define base classes that cannot be instantiated directly:

```typescript
abstract class Animal {
  abstract makeSound(): void;

  move(): string {
    return "Moving...";
  }
}

class Dog extends Animal {
  makeSound(): void {
    console.log("Woof!");
  }
}

let dog = new Dog();
dog.makeSound(); // Woof!
console.log(dog.move()); // Moving...
```

### Interfaces

* Interfaces in TypeScript define the shape or structure of objects, specifying the required properties and their types.
* They can also describe function signatures, arrays, and more.
* Interfaces are a powerful way to enforce a contract for objects and classes.

#### Define the shape of objects

```typescript
interface User {
  name: string;
  age: number;
  email?: string; // Optional property
}

let user: User = {
  name: "Leila",
  age: 25,
};

// Example of using an interface with a function
interface Greetable {
  greet(): string;
}

const person: User & Greetable = {
  name: "Leila",
  age: 25,
  greet() {
    return `Hello, ${this.name}!`;
  },
};

console.log(person.greet()); // Output: Hello, Leila!
```

#### Extending Multiple Interfaces with Classes

* A class can implement multiple interfaces in TypeScript using the `implements` keyword.
* This allows a class to adhere to the contracts defined by multiple interfaces, ensuring it provides all required properties and methods from each interface.
* Use a comma to separate the interfaces in the `implements` clause.

```typescript
interface Printable {
  print(): void;
}

interface Loggable {
  log(message: string): void;
}

class Document implements Printable, Loggable {
  content: string;

  constructor(content: string = "") {
    this.content = content;
  }

  print() {
    console.log(`Printing document: ${this.content}`);
  }

  log(message: string) {
    console.log(`Document Log: ${message}`);
  }
}

const doc = new Document("Sample content");
doc.print();
doc.log("Error occurred");
```

### Static Members in TypeScript

In TypeScript, **static members** belong to the class itself rather than an instance of the class. This means they are shared across all instances and can be accessed directly through the class name.

* To define a static property or method, use the `static` keyword inside a class:

```typescript
class Logger {
  static logLevel: string = "INFO";

  static log(message: string): void {
    console.log(`[${this.logLevel}] ${message}`);
  }
}

// Accessing static members
console.log(Logger.logLevel); // Outputs: INFO
Logger.log("Application started");
```

### Generics

* Generics in TypeScript allow you to create reusable components, functions, classes, or interfaces that work with a variety of types while maintaining type safety.
* Instead of hardcoding specific types, generics use type parameters to make code flexible and reusable, enabling developers to write functions or classes that can operate on different data types without sacrificing TypeScript’s type-checking capabilities.

#### Create reusable code with flexible types

```typescript
interface Printable {
  print(): string;
}

function printItem<T extends Printable>(item: T): string {
  return item.print();
}

class MyDocument implements Printable {
  print() {
    return "Document content";
  }
}

class MyImage implements Printable {
  print() {
    return "Image data";
  }
}

const doc = new MyDocument();
const img = new MyImage();

console.log(printItem(doc)); // Output: Document content
console.log(printItem(img)); // Output: Image data
// console.log(printItem("string")); // Error: string does not satisfy Printable
```

#### Create flexible, type-safe data structures

```typescript
interface Stackable<T> {
  push(item: T): void;
  pop(): T | undefined;
  peek(): T | undefined;
  isEmpty(): boolean;
}

class Stack<T> implements Stackable<T> {
  private items: T[] = [];

  push(item: T): void {
    this.items.push(item);
  }

  pop(): T | undefined {
    return this.items.pop();
  }

  peek(): T | undefined {
    return this.items.at(-1);
  }

  isEmpty(): boolean {
    return this.items.length === 0;
  }

  size(): number {
    return this.items.length;
  }
}

// Example usage with numbers
const numberStack = new Stack<number>();
numberStack.push(10);
numberStack.push(20);
numberStack.push(30);
console.log(numberStack.peek()); // Output: 30
console.log(numberStack.pop()); // Output: 30
console.log(numberStack.size()); // Output: 2
console.log(numberStack.isEmpty()); // Output: false
// numberStack.push("string"); // Error: Argument of type 'string' is not assignable to parameter of type 'number'

// Example usage with strings
const stringStack = new Stack<string>();
stringStack.push("Hello");
stringStack.push("TypeScript");
console.log(stringStack.peek()); // Output: TypeScript
console.log(stringStack.pop()); // Output: TypeScript
console.log(stringStack.size()); // Output: 1
console.log(stringStack.isEmpty()); // Output: false

// Example usage with custom objects
interface User {
  name: string;
  id: number;
}

const userStack = new Stack<User>();
userStack.push({ name: "Leila", id: 1 });
userStack.push({ name: "Jose", id: 2 });
userStack.push({ name: "Artur", id: 2 });

console.log('Peak:', userStack.peek());
while (!userStack.isEmpty()) {
  const user = userStack.pop();
  console.log(user);
}
```

### Utility Types in TypeScript

TypeScript provides several **utility types** that help manipulate and refine existing types. Some of the most commonly used ones include `Partial`, `Pick`, and `Omit`.

#### `Partial<T>`

The `Partial` utility type makes all properties of a given type optional.

```typescript
interface User {
  name: string;
  age: number;
}

let partialUser: Partial<User> = { name: "Leila" }; // Only some properties required
```

#### Pick<T, K>

The Pick utility type creates a new type by selecting only specified properties from an existing type.

```typescript
interface User {
  id: number;
  name: string;
  age: number;
  email: string;
}

type PickedUser = Pick<User, "name" | "email">;

const pickedUser: PickedUser = {
  name: "Leila",
  email: "Leila@example.com",
}; // Only 'name' and 'email' are required
```

#### Omit<T, K>

The Omit utility type removes specified properties from an existing type, effectively creating a new type without them.

```typescript
interface User {
  id: number;
  name: string;
  age: number;
  email: string;
}

type OmittedUser = Omit<User, "age" | "email">;

const omittedUser: OmittedUser = {
  id: 1,
  name: "Leila",
}; // 'age' and 'email' are omitted
```
