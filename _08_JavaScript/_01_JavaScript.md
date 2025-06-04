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

## Functions

* Functions in JavaScript are reusable blocks of code that perform specific tasks, accept inputs via parameters, and may return a value.
* JavaScript is dynamically typed, meaning parameter lists do not specify types (e.g., string, number) and functions do not declare a return type.
* This allows flexibility but requires careful handling to avoid errors, as parameters and return values can be of any type (e.g., numbers, strings, objects, or even undefined).

* Declaration

  ```javascript
  function functionName(parameter1, parameter2, ...) {
    // Code to execute
    return value; // Optional return statement
  }
  ```

  * Key Characteristics
    * **No Parameter Types**: Parameters in the function definition (e.g., name, a, b) do not specify types. You can pass any value (e.g., string, number, object, or null), and JavaScript will accept it without compile-time type checking.
    * **No Return Type**: Functions do not declare what type they return. A function can return any value (e.g., string, number, array, or nothing/undefined), and this can vary based on the function's logic.
    * **Dynamic Typing Implications**: Since types are not enforced, developers must validate inputs or handle varying return types to prevent runtime errors (e.g., checking if a parameter is a number before performing arithmetic).

## Array

Arrays in JavaScript are ordered, zero-indexed lists used to store multiple values in a single variable.

>Note: Unlike many others languages, an array in JavaScript has no type and each element type is assigned dynamically.

* Array Declaration

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

* Common Array Methods

| Command    | Description                                                                 | Syntax                                             |
|------------|-----------------------------------------------------------------------------|----------------------------------------------------|
| Access     | Retrieves the element at the specified index.                               | `arrayName[index]`                                 |
| Modify     | Updates the element at the specified index.                                 | `arrayName[index] = value`                         |
| at()       | Accesses an element at a specified index (supports negative indices).       | `arrayName.at(index)`                              |
| push()     | Adds one or more elements to the end of an array.                           | `arrayName.push(item1, item2, ...)`                |
| pop()      | Removes and returns the last element of an array.                           | `arrayName.pop()`                                  |
| unshift()  | Adds one or more elements to the beginning of an array.                     | `arrayName.unshift(item1, item2, ...)`             |
| shift()    | Removes and returns the first element of an array.                          | `arrayName.shift()`                                |
| forEach()  | Executes a function for each array element.                                 | `arrayName.forEach(callback(element, index))`      |
| map()      | Creates a new array with the results of calling a function on every element.| `arrayName.map(callback(element, index))`          |
| filter()   | Creates a new array with elements that pass a test.                         | `arrayName.filter(callback(element, index))`       |
| indexOf()  | Returns the first index of a specified value, or -1 if not found.           | `arrayName.indexOf(value)`                         |
| includes() | Returns `true` if the array contains a specified value, `false` otherwise.  | `arrayName.includes(value)`                        |
| slice()    | Returns a shallow copy of a portion of an array (non-destructive).          | `arrayName.slice(start, end)`                      |
| splice()   | Adds/removes elements from an array (modifies original array).              | `arrayName.splice(start, deleteCount, item1, ...)` |
| concat()   | Merges two or more arrays, returning a new array.                           | `arrayName.concat(array1, array2, ...)`            |

>Note: The names `push`, `pop`,`shift` and `unshift` came from common operation on data structrures.

