import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  constructor(
    private authService: AuthService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
  }

  loggedIn() {
    // direciono para a função loggedIn criado '/_services/auth.service' porque lá ele já realiza a verificação de login  
    return this.authService.loggedIn();
  }

  entrar() {
    this.router.navigate(['/user/login']);
  }

  logout() {
    // aqui removo o token armazenado no local storange
    localStorage.removeItem('token');
    this.toastr.show('Log out efetuado!');
    this.router.navigate(['/user/login']);
  }

}