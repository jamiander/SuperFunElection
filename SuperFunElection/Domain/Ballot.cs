namespace SuperFunElection.Domain
{
    public class Ballot : Entity
    {
        public Ballot() { }
        public Ballot(int id, string voterName, Candidacy candidacy)
        {
            Id = id;
            Voter = voterName;
            Candidacy = candidacy;
        }

        public string Voter { get; private set; }
        
        public Candidacy Candidacy { get; private set;}
    }
}
