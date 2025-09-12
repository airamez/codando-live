import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { TodoService, TodoItem } from './todo.service';

@Component({
  selector: 'app-todo',
  standalone: true,
  imports: [CommonModule, FormsModule],
  template: `
    <div class="todo-container">
      <h1>Todo App</h1>
      
      <div class="add-todo">
        <input 
          type="text" 
          [(ngModel)]="newTodoTitle" 
          placeholder="Add a new todo..."
          (keyup.enter)="addTodo()"
          class="todo-input"
        >
        <button (click)="addTodo()" class="add-btn">Add</button>
      </div>

      <div class="todo-list">
        @if (todos().length === 0) {
          <p class="no-todos">No todos yet. Add one above!</p>
        }
        
        @for (todo of todos(); track todo.id) {
          <div class="todo-item" [class.completed]="todo.isCompleted">
            <input 
              type="checkbox" 
              [checked]="todo.isCompleted"
              (change)="toggleTodo(todo)"
              class="todo-checkbox"
            >
            <span class="todo-title">{{ todo.title }}</span>
            <button (click)="deleteTodo(todo.id)" class="delete-btn">Delete</button>
          </div>
        }
      </div>

      @if (loading()) {
        <div class="loading">Loading...</div>
      }

      @if (error()) {
        <div class="error">{{ error() }}</div>
      }
    </div>
  `,
  styles: [`
    .todo-container {
      max-width: 600px;
      margin: 2rem auto;
      padding: 2rem;
      font-family: -apple-system, BlinkMacSystemFont, 'Segoe UI', Roboto, sans-serif;
    }

    h1 {
      text-align: center;
      color: #333;
      margin-bottom: 2rem;
    }

    .add-todo {
      display: flex;
      gap: 1rem;
      margin-bottom: 2rem;
    }

    .todo-input {
      flex: 1;
      padding: 0.75rem;
      border: 2px solid #ddd;
      border-radius: 4px;
      font-size: 1rem;
    }

    .todo-input:focus {
      outline: none;
      border-color: #007bff;
    }

    .add-btn {
      padding: 0.75rem 1.5rem;
      background: #007bff;
      color: white;
      border: none;
      border-radius: 4px;
      cursor: pointer;
      font-size: 1rem;
    }

    .add-btn:hover {
      background: #0056b3;
    }

    .todo-list {
      space-y: 0.5rem;
    }

    .todo-item {
      display: flex;
      align-items: center;
      gap: 1rem;
      padding: 1rem;
      border: 1px solid #ddd;
      border-radius: 4px;
      margin-bottom: 0.5rem;
    }

    .todo-item.completed {
      background: #f8f9fa;
      opacity: 0.7;
    }

    .todo-checkbox {
      width: 1.2rem;
      height: 1.2rem;
    }

    .todo-title {
      flex: 1;
      font-size: 1rem;
    }

    .todo-item.completed .todo-title {
      text-decoration: line-through;
    }

    .delete-btn {
      padding: 0.5rem 1rem;
      background: #dc3545;
      color: white;
      border: none;
      border-radius: 4px;
      cursor: pointer;
      font-size: 0.875rem;
    }

    .delete-btn:hover {
      background: #c82333;
    }

    .no-todos {
      text-align: center;
      color: #666;
      font-style: italic;
      padding: 2rem;
    }

    .loading {
      text-align: center;
      padding: 1rem;
      color: #666;
    }

    .error {
      background: #f8d7da;
      color: #721c24;
      padding: 1rem;
      border-radius: 4px;
      margin-top: 1rem;
    }
  `]
})
export class TodoComponent implements OnInit {
  todos = signal<TodoItem[]>([]);
  loading = signal(false);
  error = signal<string | null>(null);
  newTodoTitle = '';

  constructor(private todoService: TodoService) {}

  ngOnInit(): void {
    this.loadTodos();
  }

  loadTodos(): void {
    this.loading.set(true);
    this.error.set(null);
    
    this.todoService.getTodos().subscribe({
      next: (todos) => {
        this.todos.set(todos);
        this.loading.set(false);
      },
      error: (err) => {
        console.error('Error loading todos:', err);
        this.error.set('Failed to load todos. Make sure the API is running.');
        this.loading.set(false);
      }
    });
  }

  addTodo(): void {
    if (!this.newTodoTitle.trim()) return;

    const newTodo = {
      title: this.newTodoTitle.trim(),
      isCompleted: false
    };

    this.todoService.createTodo(newTodo).subscribe({
      next: (todo) => {
        this.todos.update(todos => [...todos, todo]);
        this.newTodoTitle = '';
      },
      error: (err) => {
        console.error('Error creating todo:', err);
        this.error.set('Failed to create todo.');
      }
    });
  }

  toggleTodo(todo: TodoItem): void {
    const updatedTodo = { ...todo, isCompleted: !todo.isCompleted };
    
    this.todoService.updateTodo(todo.id, updatedTodo).subscribe({
      next: () => {
        this.todos.update(todos => 
          todos.map(t => t.id === todo.id ? updatedTodo : t)
        );
      },
      error: (err) => {
        console.error('Error updating todo:', err);
        this.error.set('Failed to update todo.');
      }
    });
  }

  deleteTodo(id: number): void {
    this.todoService.deleteTodo(id).subscribe({
      next: () => {
        this.todos.update(todos => todos.filter(t => t.id !== id));
      },
      error: (err) => {
        console.error('Error deleting todo:', err);
        this.error.set('Failed to delete todo.');
      }
    });
  }
}
