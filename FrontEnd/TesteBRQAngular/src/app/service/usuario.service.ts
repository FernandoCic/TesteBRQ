import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { HttpParams, HttpClient } from '@angular/common/http';
import { Usuario } from "../models/usuario";


@Injectable({
    providedIn: 'root'
})
export class UsuariosService {

    private url = "https:localhost:44339/api/usuarios/"
    constructor(private http: HttpClient) { }

    obterUsuarios(): Observable<Usuario[]>  {
        return this.http.get<Usuario[]>(this.url);
    }

    obterUsuarioId(id: number){
        return this.http.get<Usuario>(this.url + id.toString());
    }

    adicionarUsuario(usuario: Usuario ){
        return this.http.post<Usuario>(this.url, usuario);
    }

    atualizarUsuario(id: number, usuario: Usuario){
        usuario.id = id;
        return this.http.put<Usuario>(this.url + id, usuario);
    }

    excluirUsuario(id: number) {
        return this.http.delete<Usuario>(this.url + id.toString());
    }
}