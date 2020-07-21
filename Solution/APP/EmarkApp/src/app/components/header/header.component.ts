import { Component, Input} from '@angular/core';
import { Router } from '@angular/router';
import { MenuController } from '@ionic/angular';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent {

  isOpen=true;
  constructor(public router:Router, private menu: MenuController) {  }
  @Input() usuarioNombre:string;
  @Input() iconos:string;
  @Input() fotoPerfil:string;
  ngOnInit() {}

  irPagina1() {
    this.router.navigate(['/home']);
  }

  irCarritoPagina(){
    this.router.navigate(['/carrito']);
  }

  irPedidosPagina(){
    this.router.navigate(['/pedidos']);
  }

  irPerfilPagina(){
    this.router.navigate(['/perfil']);
  }

  async abrirMenuHamburguesa(){
    var x = screen.width/2;
    document.getElementById("my-custom-menu").style.width = x+x/3+"px";
    if(this.isOpen){
      await this.menu.open("hambuerguesa");
      this.isOpen=false;
    }else if(!this.isOpen){
      await this.menu.close("hambuerguesa");
      this.isOpen=true;
    }
    
  }
}
