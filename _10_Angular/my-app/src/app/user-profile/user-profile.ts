import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'user-profile',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './user-profile.html',
  styleUrl: './user-profile.css'
})
export class UserProfile {
  user = { name: '', isPremium: false };
  premiumUsers = ['leila', 'jose', 'artur'];
  inputUsername: string = '';

  checkPremiumStatus() {
    this.user.name = this.inputUsername;
    this.user.isPremium = this.premiumUsers.includes(this.inputUsername.toLowerCase());
  }
}