# JavaScript Overview

JavaScript is a versatile, high-level programming language primarily used for web development. It runs in browsers and on servers (via Node.js), enabling dynamic, interactive web experiences.

## Who Maintains JavaScript

* JavaScript, officially standardized as [ECMAScript](https://262.ecma-international.org/), is maintained by Ecma International, specifically through its [Technical Committee 39 (TC39)](https://tc39.es/ecma262/).
* TC39 consists of JavaScript developers, implementers, academics, and representatives from major tech companies like Google, Apple, and Microsoft.
* They collaborate to evolve the ECMAScript specification, defining language syntax, semantics, and features.
* The process is open, with proposals discussed publicly on GitHub and ratified annually.
* [GitHub repository](https://github.com/tc39/ecma262)

>Note: JavaScript is an implementation of ECMAScript, and browser vendors (e.g., Chrome’s V8, Firefox’s SpiderMonkey) ensure their engines align with the standard. The open-source community also contributes significantly to its evolution.

## Adding JavaScript to HTML pages

* JavaScript can be added to a web page in several ways.
  * Event Handlers

    ```html
    <!DOCTYPE html>
    <html lang="en">
    <body>
      <button onclick="alert('Hello, world!')">Click Me</button>
    </body>
    </html>
    ```

  * Internal

    ```html
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <script>
            function sayHello() {
                alert('Hello, world!');
            }
        </script>
    </head>
    <body>
        <button onclick="sayHello()">Click Me</button>
    </body>
    </html>
    ```

  * External File

    ```html
    <!DOCTYPE html>
    <html lang="en">
    <head>
        <script src="script.js"></script>
    </head>
    <body>
        <button onclick="sayHello()">Click Me</button>
    </body>
    </html>
    ```

## Debugging

Add the command `debugger;` and the browser will enable debugging functionality on the Dev Tools

## Logging information to the browser console

  ```javascript
  console.log('Hello World!');
  console.log('Hello', 'World');
  ```

## Variables and Data Types

JavaScript uses three keywords to declare variables:

* **`var`**
  * Function-scoped, can be redeclared and reassigned.
  * It is available throughout the entire function in which it’s declared.
  * Less commonly used in modern JavaScript due to scoping issues.
* **`let`**
  * Block-scoped, can be reassigned but not redeclared in the same scope.
  * It is only available inside the {} block in which it’s defined.
  * Preferred for variable declarations.
* **`const`**: Block-scoped, cannot be reassigned or redeclared. Used for constants or values that won’t change.

* Examples:

  ```javascript
  let name = "Alice"; // String
  const age = 25; // Number
  var isStudent = true; // Boolean
  ```

* **Data Types**:

  * **Primitive**: `string`, `number`, `boolean`, `null`, `undefined`, `symbol`, `bigint`.
  * **Reference**: `object` (includes arrays, functions, and more).

* **Key Points**:

* JavaScript is dynamically typed; variables can hold any data type without explicit declaration.
* Use `typeof` to check a variable’s type (e.g., `typeof name // "string"`).

## Basic Operators and Control Flow

* JavaScript supports standard operators for
  * Arithmetic: `+`, `-`, `*`, `/`, `%`
  * Comparison `==`, `===`, `!=`, `!==`, `>`, `<`
  * Logical operations `&&`, `||`, `!`
* **Control Flow**:
  * **Conditionals**
    * `if`, `else if`, `else`
    * `switch`
  * **Loops**
    * `for`
    * `while`
    * `do...while`
    * `for...of`
    * `for...in`
  * **Ternary Operator**
    * `condition ? valueIfTrue : valueIfFalse`.
* Read input from user

  ```javascript
  let name = prompt("Enter your name:");
  console.log(`Hello, ${name}!`);
  ```

* Showing values to the user

  ```javascript
  let name = prompt("Enter your name:");
  alert(`Hello, ${name}!`);
  ```

* **Examples**:
  * [_02_JavaScriptIntro.js](_02_JavaScriptIntro.js)

## Functions

* **Declaration Types**:
  * **Function Declaration**: `function greet(name) { return "Hello, " + name; }`
  * **Function Expression**: `const greet = function(name) { return "Hello, " + name; };`
  * **Arrow Function (ES6)**: `const greet = (name) => "Hello, " + name;`

## Arrays

Arrays are ordered, zero-indexed lists used to store multiple values in a single variable.

* **Creating Arrays**:

  ```javascript
  let fruits = ["apple", "banana", "orange"];
  ```

* **Common Methods**:
  * **Access/Modify**: `fruits[0]` (access), `fruits[1] = "grape"` (modify).
  * **Add/Remove**: `push()`, `pop()`, `unshift()`, `shift()`.
  * **Iterate**: `forEach()`, `map()`, `filter()`, `reduce()`.
  * **Search**: `indexOf()`, `includes()`.
  * **Transform**: `slice()`, `splice()`, `concat()`.
* **Example**:

  ```javascript
  let numbers = [1, 2, 3, 4];
  let doubled = numbers.map(num => num * 2); // [2, 4, 6, 8]
  let evens = numbers.filter(num => num % 2 === 0); // [2, 4]
  ```

## Objects and Collections

Objects store key-value pairs, where keys are strings (or symbols) and values can be any data type.

* **Creating Objects**:

  ```javascript
  let person = {
    name: "Bob",
    age: 30,
    greet() { return `Hi, I'm ${this.name}`; }
  };
  ```

* **Accessing/Modifying**:
  * Dot notation: `person.name`
  * Bracket notation: `person["age"]`
  * Add/Update: `person.job = "developer";`

* **Collections**:
* **Map**: Stores key-value pairs, where keys can be any type (unlike objects). Useful for dynamic keys.

  ```javascript
  let map = new Map();
  map.set("key1", "value1");
  map.set(42, "answer");
  console.log(map.get(42)); // "answer"
  ```

* **Key Methods**:
  * **Map**: `set()`, `get()`, `has()`, `delete()`, `clear()`.

* **Set**: Stores unique values of any type.

  ```javascript
  let set = new Set([1, 2, 2, 3]);
  console.log(set); // Set {1, 2, 3}
  set.add(4); // Add new value
  ```

* **Key Methods**:
  * **Set**: `add()`, `has()`, `delete()`, `clear()`.

* **Template Literals**: String interpolation with backticks.

  ```javascript
  let greeting = `Hello, ${name}!`; // "Hello, Alice!"
  ```
