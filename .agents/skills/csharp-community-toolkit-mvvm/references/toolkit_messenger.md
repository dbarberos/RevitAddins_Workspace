# Messenger (Pub/Sub) with MVVM Toolkit

The Messenger allows completely decoupled communication between objects (e.g., ViewModel A sending a message to ViewModel B without referencing it).

## 1. Defining a Message
Messages are strongly-typed records or classes. Use `ValueChangedMessage<T>` for simple data passing.

```csharp
// Custom message
public record UserLoggedInMessage(string Username);

// Built-in simple message
using CommunityToolkit.Mvvm.Messaging.Messages;
public class ThemeChangedMessage : ValueChangedMessage<string>
{
    public ThemeChangedMessage(string theme) : base(theme) { }
}
```

## 2. Sending a Message
Use the static `WeakReferenceMessenger.Default` to send a message globally.

```csharp
[RelayCommand]
private void Login()
{
    // Broadcast the message
    WeakReferenceMessenger.Default.Send(new UserLoggedInMessage("AdminUser"));
}
```

## 3. Receiving a Message
To listen for messages, a ViewModel should:
1. Inherit from `ObservableRecipient` (instead of `ObservableObject`).
2. Implement `IRecipient<TMessage>`.
3. Set `IsActive = true` to register the recipient automatically.

```csharp
public partial class HeaderViewModel : ObservableRecipient, IRecipient<UserLoggedInMessage>
{
    [ObservableProperty]
    private string _welcomeText = "Not logged in";

    public HeaderViewModel()
    {
        // Activates the messenger registration
        IsActive = true;
    }

    // Required by IRecipient<T>
    public void Receive(UserLoggedInMessage message)
    {
        WelcomeText = $"Welcome, {message.Username}!";
    }
}
```

## 4. Request Messages (Two-way communication)
A ViewModel can request data from another unknown ViewModel.

```csharp
// 1. Define Request
public class CurrentUserRequestMessage : RequestMessage<string> { }

// 2. Sender requests data
string currentUser = WeakReferenceMessenger.Default.Send<CurrentUserRequestMessage>();

// 3. Receiver replies
public class AuthViewModel : ObservableRecipient, IRecipient<CurrentUserRequestMessage>
{
    public void Receive(CurrentUserRequestMessage message)
    {
        message.Reply("AdminUser"); // Responds to the sender
    }
}
```
