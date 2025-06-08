import DataAccessService from './_07_ProductService.js';

const productService = new DataAccessService();

// Getting all components by ID
const ui = {
  productForm: document.getElementById('productForm'),
  productsBody: document.getElementById('productsBody'),
  cancelEdit: document.getElementById('cancelEdit'),
  productId: document.getElementById('productId'),
  productName: document.getElementById('productName'),
  supplierId: document.getElementById('supplierId'),
  categoryId: document.getElementById('categoryId'),
  quantityPerUnit: document.getElementById('quantityPerUnit'),
  unitPrice: document.getElementById('unitPrice'),
  discontinued: document.getElementById('discontinued'),
  errorMessage: document.getElementById('errorMessage'),
  loadingIndicator: document.getElementById('loadingIndicator'),
  prevPage: document.getElementById('prevPage'),
  nextPage: document.getElementById('nextPage'),
  pageInfo: document.getElementById('pageInfo'),
};

// Pagination state
const pagination = {
  currentPage: 1,
  itemsPerPage: 10,
  totalItems: 0,
};

// Sort state
const sortState = {
  column: 'productId', // Default sort by ID
  direction: 'asc', // Default ascending
};

document.addEventListener('DOMContentLoaded', async () => {
  ui.productForm.addEventListener('submit', handleSubmit);
  ui.cancelEdit.addEventListener('click', resetForm);
  ui.prevPage.addEventListener('click', () => changePage(-1));
  ui.nextPage.addEventListener('click', () => changePage(1));
  // Add sort event listeners to table headers
  document.querySelectorAll('#productsTable th').forEach((header, index) => {
    header.addEventListener('click', () => sortTable(index));
  });
  await initialize();
});

async function initialize() {
  try {
    showLoading(true);
    await Promise.all([populateDropdowns(), renderProducts()]);
  } catch (error) {
    showError(`Failed to initialize: ${error.message}`);
  } finally {
    showLoading(false);
  }
}

async function populateDropdowns() {
  productService.getSuppliers()
    .then(response => {
      (response || []).forEach(supplier => {
        const option = document.createElement('option');
        option.value = supplier.supplierId;
        option.textContent = supplier.companyName;
        ui.supplierId.appendChild(option);
      });
    })
    .catch(error => {
      showError(`Failed to populate suppliers: ${error.message}`);
    });

  productService.getCategories()
    .then(response => {
      (response || []).forEach(category => {
        const option = document.createElement('option');
        option.value = category.categoryId;
        option.textContent = category.description;
        ui.categoryId.appendChild(option);
      });
    })
    .catch(error => {
      showError(`Failed to populate categories: ${error.message}`);
    });
}

async function handleSubmit(event) {
  event.preventDefault();
  try {
    showLoading(true);
    const product = {
      ProductName: ui.productName.value,
      SupplierId: ui.supplierId.value ? parseInt(ui.supplierId.value) : null,
      CategoryId: ui.categoryId.value ? parseInt(ui.categoryId.value) : null,
      QuantityPerUnit: ui.quantityPerUnit.value,
      UnitPrice: parseFloat(ui.unitPrice.value) || 0,
      Discontinued: ui.discontinued.checked,
    };

    const productId = parseInt(ui.productId.value);
    if (productId) {
      product.ProductId = productId;
      await productService.updateProduct(product);
    } else {
      await productService.addProduct(product);
    }

    resetForm();
    pagination.currentPage = 1; // Reset to first page after save
    await renderProducts();
  } catch (error) {
    showError(`Failed to save product: ${error.message}`);
  } finally {
    showLoading(false);
  }
}

function resetForm() {
  ui.productForm.reset();
  ui.productId.value = '';
  ui.cancelEdit.style.display = 'none';
  ui.errorMessage.textContent = '';
}