* Examples

  ```javascript
  // Initial array with 8 fruits
  let fruits = ["apple", "banana", "orange", "grape", "mango", "kiwi", "pear", "peach"];
  print(fruits);

  // Access: Retrieve element at index 2
  console.log(fruits[2]); // Output: orange

  // Modify: Update element at index 3
  fruits[3] = "cherry";
  console.log(fruits); // Output: ["apple", "banana", "orange", "cherry", "mango", "kiwi", "pear", "peach"]

  // at(): Access last element using negative index
  let lastFruit = fruits.at(-1);
  console.log(lastFruit); // Output: peach

  // push(): Add elements to the end
  fruits.push("pineapple");
  console.log(fruits); // Output: ["apple", "banana", "orange", "cherry", "mango", "kiwi", "pear", "peach", "pineapple"]

  // pop(): Remove and return last element
  let removedFruit = fruits.pop();
  console.log(removedFruit); // Output: pineapple
  console.log(fruits); // Output: ["apple", "banana", "orange", "cherry", "mango", "kiwi", "pear", "peach"]

  // unshift(): Add elements to the beginning
  fruits.unshift("strawberry");
  console.log(fruits); // Output: ["strawberry", "apple", "banana", "orange", "cherry", "mango", "kiwi", "pear", "peach"]

  // shift(): Remove and return first element
  let firstFruit = fruits.shift();
  console.log(firstFruit); // Output: strawberry
  console.log(fruits); // Output: ["apple", "banana", "orange", "cherry", "mango", "kiwi", "pear", "peach"]

  // forEach(): Iterate and log each fruit
  fruits.forEach(fruit => console.log(fruit));
  // Output: apple, banana, orange, cherry, mango, kiwi, pear, peach

  // map(): Create new array with fruit names in uppercase
  let upperFruits = fruits.map(fruit => fruit.toUpperCase());
  console.log(upperFruits); // Output: ["APPLE", "BANANA", "ORANGE", "CHERRY", "MANGO", "KIWI", "PEAR", "PEACH"]

  // filter(): Create new array with fruits having 5 or fewer characters
  let shortFruits = fruits.filter(fruit => fruit.length <= 5);
  console.log(shortFruits); // Output: ["apple", "mango", "kiwi", "pear", "peach"]

  // indexOf(): Find index of "cherry"
  let cherryIndex = fruits.indexOf("cherry");
  console.log(cherryIndex); // Output: 3

  // includes(): Check if "banana" exists
  let hasBanana = fruits.includes("banana");
  console.log(hasBanana); // Output: true

  // slice(): Extract portion from index 1 to 3
  let someFruits = fruits.slice(1, 4);
  console.log(someFruits); // Output: ["banana", "orange", "cherry"]
  console.log(fruits); // Original unchanged: ["apple", "banana", "orange", "cherry", "mango", "kiwi", "pear", "peach"]

  // splice(): Remove 1 element at index 2 and add "lemon"
  // Syntax: splice(start, deleteCount, item1, item2, ..., itemN)
  fruits.splice(2, 1, "lemon");
  console.log(fruits); // Output: ["apple", "banana", "lemon", "cherry", "mango", "kiwi", "pear", "peach"]

  // concat(): Merge with another array
  let moreFruits = ["plum", "lime"];
  let allFruits = fruits.concat(moreFruits);
  console.log(allFruits); // Output: ["apple", "banana", "lemon", "cherry", "mango", "kiwi", "pear", "peach", "plum", "lime"]
  ```

## Exception Handling

