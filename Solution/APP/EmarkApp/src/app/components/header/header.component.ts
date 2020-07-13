import { Component, Input} from '@angular/core';
import { Router } from '@angular/router';
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.scss'],
})
export class HeaderComponent {


  constructor(public router:Router) { }
  @Input() titulo:string;
  @Input() iconos:string;
  ngOnInit() {}

  irPagina1() {
    this.router.navigate(['/home']);
  }
}
