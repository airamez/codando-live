export default class DataAccessService {
  constructor() {
    this.products = [];
    this.nextId = 1;

    // Simulating database retrieval for suppliers and categories
    this.suppliers = [
      { id: 1, name: "TechNova Solutions" },
      { id: 2, name: "Digital Powerhouse" },
      { id: 3, name: "ElectroGenius Supplies" },
      { id: 4, name: "NextWave Electronics" },
      { id: 5, name: "Innovatech Components" }
    ];

    this.categories = [
      { id: 1, name: "Smartphones & Accessories" },
      { id: 2, name: "Computers & Laptops" },
      { id: 3, name: "Audio & Sound Systems" },
      { id: 4, name: "Gaming & Consoles" },
      { id: 5, name: "Wearable Tech" },
      { id: 6, name: "Home Automation & IoT" },
      { id: 7, name: "Cameras & Photography" }
    ];
  }

  addProduct(product) {
    product.id = this.nextId++;
    this.products.push(product);
  }

  updateProduct(updatedProduct) {
    const index = this.products.findIndex(p => p.id === updatedProduct.id);
    if (index !== -1) {
      this.products[index] = updatedProduct;
    }
  }

  deleteProduct(id) {
    this.products = this.products.filter(p => p.id !== id);
  }

  getProducts() {
    return this.products;
  }

  getProductById(id) {
    return this.products.find(p => p.id === id);
  }

  getSuppliers() {
    return this.suppliers;
  }

  getCategories() {
    return this.categories;
  }

  getSupplier(id) {
    return this.suppliers.find(supplier => supplier.id === id) || null;
  }

  getCategory(id) {
    return this.categories.find(category => category.id === id) || null;
  }
}