import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // For [(ngModel)]
import { SelectModule } from 'primeng/select'; // Updated import
import { TableModule } from 'primeng/table';
import { ButtonModule } from 'primeng/button';
import { DialogModule } from 'primeng/dialog';
import { InputTextModule } from 'primeng/inputtext';
import { TextareaModule } from 'primeng/textarea';
import { RippleModule } from 'primeng/ripple';
import { SelectItem } from 'primeng/api';

@Component({
  selector: 'users-and-posts',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    SelectModule,
    TableModule,
    ButtonModule,
    DialogModule,
    InputTextModule,
    TextareaModule,
    RippleModule
  ],
  templateUrl: './users-and-posts.html',
  styleUrl: './users-and-posts.css'
})
export class UsersAndPosts implements OnInit {
  users: SelectItem[] = [];
  selectedUser: number | null = null;
  posts: any[] = [];
  postForm: FormGroup;
  dialogVisible: boolean = false;
  isEditing: boolean = false;
  currentPost: any = null;

  constructor(private http: HttpClient, private fb: FormBuilder) {
    this.postForm = this.fb.group({
      title: ['', Validators.required],
      body: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    this.http.get<any[]>('https://jsonplaceholder.typicode.com/users').subscribe(users => {
      this.users = users.map(user => ({ label: user.name, value: user.id }));
    });
  }

  onUserChange(event: any): void {
    if (event.value) {
      this.http.get<any[]>(`https://jsonplaceholder.typicode.com/posts?userId=${event.value}`).subscribe(posts => {
        this.posts = posts;
      });
    } else {
      this.posts = [];
    }
  }

  showDialog(isEditing: boolean, post?: any): void {
    this.isEditing = isEditing;
    if (isEditing && post) {
      this.currentPost = post;
      this.postForm.patchValue({
        title: post.title,
        body: post.body
      });
    } else {
      this.currentPost = null;
      this.postForm.reset();
    }
    this.dialogVisible = true;
  }

  savePost(): void {
    if (this.postForm.invalid) return;

    const postData = {
      ...this.postForm.value,
      userId: this.selectedUser
    };

    if (this.isEditing) {
      postData['id'] = this.currentPost.id;
      this.http.put<any>(`https://jsonplaceholder.typicode.com/posts/${this.currentPost.id}`, postData).subscribe(updatedPost => {
        const index = this.posts.findIndex(p => p.id === updatedPost.id);
        if (index !== -1) {
          this.posts[index] = updatedPost;
          this.posts = [...this.posts];
        }
        this.dialogVisible = false;
      });
    } else {
      this.http.post<any>('https://jsonplaceholder.typicode.com/posts', postData).subscribe(newPost => {
        this.posts = [...this.posts, newPost];
        this.dialogVisible = false;
      });
    }
  }

  deletePost(id: number): void {
    this.http.delete(`https://jsonplaceholder.typicode.com/posts/${id}`).subscribe(() => {
      this.posts = this.posts.filter(p => p.id !== id);
    });
  }
}