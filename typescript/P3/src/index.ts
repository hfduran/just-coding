import View from './view';
import Controller from './controller';
import Model from './model';

const view = new View();
const model = new Model(view);
const controller = new Controller(model);

controller.get_terminal_inputs();
