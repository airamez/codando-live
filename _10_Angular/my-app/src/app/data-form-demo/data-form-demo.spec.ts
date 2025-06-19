import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DataFormDemo } from './data-form-demo';

describe('DataFormDemo', () => {
  let component: DataFormDemo;
  let fixture: ComponentFixture<DataFormDemo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DataFormDemo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DataFormDemo);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
