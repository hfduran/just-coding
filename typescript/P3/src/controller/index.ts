/* eslint-disable no-constant-condition */
import * as readline from 'readline';
import {stdin as input, stdout as output} from 'process';
import vote_types from '../utils/vote_types';
import Model from '../model';

export default class Controller {
  model: Model;
  constructor(model: Model) {
    this.model = model;
  }

  get_terminal_inputs() {
    console.log(' ----- MAQUINA DE VOTAÇÃO VIRTUAL -----\n');
    while (true) {
      const r1 = readline.createInterface({input, output});
      console.log(' ----- Imprima seu voto ----- ');
      console.log('(use 0 para voto em branco e -1 para voto nulo)');

      vote_types.forEach(({label, value}) => {
        r1.question(`   Voto para ${label}: `, answer => {
          const vote = Number(answer);
          this.model.add_vote(value, vote);
        });
      });
      break;
    }
  }
}
