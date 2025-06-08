import DataAccessService from './_07_ProductService.js';

// Initialize DataAccessService instance for product-related operations
const productService = new DataAccessService();

// UI elements for DOM manipulation
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
  pageSelect: document.getElementById('pageSelect'),
};

// Pagination state for managing product list navigation
const pagination = {
  currentPage: 1,
  itemsPerPage: 10,
  totalItems: 0,
};

// Sorting state for table column sorting
const sortState = {
  column: 'productId',
  direction: 'asc',
};

// Initialize event listeners when DOM is fully loaded
document.addEventListener('DOMContentLoaded', async () => {
  ui.productForm.addEventListener('submit', handleSubmit);
  ui.cancelEdit.addEventListener('click', resetForm);
  ui.prevPage.addEventListener('click', () => changePage(-1));
  ui.nextPage.addEventListener('click', () => changePage(1));
  ui.pageSelect.addEventListener('change', (e) => {
    pagination.currentPage = parseInt(e.target.value);
    renderProducts();
  });
  document.querySelectorAll('#productsTable th').forEach((header, index) => {
    header.addEventListener('click', () => sortTable(index));
  });
  await initialize();
});

/**
 * Initializes the application by populating dropdowns and rendering products
 * @returns {Promise<void>}
 */
async function initialize() {
  try {
    showLoading(true);
    // Concurrently fetch dropdown data and render initial product list
    await Promise.all([populateDropdowns(), renderProducts()]);
  } catch (error) {
    showError(`Failed to initialize: ${error.message}`);
  } finally {
    showLoading(false);
  }
}

/**
 * Populates supplier and category dropdowns with data from the service
 * @returns {Promise<void>}
 */
