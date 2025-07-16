import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-home',
  imports: [FormsModule],
  templateUrl: './home.html',
  styleUrl: './home.css'
})
export class Home {

  userId: string = '';
  
  constructor(private router: Router) {}

  navigateToUser() {
    if (this.userId) {
      this.router.navigate(['/user', this.userId]);
    }
  }
}