* Exception handling in JavaScript allows developers to manage errors gracefully, preventing crashes and enabling better user experiences.
* The primary mechanism for handling exceptions is the `try-catch` statement, with additional constructs like `finally` and `throw`.
* The [`try-catch`](https://www.w3schools.com/js/js_errors.asp) statement is used to handle exceptions (errors) that occur during code execution.
* Code in the `try` block is executed, and if an error occurs, control is passed to the `catch` block to handle the error.
* Syntax

  ```javascript
  try {
  // Code that might throw an error
  } catch (err if err instanceof TypeError) {
    // Handle TypeError
  } catch (err if err instanceof RangeError) {
    // Handle RangeError
  } catch (err) {
    // Handle any other errors
  } finally { // Optional
    // Code that always executes
  }
  ```

* Example

  ```javascript
  try {
    let invalidJSON = "this is not a valid json";
    let result = JSON.parse(invalidJSON); // Throws SyntaxError
  } catch (error) {
    console.log("An error occurred:", error.message); // Output: An error occurred: Unexpected token i in JSON at position 0
  }

  try {
    let data = fetchData(); // Assume this might throw an exception
  } catch (error) {
    console.log("Error:", error.message);
  } finally {
    console.log("Cleanup complete"); // Always runs
  }
  ```

  * The `error` parameter in the `catch` block is an instance of the `Error` object (or its subclasses like `SyntaxError`, `TypeError`, etc.).
  * Common properties of the `error` object include `name` (type of error) and `message` (description of the error).
  * The `finally` block executes regardless of whether an error occurs, making it useful for cleanup tasks.

* **Backward Compatibility**: Multiple catch blocks with specific error types are supported in modern JavaScript (ES2022+). In older environments, you’d typically use a single catch block and check the error type manually with instanceof.

  ```javascript
  try {
    let value = null;
    value.toUpperCase();
  } catch (err) {
    if (err instanceof TypeError) {
      console.log("Caught a TypeError:", err.message);
    } else if (err instanceof RangeError) {
      console.log("Caught a RangeError:", err.message);
    } else {
      console.log("Caught an unexpected error:", err.message);
    }
  }
  ```

* **Throwing Exceptions**
  * The `throw` statement allows you to create custom errors. You can throw any value, but it’s best to throw an `Error` object for consistency.

  ```javascript
  function divide(a, b) {
    if (b === 0) {
      throw new Error("Division by zero is not allowed");
    }
    return a / b;
  }

  try {
    console.log(divide(10, 0));
  } catch (error) {
    console.log("Caught error:", error.message); // Output: Caught error: Division by zero is not allowed
  }
  ```

* **Error Types**
  * `Error`: Generic error.
  * `SyntaxError`: Parsing errors, e.g., invalid JSON.
  * `TypeError`: Incorrect type usage, e.g., calling a non-function.
  * `RangeError`: Value out of valid range, e.g., invalid array length.
  * `ReferenceError`: Accessing undefined variables.
  * `EvalError`: An error has occurred in the eval() function
  * `URIError`: An error in encodeURI() has occurred

## Object-Oriented Programming

* JavaScript supports object-oriented programming (OOP) through objects, prototypes, and, since ES6 (2015), class syntax.
* OOP in JavaScript allows you to model real-world entities using objects that encapsulate data (properties) and behavior (methods).
* JavaScript's OOP is flexible due to its prototype-based inheritance, differing from traditional class-based languages like Java or C++.

* Core OOP Concepts

  | Concept          | Description                                                                 |
  |------------------|-----------------------------------------------------------------------------|
  | **Object**       | A collection of properties (data) and methods (functions) representing an entity. |
  | **Class**        | A blueprint for creating objects with shared properties and methods (introduced in ES6). |
  | **Encapsulation**| Restricting access to an object's internal data, exposing only necessary parts via methods. |
  | **Inheritance**  | Allowing a class to inherit properties and methods from another class using `extends`. |
  | **Polymorphism** | Objects of different classes can be treated as instances of a common superclass, with methods behaving differently. |

* Key Characteristics
  * **Objects**: In JavaScript, objects are dynamic collections of key-value pairs. They can be created using object literals `{}`, constructors, or classes.
  * **Prototype-Based**: JavaScript uses prototypes for inheritance, allowing objects to share properties and methods via a prototype chain.
  * **Classes**: ES6 introduced `class` syntax as a cleaner way to define constructor functions and prototypes, but JavaScript remains prototype-based under the hood.
  * **Dynamic Typing**: Properties and methods can be added or modified at runtime, offering flexibility but requiring careful management.
  * **Private Properties**: Modern JavaScript (ES2022) supports private fields with `#` prefix for encapsulation, though older code may use conventions like `_` for private-like behavior.

* Example

  ```javascript
  // 1. Object Literal: Basic book object
  const book = {
    title: 'JavaScript Guide',
    author: 'Jane Doe',
    pages: 200,
    read() {
      console.log(`Reading ${this.title} by ${this.author}`);
    }
  };
  book.read(); // Output: Reading JavaScript Guide by Jane Doe
  console.log(book.pages); // Output: 200

  // 2. Class: Define a Book class with encapsulation
  class Book {
    #pages; // Private field for encapsulation
    constructor(title, author, pages) {
      this.title = title;
      this.author = author;
      this.#pages = pages;
    }
    getPages() {
      return this.#pages; // Access private field via method
    }
    read() {
      return `Reading ${this.title} by ${this.author}`;
    }
  }
  const book1 = new Book('Learning JS', 'John Smith', 300);
  console.log(book1.read()); // Output: Reading Learning JS by John Smith
  console.log(book1.getPages()); // Output: 300
  // console.log(book1.#pages); // Error: Private field '#pages' must be declared in an enclosing class

  // 3. Inheritance: EBook class extends Book
  class EBook extends Book {
    constructor(title, author, pages, format) {
      super(title, author, pages);
      this.format = format;
    }
    download() {
      return `Downloading ${this.title} in ${this.format} format`;
    }
  }
  const ebook1 = new EBook('JS Advanced', 'Alice Brown', 250, 'PDF');
  console.log(ebook1.read()); // Output: Reading JS Advanced by Alice Brown
  console.log(ebook1.download()); // Output: Downloading JS Advanced in PDF format
  console.log(ebook1.getPages()); // Output: 250

  // 4. Polymorphism: Override read method in AudioBook
  class AudioBook extends Book {
    constructor(title, author, pages, duration) {
      super(title, author, pages);
      this.duration = duration;
    }
    read() {
      return `Listening to ${this.title} for ${this.duration} hours`;
    }
  }
  const audiobook1 = new AudioBook('JS Basics', 'Emma Wilson', 150, 5);
  console.log(audiobook1.read()); // Output: Listening to JS Basics for 5 hours

  // 5. Polymorphism with Array: Treat different objects as Book instances
  const library = [
    new Book('JavaScript Guide', 'Jane Doe', 200),
    new EBook('JS Advanced', 'Alice Brown', 250, 'EPUB'),
    new AudioBook('JS Basics', 'Emma Wilson', 150, 5)
  ];
  library.forEach(item => {
    console.log(item.read());
  });
  // Output:
  // Reading JavaScript Guide by Jane Doe
  // Reading JS Advanced by Alice Brown
  // Listening to JS Basics for 5 hours

  // 6. Dynamic Property Addition: Add a property at runtime
  const book2 = new Book('Dynamic JS', 'Bob Lee', 400);
  book2.rating = 4.5; // Dynamically add a property
  console.log(book2.rating); // Output: 4.5
  console.log(book2.getPages()); // Output: 400

  // 7. Prototype Extension: Add a method to all Book instances
  Book.prototype.summary = function() {
    return `${this.title} by ${this.author}, ${this.getPages()} pages`;
  };
  console.log(book1.summary()); // Output: Learning JS by John Smith, 300 pages
  console.log(ebook1.summary()); // Output: JS Advanced by Alice Brown, 250 pages
  ```

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

## HTML Components Events

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

## HTTP Request

* Demo with ASP.NET Controller
* Async
  * Promise
* CORS

## Building UI with Pure JavaScript

## Using third part components
