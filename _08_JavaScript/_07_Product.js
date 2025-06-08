import DataAccessService from './_07_ProductService.js';

const productService = new DataAccessService();

// Getting all components by ID
const uiComponents = {
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

document.addEventListener('DOMContentLoaded', async () => {
  uiComponents.productForm.addEventListener('submit', handleSubmit);
  uiComponents.cancelEdit.addEventListener('click', resetForm);
  uiComponents.prevPage.addEventListener('click', () => changePage(-1));
  uiComponents.nextPage.addEventListener('click', () => changePage(1));
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
        uiComponents.supplierId.appendChild(option);
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
        uiComponents.categoryId.appendChild(option);
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
      ProductName: uiComponents.productName.value,
      SupplierId: uiComponents.supplierId.value ? parseInt(uiComponents.supplierId.value) : null,
      CategoryId: uiComponents.categoryId.value ? parseInt(uiComponents.categoryId.value) : null,
      QuantityPerUnit: uiComponents.quantityPerUnit.value,
      UnitPrice: parseFloat(uiComponents.unitPrice.value) || 0,
      Discontinued: uiComponents.discontinued.checked,
    };

    const productId = parseInt(uiComponents.productId.value);
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
  uiComponents.productForm.reset();
  uiComponents.productId.value = '';
  uiComponents.cancelEdit.style.display = 'none';
  uiComponents.errorMessage.textContent = '';
}

async function renderProducts() {
  try {
    showLoading(true);
    const [products, suppliers, categories] = await Promise.all([
      productService.getProducts() || [],
      productService.getSuppliers() || [],
      productService.getCategories() || [],
    ]);

    pagination.totalItems = products.length;
    updatePaginationControls();

    const startIndex = (pagination.currentPage - 1) * pagination.itemsPerPage;
    const endIndex = startIndex + pagination.itemsPerPage;
    const paginatedProducts = products.slice(startIndex, endIndex);

    uiComponents.productsBody.innerHTML = '';
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
      uiComponents.productsBody.appendChild(row);
    });

    uiComponents.productsBody.querySelectorAll('.edit').forEach(button =>
      button.addEventListener('click', () => editProduct(parseInt(button.dataset.id)))
    );
    uiComponents.productsBody.querySelectorAll('.delete').forEach(button =>
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
      uiComponents.productId.value = product.productId;
      uiComponents.productName.value = product.productName;
      uiComponents.supplierId.value = product.supplierId || '';
      uiComponents.categoryId.value = product.categoryId || '';
      uiComponents.quantityPerUnit.value = product.quantityPerUnit || '';
      uiComponents.unitPrice.value = product.unitPrice;
      uiComponents.discontinued.checked = product.discontinued;
      uiComponents.cancelEdit.style.display = 'inline';
      uiComponents.errorMessage.textContent = '';
      // Scroll to top of page
      window.scrollTo({ top: 0, behavior: 'smooth' });
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
    // Adjust page if current page becomes empty
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
  uiComponents.loadingIndicator.style.display = isLoading ? 'block' : 'none';
}

function showError(message) {
  uiComponents.errorMessage.textContent = message;
}

function updatePaginationControls() {
  const totalPages = Math.ceil(pagination.totalItems / pagination.itemsPerPage);
  uiComponents.pageInfo.textContent = `Page ${pagination.currentPage} of ${totalPages || 1}`;
  uiComponents.prevPage.disabled = pagination.currentPage === 1;
  uiComponents.nextPage.disabled = pagination.currentPage >= totalPages;
}

function changePage(direction) {
  pagination.currentPage += direction;
  renderProducts();
}