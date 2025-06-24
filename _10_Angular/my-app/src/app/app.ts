import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
// import { HelloWorld } from './hello-world/hello-world';
// import { BindingDemo } from './binding-demo/binding-demo';
// import { DataFormDemo } from './data-form-demo/data-form-demo';
// import { TaskList } from './task-list/task-list';
import { TaskListModern } from './task-list-modern/task-list-modern';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    // HelloWorld,
    // BindingDemo,
    // DataFormDemo,
    // TaskList,
    TaskListModern
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'my-app';
}
