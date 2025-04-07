import { Component, Input } from '@angular/core';
import { FormArray, FormBuilder, Validators, ReactiveFormsModule, FormGroup } from '@angular/forms';
import {  NgFor } from '@angular/common';
import { NgxMaskDirective } from 'ngx-mask'; // se estiver usando a máscara
import { AbstractControl, ValidationErrors } from '@angular/forms';


@Component({
  selector: 'app-phone-list',
  standalone: true,
  templateUrl: './phonelist.component.html',
  imports: [
    ReactiveFormsModule,
    NgFor,
    NgxMaskDirective // remova se não estiver usando máscara
  ]
})
export class PhoneListComponent {
  @Input() phones!: FormArray;
  @Input() parentForm!: FormGroup; // <- novo

  constructor(private fb: FormBuilder) {}

  addPhone(): void {
    this.phones.push(this.fb.group({
      number: ['', Validators.required]
    }));
  }

  removePhone(index: number): void {
    this.phones.removeAt(index);
  }
}

export function peloMenosUmTelefone(control: AbstractControl): ValidationErrors | null {
  const formArray = control as FormArray;
  return formArray.length > 0 ? null : { minimoUmTelefone: true };
}
