//menu-principal.component.ts
import { Component, AfterViewInit } from '@angular/core';
import { CommonModule } from '@angular/common';

declare var bootstrap: any;

@Component({
  selector: 'app-menu-principal',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './menu-principal.component.html',
  styleUrls: ['./menu-principal.component.css']
})
export class MenuPrincipalComponent implements AfterViewInit {
  ngAfterViewInit(): void {
    setTimeout(() => {
      const dropdownTriggerEl = document.getElementById('crmDropdownMenu');
      console.log('Dropdown trigger encontrado:', dropdownTriggerEl);
      if (dropdownTriggerEl) {
        new bootstrap.Dropdown(dropdownTriggerEl);
      }
    });
    document.getElementById('crmDropdownMenu')?.click();

  }
  
  
}
