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
