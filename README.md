# intercept-the-message-created-in-sendmessage-event-in-.net-maui-chat
How to intercept the message created in SendMessage event in .NET MAUI CHAT?

## Sample

```xaml  
      <sfChat:SfChat x:Name="sfChat"
                       Messages="{Binding Messages}"
                       SendMessageCommand="{Binding SendMessageCommand}"
                       CurrentUser="{Binding CurrentUser}" />

ViewModel:

    public ICommand SendMessageCommand { get; set; }

    public GettingStartedViewModel()
    {
        SendMessageCommand = new Command(ExecuteSendMessageCommand);
    }

   private void ExecuteSendMessageCommand(object obj)
   {
        // Skips adding new message in Messages collection.
        var eventArgs = obj as Syncfusion.Maui.Chat.SendMessageEventArgs;
        eventArgs!.Handled = true;

        // Retrieve message using SendMessageEventArgs.Message.
        // Now add the actual sent message into collection as required.
        var message = eventArgs.Message;
        if (message != null) { this.Messages.Add(message); }

        // You can add the special message into collection as like below.
        TextMessage textMessage = new TextMessage() { Author = this.CurrentUser };
        textMessage.Text = "Special Message";
        this.Messages.Add(textMessage);
   }

```

## Requirements to run the demo

To run the demo, refer to [System Requirements for .NET MAUI](https://help.syncfusion.com/maui/system-requirements)

## Troubleshooting:
### Path too long exception

If you are facing path too long exception when building this example project, close Visual Studio and rename the repository to short and build the project.

## License

Syncfusion® has no liability for any damage or consequence that may arise from using or viewing the samples. The samples are for demonstrative purposes. If you choose to use or access the samples, you agree to not hold Syncfusion® liable, in any form, for any damage related to use, for accessing, or viewing the samples. By accessing, viewing, or seeing the samples, you acknowledge and agree Syncfusion®'s samples will not allow you seek injunctive relief in any form for any claim related to the sample. If you do not agree to this, do not view, access, utilize, or otherwise do anything with Syncfusion®'s samples.
