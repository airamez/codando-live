import { Component, Input, Output, EventEmitter, AfterViewInit } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'color-selector',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './color-selector.html',
  styleUrls: ['./color-selector.css']
})
export class ColorSelector implements AfterViewInit {
  @Input() colors: { value: string, label: string }[] = [];
  @Input() label: string = 'Select Color';
  @Output() colorChange = new EventEmitter<string>();

  selectedColor: string;

  constructor() {
    this.selectedColor = this.colors.length > 0 ? this.colors[0].value : '';
  }

  ngAfterViewInit() {
    if (this.selectedColor) {
      this.colorChange.emit(this.selectedColor);
    }
  }

  onColorChange() {
    this.colorChange.emit(this.selectedColor);
  }
}