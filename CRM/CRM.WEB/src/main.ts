import { bootstrapApplication } from '@angular/platform-browser';
import { AppComponent } from './app/app.component';
import { appConfig } from './app/app.config';
import { provideNgxMask } from 'ngx-mask';

// Combina os providers do appConfig com os do ngx-mask
bootstrapApplication(AppComponent, {
  ...appConfig,
  providers: [
    ...(appConfig.providers || []),
    provideNgxMask()
  ]
}).catch((err) => console.error(err));
