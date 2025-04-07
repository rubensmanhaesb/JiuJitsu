import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, FormArray, Validators, ReactiveFormsModule } from '@angular/forms';
import { PhoneListComponent, peloMenosUmTelefone } from '../../../../services/Phone/phonelist.component';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { UtilService } from '../../../../services/util/util.service';
import { Router } from '@angular/router';
import { EnderecoFormComponent } from '../../../../services/endereco/endereco-form.component';
import { PessoaJuridica } from '../../../../models/pessoa-juridica.model';

declare var bootstrap: any;


@Component({
	selector: 'app-cadastro-pessoa-juridica',
	standalone: true,
	imports: [
		ReactiveFormsModule,
		CommonModule,
		PhoneListComponent,
		EnderecoFormComponent
	],
	templateUrl: './cadastro-pessoa-juridica.component.html'
})
export class CadastroPessoaJuridicaComponent {
	@Output() aoFechar = new EventEmitter<void>();
	form: FormGroup;
	mensagem: string = '';
	submitted: boolean = false; // ✅ Adicione isso aqui

	fechar() {
		
		(document.activeElement as HTMLElement)?.blur(); // Remove o foco de qualquer elemento focado dentro da modal
		this.form.reset();

		// Zera manualmente os telefones
		this.phones.clear();

		// Desabilita os campos de número e complemento
		this.form.get('numero')?.disable();
		this.form.get('complemento')?.disable();

		this.ativarAbaGeral();

		this.aoFechar.emit();
	}


	private ativarAbaGeral(): void {
		const triggerEl = document.querySelector('#home-tabInsert');
		if (triggerEl) {
			// Usa a API do Bootstrap para ativar a aba
			const tab = new bootstrap.Tab(triggerEl);
			tab.show();
		}
	}
	
	



	constructor(private fb: FormBuilder, private httpClient: HttpClient, private utilService: UtilService, private router: Router) {
		this.form = this.fb.group({
			razaoSocial: ['', [Validators.required, Validators.minLength(2)]],
			nomeFantasia: ['', [Validators.required, Validators.minLength(2)]],
			email: ['', [Validators.required, Validators.email]],
			cep: ['', Validators.required],
			logradouro: [''],
			bairro: [''],
			localidade: [''],
			uf: [''],
			numero: [{ value: '', disabled: true }],
			complemento: [{ value: '', disabled: true }],
			ibge: [''],
			phones: this.fb.array([], [peloMenosUmTelefone])
		});
	}
	private construirObjetoEmpresa(): PessoaJuridica {
		const formValue = this.form.getRawValue(); // inclui os campos desabilitados

		const empresa: PessoaJuridica = new PessoaJuridica();
		empresa.razaoSocial = formValue.razaoSocial;
		empresa.nomeFantasia = formValue.nomeFantasia;
		empresa.email = formValue.email;
		empresa.cnpj = ''; // Supondo que será preenchido depois

		// Telefones (transforma array de objetos em array de strings)
		empresa.telefones = formValue.phones.map((telefone: any) => telefone.number);

		// Endereço
		empresa.endereco = {
			cep: formValue.cep,
			logradouro: formValue.logradouro,
			bairro: formValue.bairro,
			localidade: formValue.localidade,
			uf: formValue.uf,
			numero: formValue.numero,
			complemento: formValue.complemento,
			ibge: formValue.ibge
		};

		return empresa;
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
		this.submitted = true;

		if (this.form.invalid) {
			return;
		}

		const empresa = this.construirObjetoEmpresa();
		console.log('Empresa preenchida:', empresa);
	}

}
