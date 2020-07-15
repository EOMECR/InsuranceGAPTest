import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HeaderComponent } from './header/header.component';
import { SearchbarComponent } from './searchbar/searchbar.component';

@NgModule({
  declarations: [
    HeaderComponent,
    SearchbarComponent
  ],
  exports:[
    HeaderComponent,
    SearchbarComponent
  ],
  imports: [
    CommonModule
  ]
})
export class ComponentsModule { }
