import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

import { IonicModule } from '@ionic/angular';

import { ProductosProvedorPageRoutingModule } from './productos-provedor-routing.module';
import { ComponentsModule } from 'src/app/components/components.module';
import { ProductosProvedorPage } from './productos-provedor.page';

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    IonicModule,
    ProductosProvedorPageRoutingModule,
    ComponentsModule
  ],
  declarations: [ProductosProvedorPage]
})
export class ProductosProvedorPageModule {}
