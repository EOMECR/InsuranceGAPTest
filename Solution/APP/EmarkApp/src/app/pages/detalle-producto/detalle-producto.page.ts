import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detalle-producto',
  templateUrl: './detalle-producto.page.html',
  styleUrls: ['./detalle-producto.page.scss'],
})
export class DetalleProductoPage implements OnInit {
  products: Array<{id: number, idSubcategoria: number, nombre: string, precio: string, valoracion: number, url: string }>
  producto: object;
  constructor(private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
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
    ];
    this.producto={};
    this.obtenerProducto();
  }

  obtenerProducto(){
    var productoId ="";
    this.route.queryParams.subscribe(params=>{
      if(params && params.productId)
        productoId = JSON.parse(params.productId);
    });
    var pro: object=[];
    for(var a=0; a<this.products.length;a++){
      if(this.products[a].id.toString() == productoId){
      var imagenes: Array<any>= [this.products[a].url, "https://hardzone.es/app/uploads-hardzone.es/2018/04/grafeno-edit.jpg",
        "https://est.zetaestaticos.com/cordoba/img/noticias/1/272/1272977_1.jpg"];
      this.producto ={id: productoId, nombre: this.products[a].nombre, precio: this.products[a].precio, imagenes};
      return;
      }
    }

  }

}
