import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreatePurchaseRequestPageComponent } from './create-purchase-request-page.component';

describe('CreatePurchaseRequestPageComponent', () => {
  let component: CreatePurchaseRequestPageComponent;
  let fixture: ComponentFixture<CreatePurchaseRequestPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreatePurchaseRequestPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreatePurchaseRequestPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
