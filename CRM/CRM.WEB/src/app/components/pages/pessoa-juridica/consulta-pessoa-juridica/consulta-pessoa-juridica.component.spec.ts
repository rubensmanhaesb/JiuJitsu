import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultaPessoaJuridicaComponent } from './consulta-pessoa-juridica.component';

describe('CconsultaPessoaJuridicaComponent', () => {
  let component: ConsultaPessoaJuridicaComponent;
  let fixture: ComponentFixture<ConsultaPessoaJuridicaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ConsultaPessoaJuridicaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ConsultaPessoaJuridicaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
