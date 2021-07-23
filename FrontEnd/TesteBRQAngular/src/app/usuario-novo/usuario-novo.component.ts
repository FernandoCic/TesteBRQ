import { Component, OnInit } from '@angular/core';
import { UsuariosService } from "../service/usuario.service";
import { FormBuilder, FormGroup, NgForm, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Usuario } from '../models/usuario';

@Component({
  selector: 'app-usuario-novo',
  templateUrl: './usuario-novo.component.html',
  styleUrls: ['./usuario-novo.component.css']
})
export class UsuarioNovoComponent implements OnInit {

  usuarioForm: FormGroup;
  constructor(private router: Router, private route: ActivatedRoute,
    private usuariosService: UsuariosService, private formBuilder: FormBuilder) { }

  ngOnInit(): void {
    this.usuarioForm = this.formBuilder.group({
      'usuarioId': null,
      'nome': [null, Validators.required],
      'cpf': [null, Validators.required],
      'email': [null, Validators.required],
      'telefone': [null, Validators.required],
      'sexo': [null, Validators.required],
      'dataNascimento': [null, Validators.required]
  })  
  }

  addUsuario(form: Usuario){
    this.usuariosService.adicionarUsuario(form)
    .subscribe(res => {
      const id = res['id'];
      this.router.navigate(['/usuario']);
    })
  }

}
