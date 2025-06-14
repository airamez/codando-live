# JavaScript Overview

JavaScript is a versatile, high-level programming language primarily used for web development. It runs in browsers and on servers (via Node.js), enabling dynamic, interactive web experiences.

## Who Maintains JavaScript

* JavaScript, officially standardized as [ECMAScript](https://262.ecma-international.org/), is maintained by Ecma International, specifically through its [Technical Committee 39 (TC39)](https://tc39.es/ecma262/).
* TC39 consists of JavaScript developers, implementers, academics, and representatives from major tech companies like Google, Apple, and Microsoft.
* They collaborate to evolve the ECMAScript specification, defining language syntax, semantics, and features.
* The process is open, with proposals discussed publicly on GitHub and ratified annually.
* [GitHub repository](https://github.com/tc39/ecma262)

>Note: JavaScript is an implementation of ECMAScript, and browser vendors (e.g., Chrome’s V8, Firefox’s SpiderMonkey) ensure their engines align with the standard. The open-source community also contributes significantly to its evolution.

* **TIP**: There are many options to play with JavaScript directly in the browser. This is a good one:
  * <https://playcode.io/javascript>

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
It is a part of the [Document Object Model (DOM)](https://www.w3schools.com/js/js_htmldom.asp) and serves as the entry point for accessing and manipulating HTML elements.
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

## A CRUD Demo: StormWind Product

The demo is a single-page web application that allows users to manage products with the following features:

* **Create**: Add new products via a form.
* **Read**: Display a list of products in a table.
* **Update**: Edit existing products using the same form.
* **Delete**: Remove products from the list.

The application uses the Northwind dataset, with a form for input and a table to display products, interacting with a `DataAccessService` for data operations.

* Files
  * HTML: [_05_ProductCRUD.html](./_05_ProductCRUD.html)
    * Defines the user interface with a form for product input and a table for listing products.
    * **Structure**: Contains a form (`#productForm`) with fields for product details (name, supplier, category, quantity, price, discontinued) and a table (`#productsTable`) for listing products.
    * **Key Elements**:
      * `<input type="hidden" id="productId">`: Stores the ID of the product being edited.
      * `<button id="cancelEdit">`: Hidden by default, shown during edit mode to reset the form.
      * `<script defer type="module">`: Loads the JavaScript as a module to support ES6 imports.
  * CSS: [_05_ProductCRUD.css`](./_05_ProductCRUD.css)
    * Styles the application (not provided but referenced in HTML).
  * Page JavaScript: [_05_ProductCRUD.js](./_05_ProductCRUD.js)
    * Handles DOM manipulation, event listeners, and interactions with the service layer.
    * **Imports**: Uses `DataAccessService` from `_05_ProductService.js` to handle data operations.
    * **Initialization**:
      * On `DOMContentLoaded`, populates dropdowns for suppliers and categories, renders the product list, and sets up form submission and cancel button listeners.
    * **Event Handling**:
      * **Form Submission (`handleSubmit`)**: Collects form data, creates or updates a product based on whether `productId` exists, and refreshes the product list.
      * **Edit/Delete Buttons**: Uses event delegation to handle clicks on dynamically created buttons. `editProduct` populates the form with product data; `deleteProduct` removes a product and refreshes the table.
    * **Rendering (`renderProducts`)**: Clears and repopulates the table body with product data, attaching event listeners to edit/delete buttons.
    * **Form Reset (`resetForm`)**: Clears form inputs and hides the cancel button after submission or cancellation.
  * Service JavaScript: [_05_ProductService.js](./_05_ProductService.js)
    * Manages data operations (assumed to handle API calls or mock data).
    * Simulate (Mock) a dataset or an API (e.g., Northwind API) to manage product data.
    * Provides methods like:
      * `getProducts()`
      * `getProductById(id)`
      * `addProduct(product)`
      * `updateProduct(product)`
      * `deleteProduct(id)`
      * `getSuppliers()`
      * `getSupplier(id)`
      * `getCategories()`
      * `getCategory(id)`

* Live Server Extension
  * When developing web applications locally, browsers impose CORS restrictions to prevent unauthorized cross-origin requests. If you open the HTML file directly (e.g., `file://`), JavaScript cannot fetch data from APIs or local JSON files due to these restrictions. Live Server creates a local web server (e.g., `http://localhost:5500`), allowing the application to make requests without CORS issues. This mimics a production environment and is critical for testing applications that rely on external data sources.
  * **Why Live Server is Needed**: When running the application locally (e.g., via `file://` protocol), browsers enforce CORS (Cross-Origin Resource Sharing) restrictions, which block requests to local files or APIs. The Live Server extension for Visual Studio Code (or similar tools) serves the files over `http://localhost`, bypassing CORS issues by simulating a web server environment. This ensures the application can fetch data or interact with APIs without security errors.
  * **Run the Application**: Right click on `_05_ProductCRUD.html` and select the option `Open with Live Server`.

  ![Live Server Extension](images/LiveServerExtension.png)

  >Note: Try to open the `_08_JavaScript/_05_ProductCRUD.html` directly from the browser.

## HTTP Requests

* HTTP (Hypertext Transfer Protocol) is the foundation of data communication on the web.
* HTTP requests allow your application to communicate with servers to fetch or send data, such as retrieving JSON from an API or submitting form data.
* We had classes about HTTP Request already
  * [HTTP Request from CSharp](https://github.com/airamez/codando-live/blob/main/_01_CSharp/_20_API/_09_HttpRequest.cs)
  * [HTTP from Web API classes](https://github.com/airamez/codando-live/blob/main/_06_WebAPI/_00_WebAPI.md#http---hyper-text-transfer-protocol)
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
  * An Web API (Web Application Programming Interface) is a server endpoint that provides data or services.
  * This is public API used for tests and demos:
    * `https://jsonplaceholder.typicode.com`

### XMLHttpRequest (XHR)

* [XMLHttpRequest](https://developer.mozilla.org/en-US/docs/Web/API/XMLHttpRequest) is an older method for making HTTP requests in JavaScript.
* While less common today, understanding it helps grasp the evolution of HTTP handling.
* Sintaxe

  ```javascript
  const xhr = new XMLHttpRequest();
  xhr.open(method, url, true); // true for asynchronous

  // Set headers
  xhr.setRequestHeader('Content-Type', 'application/json');

  // Handle response
  xhr.onload = () => {
    if (xhr.status >= 200 && xhr.status < 300) {
      resolve(JSON.parse(xhr.responseText)); // Parse JSON response
    } else {
      reject(new Error(`HTTP error! Status: ${xhr.status}`));
    }
  };

  // Handle network errors
  xhr.onerror = () => reject(new Error('Network error occurred'));

  // Send request
  xhr.send(data ? JSON.stringify(data) : null);  
  ```

* Example: Fetching Users with XHR

  ```javascript
  const xhr = new XMLHttpRequest();
  xhr.open('GET', 'https://jsonplaceholder.typicode.com/users', true);
  xhr.onreadystatechange = function () {
    if (xhr.readyState === 4 && xhr.status === 200) {
      const data = JSON.parse(xhr.responseText);
      console.log(data);
    }
  };
  xhr.send();
  ```

* Key Points
  * `open(method, url, async)`: Initializes the request.
  * `readyState`: Indicates the request's status (4 = done).
  * `status`: HTTP status code.
  * `responseText`: The server's response as text.
  * **Drawbacks**: XHR is verbose and lacks modern features like Promises.

### The Fetch API

* The [fetch API](https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API) is a modern, promise-based way to make HTTP requests.
* It's simpler and more flexible than XHR.
* The nature of fetch API is **Async**
* Sintaxe:

  ```javascript
  return fetch(url, {
    method: method, // GET, POST, PUT, DELETE, etc.
    headers: {
      'Content-Type': 'application/json',
      'Authorization': 'Bearer your-token-here', // Example auth header
    },
    body: data ? JSON.stringify(data) : null // Include body for POST/PUT
  })
    .then(response => {
      if (!response.ok) {
        throw new Error(`HTTP error! Status: ${response.status}`);
      }
      return response.json(); // Parse JSON response
    })
    .catch(error => {
      console.error('Error:', error);
      throw error;
    });
  ```

>Note: For Get resquests the `method` parameter is optional

* Basic GET Request

  ```javascript
  fetch('https://jsonplaceholder.typicode.com/users')
    .then(response => response.json())
    .then(data => console.log(data))
    .catch(error => console.error('Error:', error));
  ```

* Key Points
  * `fetch` returns a Promise that resolves to a `Response` object.
  * Use `.json()` to parse the response body as JSON.
  * Handle errors in the `.catch` block.
* POST Request Example

  ```javascript
  const data = {
      title: 'New Post',
      body: 'This is a new post.',
      userId: 1,
    }
  fetch('https://jsonplaceholder.typicode.com/posts', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    body: JSON.stringify(data),
  })
    .then(response => response.json())
    .then(data => console.log(data))
    .catch(error => console.error('Error:', error));
  ```

* Fetch Options
  * `method`: HTTP method (e.g., 'GET', 'POST').
  * `headers`: Request headers (e.g., for content type).
  * `body`: Data to send (must be stringified for JSON).

### Promises in HTTP Requests

* [Promises](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/Promise) are a way to handle asynchronous operations, like HTTP requests, in a cleaner way than callbacks.
* A Promise represents a value that may be available now, in the future, or never. It has three states:
  * **Pending**: Initial state.
  * **Fulfilled**: Operation completed successfully.
  * **Rejected**: Operation failed.

* **Chaining Promises**

  ```javascript
  // Initiate a GET request to fetch a list of users from the JSONPlaceholder API
  fetch('https://jsonplaceholder.typicode.com/users')
    // Handle the response from the first fetch request
    .then(response => {
      // Check if the response status is not OK (e.g., 404, 500); throw an error if so
      if (!response.ok) throw new Error('Network response was not ok');
      // Parse the response body as JSON and return the resulting Promise
      return response.json();
    })
    // Handle the parsed JSON data (array of users) from the first request
    .then(data => {
      // Log the array of users to the console for debugging
      console.log(data);
      // Initiate a second GET request to fetch posts for the first user, using their ID
      return fetch(`https://jsonplaceholder.typicode.com/posts?userId=${data[0].id}`);
    })
    // Handle the response from the second fetch request (posts)
    .then(response => response.json())
    // Handle the parsed JSON data (array of posts) from the second request
    .then(posts => console.log(posts))
    // Catch and handle any errors that occur in the Promise chain
    .catch(error => console.error('Error:', error));
  ```

* Async/Await

`async/await` is syntactic sugar for Promises, making asynchronous code look synchronous.

```javascript
async function getUserAndPosts() {
  try {
    const userResponse = await fetch('https://jsonplaceholder.typicode.com/users/1');
    if (!userResponse.ok) throw new Error('Failed to fetch user');
    const user = await userResponse.json();
    
    const postsResponse = await fetch(`https://jsonplaceholder.typicode.com/posts?userId=${user.id}`);
    const posts = await postsResponse.json();
    
    console.log(user, posts);
  } catch (error) {
    console.error('Error:', error);
  }
}
```

* Key Points
  * Use `try/catch` for error handling with `async/await`.
  * `await` can only be used inside `async` functions.

### Promise All

* Promise.all takes an array of Promises and resolves when all complete, returning an array of results.
* Enables concurrent HTTP requests, improving performance over sequential requests.
* Single .catch block handles errors from any failed request in the Promise.all chain.
* Ideal for fetching related data from multiple API endpoints simultaneously.
* Efficient asynchronous for real-world applications like dashboards or feeds.

```javascript
function multiUserPostsRequest() {
  // Create an array of Promises for fetching posts
  const promises = [
    fetch('https://jsonplaceholder.typicode.com/posts?userId=1'),
    fetch('https://jsonplaceholder.typicode.com/posts?userId=2'),
    fetch('https://jsonplaceholder.typicode.com/posts?userId=3')
  ];
  // Wait for all Promises to resolve and handle results
  Promise.all(promises.map(promise =>
    promise.then(response => response.json())
  ))
    .then(results => displayResult(results.flat()))
    .catch(error => displayResult({ error: `Failed to fetch posts:${error}` }));
}
```

### Demo

* Files
  * [_08_JavaScript/_06_HttpRequest.css](./_06_HttpRequest.css)
  * [_08_JavaScript/_06_HttpRequest.html](./_06_HttpRequest.html)
  * [_08_JavaScript/_06_HttpRequest.js](./_06_HttpRequest.js)

>Note: Show the same requests on Postman

## A CRUD Demo (with HTTP Requests): StormWind Product

* Completing the CRUD demo by calling controllers to persis the data.
* A controller to handler Product CRUD operations was created.

![Product CRUD](./images/Products.png)

* Files
  * [_06_WebAPI/Controllers/ProductNortWindController.cs](../_06_WebAPI/Controllers/ProductNortWindController.cs)
  * [_08_JavaScript/_07_HttpRequest.css](./_07_HttpRequest.css)
  * [_08_JavaScript/_07_HttpRequest.html](./_07_HttpRequest.html)
  * [_08_JavaScript/_07_HttpRequest.js](./_07_HttpRequest.js)

## Cross-Origin Resource Sharing (CORS) Overview

CORS (Cross-Origin Resource Sharing) is a security mechanism implemented by browsers to control how web pages in one domain can request and interact with resources from another domain. It prevents unauthorized cross-origin requests while allowing legitimate ones through a set of HTTP headers.

* Reference Materials
  * [MDN Web Docs: CORS](https://developer.mozilla.org/en-US/docs/Web/HTTP/CORS)
  * [ASP.NET Core CORS Documentation](https://docs.microsoft.com/en-us/aspnet/core/security/cors)
  * [Fetch API Documentation](https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API)
  * [Understanding CORS (Blog)](https://www.telerik.com/blogs/understanding-cors)

### Why CORS Matters

* **Security**: Protects users by restricting which origins can access resources.
* **Flexibility**: Enables controlled sharing of resources across different domains.
* **Common Use Case**: Web applications making API calls to a different domain (e.g., a frontend at `http://web-application:3000` calling an API at `http://api.example.com`).

### How CORS Works

1. **Browser Makes a Request**: When JavaScript code (e.g., using `fetch` or `XMLHttpRequest`) attempts to access a resource from a `different origin`, the browser enforces the Same-Origin Policy.
   * `different origin` means: Request to a server with a different protocol, domain, or port than the one hosting the web page.
2. **Preflight Requests**: For certain "complex" requests (e.g., non-GET methods or custom headers), the browser sends an HTTP `OPTIONS` request to check if the server allows the cross-origin request.
3. **Server Response**: The server responds with CORS headers (e.g., `Access-Control-Allow-Origin`) to indicate whether the request is permitted.
4. **Browser Decision**: If the server’s CORS headers allow the request, the browser proceeds; otherwise, it blocks the response from being accessed by the client.

### Key CORS Headers

* **`Access-Control-Allow-Origin`**: Specifies which origins are allowed (e.g., `*` for all or a specific origin like `http://localhost:3000`).
* **`Access-Control-Allow-Methods`**: Lists allowed HTTP methods (e.g., `GET, POST, PUT`).
* **`Access-Control-Allow-Headers`**: Specifies allowed headers in requests.
* **`Access-Control-Allow-Credentials`**: Indicates whether credentials (e.g., cookies) can be included.
* **`Access-Control-Max-Age`**: Defines how long preflight responses can be cached.

## CORS in JavaScript (Client-Side Example)

Below is an example of making a cross-origin request using the `fetch` API in pure JavaScript.

### Example: JavaScript Fetch Request

```javascript
// Making a cross-origin GET request
fetch('http://api.example.com/data', {
  method: 'GET',
  headers: {
    'Content-Type': 'application/json',
    'Custom-Header': 'value'
  }
})
  .then(response => {
    if (!response.ok) throw new Error('Network response was not ok');
    return response.json();
  })
  .then(data => console.log(data))
  .catch(error => console.error('Error:', error));
```

## CORS in ASP.NET Core WebAPI (Server-Side Example)

In ASP.NET Core, CORS is configured in the server to allow specific origins, methods, and headers.

* Example: Configuring CORS in ASP.NET Core
  * Below is an example of setting up CORS in an ASP.NET Core WebAPI project.
  * Step 1: Configure CORS in `Program.cs`

    ```csharp
    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.
    builder.Services.AddControllers();
    // Configure CORS
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowSpecificOrigin",
            policy =>
            {
                policy.WithOrigins("http://localhost:3000") // Allow specific origin
                      .AllowAnyMethod()                    // Allow all HTTP methods
                      .AllowAnyHeader()                    // Allow all headers
                      .AllowCredentials();                 // Allow cookies/credentials
            });
    });

    var app = builder.Build();
    // Configure the HTTP request pipeline.
    app.UseHttpsRedirection();
    app.UseCors("AllowSpecificOrigin"); // Apply CORS policy
    app.UseAuthorization();
    app.MapControllers();
    app.Run();
    ```

  * Step 2: Example Controller

    ```csharp
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "Hello from the API!" });
        }

        [HttpPost]
        public IActionResult Post([FromBody] object data)
        {
            return Ok(new { Received = data });
        }
    }
    ```

* Notes
  * **CORS Policy**: The `AllowSpecificOrigin` policy allows requests from `http://localhost:3000`. Replace with your frontend’s origin.
  * **Preflight Handling**: ASP.NET Core automatically handles `OPTIONS` requests when CORS is enabled.
  * **Granularity**: Use `WithOrigins`, `WithMethods`, or `WithHeaders` for fine-grained control.

## Common CORS Issues and Solutions

* **Error**: `No 'Access-Control-Allow-Origin' header is present`
  * **Solution**: Ensure the server includes the `Access-Control-Allow-Origin` header for the requesting origin.
* **Error**: `Preflight request fails`
  * **Solution**: Verify the server allows the requested methods and headers via `Access-Control-Allow-Methods` and `Access-Control-Allow-Headers`.
* **Error**: `Credentials issue`
  * **Solution**: Set `Access-Control-Allow-Credentials` to `true` on the server and include `credentials: 'include'` in the client request.
