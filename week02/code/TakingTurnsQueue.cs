/// <summary>
/// This queue is circular. When people are added via AddPerson, they are added to the 
/// back of the queue (per FIFO rules). When GetNextPerson is called, the next person
/// in the queue is returned and then they are placed back into the queue. 
/// If they have finite turns, one turn is used. If they have infinite turns (turns <= 0),
/// they are always placed back in the queue without modifying their turns.
/// When a person runs out of turns (turns reaches 0), they are not added back.
/// </summary>
public class TakingTurnsQueue
{
    private readonly PersonQueue _people = new();

    public int Length => _people.Length;

    /// <summary>
    /// Add new people to the queue with a name and number of turns.
    /// </summary>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    /// <summary>
    /// Get the next person in the queue and return them. The person will re-enter the queue
    /// unless they have run out of turns. A turns value of 0 or less means infinite turns 
    /// and shall not be decremented. If the queue is empty, throw an InvalidOperationException.
    /// </summary>
    public Person GetNextPerson()
    {
        if (_people.IsEmpty())
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        var person = _people.Dequeue();

        // Infinite turns (turns <= 0)
        if (person.Turns <= 0)
        {
            _people.Enqueue(person);
            return person;
        }

        // Finite turns: use one turn
        person.Turns -= 1;

        if (person.Turns > 0)
        {
            _people.Enqueue(person);
        }

        return person;
    }

    public override string ToString()
    {
        return _people.ToString();
    }
}
