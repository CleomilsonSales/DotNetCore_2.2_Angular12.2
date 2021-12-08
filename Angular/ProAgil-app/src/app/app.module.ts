// Módulos
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TooltipModule, BsDropdownModule, ModalModule, BsDatepickerModule } from 'ngx-bootstrap';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { ToastrModule } from 'ngx-toastr';

// serviços 
import { EventoService } from './_services/evento.service';

// Componentes
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { EventosComponent } from './eventos/eventos.component';
import { PalestrantesComponent } from './palestrantes/palestrantes.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { ContatosComponent } from './contatos/contatos.component';
import { TituloComponent } from './_shared/titulo/titulo.component';

// Pipes
import { DateFormatPipePipe } from './_helps/DateFormatPipe.pipe';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';



@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      EventosComponent,
      PalestrantesComponent,
      DashboardComponent,
      ContatosComponent,
      TituloComponent,
      UserComponent,
      LoginComponent,
      RegistrationComponent,
      DateFormatPipePipe

   ],
   imports: [
    BrowserModule,
    /* npm install ngx-bootstrap --save para instalar o ngx */ 
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    TooltipModule.forRoot(),
    ModalModule.forRoot(),
    BrowserAnimationsModule,
    ToastrModule.forRoot({
       timeOut: 3000,
       preventDuplicates: true,
       progressBar: true
    }),
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule
 ],
 providers: [
    EventoService
 ],
 bootstrap: [
    AppComponent
 ]
})
export class AppModule { }

