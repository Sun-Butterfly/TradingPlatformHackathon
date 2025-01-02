import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateMessagePageComponent } from './create-message-page.component';

describe('CreateMessagePageComponent', () => {
  let component: CreateMessagePageComponent;
  let fixture: ComponentFixture<CreateMessagePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateMessagePageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateMessagePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
