// endereco-form.component.ts
import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { ViaCepService } from './via-cep.service';


@Component({
  selector: 'app-endereco-form',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  providers: [ViaCepService], 
  templateUrl: './endereco-form.component.html'
})
export class EnderecoFormComponent implements OnInit {
  @Input() parentForm!: FormGroup;

  constructor(private fb: FormBuilder, private viaCep: ViaCepService) {}

  ngOnInit(): void {
    this.parentForm.addControl('cep', this.fb.control('', [Validators.required]));
    this.parentForm.addControl('logradouro', this.fb.control({ value: '', disabled: true }));
    this.parentForm.addControl('bairro', this.fb.control({ value: '', disabled: true }));
    this.parentForm.addControl('localidade', this.fb.control({ value: '', disabled: true }));
    this.parentForm.addControl('uf', this.fb.control({ value: '', disabled: true }));
    this.parentForm.addControl('numero', this.fb.control({ value: '', disabled: true }, Validators.required));
    this.parentForm.addControl('complemento', this.fb.control({ value: '', disabled: true }));
    this.parentForm.addControl('ibge', this.fb.control(''));
  }

  onCepBlur(): void {
    const cep = this.parentForm.get('cep')?.value;
    if (!cep || cep.length < 8) return;

    this.viaCep.getAddressByCep(cep).subscribe((data: any) => {
      this.parentForm.patchValue({
        logradouro: data.logradouro,
        bairro: data.bairro,
        localidade: data.localidade,
        uf: data.uf,
        ibge: data.ibge
      });
      this.parentForm.get('numero')?.enable();
      this.parentForm.get('complemento')?.enable();
    });
  }
}
