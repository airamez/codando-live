import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TruncatePipe } from './truncate.pipe';

@Component({
  selector: 'product-list',
  standalone: true,
  imports: [CommonModule, TruncatePipe],
  // WARNING: HTML and CSS template embebed into the component
  // NOT A GOOD IDEA
  template: `
    <h1>Product List</h1>
    <ul>
      <li *ngFor="let product of products">
        {{ product.name }}: {{ product.description | truncate:50 }}
      </li>
    </ul>
    <h3>Example with Custom Limit</h3>
    <p>{{ sampleText | truncate:20:'###' }}</p>
    <p>Today: {{ today | date:'medium' }}</p>
    <p>Today: {{ today | date:'medium' | truncate:20 }}</p>
  `,
  styles: [`
    h1 {
      font-size: 2rem;
      color: #1a3c34;
      margin-bottom: 1.5rem;
      text-align: center;
    }

    ul {
      list-style: none;
      padding: 0;
      margin: 0 0 2rem 0;
    }

    li {
      padding: 0.75rem 1rem;
      background-color: #f8f9fa;
      border-radius: 0.5rem;
      margin-bottom: 0.5rem;
      font-size: 1rem;
      color: #333;
      transition: background-color 0.2s ease;
    }

    li:hover {
      background-color: #e9ecef;
    }

    h3 {
      font-size: 1.25rem;
      color: #2b5f56;
      margin-bottom: 1rem;
    }

    p {
      font-size: 1rem;
      color: #555;
      background-color: #fff;
      padding: 1rem;
      border: 1px solid #dee2e6;
      border-radius: 0.5rem;
      max-width: 600px;
      margin: 0 auto;
    }

    :host {
      display: block;
      padding: 2rem;
      max-width: 800px;
      margin: 0 auto;
    }
  `]
})
export class ProductList {
  today: Date = new Date();
  sampleText: string = 'This is a long description that needs truncation for display purposes.';
  products = [
    { name: 'Laptop', description: 'A high-performance laptop for professionals and gamers.' },
    { name: 'Phone', description: 'A sleek smartphone with advanced camera features.' },
    { name: 'Tablet', description: 'A lightweight tablet for productivity and entertainment.' }
  ];
}