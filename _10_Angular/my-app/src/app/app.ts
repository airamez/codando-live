import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { HelloWorld } from './hello-world/hello-world';
import { BindingDemo } from './binding-demo/binding-demo';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, HelloWorld, BindingDemo],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  protected title = 'my-app';
}
