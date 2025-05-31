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

>Warning: It is possible to declare a variable without explicitly using `var`, `let`, or `const`, but this is generally a bad practice and depends on the context. This can be avoid by using `"use strict";` at the begin of the JavaScript file.

* It is recommended to use `"use strict";` at the beging of your JavaScript files
  * **Prevents Implicit Globals**: Strict mode throws a ReferenceError when assigning to undeclared variables, avoiding accidental global variables (like overwriting window.name in browsers).
  * **Eliminates Silent Errors**: Strict mode turns certain silent failures into explicit errors, such as assigning to read-only properties or using reserved words incorrectly.
  * **Disallows Deprecated Features**: It prevents the use of outdated or problematic features.
  * **Better Performance**: Some JavaScript engines optimize code better in strict mode due to its stricter rules.

* **Data Types**
  * **Primitive Types**
    * `string`: Represents textual data (e.g., "hello").
    * `number`: Represents numeric values, including integers and floating-point numbers (e.g., 42, 3.14).
    * `boolean`: Represents true or false.
    * `null`: Represents the intentional absence of any value.
    * `undefined`: Indicates a variable that has been declared but not assigned a value.
    * `symbol`: Represents a unique and immutable identifier (introduced in ES6).
    * `bigint`: Represents whole numbers larger than the number type can safely handle (introduced in ES2020).
  * **Reference Type**
    * `object`: Includes plain objects (`{}`), arrays (`[]`), functions, dates, regular expressions, and more.
    * Objects are mutable and stored by reference.
  * **Key Points**
    * JavaScript is dynamically typed; variables can hold any data type without explicit declaration.
    * Use `typeof` to check a variable’s type (e.g., `typeof name // "string"`).

  * Examples

  ```javascript
  // Variables
  let firstName = "Jose"; // String
  console.log(firstName, typeof firstName);
  let age = 25; // Number
  console.log(age, typeof age);
  let price = 19.99; // Number
  console.log(price, typeof price);
  let isStudent = true; // Boolean
  console.log(isStudent, typeof isStudent);
  let product = null; // null
  console.log(product, typeof product);

  // The same variable can receive different types
  let mutantVar = "I am a string";
  console.log(mutantVar, typeof mutantVar);
  mutantVar = 10;
  console.log(mutantVar, typeof mutantVar);
  mutantVar = true;
  console.log(mutantVar, typeof mutantVar);
  ```

>Note: When JavaScript is running in a HTML page, `name` represents a property for the Windows Name: `window.name`. Avoid using name as a variable or function name in JavaScript, especially in browser environments, to prevent conflicts with window.name or other DOM-related properties.

* Read input from user

  ```javascript
  firstName = prompt("What is your name?");
  console.log(`Hello ${firstName}!`);
  ```

* Showing values to the user

  ```javascript
  alert(`Hello, ${firstName}!`);
  ```

Below is the updated section with descriptions for each Arithmetic, Comparison, and Logical operator, with each operator described on a single line, as requested.

## Basic Operators

* Arithmetic:
  * `+`: Adds two numbers or concatenates strings.
  * `-`: Subtracts one number from another.
  * `*`: Multiplies two numbers.
  * `/`: Divides one number by another.
  * `%`: Returns the remainder of division between two numbers.
* Comparison:
  * `==`: Checks if two values are equal, with type coercion.
  * `===`: Checks if two values are equal and of the same type, without coercion.
  * `!=`: Checks if two values are not equal, with type coercion.
  * `!==`: Checks if two values are not equal or not of the same type, without coercion.
  * `>`: Checks if the left value is greater than the right value.
  * `<`: Checks if the left value is less than the right value.
  * `>=`: Checks if the left value is greater than or equal to the right value.
  * `<=`: Checks if the left value is less than or equal to the right value.
  * Examples of `==`, `===`, `!=` and `!==`

    ```javascript
    // Loose equality (==) - Allows type coercion
    console.log(5 == "5"); // true (string "5" is coerced to number 5)
    console.log(true == 1); // true (boolean true is coerced to number 1)
    console.log(null == undefined); // true (special case: null and undefined are considered equal with ==)

    // Strict equality (===) - No type coercion, checks value and type
    console.log(5 === "5"); // false (number 5 and string "5" have different types)
    console.log(true === 1); // false (boolean true and number 1 have different types)
    console.log(null === undefined); // false (null and undefined have different types)

    // Loose inequality (!=) - Allows type coercion
    console.log(5 != "5"); // false (string "5" is coerced to number 5, so they're equal)
    console.log(true != 1); // false (boolean true is coerced to number 1, so they're equal)
    console.log(null != undefined); // false (null and undefined are considered equal with !=)

    // Strict inequality (!==) - No type coercion, checks value and type
    console.log(5 !== "5"); // true (number 5 and string "5" have different types)
    console.log(true !== 1); // true (boolean true and number 1 have different types)
    console.log(null !== undefined); // true (null and undefined have different types)
    ```

    * Key Points
      * `==` and `!=`: Perform type coercion, converting operands to the same type before comparing (e.g., string to number, boolean to number).
      * `===` and `!==`: Do not perform type coercion, requiring both value and type to match (or differ for !==).
      * Use `===` and `!==` in modern JavaScript to avoid unexpected results from coercion, making code more predictable.

* Logical operations:
  * `&&`: Returns true if both operands are true (logical AND).
  * `||`: Returns true if at least one operand is true (logical OR).
  * `!`: Returns the opposite boolean value of the operand (logical NOT).

## Control Flow

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
  * `for`: initializes a counter, checks a condition, and updates the counter after each iteration.
    It runs until the condition is false.

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
  * [_02_Intro.html](_02_Intro.html)
  * [_02_Intro.js](_02_Intro.js)

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

>Note: Unlike many others languages, an array in JavaScript has no type and each index has the type assigned dynamically.

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
    let fruits = ["apple", "banana", "orange", "jaca"];
    console.log(fruits);
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
| `document.title` | Gets or sets the title of the document (text in the `<title>` tag). |
| `document.body` | Returns the `<body>` element of the document. |
| `document.name` | Returns the `name` element of the document. A variable called `name` is define for all html page |
| `document.documentElement` | Returns the `<html>` element of the document. |
| `document.getElementById(id)` | Returns the element with the specified `id`, or `null` if not found. |
| `document.getElementsByClassName(className)` | Returns a live HTMLCollection of elements with the specified class name. |
| `document.getElementsByTagName(tagName)` | Returns a live HTMLCollection of elements with the specified tag name (e.g., `div`, `input`). |
| `document.querySelector(selector)` | Returns the first element matching the CSS selector, or `null` if not found. |
| `document.querySelectorAll(selector)` | Returns a static NodeList of all elements matching the CSS selector. |
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
