import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SingupAdminComponent } from './singup-admin.component';

describe('SingupAdminComponent', () => {
  let component: SingupAdminComponent;
  let fixture: ComponentFixture<SingupAdminComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SingupAdminComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SingupAdminComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
