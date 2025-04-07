import { Routes } from '@angular/router';
import { ConsultaPessoaJuridicaComponent } from './components/pages/pessoa-juridica/consulta-pessoa-juridica/consulta-pessoa-juridica.component';


export const routes: Routes = [
    {
        path: "crm/empresas/consulta",
        component: ConsultaPessoaJuridicaComponent
    }    
];
