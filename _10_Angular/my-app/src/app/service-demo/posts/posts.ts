import { Component, Input, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute } from '@angular/router';
import { UserPostsService } from '../services/user-posts.service';
import { UserPost } from '../models/UserPost'; 
import { PostList } from '../post-list/post-list';
import { PostAdd } from '../post-add/post-add';
import { PostEdit } from '../post-edit/post-edit';

@Component({
  selector: 'app-posts',
  standalone: true,
  imports: [CommonModule, PostList, PostAdd, PostEdit],
  templateUrl: './posts.html',
  styleUrls: ['./posts.css']
})
export class Posts implements OnInit {
  @Input() userId!: number;
  posts: UserPost[] = [];
  showAdd = false;
  selectedPost: UserPost | null = null;

  constructor(
    private route: ActivatedRoute,
    private userPostsService: UserPostsService) {}

  ngOnInit(): void {
      this.route.params.subscribe(params => {
        this.userId = +params['userId'];  // Extract userId from URL param
        this.loadPosts();
      });
    }

  loadPosts(): void {
    this.userPostsService.getPostsByUser(this.userId).subscribe({
      next: (posts) => this.posts = posts,
      error: (err) => console.error('Error loading posts:', err)
    });
  }

  onAdd(): void {
    this.showAdd = true;
  }

  onEdit(post: UserPost): void {
    this.selectedPost = post;
  }

  onDelete(postId: number): void {
    if (confirm('Are you sure you want to delete this post?')) {
      this.userPostsService.deletePost(postId).subscribe({
        next: () => this.loadPosts(),
        error: (err) => console.error('Error deleting post:', err)
      });
    }
  }

  onSaved(): void {
    this.showAdd = false;
    this.selectedPost = null;
    this.loadPosts();
  }

  onCancel(): void {
    this.showAdd = false;
    this.selectedPost = null;
  }
}