//debugger; // Execution will pause here if DevTools is open

// Log
console.log('Hello World!');
console.log('Hello', 'World');

// Variables
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

// Read input from user
name = prompt("What is your name?");
console.log(`Hello ${name}!`);

// Showing data to the user
alert(`Hello, ${name}!`);

//Basic Operators
let n1 = 10;
let n2 = 3;
let result1 = n1 / n2; // 10 ÷ 3 ≈ 3.333...
console.log(result1);
let result2 = Math.floor(n1 / n2)
console.log(result2);

// Random number
let randomDecimal = Math.random() * 100;
console.log(randomDecimal);