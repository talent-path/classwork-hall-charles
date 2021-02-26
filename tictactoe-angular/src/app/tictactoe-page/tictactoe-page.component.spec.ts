import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TictactoePageComponent } from './tictactoe-page.component';

describe('TictactoePageComponent', () => {
  let component: TictactoePageComponent;
  let fixture: ComponentFixture<TictactoePageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TictactoePageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TictactoePageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
