import DataAccessService from './_05_ProductService.js';

// Instantiate the service
const productService = new DataAccessService();

document.addEventListener('DOMContentLoaded', () => {
  populateDropdowns();
  renderProducts();
  document.getElementById('productForm').addEventListener('submit', handleSubmit);
  document.getElementById('cancelEdit').addEventListener('click', resetForm);
});

document.addEventListener('click', (event) => {
  if (event.target.classList.contains('edit')) {
    const id = parseInt(event.target.dataset.id);
    editProduct(id);
  }

  if (event.target.classList.contains('delete')) {
    const id = parseInt(event.target.dataset.id);
    deleteProduct(id);
  }
});

function populateDropdowns() {
  const supplierSelect = document.getElementById('supplierId');
  const categorySelect = document.getElementById('categoryId');

  productService.getSuppliers().forEach(supplier => {
    const option = document.createElement('option');
    option.value = supplier.id;
    option.textContent = supplier.name;
    supplierSelect.appendChild(option);
  });

  productService.getCategories().forEach(category => {
    const option = document.createElement('option');
    option.value = category.id;
    option.textContent = category.name;
    categorySelect.appendChild(option);
  });
}

function handleSubmit(event) {
  event.preventDefault();

  const product = {
    productName: document.getElementById('productName').value,
    supplierId: parseInt(document.getElementById('supplierId').value),
    categoryId: parseInt(document.getElementById('categoryId').value),
    quantityPerUnit: document.getElementById('quantityPerUnit').value,
    unitPrice: parseFloat(document.getElementById('unitPrice').value),
    discontinued: document.getElementById('discontinued').checked
  };

  const existingId = parseInt(document.getElementById('productId').value);
  if (existingId) {
    product.id = existingId;
    productService.updateProduct(product);
  } else {
    productService.addProduct(product);
  }

  resetForm();
  renderProducts();
}

function resetForm() {
  document.getElementById('productForm').reset();
  document.getElementById('productId').value = '';
  document.getElementById('cancelEdit').style.display = 'none';
}

function renderProducts() {
  const tbody = document.getElementById('productsBody');
  tbody.innerHTML = '';

  productService.getProducts().forEach(product => {
    const row = document.createElement('tr');
    row.innerHTML = `
      <td>${product.id}</td>
      <td>${product.productName}</td>
      <td>${productService.getSupplier(product.supplierId).name}</td>
      <td>${productService.getCategory(product.categoryId).name}</td>
      <td>${product.quantityPerUnit}</td>
      <td>${product.unitPrice.toFixed(2)}</td>
      <td>${product.discontinued ? 'Yes' : 'No'}</td>
      <td>
          <button id="editBtn-${product.id}" class="edit" data-id="${product.id}">Edit</button>
          <button id="deleteBtn-${product.id}" class="delete" data-id="${product.id}">Delete</button>
      </td>
    `;
    tbody.appendChild(row);
  });

  // Assign event listeners after buttons are created
  productService.getProducts().forEach(product => {
    document.getElementById(`editBtn-${product.id}`).addEventListener('click', () => {
      editProduct(product.id);
    });

    document.getElementById(`deleteBtn-${product.id}`).addEventListener('click', () => {
      deleteProduct(product.id);
    });
  });
}


function editProduct(id) {
  const product = productService.getProductById(id);
  if (product) {
    document.getElementById('productId').value = product.id;
    document.getElementById('productName').value = product.productName;
    document.getElementById('supplierId').value = product.supplierId;
    document.getElementById('categoryId').value = product.categoryId;
    document.getElementById('quantityPerUnit').value = product.quantityPerUnit;
    document.getElementById('unitPrice').value = product.unitPrice;
    document.getElementById('discontinued').checked = product.discontinued;
    document.getElementById('cancelEdit').style.display = 'inline';
  }
}

function deleteProduct(id) {
  productService.deleteProduct(id);
  renderProducts();
}
