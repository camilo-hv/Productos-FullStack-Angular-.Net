import { Routes } from '@angular/router';
import { LandingComponent } from './landing/landing.component';
import { IndiceProductosComponent } from './indice-productos/indice-productos.component';

export const routes: Routes = [
    {path: '', component: LandingComponent},
    {path: 'productos', component: IndiceProductosComponent}
];
