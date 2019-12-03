/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { By } from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import { FirmContComponent } from './firm-cont.component';

describe('FirmContComponent', () => {
  let component: FirmContComponent;
  let fixture: ComponentFixture<FirmContComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FirmContComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FirmContComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
