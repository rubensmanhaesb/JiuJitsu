import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CadastroPessoaJuridicaComponent } from "../cadastro-pessoa-juridica/cadastro-pessoa-juridica.component";
import { EdicaPessoaJuridicaComponent } from '../edica-pessoa-juridica/edica-pessoa-juridica.component';
import { UtilService } from '../../../../services/util/util.service';
import { PaginationComponent } from '../../../../services/pagination/pagination.component';



@Component({
  selector: 'app-consulta-pessoa-juridica',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    CadastroPessoaJuridicaComponent,
    EdicaPessoaJuridicaComponent,
    PaginationComponent
  ],
  templateUrl: './consulta-pessoa-juridica.component.html',
  styleUrls: ['./consulta-pessoa-juridica.component.css']
})
export class ConsultaPessoaJuridicaComponent {

  empresas: any[] = [];
  empresasPaginadas: any[] = [];
  itensPorPagina: number = 5;
  mensagem: string = '';

  constructor(private httpClient: HttpClient, private utilService: UtilService) { }

  ngOnInit(): void {
    this.getAll();
  }

  onPageChange(pagina: any[]): void {
    this.empresasPaginadas = pagina;
  }

  getAll(pagina: number = 1): void {
    console.log("buscarEmpresas foi chamado com página:", pagina);

    const endpoint = `${this.utilService.getTasksEndpoint()}pessoajuridica`;
    console.log('Endpoint:', endpoint);
    this.httpClient.get<any[]>(endpoint).subscribe({
      next: (data) => {
        console.log('Dados recebidos:', data);

        this.empresas = data;

        this.onPageChange(this.empresas.slice(0, this.itensPorPagina));

        if (this.empresas.length == 0) {
          this.mensagem = 'Nenhum registro foi encontrado para as datas selecionadas.';
        }
      },
      error: (err) => {
        console.error('Erro ao buscar empresas:', err);
        this.mensagem = 'Erro ao carregar dados.';
      }
    });
  }
}
