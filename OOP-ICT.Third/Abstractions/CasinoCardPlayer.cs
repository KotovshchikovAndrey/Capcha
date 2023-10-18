using OOP_ICT.Models;
using OOP_ICT.Third.Exceptions;

namespace OOP_ICT.Third.Abstractions;

public abstract class CasinoCardPlayer<T>
{
    public T ModelInstance { get; }
    protected List<Card> Cards = new List<Card>();

    protected CasinoCardPlayer(T modelInstance)
    {
        ModelInstance = modelInstance ?? throw CardPlayerException.NullReference("Model instance cannot be null!");;
    }

    public IReadOnlyList<Card> GetCards() => Cards.AsReadOnly();
    public void AddCard(Card card) => Cards.Add(card);
    public abstract void SetInitialCards(List<Card> cards);
}