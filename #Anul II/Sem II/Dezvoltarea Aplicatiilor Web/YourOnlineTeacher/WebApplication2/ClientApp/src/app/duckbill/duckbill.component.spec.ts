import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DuckbillComponent } from './duckbill.component';

describe('DuckbillComponent', () => {
  let component: DuckbillComponent;
  let fixture: ComponentFixture<DuckbillComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DuckbillComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DuckbillComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
