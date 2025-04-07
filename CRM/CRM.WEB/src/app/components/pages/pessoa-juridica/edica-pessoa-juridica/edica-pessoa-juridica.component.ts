import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators, ReactiveFormsModule } from '@angular/forms';
import { PhoneListComponent } from '../../../../services/Phone/phonelist.component';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { UtilService } from '../../../../services/util/util.service';
import { Router } from '@angular/router';


@Component({
	selector: 'app-edica-pessoa-juridica',
	standalone: true,
	imports: [
		ReactiveFormsModule,
		CommonModule,
		PhoneListComponent
	],
	templateUrl: './edica-pessoa-juridica.component.html',
})
export class EdicaPessoaJuridicaComponent {
	@Output() aoFechar = new EventEmitter<void>();

	fechar() {
		this.aoFechar.emit();
	}
	form: FormGroup;

	mensagem: string = '';

	constructor(private fb: FormBuilder, private httpClient: HttpClient, private utilService: UtilService, private router: Router) {
		this.form = this.fb.group({
			razaoSocial: ['', [Validators.required, Validators.minLength(2)]],
			nomeFantasia: ['', [Validators.required, Validators.minLength(2)]],
			email: ['', [Validators.required, Validators.email]],
			phones: this.fb.array([this.createPhone()])
		});
	}

	get f() {
		return this.form.controls;
	}

	get phones(): FormArray {
		return this.form.get('phones') as FormArray;
	}

	createPhone(): FormGroup {
		return this.fb.group({
			number: ['', Validators.required]
		});
	}

	salvar(): void {
		console.log(this.form.value);
	}
}