async function renderProducts() {
  try {
    showLoading(true);
    const [products, suppliers, categories] = await Promise.all([
      productService.getProducts() || [],
      productService.getSuppliers() || [],
      productService.getCategories() || [],
    ]);

    // Sort products based on sortState
    const sortedProducts = [...products].sort((a, b) => {
      const column = sortState.column;
      const direction = sortState.direction === 'asc' ? 1 : -1;
      let valueA = a[column];
      let valueB = b[column];

      // Handle special cases for Supplier and Category
      if (column === 'supplier') {
        const supplierA = suppliers.find(s => s.supplierId === a.supplierId);
        const supplierB = suppliers.find(s => s.supplierId === b.supplierId);
        valueA = supplierA?.companyName || 'Unknown';
        valueB = supplierB?.companyName || 'Unknown';
      } else if (column === 'category') {
        const categoryA = categories.find(c => c.categoryId === a.categoryId);
        const categoryB = categories.find(c => c.categoryId === b.categoryId);
        valueA = categoryA?.categoryName || 'Unknown';
        valueB = categoryB?.categoryName || 'Unknown';
      }

      // Handle numeric and boolean values
      if (typeof valueA === 'number' || typeof valueB === 'number') {
        return (valueA - valueB) * direction;
      } else if (typeof valueA === 'boolean' || typeof valueB === 'boolean') {
        return (valueA === valueB ? 0 : valueA ? -1 : 1) * direction;
      }
      // String comparison
      return valueA.localeCompare(valueB) * direction;
    });

    pagination.totalItems = sortedProducts.length;
    updatePaginationControls();

    const startIndex = (pagination.currentPage - 1) * pagination.itemsPerPage;
    const endIndex = startIndex + pagination.itemsPerPage;
    const paginatedProducts = sortedProducts.slice(startIndex, endIndex);

    ui.productsBody.innerHTML = '';
    paginatedProducts.forEach(product => {
      const supplier = suppliers.find(s => s.supplierId === product.supplierId);
      const category = categories.find(c => c.categoryId === product.categoryId);
      const row = document.createElement('tr');
      row.innerHTML = `
                <td>${product.productId}</td>
                <td>${product.productName}</td>
                <td>${supplier?.companyName || 'Unknown'}</td>
                <td>${category?.categoryName || 'Unknown'}</td>
                <td>${product.quantityPerUnit || ''}</td>
                <td>${product.unitPrice.toFixed(2)}</td>
                <td>${product.discontinued ? 'Yes' : 'No'}</td>
                <td>
                    <button class="edit" data-id="${product.productId}">Edit</button>
                    <button class="delete" data-id="${product.productId}">Delete</button>
                </td>
            `;
      ui.productsBody.appendChild(row);
    });

    // Update header classes for sort indicators
    document.querySelectorAll('#productsTable th').forEach((header, index) => {
      const columnKey = getColumnKey(index);
      header.classList.remove('sort-asc', 'sort-desc');
      if (columnKey === sortState.column) {
        header.classList.add(`sort-${sortState.direction}`);
      }
    });

    ui.productsBody.querySelectorAll('.edit').forEach(button =>
      button.addEventListener('click', () => editProduct(parseInt(button.dataset.id)))
    );
    ui.productsBody.querySelectorAll('.delete').forEach(button =>
      button.addEventListener('click', () => deleteProduct(parseInt(button.dataset.id)))
    );
  } catch (error) {
    throw new Error(`Failed to render products: ${error.message}`);
  } finally {
    showLoading(false);
  }
}

async function editProduct(id) {
  try {
    showLoading(true);
    const product = await productService.getProductById(id);
    if (product) {
      ui.productId.value = product.productId;
      ui.productName.value = product.productName;
      ui.supplierId.value = product.supplierId || '';
      ui.categoryId.value = product.categoryId || '';
      ui.quantityPerUnit.value = product.quantityPerUnit || '';
      ui.unitPrice.value = product.unitPrice.toFixed(2);
      ui.discontinued.checked = product.discontinued;
      ui.cancelEdit.style.display = 'inline';
      ui.errorMessage.textContent = '';
      window.scrollTo({ top: 0, left: 0, behavior: 'smooth' });
    }
  } catch (error) {
    showError(`Failed to load product: ${error.message}`);
  } finally {
    showLoading(false);
  }
}

async function deleteProduct(id) {
  try {
    showLoading(true);
    await productService.deleteProduct(id);
    const totalPages = Math.ceil(pagination.totalItems / pagination.itemsPerPage);
    if (pagination.currentPage > totalPages && pagination.currentPage > 1) {
      pagination.currentPage--;
    }
    await renderProducts();
  } catch (error) {
    showError(`Failed to delete product: ${error.message}`);
  } finally {
    showLoading(false);
  }
}

function showLoading(isLoading) {
  ui.loadingIndicator.style.display = isLoading ? 'block' : 'none';
}

function showError(message) {
  ui.errorMessage.textContent = message;
}

function updatePaginationControls() {
  const totalPages = Math.ceil(pagination.totalItems / pagination.itemsPerPage);
  ui.pageInfo.textContent = `Page ${pagination.currentPage} of ${totalPages || 1}`;
  ui.prevPage.disabled = pagination.currentPage === 1;
  ui.nextPage.disabled = pagination.currentPage >= totalPages;
}

function changePage(direction) {
  pagination.currentPage += direction;
  renderProducts();
}

function sortTable(columnIndex) {
  const columnKeys = ['productId', 'productName', 'supplier', 'category', 'quantityPerUnit', 'unitPrice', 'discontinued'];
  const newColumn = columnKeys[columnIndex];
  if (!newColumn) return; // Skip Actions column
  if (sortState.column === newColumn) {
    // Toggle direction if same column
    sortState.direction = sortState.direction === 'asc' ? 'desc' : 'asc';
  } else {
    // New column, reset to ascending
    sortState.column = newColumn;
    sortState.direction = 'asc';
  }
  renderProducts();
}

function getColumnKey(index) {
  const columnKeys = ['productId', 'productName', 'supplier', 'category', 'quantityPerUnit', 'unitPrice', 'discontinued'];
  return columnKeys[index] || '';
}