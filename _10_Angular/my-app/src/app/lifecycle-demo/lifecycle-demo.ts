import {
  Component, ViewChild, ElementRef, AfterViewInit, OnChanges,
  OnInit, OnDestroy, SimpleChanges, Input, Renderer2
} from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'lifecycle-demo',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './lifecycle-demo.html',
  styleUrls: ['./lifecycle-demo.css']
})
export class LifecycleDemo implements OnChanges, OnInit, AfterViewInit, OnDestroy {
  @Input() inputData: any;
  @ViewChild('textArea', { static: false }) textArea!: ElementRef<HTMLTextAreaElement>;
  @ViewChild('logArea', { static: false }) logArea!: ElementRef<HTMLTextAreaElement>;
  @ViewChild('colorSelect', { static: false }) colorSelect!: ElementRef<HTMLSelectElement>;
  @ViewChild('targetSelect', { static: false }) targetSelect!: ElementRef<HTMLSelectElement>;
  @ViewChild('applyButton', { static: false }) applyButton!: ElementRef<HTMLButtonElement>;
  wordCount: number | null = null;
  charCount: number | null = null;
  private logs: string[] = [];
  colors: { value: string, label: string }[] = []; // Public for colorSelect @for
  private targets: { value: string, label: string }[] = []; // Private for targetSelect
  private inputHandler: () => void;

  constructor(private renderer: Renderer2) {
    this.inputHandler = () => {
      this.updateCounts();
      this.appendLog(`Textarea input changed: ${this.textArea.nativeElement.value.slice(0, 50)}${this.textArea.nativeElement.value.length > 50 ? '...' : ''}\n`);
    };
  }

  ngOnChanges(changes: SimpleChanges) {
    let logMessage = 'ngOnChanges: Changes detected\n';
    for (const propName of Object.keys(changes)) {
      const change = changes[propName];
      const from = JSON.stringify(change.previousValue);
      const to = JSON.stringify(change.currentValue);
      logMessage += `  ${propName}: Previous = ${from}, Current = ${to}\n`;
    }
    this.logs.push(logMessage);
    console.log(logMessage.trim());
  }

  ngOnInit() {
    const logMessage = 'ngOnInit: Component initialized\n';
    this.logs.push(logMessage);
    console.log(logMessage.trim());
    this.colors = [
      { value: 'red', label: 'Red' },
      { value: 'blue', label: 'Blue' },
      { value: 'green', label: 'Green' },
      { value: 'yellow', label: 'Yellow' },
      { value: 'purple', label: 'Purple' }
    ];
    this.targets = [
      { value: 'color', label: 'Text Color' },
      { value: 'background-color', label: 'Background Color' }
    ];
  }

  ngAfterViewInit() {
    const logMessage = 'ngAfterViewInit: View initialized\n';
    this.logs.push(logMessage);
    console.log(logMessage.trim());
    this.textArea.nativeElement.focus();

    // Populate targetSelect dropdown using Renderer2
    this.targets.forEach(target => {
      const option = this.renderer.createElement('option');
      this.renderer.setProperty(option, 'value', target.value);
      this.renderer.setProperty(option, 'text', target.label);
      this.renderer.appendChild(this.targetSelect.nativeElement, option);
    });

    // Log dropdown contents for debugging
    this.appendLog(`Color dropdown options: ${Array.from(this.colorSelect.nativeElement.options).map(o => o.value).join(', ')}\n`);
    this.appendLog(`Target dropdown options: ${Array.from(this.targetSelect.nativeElement.options).join(', ')}\n`);

    this.textArea.nativeElement.addEventListener('input', this.inputHandler);
    this.applyButton.nativeElement.addEventListener('click', this.handleApplyClick.bind(this));

    this.logArea.nativeElement.value = this.logs.join('');
    this.logArea.nativeElement.scrollTop = this.logArea.nativeElement.scrollHeight;
  }

  private handleApplyClick() {
    this.updateColor();
  }

  ngOnDestroy() {
    const logMessage = 'ngOnDestroy: Component destroyed\n';
    this.logs.push(logMessage);
    console.log(logMessage.trim());
    this.appendLog(logMessage);
    this.textArea.nativeElement.removeEventListener('input', this.inputHandler);
    this.applyButton.nativeElement.removeEventListener('click', this.handleApplyClick.bind(this));
  }

  private updateCounts() {
    const text = this.textArea.nativeElement.value.trim();
    this.wordCount = text ? text.split(/\s+/).length : 0;
    this.charCount = this.textArea.nativeElement.value.length;
  }

  private updateColor() {
    const color = this.colorSelect.nativeElement.value;
    const target = this.targetSelect.nativeElement.value;
    this.appendLog(`updateColor called: color=${color}, target=${target}\n`);

    if (target === 'color') {
      this.textArea.nativeElement.style.color = color;
    } else if (target === 'background-color') {
      this.textArea.nativeElement.style.backgroundColor = color;
    }

    // Debug inline and computed styles
    const computedStyle = window.getComputedStyle(this.textArea.nativeElement);
    this.appendLog(`Styles applied: inline color=${this.textArea.nativeElement.style.color}, inline backgroundColor=${this.textArea.nativeElement.style.backgroundColor}\n`);
    this.appendLog(`Computed styles: color=${computedStyle.color}, backgroundColor=${computedStyle.backgroundColor}\n`);
  }

  private appendLog(message: string) {
    this.logs.push(message);
    if (this.logArea) {
      this.logArea.nativeElement.value = this.logs.join('');
      this.logArea.nativeElement.scrollTop = this.logArea.nativeElement.scrollHeight;
    }
  }
}