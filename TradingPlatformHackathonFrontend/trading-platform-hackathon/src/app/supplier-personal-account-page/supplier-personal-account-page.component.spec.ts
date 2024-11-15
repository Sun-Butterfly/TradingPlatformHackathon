import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SupplierPersonalAccountPageComponent } from './supplier-personal-account-page.component';

describe('SupplierPersonalAccountPageComponent', () => {
  let component: SupplierPersonalAccountPageComponent;
  let fixture: ComponentFixture<SupplierPersonalAccountPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SupplierPersonalAccountPageComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SupplierPersonalAccountPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
