// Mouse Events
const button = document.getElementById('btn');
button.addEventListener('click', () => {
  console.log('Button clicked!'); // String output
});
button.addEventListener('dblclick', () => {
  console.log(2); // Integer output
});

const box = document.getElementById('box');
box.addEventListener('mouseover', () => {
  box.style.backgroundColor = 'lightgreen';
  console.log(true); // Boolean output
});
box.addEventListener('mouseout', () => {
  box.style.backgroundColor = 'lightblue';
});

// Keyboard Events
const input = document.getElementById('textInput');
input.addEventListener('keydown', (event) => {
  console.log(`Key pressed: ${event.key}`); // String output
});
input.addEventListener('keyup', () => {
  console.log(input.value.length); // Integer: length of input string
});

// Form Events
const form = document.getElementById('myForm');
form.addEventListener('submit', (event) => {
  event.preventDefault(); // Prevent form submission
  console.log('Form submitted!');
});

input.addEventListener('change', () => {
  console.log(`New value: ${input.value}`); // String output
});
input.addEventListener('input', () => {
  console.log(input.value); // String: real-time input
});
input.addEventListener('focus', () => {
  console.log(true); // Boolean: input focused
});
input.addEventListener('blur', () => {
  console.log(false); // Boolean: input lost focus
});

// Window/Document Events
window.addEventListener('load', () => {
  console.log('Page loaded!');
});
window.addEventListener('resize', () => {
  console.log(window.innerWidth); // Integer: window width
});
window.addEventListener('scroll', () => {
  console.log(window.scrollY); // Decimal: scroll position
});