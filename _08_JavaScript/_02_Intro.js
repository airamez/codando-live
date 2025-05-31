// "use strict";

//debugger; // Execution will pause here if DevTools is open

// Log
console.log('Hello World!');
console.log('Hello', 'World');

// Variables
let firstName = "Alice"; // String
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

// Read input from user
firstName = prompt("What is your name?");
console.log(`Hello ${firstName}!`);

// Showing data to the user
alert(`Hello, ${firstName}!`);

//Basic Operators
let n1 = 10;
let n2 = 3;
let result1 = n1 / n2; // 10 ÷ 3 ≈ 3.333...
console.log(result1);
let result2 = Math.floor(n1 / n2);
console.log(result2);

// Random number
let randomDecimal = Math.floor(Math.random() * 100);
console.log(randomDecimal);

// Only possible without: `"use strict";`
x = 10
console.log(x);
// NOTE: UNCOMMENT THE FIRST LIKE AND TRY
