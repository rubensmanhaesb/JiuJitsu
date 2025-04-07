import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { MenuPrincipalComponent } from './components/menu-principal/menu-principal.component';
import { ConsultaPessoaJuridicaComponent } from './components/pages/pessoa-juridica/consulta-pessoa-juridica/consulta-pessoa-juridica.component';




@Component({
  selector: 'app-root',
  imports: [
    RouterOutlet,
    MenuPrincipalComponent,
    ConsultaPessoaJuridicaComponent
  ],
  templateUrl: './app.component.html'
})
export class AppComponent {
  title = 'CRM.WEB';
}
