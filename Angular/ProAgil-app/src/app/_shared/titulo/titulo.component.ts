import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.css']
})
export class TituloComponent implements OnInit {
  // @Input é como o props do Vue.js ele pega o valor que eu definir na tag e insere na variável titulo 
  @Input() titulo: string;
  constructor() { }

  ngOnInit() {
  }

  
}
