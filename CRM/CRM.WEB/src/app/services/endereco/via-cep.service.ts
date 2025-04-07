import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable()

export class ViaCepService {
  constructor(private http: HttpClient) {}

  getAddressByCep(cep: string) {
    return this.http.get(`https://viacep.com.br/ws/${cep}/json/`);
  }
}
