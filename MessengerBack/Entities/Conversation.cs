using MessengerBack.Entities.Enums;

namespace MessengerBack.Entities;

public class Conversation
{
    public Guid Id { get; init; }
    public string Title { get; set; }
    public bool IsOneToOne { get; set; }
}