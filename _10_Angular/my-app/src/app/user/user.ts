import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user',
  imports: [],
  templateUrl: './user.html',
  styleUrl: './user.css'
})
export class User {
    userId: string | null = null;

    constructor(private route: ActivatedRoute) {}

    ngOnInit(): void {
      this.route.paramMap.subscribe(params => {
        this.userId = params.get('id');
      });
    }
}
