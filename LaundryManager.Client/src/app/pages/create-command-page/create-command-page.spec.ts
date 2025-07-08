import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateCommandPage } from './create-command-page';

describe('CreateCommandPage', () => {
  let component: CreateCommandPage;
  let fixture: ComponentFixture<CreateCommandPage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CreateCommandPage]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CreateCommandPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
