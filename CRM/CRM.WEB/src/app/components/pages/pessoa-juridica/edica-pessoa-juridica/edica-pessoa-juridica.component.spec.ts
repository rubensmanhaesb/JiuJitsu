import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EdicaPessoaJuridicaComponent } from './edica-pessoa-juridica.component';

describe('EdicaPessoaJuridicaComponent', () => {
  let component: EdicaPessoaJuridicaComponent;
  let fixture: ComponentFixture<EdicaPessoaJuridicaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [EdicaPessoaJuridicaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(EdicaPessoaJuridicaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
