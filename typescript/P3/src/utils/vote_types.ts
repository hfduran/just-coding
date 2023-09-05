type VoteTypesDTO = {
  label: string;
  value: string;
};

const vote_types: VoteTypesDTO[] = [
  {label: 'Presidente', value: 'president'},
  {label: 'Senador', value: 'senator'},
  {label: 'Deputado Federal', value: 'federal_deputy'},
  {label: 'Deputado Estadual', value: 'stadual_deputy'},
];

export default vote_types;
