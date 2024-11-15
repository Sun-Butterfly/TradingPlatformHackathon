import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BuyerPersonalAccountPageComponent } from './buyer-personal-account-page.component';

describe('BuyerPersonalAccountPageComponent', () => {
  let component: BuyerPersonalAccountPageComponent;
  let fixture: ComponentFixture<BuyerPersonalAccountPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [BuyerPersonalAccountPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BuyerPersonalAccountPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
