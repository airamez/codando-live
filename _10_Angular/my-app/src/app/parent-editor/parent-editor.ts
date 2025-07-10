import { Component, ViewChild, ElementRef } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ColorSelector } from '../color-selector/color-selector';

@Component({
  selector: 'parent-editor',
  standalone: true,
  imports: [FormsModule, ColorSelector],
  templateUrl: './parent-editor.html',
  styleUrls: ['./parent-editor.css']
})
export class ParentEditor {
  @ViewChild('textArea', { static: false }) textArea!: ElementRef<HTMLTextAreaElement>;

  textColors: { value: string, label: string }[] = [
    { value: 'red', label: 'Red' },
    { value: 'blue', label: 'Blue' },
    { value: 'green', label: 'Green' }
  ];

  backgroundColors: { value: string, label: string }[] = [
    { value: 'lightgray', label: 'Light Gray' },
    { value: 'beige', label: 'Beige' },
    { value: 'lightyellow', label: 'Light Yellow' }
  ];

  private inputHandler: () => void;

  constructor() {
    this.inputHandler = () => {
      const text = this.textArea?.nativeElement?.value || '';
      console.log(`Textarea input changed: ${text}`);
    };
  }

  setInputListener() {
    if (this.textArea) {
      this.textArea.nativeElement.addEventListener('input', this.inputHandler);
    }
  }

  removeInputListener() {
    if (this.textArea) {
      this.textArea.nativeElement.removeEventListener('input', this.inputHandler);
    }
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