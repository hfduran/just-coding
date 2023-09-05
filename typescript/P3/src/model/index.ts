import vote_types from '../utils/vote_types';
import View from '../view';

class Storer {
  private votes_array: Map<number, number>;
  constructor() {
    this.votes_array = new Map<number, number>();
  }
  add_vote(candidate_number: number) {
    if (this.votes_array.has(candidate_number)) {
      this.votes_array.set(
        candidate_number,
        this.votes_array.get(candidate_number)! + 1
      );
    } else {
      this.votes_array.set(candidate_number, 1);
    }
  }
  get_votes() {
    return [...this.votes_array].sort((a, b) => {
      if (a[0] > b[0]) return 1;
      else if (a[0] < b[0]) return -1;
      else return 0;
    });
  }
}

export default class Model {
  private storers: Map<string, Storer>;
  private view: View;
  constructor(view: View) {
    this.view = view;
    this.storers = new Map<string, Storer>();
    vote_types.forEach(({label}) => {
      this.storers.set(label, new Storer());
    });
  }
  add_vote(candidate_type: string, candidate_number: number) {
    this.storers.get(candidate_type)!.add_vote(candidate_number);
  }
  finish_voting() {
    const votes = [...this.storers.entries()]
      .sort((a, b) => {
        if (a[0] > b[0]) return 1;
        else if (a[0] < b[0]) return -1;
        else return 0;
      })
      .map(([key, storer]) => ({
        type: key,
        votes: storer.get_votes(),
      }));
    this.view.show_votes(votes);
  }
}
