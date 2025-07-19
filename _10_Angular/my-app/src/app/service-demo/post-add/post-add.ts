import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserPostsService } from '../services/user-posts.service';
import { UserPost } from '../models/UserPost';

@Component({
  selector: 'app-post-add',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './post-add.html',
  styleUrls: ['./post-add.css']
})
export class PostAdd implements OnInit {
  @Input() userId!: number;
  @Output() saved = new EventEmitter<void>();
  @Output() cancel = new EventEmitter<void>();

  postForm!: FormGroup;

  constructor(private fb: FormBuilder, private apiService: UserPostsService) {}

  ngOnInit(): void {
    this.postForm = this.fb.group({
      title: ['', Validators.required],
      body: ['', Validators.required]
    });
  }

  onSubmit(): void {
    if (this.postForm.valid) {
      const newPost: UserPost = {
        userId: this.userId,
        title: this.postForm.value.title,
        body: this.postForm.value.body
      };
      this.apiService.createPost(newPost).subscribe({
        next: () => this.saved.emit(),
        error: (err) => console.error('Error creating post:', err)
      });
    }
  }
}