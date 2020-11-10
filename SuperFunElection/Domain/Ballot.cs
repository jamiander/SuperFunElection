namespace SuperFunElection.Domain
{
    public class Ballot : Entity
    {

        public Ballot() { }
        public Ballot(PersonName voterName, Candidacy candidacy) : this(0, voterName, candidacy)
        {
        }
        public Ballot(int id, PersonName voterName, Candidacy candidacy)
        {
            Id = id;
            Voter = voterName;
            Candidacy = candidacy;
        }

        public PersonName Voter { get; private set; }
        
        public Candidacy Candidacy { get; private set;}
    }
}
