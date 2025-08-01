import { Component, Input, Output, EventEmitter, AfterViewInit, OnChanges, SimpleChanges } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'color-selector',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './color-selector.html',
  styleUrls: ['./color-selector.css']
})
export class ColorSelector implements AfterViewInit, OnChanges {
  @Input() colors: { value: string, label: string }[] = [];
  @Input() label: string = 'Select Color';
  @Output() colorChange = new EventEmitter<string>();

  selectedColor: string = '';

  constructor() {
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes['colors'] && changes['colors'].currentValue?.length > 0) {
      this.selectedColor = this.colors[0].value;
      this.colorChange.emit(this.selectedColor);
    }
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