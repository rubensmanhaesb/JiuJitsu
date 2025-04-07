import { Endereco } from '../services/endereco/endereco.model';

export class PessoaJuridica {
  id?: number;
  razaoSocial: string = '';
  nomeFantasia: string = '';
  cnpj: string = '';
  email: string = '';
  telefones: string[] = [];
  endereco: Endereco = new Endereco();
}
