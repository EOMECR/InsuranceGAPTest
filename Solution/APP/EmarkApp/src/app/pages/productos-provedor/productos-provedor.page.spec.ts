import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { ProductosProvedorPage } from './productos-provedor.page';

describe('ProductosProvedorPage', () => {
  let component: ProductosProvedorPage;
  let fixture: ComponentFixture<ProductosProvedorPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductosProvedorPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(ProductosProvedorPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
