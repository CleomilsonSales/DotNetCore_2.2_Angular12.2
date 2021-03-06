import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  titulo = 'Login';
  model: any = {};


  constructor(
    private authService: AuthService,
    private router: Router,
    private toastr: ToastrService
  ) { }

  ngOnInit() {
    if(localStorage.getItem('token') !== null){
      this.router.navigate(['/dasboard'])
    }
  }

  login(){
    this.authService.login(this.model)
      .subscribe(
        () =>{
          this.router.navigate(['/dasboard']);
          this.toastr.success('Login Efetuado!');
        },
        error =>{
          this.toastr.error('Falha no login');
        }
      )  
  }
}
