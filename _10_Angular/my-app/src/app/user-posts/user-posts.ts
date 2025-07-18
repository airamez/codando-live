// post-list.component.ts
import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { Observable, catchError, of } from 'rxjs';

interface Post {
  userId: number;
  id: number;
  title: string;
  body: string;
}

@Component({
  selector: 'user-posts',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user-posts.html',
  styleUrls: ['./user-posts.css']
})
export class UserPosts {
  userId: number | null = null;
  posts$: Observable<Post[]> | null = null;
  errorMessage: string | null = null;

  constructor(private http: HttpClient) {}

  getPosts() {
    if (this.userId === null || this.userId <= 0) {
      this.errorMessage = 'Please enter a valid User ID.';
      this.posts$ = null;
      return;
    }

    this.errorMessage = null;
    this.posts$ = this.http.get<Post[]>(`https://jsonplaceholder.typicode.com/posts?userId=${this.userId}`).pipe(
      catchError(err => {
        this.errorMessage = 'An error occurred while fetching posts.';
        return of([]);
      })
    );
  }
}