
// Mouse Events
const button = document.getElementById('btn');
button.addEventListener('click', () => {
  console.log('Button clicked!');
});
button.addEventListener('dblclick', () => {
  console.log('Button double-clicked!');
});

const box = document.getElementById('box');
box.addEventListener('mouseover', () => {
  box.style.backgroundColor = 'lightgreen';
});
box.addEventListener('mouseout', () => {
  box.style.backgroundColor = 'lightblue';
});

const runningButton = document.getElementById("running_btn");
// Set initial position at the bottom of the page
window.addEventListener('load', () => {
  console.log('Page loaded!');
  const paragraphContainer = document.getElementById('paragraphContainer');
  const rect = paragraphContainer.getBoundingClientRect();
  const scrollY = window.scrollY || window.pageYOffset;
  runningButton.style.left = `${rect.left}px`;
  runningButton.style.top = `${rect.bottom + scrollY + 10}px`; // 10px gap below paragraphContainer
});
runningButton.addEventListener('mouseover', () => {
  const maxX = window.innerWidth - runningButton.offsetWidth;
  const maxY = window.innerHeight - runningButton.offsetHeight;
  // Generate random positions
  const randomX = Math.floor(Math.random() * maxX);
  const randomY = Math.floor(Math.random() * maxY);
  // Apply new position
  runningButton.style.left = `${randomX}px`;
  runningButton.style.top = `${randomY}px`;
});

// Keyboard Events
const input = document.getElementById('textInput');
input.addEventListener('keydown', (event) => {
  console.log(`Key pressed: ${event.key}`); // String output
});
input.addEventListener('keyup', () => {
  console.log(input.value.length); // Integer: length of input string
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
  console.log(`Page loaded!:`);
});
window.addEventListener('resize', () => {
  console.log('innerWidth =', window.innerWidth); // Integer: window width
});
window.addEventListener('scroll', () => {
  console.log(`ScrollY =`, window.scrollY); // Decimal: scroll position
});

// Dynamic Paragraph Addition
const paragraphInput = document.getElementById('paragraphInput');
const addParagraphBtn = document.getElementById('addParagraphBtn');
const paragraphContainer = document.getElementById('paragraphContainer');
addParagraphBtn.addEventListener('click', addParagraph);

function addParagraph() {
  const text = paragraphInput.value.trim();
  if (text) {
    const p = document.createElement('p');
    p.textContent = text;
    paragraphContainer.appendChild(p);
    paragraphInput.value = ''; // Clear input after adding
  }
}
