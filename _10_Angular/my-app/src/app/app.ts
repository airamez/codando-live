import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HelloWorld } from './hello-world/hello-world';
import { BindingDemo } from './binding-demo/binding-demo';
import { DataFormDemo } from './data-form-demo/data-form-demo';

@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    // HelloWorld,
    // BindingDemo,
    DataFormDemo],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'my-app';
}
