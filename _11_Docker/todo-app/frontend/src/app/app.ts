import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { TodoComponent } from './todo.component';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, TodoComponent],
  template: `
    <app-todo></app-todo>
    <router-outlet />
  `,
  styles: [`
    :host {
      display: block;
      min-height: 100vh;
      background: #f5f5f5;
    }
  `]
})
export class App {}
