import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UserPost } from '../models/UserPost'; 

@Component({
  selector: 'app-post-list',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './post-list.html',
  styleUrls: ['./post-list.css']
})
export class PostList {
  @Input() posts: UserPost[] = [];
  @Output() edit = new EventEmitter<UserPost>();
  @Output() delete = new EventEmitter<number>();
}