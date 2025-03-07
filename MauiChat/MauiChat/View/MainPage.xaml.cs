using Syncfusion.Maui.Chat;
using Syncfusion.Maui.Core.Carousel;

namespace MauiChat
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void SfChat_SendMessage(object sender, Syncfusion.Maui.Chat.SendMessageEventArgs e)
        {
            // Skips adding new message in Messages collection.
            e.Handled = true;

            // Now add the actual sent message into collection as required.
            viewModel.Messages.Add(e.Message);

            // You can add the special message into collection as like below.
            TextMessage textMessage = new TextMessage() { Author = viewModel.CurrentUser };
            textMessage.Text = "Special Message";
            viewModel.Messages.Add(textMessage);

        }
    }

}
