import { Component, ViewChild, ElementRef, AfterViewInit } from '@angular/core';

@Component({
  selector: 'text-editor',
  standalone: true,
  templateUrl: './text-editor.html',
  styleUrls: ['./text-editor.css']
})
export class TextEditor implements AfterViewInit {
  @ViewChild('textArea', { static: false }) textArea!: ElementRef<HTMLTextAreaElement>;
  wordCount: number | null = null;
  isLarge: boolean = false;
  colors: string[] = ['#000000', '#ff0000', '#00ff00', '#0000ff'];
  colorIndex: number = 0;

  ngAfterViewInit() {
    this.textArea.nativeElement.focus();
  }

  focusTextArea() {
    this.textArea.nativeElement.focus();
  }

  changeTextColor() {
    this.colorIndex = (this.colorIndex + 1) % this.colors.length;
    this.textArea.nativeElement.style.color = this.colors[this.colorIndex];
  }

  resizeTextArea() {
    this.isLarge = !this.isLarge;
    this.textArea.nativeElement.style.height = this.isLarge ? '300px' : '100px';
  }

  countWords() {
    const text = this.textArea.nativeElement.value.trim();
    this.wordCount = text ? text.split(/\s+/).length : 0;
  }
}