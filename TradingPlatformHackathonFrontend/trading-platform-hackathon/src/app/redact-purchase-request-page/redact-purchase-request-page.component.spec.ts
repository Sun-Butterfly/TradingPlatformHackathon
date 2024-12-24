import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RedactPurchaseRequestPageComponent } from './redact-purchase-request-page.component';

describe('RedactPurchaseRequestPageComponent', () => {
  let component: RedactPurchaseRequestPageComponent;
  let fixture: ComponentFixture<RedactPurchaseRequestPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RedactPurchaseRequestPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RedactPurchaseRequestPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
