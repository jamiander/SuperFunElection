using System.Collections.Generic;

namespace SuperFunElection
{
    public class Election
    {

        public Election()
        { }
        public Election(int id, string date, List<Candidate> candidates, List<Ballot> ballots)
        {
            Id = id;
            Date = date;
            Candidates = candidates;
            Ballots = ballots;
        }

        public int Id { get; set; }
        public string Date { get; set; }
        public List<Candidate> Candidates { get; set; }
        public List<Ballot> Ballots { get; set; }

        private List<Election> _items = new List<Election>();
        public IReadOnlyList<Election> Items { get { return _items.AsReadOnly(); } }

        public void CreateNewElection(int Id, string Date, List<Candidate> Candidates, List<Ballot> Ballots)
        {
            var newElection = new Election(Id, Date, Candidates, Ballots);
            _items.Add(newElection);
        }

    }
}
