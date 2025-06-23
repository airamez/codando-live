import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'task-list-modern',
  imports: [FormsModule],
  templateUrl: './task-list-modern.html',
  styleUrl: './task-list-modern.css'
})
export class TaskListModern {
  task = "";
  tasks: string[] = [];

  addTask() {
    if (this.task.length > 0) {
      this.tasks.push(this.task);
    }
    this.task = "";
  }
}
