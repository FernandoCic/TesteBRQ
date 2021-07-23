import { Component, OnInit } from "@angular/core";
import { Observable } from "rxjs";
import { Usuario } from "../models/usuario";
import  {FormBuilder, Validators} from '@angular/forms' ; 
import { UsuariosService } from "../service/usuario.service";

@Component({
    selector: 'app-usuario',
    templateUrl: './usuario.component.html',
    styleUrls: ['./usuario.component.scss']
})
export class UsuarioComponent implements OnInit {
    
    displayedColumns: string[] = ['nome', 'cpf', 'email', 'cpf', 'telefone', 'sexo', 'dataNascimento', 'editar', 'detalhe', 'excluir'];
    usuarios: Usuario[];
     usuadarios: any;

    constructor(private usuariosService: UsuariosService) {}

    ngOnInit(){
        this.obterUsuarios();
    }

    obterUsuarios(){
        this.usuariosService.obterUsuarios()
            .subscribe(res => {
                this.usuarios = res;
            });
    }
}