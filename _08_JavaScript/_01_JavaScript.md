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

* **Data Types**:

  * **Primitive**: `string`, `number`, `boolean`, `null`, `undefined`, `symbol`, `bigint`.
  * **Reference**: `object` (includes arrays, functions, and more).
  * Examples:

* **Key Points**:
  * JavaScript is dynamically typed; variables can hold any data type without explicit declaration.
  * Use `typeof` to check a variable’s type (e.g., `typeof name // "string"`).

  ```javascript
  let name = "Alice"; // String
  console.log(name, typeof name);
  let age = 25; // Number
  console.log(age, typeof age);
  let price = 19.99; // Number
  console.log(price, typeof price)
  let isStudent = true; // Boolean
  console.log(isStudent, typeof isStudent)
  let product = null; // null
  console.log(product, typeof product)
  ```

* Read input from user

  ```javascript
  name = prompt("What is your name?");
  console.log(`Hello ${name}!`);
  ```

* Showing values to the user

  ```javascript
  alert(`Hello, ${name}!`);
  ```

## Basic Operators and Control Flow

* JavaScript supports standard operators for
  * Arithmetic: `+`, `-`, `*`, `/`, `%`

    ```javascript
    let n1 = 10;
    let n2 = 3;
    let result1 = n1 / n2; // 10 ÷ 3 ≈ 3.333...
    console.log(result1);
    let result2 = Math.floor(n1 / n2)
    console.log(result2);
    ```

  * Comparison `==`, `===`, `!=`, `!==`, `>`, `<`
  * Logical operations `&&`, `||`, `!`
