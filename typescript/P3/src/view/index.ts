export default class View {
  show_votes(
    votes: {
      type: string;
      votes: [number, number][];
    }[]
  ) {
    votes.forEach(vote => {
      console.log(`votos para ${vote.type}`);
      console.log(vote.type);
    });
  }
}
