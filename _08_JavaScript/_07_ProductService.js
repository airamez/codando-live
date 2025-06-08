export default class DataAccessService {
  baseUrl = 'http://localhost:5062/api/ProductNorthWind'; // Adjust to your API base URL

  async fetchJson(url, options = {}) {
    const response = await fetch(url, {
      ...options,
      headers: {
        'Content-Type': 'application/json',
        ...options.headers,
      },
    });
    if (!response.ok) {
      const errorData = await response.json().catch(() => ({}));
      throw new Error(errorData.error || `HTTP error: ${response.statusText}`);
    }
    return response.status === 204 ? null : await response.json();
  }

  async getProducts() {
    return this.fetchJson(this.baseUrl);
  }

  async getProductById(id) {
    return this.fetchJson(`${this.baseUrl}/${id}`);
  }

  async getSuppliers() {
    return this.fetchJson(`${this.baseUrl}/suppliers`);
  }

  async getSupplier(id) {
    return this.fetchJson(`${this.baseUrl}/suppliers/${id}`);
  }

  async getCategories() {
    return this.fetchJson(`${this.baseUrl}/categories`);
  }

  async getCategory(id) {
    return this.fetchJson(`${this.baseUrl}/categories/${id}`);
  }

  async addProduct(product) {
    return this.fetchJson(this.baseUrl, {
      method: 'POST',
      body: JSON.stringify(product),
    });
  }

  async updateProduct(product) {
    return this.fetchJson(`${this.baseUrl}/${product.ProductId}`, {
      method: 'PUT',
      body: JSON.stringify(product),
    });
  }

  async deleteProduct(id) {
    return this.fetchJson(`${this.baseUrl}/${id}`, {
      method: 'DELETE',
    });
  }
}