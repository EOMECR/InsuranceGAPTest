import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ProductosProvedorPage } from './productos-provedor.page';

const routes: Routes = [
  {
    path: '',
    component: ProductosProvedorPage
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class ProductosProvedorPageRoutingModule {}
