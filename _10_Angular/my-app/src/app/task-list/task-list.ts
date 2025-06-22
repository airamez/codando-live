import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'task-list',
  imports: [FormsModule, CommonModule],
  templateUrl: './task-list.html',
  styleUrl: './task-list.css'
})
export class TaskList {
  task = "";
  tasks: string[] = [];

  addTask() {
    if (this.task.length > 0) {
      this.tasks.push(this.task);
    }
    this.task = "";
  }
}
