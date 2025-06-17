import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'binding-demo',
  imports: [FormsModule],
  templateUrl: './binding-demo.html',
  styleUrl: './binding-demo.css'
})
export class BindingDemo {
  title = 'Welcome to Angular!';
  isDisabled = true;

  enable() {
    this.isDisabled = !this.isDisabled;
  }

  clicked() {
    alert('You did it!');
  }

  counter = 0;
  
  increment() {
    this.counter++;
  }
  
  decrement() {
    this.counter--;
  }

  userName = '';

  resetName() {
    this.userName = "Jose"
  }
}
