import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsuarioComponent } from './usuario/usuario.component';
import { UsuarioDetalheComponent } from './usuario-detalhe/usuario-detalhe.component';
import { UsuarioNovoComponent } from './usuario-novo/usuario-novo.component';
import { UsuarioEditarComponent } from './usuario-editar/usuario-editar.component';
import { UsuarioExcluirComponent } from './usuario-excluir/usuario-excluir.component';


const routes: Routes = [
  {
    path: 'usuario',
    component: UsuarioComponent,
    data: { title: 'Lista de usuarios' }
  },
  {
    path: 'usuario-detalhe/:id',
    component: UsuarioDetalheComponent,
    data: { title: 'Detalhe do usuario' }
  },
  {
    path: 'usuario-novo',
    component: UsuarioNovoComponent,
    data: { title: 'Adicionar usuario' }
  },
  {
    path: 'usuario-editar/:id',
    component: UsuarioEditarComponent,
    data: { title: 'Editar o usuario' }
  },
  {
    path: 'usuario-excluir/:id',
    component: UsuarioExcluirComponent,
    data: { title: 'Excluir o usuario' }
  },
  { path: '',
    redirectTo: '/usuario',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
