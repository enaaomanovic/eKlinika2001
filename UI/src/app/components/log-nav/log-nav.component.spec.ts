import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LogNavComponent } from './log-nav.component';

describe('LogNavComponent', () => {
  let component: LogNavComponent;
  let fixture: ComponentFixture<LogNavComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LogNavComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(LogNavComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
