// Array to store product data
let products = [];
// Counter for generating unique product IDs
let nextId = 1;

// Predefined list of suppliers with their IDs and names
const suppliers = [
  { id: 1, name: "TechNova Solutions" },
  { id: 2, name: "Digital Powerhouse" },
  { id: 3, name: "ElectroGenius Supplies" },
  { id: 4, name: "NextWave Electronics" },
  { id: 5, name: "Innovatech Components" }
];

// Predefined list of product categories with their IDs and names
const categories = [
  { id: 1, name: "Smartphones & Accessories" },
  { id: 2, name: "Computers & Laptops" },
  { id: 3, name: "Audio & Sound Systems" },
  { id: 4, name: "Gaming & Consoles" },
  { id: 5, name: "Wearable Tech" },
  { id: 6, name: "Home Automation & IoT" },
  { id: 7, name: "Cameras & Photography" }
];

// Event listener to run when the DOM is fully loaded
document.addEventListener('DOMContentLoaded', () => {
  // Populate dropdown menus with suppliers and categories
  populateDropdowns();
  // Display the initial list of products
  renderProducts();
  // Add submit event listener to the product form
  document.getElementById('productForm').addEventListener('submit', handleSubmit);
  // Add click event listener to the cancel button
  document.getElementById('cancelEdit').addEventListener('click', resetForm);
});

// Function to populate supplier and category dropdown menus
function populateDropdowns() {
  // Get references to the dropdown elements
  const supplierSelect = document.getElementById('supplierId');
  const categorySelect = document.getElementById('categoryId');

  // Add each supplier as an option in the supplier dropdown
  suppliers.forEach(supplier => {
    const option = document.createElement('option');
    option.value = supplier.id; // Set the option value to supplier ID
    option.textContent = supplier.name; // Set the displayed text to supplier name
    supplierSelect.appendChild(option); // Add option to the dropdown
  });

  // Add each category as an option in the category dropdown
  categories.forEach(category => {
    const option = document.createElement('option');
    option.value = category.id; // Set the option value to category ID
    option.textContent = category.name; // Set the displayed text to category name
    categorySelect.appendChild(option); // Add option to the dropdown
  });
}

// Function to handle form submission for adding or updating products
function handleSubmit(event) {
  // Prevent the default form submission behavior (e.g., page reload)
  event.preventDefault();

  // Create a product object from form inputs
  const product = {
    id: parseInt(document.getElementById('productId').value) || nextId++, // Use existing ID or assign new one
    productName: document.getElementById('productName').value, // Get product name
    supplierId: parseInt(document.getElementById('supplierId').value), // Get selected supplier ID
    categoryId: parseInt(document.getElementById('categoryId').value), // Get selected category ID
    quantityPerUnit: document.getElementById('quantityPerUnit').value, // Get quantity per unit
    unitPrice: parseFloat(document.getElementById('unitPrice').value), // Get unit price as a number
    discontinued: document.getElementById('discontinued').checked // Get discontinued status (true/false)
  };

  // Check if the product already exists (for updating)
  const existingIndex = products.findIndex(p => p.id === product.id);
  if (existingIndex >= 0) {
    // Update existing product
    products[existingIndex] = product;
  } else {
    // Add new product to the array
    products.push(product);
  }

  // Reset the form to clear inputs
  resetForm();
  // Refresh the product list display
  renderProducts();
}

// Function to reset the form to its initial state
function resetForm() {
  // Clear all form inputs
  document.getElementById('productForm').reset();
  // Clear the hidden product ID field
  document.getElementById('productId').value = '';
  // Hide the cancel button
  document.getElementById('cancelEdit').style.display = 'none';
}

// Function to render the product list in the table
function renderProducts() {
  // Get the table body element
  const tbody = document.getElementById('productsBody');
  // Clear existing table content
  tbody.innerHTML = '';
  // Iterate through each product to create a table row
  products.forEach(product => {
    // Find the supplier and category names for the product
    const supplier = suppliers.find(s => s.id === product.supplierId);
    const category = categories.find(c => c.id === product.categoryId);
    // Create a new table row
    const row = document.createElement('tr');
    // Populate the row with product details
    row.innerHTML = `
            <td>${product.id}</td>
            <td>${product.productName}</td>
            <td>${supplier.name}</td>
            <td>${category.name}</td>
            <td>${product.quantityPerUnit}</td>
            <td>${product.unitPrice.toFixed(2)}</td>
            <td>${product.discontinued ? 'Yes' : 'No'}</td>
            <td>
                <button class="edit" onclick="editProduct(${product.id})">Edit</button> <!-- Edit button -->
                <button class="delete" onclick="deleteProduct(${product.id})">Delete</button> <!-- Delete button -->
            </td>
        `;
    // Add the row to the table body
    tbody.appendChild(row);
  });
}

// Function to populate the form with a product's data for editing
function editProduct(id) {
  // Find the product by ID
  const product = products.find(p => p.id === id);
  if (product) {
    // Populate form fields with product data
    document.getElementById('productId').value = product.id;
    document.getElementById('productName').value = product.productName;
    document.getElementById('supplierId').value = product.supplierId;
    document.getElementById('categoryId').value = product.categoryId;
    document.getElementById('quantityPerUnit').value = product.quantityPerUnit;
    document.getElementById('unitPrice').value = product.unitPrice;
    document.getElementById('discontinued').checked = product.discontinued;
    // Show the cancel button
    document.getElementById('cancelEdit').style.display = 'inline';
  }
}

// Function to delete a product from the list
function deleteProduct(id) {
  // Remove the product with the specified ID
  products = products.filter(p => p.id !== id);
  // Refresh the product list display
  renderProducts();
}