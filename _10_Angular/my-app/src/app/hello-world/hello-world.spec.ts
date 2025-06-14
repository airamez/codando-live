import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HelloWorld } from './hello-world';

describe('HelloWorld', () => {
  let component: HelloWorld;
  let fixture: ComponentFixture<HelloWorld>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HelloWorld]
    })
    .compileComponents();

    fixture = TestBed.createComponent(HelloWorld);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
