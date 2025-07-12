import { Component, ViewChild, ElementRef, OnInit } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ColorSelector } from '../color-selector/color-selector';

@Component({
  selector: 'parent-editor',
  standalone: true,
  imports: [FormsModule, ColorSelector],
  templateUrl: './parent-editor.html',
  styleUrls: ['./parent-editor.css']
})
export class ParentEditor implements OnInit {
  @ViewChild('textArea', { static: false }) textArea!: ElementRef<HTMLTextAreaElement>;

  textColors: { value: string, label: string }[] = [];

  backgroundColors: { value: string, label: string }[] = [];

  constructor() {
  }

  ngOnInit() {
    // Pretend to load the colors asynchronously, e.g., from a service or API
    setTimeout(() => {
      this.textColors = [
        { value: 'black', label: 'Black' },
        { value: 'red', label: 'Red' },
        { value: 'blue', label: 'Blue' },
        { value: 'green', label: 'Green' }
      ];

      this.backgroundColors = [
        { value: 'white', label: 'White' },
        { value: 'lightgray', label: 'Light Gray' },
        { value: 'beige', label: 'Beige' },
        { value: 'lightyellow', label: 'Light Yellow' }
      ];
    }, 3000); // Simulate a 1-second delay for loading
  }

  handleColorChange(type: 'text' | 'background', color: string) {
    if (this.textArea) {
      if (type === 'text') {
        this.textArea.nativeElement.style.color = color;
        console.log(`Text color changed to: ${color}`);
      } else {
        this.textArea.nativeElement.style.backgroundColor = color;
        console.log(`Background color changed to: ${color}`);
      }
    }
  }
}