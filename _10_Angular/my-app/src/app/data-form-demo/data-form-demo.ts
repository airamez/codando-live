import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { JsonPipe } from '@angular/common';

@Component({
  selector: 'data-form-demo',
  imports: [FormsModule, JsonPipe],
  templateUrl: './data-form-demo.html',
  styleUrl: './data-form-demo.css'
})
export class DataFormDemo {
  formData: FormDataModel = new FormDataModel();

  submitForm() {
    console.log('Form Submitted:', this.formData);
    this.formData = new FormDataModel();
  }

}

class FormDataModel {
  name: string = '';
  age: number | null = null;
  salary: number | null = null;
  startDate: string = '';
  isSubscribed: boolean = false;
}