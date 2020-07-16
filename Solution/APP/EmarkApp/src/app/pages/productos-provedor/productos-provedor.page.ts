import { Component, OnInit, ViewChild } from '@angular/core';
import { MenuController, IonInfiniteScroll } from '@ionic/angular';
import { Router } from '@angular/router';

@Component({
  selector: 'app-productos-provedor',
  templateUrl: './productos-provedor.page.html',
  styleUrls: ['./productos-provedor.page.scss'],
})
export class ProductosProvedorPage implements OnInit {
  @ViewChild(IonInfiniteScroll) infiniteScroll: IonInfiniteScroll;
  direccion ="San Ramón, Río Claro"; 
  products: Array<{id: number, idSubcategoria: number, nombre: string, precio: string, valoracion: number, url: string }>
  categorias: Array<{id: number, nombre: string}>;
  subcategorias: Array<{id: number, idCategoria: number, nombre: string}>;
  isClose = false;
  constructor(private menu: MenuController) {

    this.categorias=[
      {id: 1, nombre: "Materiales"},
      {id: 2, nombre: "Herramientas"}
    ];
    this.subcategorias=[
      {id: 1, idCategoria: 2, nombre: "Martillo"},
      {id: 2, idCategoria: 2, nombre: "Taladro"},
      {id: 3, idCategoria: 2, nombre: "Guantes"},
      {id: 4, idCategoria: 2, nombre: "Lentes"}
    ];
    this.products =[
      {id: 1, idSubcategoria: 1, nombre: "Martillo Stanley", precio: "5.000", valoracion: 2.5,
        url: "https://images-na.ssl-images-amazon.com/images/I/51lCdZLsF0L._AC_SX522_.jpg"},
      {id: 2, idSubcategoria: 1, nombre: "Martillo Bellota", precio: "7.000", valoracion: 4,
        url: "https://images-na.ssl-images-amazon.com/images/I/518jV7lwU1L._AC_SL1181_.jpg"},
      {id: 3, idSubcategoria: 2, nombre: "Taladros Black+Decker", precio: "20.000", valoracion: 4,
        url: "https://i.ebayimg.com/thumbs/images/g/d6gAAOSwilJbVGp2/s-l225.jpg"},
      {id: 4, idSubcategoria: 2, nombre: "Taladros Bosch", precio: "16.000", valoracion: 4.5,
        url: "https://images-na.ssl-images-amazon.com/images/I/61qUWQfW49L._AC_SY355_.jpg"},
      {id: 5, idSubcategoria: 3, nombre: "Guante MaxiCut", precio: "2.000", valoracion: 1,
        url: "https://dhb3yazwboecu.cloudfront.net/832/large/safetop/G151KF.jpg"},
      {id: 6, idSubcategoria: 3, nombre: "Guante DEX FIT", precio: "2.500", valoracion: 3.5,
        url: "https://m.media-amazon.com/images/I/71Om4255jeL._AC_UL320_.jpg"}
    ]

    
   }

  ngOnInit() {
  }
  async abrirMenuCategorias(){
    alert("entra");
    if(!this.isClose){
      await this.menu.open("menu_categorias");
      this.isClose =false;
    }else{
      await this.menu.close("menu_categorias");
      this.isClose =true;
    }
    
  }

  valoracion(cantidadStrellas){
    var stars: Array<{icon: string}> = [];
    var mediaEstrella = false;
    for(var a=0 ; a<5; a++){
      if(a<cantidadStrellas){
        let obj= {icon: "star"}
        stars.push(obj);
      }else if(cantidadStrellas % 2 !=0 && mediaEstrella==false){
        let obj= {icon: "star-half-outline"}
        stars.push(obj);
        mediaEstrella=true;
      }else{
        let obj= {icon: "star-outline"}
        stars.push(obj);
      }
    }
    return stars;
  }

  loadData(event){
    console.log("Cargando");
    setTimeout(()=>{
      
      var array:Array<{id: number, idSubcategoria: number, nombre: string, precio: string, valoracion: number, url: string }>=[];
      array =[
        {id: 7, idSubcategoria: 4, nombre: "3M™ Lentes de Seguridad 11796 Virtua CCS Claro", precio: "6.500", valoracion: 4.5,
          url: "https://multimedia.3m.com/mws/media/609531P/3mtm-virtuatm-sport-ccs-11796-11797.jpg"},
        {id: 8, idSubcategoria: 4, nombre: "3M® Virtua™ Lente de Seguridad Sellado", precio: "4.500", valoracion: 3,
          url: "https://multimedia.3m.com/mws/media/609531P/3mtm-virtuatm-sport-ccs-11796-11797.jpg"},
        {id: 9, idSubcategoria: 2, nombre: "Taladros Black+Decker", precio: "10.000", valoracion: 2.5,
          url: "https://m.media-amazon.com/images/I/71HGrIzxkQL._AC_SS350_.jpg"},
        {id: 10, idSubcategoria: 1, nombre: "Garra martillo con la manija de fibra de vidrio ", precio: "11.000", valoracion: 5,
          url: "https://sc01.alicdn.com/kf/Ha63883b10a704720b4a83b2ec021ec6dT.jpg"}
        ];
      for(var i=0; i<array.length; i++){
          var obj = array[i];
          this.products.push(obj);
        }
        if(this.products.length >9){
          event.target.disabled = true;
          this.infiniteScroll.disabled=true;
          return;
        }
    
    }, 1000);
  }
}
