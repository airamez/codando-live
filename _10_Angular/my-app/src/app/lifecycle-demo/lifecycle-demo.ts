import { Component, ViewChild, ElementRef, AfterViewInit, OnChanges, OnInit, OnDestroy, SimpleChanges } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'lifecycle-demo',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './lifecycle-demo.html',
  styleUrls: ['./lifecycle-demo.css']
})
export class LifecycleDemo implements OnChanges, OnInit, AfterViewInit, OnDestroy {
  @ViewChild('textArea', { static: false }) textArea!: ElementRef<HTMLTextAreaElement>;
  @ViewChild('logArea', { static: false }) logArea!: ElementRef<HTMLTextAreaElement>;
  @ViewChild('colorSelect', { static: false }) colorSelect!: ElementRef<HTMLSelectElement>;
  @ViewChild('targetSelect', { static: false }) targetSelect!: ElementRef<HTMLSelectElement>;
  @ViewChild('applyButton', { static: false }) applyButton!: ElementRef<HTMLButtonElement>;
  wordCount: number | null = null;
  charCount: number | null = null;
  private logs: string[] = []; // Store logs until view is ready
  private colors: { value: string, label: string }[] = []; // Store colors for dropdown

  ngOnChanges(changes: SimpleChanges) {
    const logMessage = `ngOnChanges: Changes detected ${JSON.stringify(changes)}\n`;
    this.logs.push(logMessage);
    console.log(logMessage.trim()); // Keep console.log for debugging
  }

  ngOnInit() {
    const logMessage = 'ngOnInit: Component initialized\n';
    this.logs.push(logMessage);
    console.log(logMessage.trim());
    // Initialize colors array
    this.colors = [
      { value: 'red', label: 'Red' },
      { value: 'blue', label: 'Blue' },
      { value: 'green', label: 'Green' },
      { value: 'yellow', label: 'Yellow' },
      { value: 'purple', label: 'Purple' }
    ];
  }

  ngAfterViewInit() {
    const logMessage = 'ngAfterViewInit: View initialized\n';
    this.logs.push(logMessage);
    console.log(logMessage.trim());
    this.textArea.nativeElement.focus();

    // Populate color dropdown
    this.colors.forEach(color => {
      const option = document.createElement('option');
      option.value = color.value;
      option.text = color.label;
      this.colorSelect.nativeElement.appendChild(option);
    });

    // Add event listener for textarea input changes
    this.textArea.nativeElement.addEventListener('input', () => {
      this.updateCounts();
      this.appendLog(`Textarea input changed: ${this.textArea.nativeElement.value.slice(0, 50)}${this.textArea.nativeElement.value.length > 50 ? '...' : ''}\n`);
    });

    // Add event listener for Apply button
    this.applyButton.nativeElement.addEventListener('click', () => this.updateColor());

    // Flush stored logs to textarea
    this.logArea.nativeElement.value = this.logs.join('');
    this.logArea.nativeElement.scrollTop = this.logArea.nativeElement.scrollHeight; // Auto-scroll to bottom
  }

  ngOnDestroy() {
    const logMessage = 'ngOnDestroy: Component destroyed\n';
    this.logs.push(logMessage);
    console.log(logMessage.trim());
    this.appendLog(logMessage);
    // Remove event listeners to prevent memory leaks
    this.textArea.nativeElement.removeEventListener('input', () => this.updateCounts());
    this.applyButton.nativeElement.removeEventListener('click', () => this.updateColor());
  }

  private updateCounts() {
    const text = this.textArea.nativeElement.value.trim();
    this.wordCount = text ? text.split(/\s+/).length : 0;
    this.charCount = this.textArea.nativeElement.value.length;
  }

  private updateColor() {
    const color = this.colorSelect.nativeElement.value;
    const target = this.targetSelect.nativeElement.value;
    // Apply the selected color to the chosen target
    this.textArea.nativeElement.style.color = target === 'color' ? color : '';
    this.textArea.nativeElement.style.backgroundColor = target === 'background-color' ? color : '';
    this.appendLog(`Color applied: ${color} to ${target}\n`);
  }

  private appendLog(message: string) {
    if (this.logArea) {
      this.logArea.nativeElement.value += message;
      this.logArea.nativeElement.scrollTop = this.logArea.nativeElement.scrollHeight; // Auto-scroll to bottom
    }
  }
}