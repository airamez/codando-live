import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
// import { HelloWorld } from './hello-world/hello-world';
// import { BindingDemo } from './binding-demo/binding-demo';
// import { DataFormDemo } from './data-form-demo/data-form-demo';
// import { TaskList } from './task-list/task-list';
// import { TaskListModern } from './task-list-modern/task-list-modern';
// import { UserProfile } from './user-profile/user-profile';
// import { TextEditor } from './text-editor/text-editor';
// import { ParentEditor } from './parent-editor/parent-editor';
import { ProductList } from './product-list';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    // HelloWorld,
    // BindingDemo,
    // DataFormDemo,
    // TaskList,
    // TaskListModern,
    // UserProfile,
    // TextEditor,
    // ParentEditor
    ProductList
  ],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'my-app';
}