async function populateDropdowns() {
  // Fetch and populate suppliers
  productService.getSuppliers()
    .then(response => {
      // Handle empty or null response
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

  // Fetch and populate categories
  productService.getCategories()
    .then(response => {
      // Handle empty or null response
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

/**
 * Handles form submission for adding or updating a product
 * @param {Event} event - Form submission event
 * @returns {Promise<void>}
 */
async function handleSubmit(event) {
  event.preventDefault();
  try {
    showLoading(true);
    // Construct product object from form inputs
    const product = {
      ProductName: ui.productName.value,
      SupplierId: ui.supplierId.value ? parseInt(ui.supplierId.value) : null,
      CategoryId: ui.categoryId.value ? parseInt(ui.categoryId.value) : null,
      QuantityPerUnit: ui.quantityPerUnit.value,
      UnitPrice: parseFloat(ui.unitPrice.value) || 0,
      Discontinued: ui.discontinued.checked,
    };

    const productId = parseInt(ui.productId.value);
    // Update existing product if productId exists, otherwise add new product
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

/**
 * Resets the product form and clears edit state
 */
function resetForm() {
  ui.productForm.reset();
  ui.productId.value = '';
  ui.cancelEdit.style.display = 'none';
  ui.errorMessage.textContent = '';
}

/**
 * Fetches products, suppliers, and categories concurrently
 * @returns {Promise<Array>} Array of products, suppliers, and categories
 */
async function fetchData() {
  try {
    return await Promise.all([
      productService.getProducts() || [],
      productService.getSuppliers() || [],
      productService.getCategories() || [],
    ]);
  } catch (error) {
    throw new Error(`Failed to fetch data: ${error.message}`);
  }
}

/**
 * Sorts products based on sortState and related data
 * @param {Array} products - Array of product objects
 * @param {Array} suppliers - Array of supplier objects
 * @param {Array} categories - Array of category objects
 * @param {Object} sortState - Sorting state { column, direction }
 * @returns {Array} Sorted products
 */
function sortProducts(products, suppliers, categories, sortState) {
  return products.slice().sort((a, b) => {
    const column = sortState.column;
    const direction = sortState.direction === 'asc' ? 1 : -1;
    let valueA = a[column];
    let valueB = b[column];

    // Handle supplier column sorting by company name
    if (column === 'supplier') {
      const supplierA = suppliers.find(s => s.supplierId === a.supplierId);
      const supplierB = suppliers.find(s => s.supplierId === b.supplierId);
      valueA = supplierA?.companyName || 'Unknown';
      valueB = supplierB?.companyName || 'Unknown';
    }

    // Handle category column sorting by category name
    if (column === 'category') {
      const categoryA = categories.find(c => c.categoryId === a.categoryId);
      const categoryB = categories.find(c => c.categoryId === b.categoryId);
      valueA = categoryA?.categoryName || 'Unknown';
      valueB = categoryB?.categoryName || 'Unknown';
    }

    // Numeric comparison for number types
    if (typeof valueA === 'number' || typeof valueB === 'number') {
      return (valueA - valueB) * direction;
    }
    // Boolean comparison for discontinued status
    else if (typeof valueA === 'boolean' || typeof valueB === 'boolean') {
      return (valueA === valueB ? 0 : valueA ? -1 : 1) * direction;
    }

    // String comparison with locale-aware sorting
    return valueA.localeCompare(valueB) * direction;
  });
}

/**
 * Paginates the sorted products
 * @param {Array} sortedProducts - Sorted array of products
 * @param {Object} pagination - Pagination state { currentPage, itemsPerPage }
 * @returns {Array} Paginated products
 */
function paginateProducts(sortedProducts, pagination) {
  // Calculate start and end indices for slicing
  const startIndex = (pagination.currentPage - 1) * pagination.itemsPerPage;
  const endIndex = startIndex + pagination.itemsPerPage;
  return sortedProducts.slice(startIndex, endIndex);
}

/**
 * Renders product rows in the table
 * @param {Array} products - Products to render
 * @param {Array} suppliers - Array of supplier objects
 * @param {Array} categories - Array of category objects
 * @param {Object} ui - UI elements (e.g., productsBody)
 */
function renderProductRows(products, suppliers, categories, ui) {
  ui.productsBody.innerHTML = ''; // Clear existing rows
  products.forEach(product => {
    // Find related supplier and category for display
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
}

/**
 * Updates table header sorting indicators
 * @param {Object} sortState - Sorting state { column, direction }
 */
function updateSortIndicators(sortState) {
  document.querySelectorAll('#productsTable th').forEach((header, index) => {
    const columnKey = getColumnKey(index);
    header.classList.remove('sort-asc', 'sort-desc');
    // Add appropriate sort indicator class if column matches
    if (columnKey === sortState.column) {
      header.classList.add(`sort-${sortState.direction}`);
    }
  });
}

/**
 * Attaches event listeners to edit and delete buttons
 * @param {Object} ui - UI elements (e.g., productsBody)
 */
function attachEventListeners(ui) {
  // Add click listeners for edit buttons
  ui.productsBody.querySelectorAll('.edit').forEach(button =>
    button.addEventListener('click', () => editProduct(parseInt(button.dataset.id)))
  );
  // Add click listeners for delete buttons
  ui.productsBody.querySelectorAll('.delete').forEach(button =>
    button.addEventListener('click', () => deleteProduct(parseInt(button.dataset.id)))
  );
}

/**
 * Main function to render products
 * @returns {Promise<void>}
 */
async function renderProducts() {
  try {
    showLoading(true);
    // Fetch all necessary data
    const [products, suppliers, categories] = await fetchData();

    // Sort and paginate products
    const sortedProducts = sortProducts(products, suppliers, categories, sortState);
    pagination.totalItems = sortedProducts.length;
    updatePaginationControls();

    const paginatedProducts = paginateProducts(sortedProducts, pagination);
    renderProductRows(paginatedProducts, suppliers, categories, ui);
    updateSortIndicators(sortState);
    attachEventListeners(ui);
  } catch (error) {
    throw new Error(`Failed to render products: ${error.message}`);
  } finally {
    showLoading(false);
  }
}

/**
 * Loads product data into form for editing
 * @param {number} id - Product ID to edit
 * @returns {Promise<void>}
 */
async function editProduct(id) {
  try {
    showLoading(true);
    const product = await productService.getProductById(id);
    if (product) {
      // Populate form fields with product data
      ui.productId.value = product.productId;
      ui.productName.value = product.productName;
      ui.supplierId.value = product.supplierId || '';
      ui.categoryId.value = product.categoryId || '';
      ui.quantityPerUnit.value = product.quantityPerUnit || '';
      ui.unitPrice.value = product.unitPrice.toFixed(2);
      ui.discontinued.checked = product.discontinued;
      ui.cancelEdit.style.display = 'inline';
      ui.errorMessage.textContent = '';
      // Smooth scroll to top for better UX
      window.scrollTo({ top: 0, behavior: 'smooth' });
    }
  } catch (error) {
    showError(`Failed to load product: ${error.message}`);
  } finally {
    showLoading(false);
  }
}

/**
 * Deletes a product and updates the table
 * @param {number} id - Product ID to delete
 * @returns {Promise<void>}
 */
async function deleteProduct(id) {
  try {
    showLoading(true);
    await productService.deleteProduct(id);
    // Adjust page if current page exceeds total pages after deletion
    const totalPages = Math.ceil(pagination.totalItems / pagination.itemsPerPage);
    if (pagination.currentPage > totalPages && pagination.currentPage > 1) {
      pagination.currentPage--;
      ui.pageSelect.value = pagination.currentPage;
    }
    await renderProducts();
  } catch (error) {
    showError(`Failed to delete product: ${error.message}`);
  } finally {
    showLoading(false);
  }
}

/**
 * Toggles loading indicator visibility
 * @param {boolean} isLoading - Whether to show or hide the loading indicator
 */
function showLoading(isLoading) {
  ui.loadingIndicator.style.display = isLoading ? 'block' : 'none';
}

/**
 * Displays error message in the UI
 * @param {string} message - Error message to display
 */
function showError(message) {
  ui.errorMessage.textContent = message;
}

/**
 * Updates pagination controls based on current state
 */
function updatePaginationControls() {
  const totalPages = Math.ceil(pagination.totalItems / pagination.itemsPerPage) || 1;
  ui.pageInfo.textContent = `[${pagination.currentPage} of ${totalPages}]`;
  // Disable navigation buttons when at boundaries
  ui.prevPage.disabled = pagination.currentPage === 1;
  ui.nextPage.disabled = pagination.currentPage >= totalPages;
  ui.pageSelect.innerHTML = '';
  // Populate page selection dropdown
  for (let i = 1; i <= totalPages; i++) {
    const option = document.createElement('option');
    option.value = i;
    option.textContent = `Page ${i}`;
    if (i === pagination.currentPage) {
      option.selected = true;
    }
    ui.pageSelect.appendChild(option);
  }
}

/**
 * Changes the current page and updates the product list
 * @param {number} direction - 1 for next page, -1 for previous page
 */
function changePage(direction) {
  pagination.currentPage += direction;
  ui.pageSelect.value = pagination.currentPage;
  renderProducts();
}

/**
 * Handles table sorting based on column click
 * @param {number} columnIndex - Index of the clicked column
 */
function sortTable(columnIndex) {
  const columnKeys = ['productId', 'productName', 'supplier', 'category', 'quantityPerUnit', 'unitPrice', 'discontinued'];
  const newColumn = columnKeys[columnIndex];
  if (!newColumn) return;
  // Toggle sort direction if same column, otherwise reset to ascending
  if (sortState.column === newColumn) {
    sortState.direction = sortState.direction === 'asc' ? 'desc' : 'asc';
  } else {
    sortState.column = newColumn;
    sortState.direction = 'asc';
  }
  renderProducts();
}

/**
 * Maps column index to sorting key
 * @param {number} index - Column index
 * @returns {string} Column key for sorting
 */
function getColumnKey(index) {
  const columnKeys = ['productId', 'productName', 'supplier', 'category', 'quantityPerUnit', 'unitPrice', 'discontinued'];
  return columnKeys[index] || '';
}