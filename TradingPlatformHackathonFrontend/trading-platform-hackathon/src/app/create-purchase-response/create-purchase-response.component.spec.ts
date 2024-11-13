import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePurchaseResponseComponent } from './create-purchase-response.component';

describe('CreatePurchaseResponseComponent', () => {
  let component: CreatePurchaseResponseComponent;
  let fixture: ComponentFixture<CreatePurchaseResponseComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreatePurchaseResponseComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatePurchaseResponseComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
