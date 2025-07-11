import { ApplicationConfig, provideBrowserGlobalErrorListeners, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { providePrimeNG } from 'primeng/config';
import Aura from '@primeuix/themes/aura';
import { routes } from './app.routes';
import { API_BASE_URL } from './api/api-client';
import { provideHttpClient, withInterceptors } from '@angular/common/http';
import { authInterceptor } from './api/interseptor';
import{environment} from '../environnement'

export const appConfig: ApplicationConfig = {
  providers: [
    provideBrowserGlobalErrorListeners(),
    provideZoneChangeDetection({ eventCoalescing: true }),
    provideRouter(routes),
    provideHttpClient() ,
    provideAnimationsAsync(),
        providePrimeNG({
            theme: {
                preset: Aura
            }
        }),
    { provide: API_BASE_URL, useValue: environment.apiBaseUrl },  
    provideHttpClient(
      withInterceptors([authInterceptor])
    )
  ]
};
