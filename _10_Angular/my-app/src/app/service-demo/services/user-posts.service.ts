import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from '../../../environments/environment';
import { UserPost } from '../models/UserPost';

@Injectable({
  providedIn: 'root'
})
export class UserPostsService {
  private baseUrl = environment.apiUrl;  // Dynamically set based on environment
  
  constructor(private http: HttpClient) { }

  getPostsByUser(userId: number): Observable<UserPost[]> {
    return this.http.get<UserPost[]>(`${this.baseUrl}/posts?userId=${userId}`);
  }

  createPost(post: UserPost): Observable<UserPost> {
    return this.http.post<UserPost>(`${this.baseUrl}/posts`, post);
  }

  updatePost(id: number, post: UserPost): Observable<UserPost> {
    return this.http.put<UserPost>(`${this.baseUrl}/posts/${id}`, post);
  }

  deletePost(id: number): Observable<UserPost> {
    return this.http.delete<any>(`${this.baseUrl}/posts/${id}`);
  }  
}
