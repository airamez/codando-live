debugger; // Execution will pause here if DevTools is open

// Log
console.log('Hello World!');
console.log('Hello', 'World');

// JavaScript Control Flow Example

// 1. Conditionals: if, else if, else
function checkAge(age) {
  if (age < 18) {
    console.log("You are a minor.");
  } else if (age >= 18 && age < 65) {
    console.log("You are an adult.");
  } else {
    console.log("You are a senior citizen.");
  }
}

checkAge(20);

// 2. Switch statement
function checkFruit(fruit) {
  switch (fruit) {
    case "banana":
      console.log("Bananas are great for potassium.");
      break;
    case "apple":
      console.log("An apple a day keeps the doctor away.");
      break;
    default:
      console.log("Unknown fruit.");
  }
}

checkFruit("apple");

// 3. Loops
// For loop
for (let i = 1; i <= 5; i++) {
  console.log(`Iteration ${i}`);
}

// While loop
let count = 0;
while (count < 3) {
  console.log(`Count: ${count}`);
  count++;
}

// Do...while loop
let num = 0;
do {
  console.log(`Number: ${num}`);
  num++;
} while (num < 3);

// For...of loop (Iterating over an array)
let colors = ["red", "green", "blue"];
for (let color of colors) {
  console.log(color);
}

// For...in loop (Iterating over object properties)
let person = { name: "José", age: 30, country: "USA" };
for (let key in person) {
  console.log(`${key}: ${person[key]}`);
}

// 4. Ternary Operator
let age = 20;
let ageStatus = age >= 18 ? "Adult" : "Minor";
console.log(ageStatus);
