export interface RedeSocial {
  Id: number;
  Nome: string;
  URL: string;
  EventoId?: number; // o '?' após o tipo informa que o atributo pode ser nulo
  PalestranteId?: number;
}
