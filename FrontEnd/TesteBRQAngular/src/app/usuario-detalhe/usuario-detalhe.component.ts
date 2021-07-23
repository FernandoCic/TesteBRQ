import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from '../models/usuario';
import { UsuariosService } from "../service/usuario.service";

@Component({
  selector: 'app-usuario-detalhe',
  templateUrl: './usuario-detalhe.component.html',
  styleUrls: ['./usuario-detalhe.component.css']
})
export class UsuarioDetalheComponent implements OnInit {

  alterarRegistro: boolean;
  usuarioId: number;
  usuarioForm: FormGroup;
  nome: String = '';
  cpf: String = '';
  email: String = '';
  telefone: String = '';
  sexo: String = '';
  dataNascimento: String = '';

  constructor(private router: Router, private route: ActivatedRoute,
    private usuariosService: UsuariosService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.obterUsuarioPorId(this.route.snapshot.params['id']);
    this.usuarioForm = this.formBuilder.group({
      'usuarioId': null,
      'nome': [null,  Validators.required],
      'cpf': [null, Validators.required],
      'email': [null, Validators.required],
      'telefone': [null, Validators.required],
      'sexo': [null, Validators.required],
      'dataNascimento': [null, Validators.required]
    }) 
  }

  obterUsuarioPorId(id: number){
    this.usuariosService.obterUsuarioId(id)
      .subscribe(data => {
        this.usuarioId = data.id;
        this.usuarioForm.setValue({
          usuarioId: data.id,
          nome: data.nome,
          cpf: data.cpf,
          email: data.email,
          telefone: data.telefone,
          sexo: data.sexo,
          dataNascimento: data.dataNascimento,
        })
      } )
}

}
