import { Component, EventEmitter, Input, OnChanges, Output, SimpleChanges } from '@angular/core';
import { FormBuilder, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { UserPostsService } from '../services/user-posts.service';
import { UserPost } from '../models/UserPost';

@Component({
  selector: 'app-post-edit',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './post-edit.html',
  styleUrls: ['./post-edit.css']
})
export class PostEdit implements OnChanges {
  @Input() post!: UserPost;
  @Output() saved = new EventEmitter<void>();
  @Output() cancel = new EventEmitter<void>();

  postForm!: FormGroup;

  constructor(private fb: FormBuilder, private userPostsService: UserPostsService) {
    this.postForm = this.fb.group({
      title: ['', Validators.required],
      body: ['', Validators.required]
    });
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['post'] && this.post) {
      this.postForm.patchValue({
        title: this.post.title,
        body: this.post.body
      });
    }
  }

  onSubmit(): void {
    if (this.postForm.valid) {
      const updatedPost = {
        ...this.post,
        title: this.postForm.value.title,
        body: this.postForm.value.body
      };
      this.userPostsService.updatePost(this.post.id!!, updatedPost).subscribe({
        next: () => this.saved.emit(),
        error: (err) => console.error('Error updating post:', err)
      });
    }
  }
}