import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/_models/User';
import { AuthService } from 'src/app/_services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit {

  registerForm: FormGroup;
  user: User;

  constructor(
    private authService: AuthService,
    private router: Router,
    public fb: FormBuilder,
    private toastr: ToastrService) {

    }

  ngOnInit() {
    this.validation();
  }

  validation( ){
    this.registerForm = this.fb.group({
      fullName : ['', Validators.required],
      email : ['', [Validators.required, Validators.email]],
      userName : ['', Validators.required],
      passwords : this.fb.group({
        password : ['', [Validators.required, Validators.minLength(4)]],
        confirmPassword : ['', Validators.required]
      }, { validator : this.compararSenhas })
    });
  }

  compararSenhas(fb: FormGroup) {
    // aqui pego o 'confirmPassword' digitado no input do html por meio de react form
    const confirmSenhaCtrl = fb.get('confirmPassword');
    // aqui verifico se confirmPassword tem erro de validação, depois checo se existe algum mismatch
    if(confirmSenhaCtrl.errors == null || 'mismatch' in confirmSenhaCtrl.errors){
      // agora checo se o que foi digitado em password é igual ao 'confirmPassword' que tem seu valor na variável 'confirmSenhaCtrl'
      if(fb.get('password').value !== confirmSenhaCtrl.value ) {
        // aqui adiciona o mismatch em password
        fb.get('password').setErrors({ mismatch: true });
      } else {
        confirmSenhaCtrl.setErrors(null);
      }
    }
  }




  cadastrarUsuario() {
    if (this.registerForm.valid) {
      // pegando o valor de password. "passwords" é o nome do grupo que ocntem password e confirmPassword
      this.user = Object.assign(
        { password: this.registerForm.get('passwords.password').value},
        this.registerForm.value );
      this.authService.register(this.user).subscribe(
        // se sucesso
        () => {
          this.router.navigate(['/user/login']);
          this.toastr.success('Cadastro Realizado');
        },
        // se der erro  
        error => {
          const erro = error.error;
          erro.forEach(element =>{
            switch (element.code) {
              case 'DuplicaUserName':
                this.toastr.error('Cadastro Duplicado!');
                break;
              default:
                this.toastr.error(`Erro no cadastro! CODE: ${element.code}`);
                break;
            }
          });
        }
      )
    }
  }
}