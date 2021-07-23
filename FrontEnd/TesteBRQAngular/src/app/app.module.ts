import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { UsuarioComponent } from './usuario/usuario.component';
import { HttpClientModule } from '@angular/common/http';
import  {FormsModule, ReactiveFormsModule} from '@angular/forms' ;  
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatRadioModule} from '@angular/material/radio'; 
import { MatButtonModule} from '@angular/material/button'; 
import { MatDatepickerModule} from '@angular/material/datepicker'; 
import { MatNativeDateModule} from '@angular/material/core'; 
import { MatIconModule} from '@angular/material/icon'; 
import { MatCardModule} from '@angular/material/card'; 
import { MatSidenavModule} from '@angular/material/sidenav'; 
import { MatFormFieldModule} from '@angular/material/form-field'; 
import { MatInputModule} from '@angular/material/input'; 
import { MatTooltipModule} from '@angular/material/tooltip'; 
import { MatToolbarModule} from '@angular/material/toolbar'; 
import { MatMenuModule} from '@angular/material/menu'; 
import { UsuariosService } from './service/usuario.service';
import { UsuarioDetalheComponent } from './usuario-detalhe/usuario-detalhe.component';
import { UsuarioNovoComponent } from './usuario-novo/usuario-novo.component';
import { UsuarioEditarComponent } from './usuario-editar/usuario-editar.component';
import { MenuComponent } from './menu/menu.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatListModule } from '@angular/material/list';
import { RouterModule } from '@angular/router';
import { MatTableModule } from '@angular/material/table';
import { UsuarioExcluirComponent } from './usuario-excluir/usuario-excluir.component'

@NgModule({
  declarations: [
    AppComponent,
    UsuarioComponent,
    UsuarioDetalheComponent,
    UsuarioNovoComponent,
    UsuarioEditarComponent,
    MenuComponent,
    UsuarioExcluirComponent
  ],
  imports: [
    BrowserModule,
    FormsModule, 
    ReactiveFormsModule,  
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatButtonModule,  
    MatMenuModule,  
    MatDatepickerModule,  
    MatNativeDateModule,  
    MatIconModule,  
    MatRadioModule,  
    MatCardModule,  
    MatSidenavModule,  
    MatFormFieldModule,  
    MatInputModule,  
    MatTooltipModule,  
    MatToolbarModule,  
    AppRoutingModule, LayoutModule, MatListModule  ,
    RouterModule,
    MatTableModule
  ],
  providers: [HttpClientModule, UsuariosService, MatDatepickerModule],
  bootstrap: [AppComponent]
})
export class AppModule { }
