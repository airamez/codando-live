import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BindingDemo } from './binding-demo';

describe('BindingDemo', () => {
  let component: BindingDemo;
  let fixture: ComponentFixture<BindingDemo>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BindingDemo]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BindingDemo);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
