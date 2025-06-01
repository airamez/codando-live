// Initial array with 8 fruits
let fruits = ["apple", "banana", "orange", "grape", "mango", "kiwi", "pear", "peach"];
console.log(fruits);

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