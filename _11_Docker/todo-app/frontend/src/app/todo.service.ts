import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface TodoItem {
  id: number;
  title: string;
  isCompleted: boolean;
  dueDate?: string;
}

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  private apiUrl = 'http://localhost:5000/api/todo';

  constructor(private http: HttpClient) { }

  getTodos(): Observable<TodoItem[]> {
    return this.http.get<TodoItem[]>(this.apiUrl);
  }

  getTodo(id: number): Observable<TodoItem> {
    return this.http.get<TodoItem>(`${this.apiUrl}/${id}`);
  }

  createTodo(todo: Omit<TodoItem, 'id'>): Observable<TodoItem> {
    return this.http.post<TodoItem>(this.apiUrl, todo);
  }

  updateTodo(id: number, todo: TodoItem): Observable<any> {
    return this.http.put(`${this.apiUrl}/${id}`, todo);
  }

  deleteTodo(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
