using MessengerBack.Entities.Enums;

namespace MessengerBack.Entities;

public class UserConversation
{
    public Guid Id { get; init; }
    public ConversationRightLevel RightLevel { get; set; }
    public User User { get; init; }
    public Conversation Conversation { get; init; }
}