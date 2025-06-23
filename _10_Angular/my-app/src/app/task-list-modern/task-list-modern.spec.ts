import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TaskListModern } from './task-list-modern';

describe('TaskListModern', () => {
  let component: TaskListModern;
  let fixture: ComponentFixture<TaskListModern>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TaskListModern]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TaskListModern);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