* **Control Flow**:
  * **Conditionals**
    * `if`, `else if`, `else`

      ```javascript
      if (condition) {
        // Code to execute if condition is true
      } else if (anotherCondition) {
        // Code to execute if anotherCondition is true
      } else {
        // Code to execute if no conditions are true
      }
      ```

    * `switch`: statement evaluates an expression and executes the code block of the matching case. The break statement exits the switch block. If no cases match, the default block runs.

      ```javascript
      switch (expression) {
        case value1:
          // Code to execute if expression === value1
          break;
        case value2:
          // Code to execute if expression === value2
          break;
        default:
          // Code to execute if no cases match
      }
      ````

  * **Loops**
    * `for`: initializes a counter, checks a condition, and updates the counter after each iteration. It runs until the condition is false.

      ```javascript
      for (initialization; condition; update) {
        // Code to execute repeatedly while condition is true
      }
      ```

    * `while`: executes the block of code as long as the condition is true

    ```javascript
    while (condition) {
      // Code to execute while condition is true
    }
    ```

    * `do...while`: executes the code block at least once, then repeats as long as the condition is true.

    ```javascript
    do {
      // Code to execute at least once
    } while (condition);
    ```

    * `for...of`: loop iterates over iterable objects like arrays or strings, assigning each element to the variable.

    ```javascript
    for (variable of iterable) {
      // Code to execute for each element in iterable
    }
    ```

    * `for...in`: iterates over the enumerable properties of an object, assigning each property name to the variable.

    ```javascript
    for (variable in object) {
      // Code to execute for each property in object
    }
    ```

  * **Ternary Operator**
    * `condition ? valueIfTrue : valueIfFalse`.

* **Examples**:
  * [_02_JavaScriptIntro.html](_02_JavaScriptIntro.html)
  * [_02_JavaScriptIntro.js](_02_JavaScriptIntro.js)

## Functions

* **Declaration Types**:
  * **Function Declaration**:
  
    ```javascript
    function functionName(parameter1, parameter2, ...) {
      // Code to execute
      return value; // Optional return statement
    }
    ```

## Array Operations

Arrays in JavaScript are ordered, zero-indexed lists used to store multiple values in a single variable.

* Creating Arrays

  ```javascript
  let arrayName = [element1, element2, ...];
  ```

  * Examples:

  ```javascript
  // String array
  let fruits = ["apple", "banana", "orange"];
  console.log(fruits); // Output: ["apple", "banana", "orange"]

  // Integer array
  let numbers = [1, 2, 3, 4, 5];
  console.log(numbers); // Output: [1, 2, 3, 4, 5]

  // Decimal array
  let prices = [9.99, 14.50, 3.25];
  console.log(prices); // Output: [9.99, 14.5, 3.25]

  // Boolean array
  let flags = [true, false, true];
  console.log(flags); // Output: [true, false, true]

  // Mixed array
  let mixed = ["apple", 1, 9.99, true];
  console.log(mixed);
  ```

* Common Methods

  * Access/Modify
    * **Access**: `arrayName[index]` retrieves the element at the specified index.
    * **Modify**: `arrayName[index] = value` updates the element at the specified index.

    * **Examples**:

    ```javascript
    // Accessing elements
    let fruits = ["apple", "banana", "orange"];
    console.log(fruits[0]); // Output: apple
    console.log(fruits[2]); // Output: orange

    // Modifying elements
    let numbers = [1, 2, 3];
    numbers[1] = 10; // Update index 1
    console.log(numbers); // Output: [1, 10, 3]

    let prices = [9.99, 14.50];
    prices[0] = 12.99; // Update index 0
    console.log(prices); // Output: [12.99, 14.5]

    let flags = [true, false];
    flags[1] = true; // Update index 1
    console.log(flags); // Output: [true, true]

    let lastFruit = fruits.at(-1);
    console.log(lastFruit);
    ```

  * Add/Remove
    * **push()**: Adds one or more elements to the end of an array.
    * **pop()**: Removes and returns the last element of an array.
    * **unshift()**: Adds one or more elements to the beginning of an array.
    * **shift()**: Removes and returns the first element of an array.
  * **Examples**:

    ```javascript
    // push(): Adding elements
    let fruits = ["apple", "banana"];
    fruits.push("orange"); // Add to end
    console.log(fruits); // Output: ["apple", "banana", "orange"]

    let numbers = [1, 2];
    numbers.push(3, 4); // Add multiple integers
    console.log(numbers); // Output: [1, 2, 3, 4]

    // pop(): Removing last element
    let prices = [9.99, 14.50, 3.25];
    let lastPrice = prices.pop(); // Remove and return last element
    console.log(lastPrice); // Output: 3.25
    console.log(prices); // Output: [9.99, 14.5]

    // unshift(): Adding to beginning
    let flags = [true, false];
    flags.unshift(false); // Add to start
    console.log(flags); // Output: [false, true, false]

    // shift(): Removing first element
    let scores = [85, 90, 95];
    let firstScore = scores.shift(); // Remove and return first element
    console.log(firstScore); // Output: 85
    console.log(scores); // Output: [90, 95]
    ```

  * Iterate
    * **forEach()**: Executes a function for each array element.
    * **map()**: Creates a new array with the results of calling a function on every element.
    * **filter()**: Creates a new array with elements that pass a test.
    * **Examples**:

      ```javascript
      // forEach(): Iterate and log elements
      let fruits = ["apple", "banana", "orange"];
      fruits.forEach(fruit => console.log(fruit));
      // Output: apple, banana, orange

      // map(): Create new array with modified elements
      let numbers = [1, 2, 3];
      let doubled = numbers.map(num => num * 2);
      console.log(doubled); // Output: [2, 4, 6]

      // filter(): Create new array with filtered elements
      let prices = [9.99, 14.50, 3.25, 20.00];
      let affordable = prices.filter(price => price < 10);
      console.log(affordable); // Output: [9.99, 3.25]
      ```

  * Search
    * **indexOf()**: Returns the first index of a specified value, or -1 if not found.
    * **includes()**: Returns `true` if the array contains a specified value, `false` otherwise.
    * **Examples**:

      ```javascript
      // indexOf(): Find index of element
      let fruits = ["apple", "banana", "orange", "banana"];
      let index = fruits.indexOf("banana");
      console.log(index); // Output: 1

      let numbers = [1, 2, 3, 2];
      let notFound = numbers.indexOf(4);
      console.log(notFound); // Output: -1

      // includes(): Check if element exists
      let prices = [9.99, 14.50, 3.25];
      let hasPrice = prices.includes(14.50);
      console.log(hasPrice); // Output: true

      let flags = [true, false, true];
      let hasFalse = flags.includes(false);
      console.log(hasFalse); // Output: true
      ```

  * Transform
    * **slice()**: Returns a shallow copy of a portion of an array (non-destructive).
    * **splice()**: Adds/removes elements from an array (modifies original array).
      * array.splice(start, deleteCount, item1, item2, ...)
    * **concat()**: Merges two or more arrays, returning a new array.
    * **Examples**:

      ```javascript
      // slice(): Extract portion of array
      let fruits = ["apple", "banana", "orange", "grape"];
      let someFruits = fruits.slice(1, 3); // From index 1 to 2
      console.log(someFruits); // Output: ["banana", "orange"]
      console.log(fruits); // Original unchanged: ["apple", "banana", "orange", "grape"]

      // splice(): Remove and/or add elements
      let numbers = [1, 2, 3, 4, 5];
      numbers.splice(2, 1, 10, 20); // Remove 1 element at index 2, add 10 and 20
      console.log(numbers); // Output: [1, 2, 10, 20, 4, 5]

      // concat(): Merge arrays
      let prices = [9.99, 14.50];
      let morePrices = [3.25, 19.99];
      let allPrices = prices.concat(morePrices);
      console.log(allPrices); // Output: [9.99, 14.5, 3.25, 19.99]

      let flags = [true, false];
      let moreFlags = [false, true];
      let allFlags = flags.concat(moreFlags);
      console.log(allFlags); // Output: [true, false, false, true]
      ```

## Math Functions

The `Math` object provides static methods for mathematical operations.

| Method | Description |
|--------|-------------|
| `Math.floor(number)` | Returns the largest integer less than or equal to the number (rounds down). |
| `Math.ceil(number)` | Returns the smallest integer greater than or equal to the number (rounds up). |
| `Math.round(number)` | Rounds the number to the nearest integer (0.5 rounds up). |
| `Math.trunc(number)` | Returns the integer part of a number by removing the decimal part (no rounding). |
| `Math.abs(number)` | Returns the absolute (positive) value of a number. |
| `Math.max(value1, value2, ...)` | Returns the largest value from a set of numbers. |
| `Math.min(value1, value2, ...)` | Returns the smallest value from a set of numbers. |
| `Math.pow(base, exponent)` | Returns the base raised to the exponent power. |
| `Math.sqrt(number)` | Returns the square root of a non-negative number. |
| `Math.random()` | Returns a random floating-point number between 0 (inclusive) and 1 (exclusive). |

## Document Object

The document object in JavaScript represents the entire HTML document loaded in a browser window.
It is a part of the Document Object Model (DOM) and serves as the entry point for accessing and manipulating HTML elements.
The document object provides properties and methods to interact with the structure, content, and styles of a web page.

| Property/Method | Description |
|-----------------|-------------|
| `document.getElementById(id)` | Returns the element with the specified `id`, or `null` if not found. |
| `document.getElementsByClassName(className)` | Returns a live HTMLCollection of elements with the specified class name. |
| `document.getElementsByTagName(tagName)` | Returns a live HTMLCollection of elements with the specified tag name (e.g., `div`, `input`). |
| `document.querySelector(selector)` | Returns the first element matching the CSS selector, or `null` if not found. |
| `document.querySelectorAll(selector)` | Returns a static NodeList of all elements matching the CSS selector. |
| `document.body` | Returns the `<body>` element of the document. |
| `document.documentElement` | Returns the `<html>` element of the document. |
| `document.title` | Gets or sets the title of the document (text in the `<title>` tag). |
| `document.createElement(tagName)` | Creates a new HTML element with the specified tag name. |
| `document.createTextNode(text)` | Creates a text node with the specified text content. |

## Accessing HTML components

In JavaScript, you can reference HTML elements (components) in the Document Object Model (DOM) to interact with them programmatically. This is essential for tasks like event handling, modifying content, or updating styles.

* Methods to Reference HTML Components
  * document.getElementById()
    * Retrieves a single element by its unique id attribute. Returns null if no element is found.
    * ```let element = document.getElementById('id');```
  * document.getElementsByClassName()
    * Returns an HTMLCollection (array-like) of elements with the specified class name.
    * ```let elements = document.getElementsByClassName('className');```
  * document.getElementsByTagName()
    * Returns an HTMLCollection of elements with the specified tag name (e.g., div, input).
    * ```let elements = document.getElementsByTagName('tagName');```
  * document.querySelector()
    * Returns the first element matching a CSS selector (e.g., #id, .class, tag). Returns null if no match is found.
    * ```let element = document.querySelector('selector');```
  * document.querySelectorAll()
    * Returns a NodeList (array-like) of all elements matching a CSS selector.
    * ```let elements = document.querySelectorAll('selector');```

## Event Binding for HTML Components

In JavaScript, events are actions or occurrences (e.g., clicks, key presses, mouse movements) that can be detected and handled by binding JavaScript functions to HTML elements.
Events allow interactivity between users and web pages.

### Common Events

| Event Category | Event | Description |
|----------------|-------|-------------|
| **Mouse Events** | `click` | Fires when an element is clicked. |
| | `dblclick` | Fires when an element is double-clicked. |
| | `mouseover` | Fires when the mouse pointer enters an element. |
| | `mouseout` | Fires when the mouse pointer leaves an element. |
| | `mousemove` | Fires when the mouse pointer moves over an element. |
| **Keyboard Events** | `keydown` | Fires when a key is pressed down. |
| | `keyup` | Fires when a key is released. |
| | `keypress` | Fires when a key that produces a character is pressed (less common, deprecated in some contexts). |
| **Form Events** | `submit` | Fires when a form is submitted. |
| | `change` | Fires when an input element’s value changes and loses focus (e.g., `<input>`, `<select>`). |
| | `input` | Fires immediately when an input element’s value changes (e.g., typing in `<input>`). |
| | `focus` | Fires when an element gains focus (e.g., clicking into an `<input>`). |
| | `blur` | Fires when an element loses focus. |
| **Window/Document Events** | `load` | Fires when a page or resource (e.g., image) finishes loading. |
| | `resize` | Fires when the browser window is resized. |
| | `scroll` | Fires when the user scrolls the page or an element. |

### Event Binding Methods

* Events can be bound to HTML elements in three primary ways:
  * Inline Event Handlers (in HTML)
    * The event handler is defined directly in the HTML attribute. Less recommended due to mixing HTML and JavaScript.
    * ```<button onclick="myFunction()">Click me</button>```
  * DOM Property Assignment
    * Assign a function to an element’s event property in JavaScript. Simple but only allows one handler per event.
    * ```element.onclick = function() { /* code */ };```
  * addEventListener (Preferred)
    * Attaches an event listener to an element, allowing multiple handlers for the same event and better control (e.g., removing listeners).
    * ```element.addEventListener('event', function() { /* code */ });```
