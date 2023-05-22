namespace MessengerBack.Entities;

public class Message
{
    public Guid Id { get; init; }
    public Conversation Conversation { get; init; }
    public User Sender { get; init; }
    public string Content { get; set; }             // TODO: can be made spatial class 
    public DateTime SendTime { get; init; }
}