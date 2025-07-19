import { Component } from '@angular/core';
import { RouterOutlet, RouterLink } from '@angular/router';
// import { HelloWorld } from './hello-world/hello-world';
// import { BindingDemo } from './binding-demo/binding-demo';
// import { DataFormDemo } from './data-form-demo/data-form-demo';
// import { TaskList } from './task-list/task-list';
// import { TaskListModern } from './task-list-modern/task-list-modern';
// import { UserProfile } from './user-profile/user-profile';
// import { TextEditor } from './text-editor/text-editor';
// import { ParentEditor } from './parent-editor/parent-editor';
// import { ProductList } from './product-list';
import { PrimeNgDemo } from './prime-ng/prime-ng-demo/prime-ng-demo';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    //RouterLink,
    // HelloWorld
    // BindingDemo
    // DataFormDemo
    // TaskList
    // TaskListModern
    // UserProfile
    // TextEditor
    // ParentEditor
    // ProductList
    PrimeNgDemo
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'my-app';
}
