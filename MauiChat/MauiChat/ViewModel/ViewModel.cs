﻿using Syncfusion.Maui.Chat;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MauiChat
{
    public class GettingStartedViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Collection of messages in a conversation.
        /// </summary>
        private ObservableCollection<object> messages;

        /// <summary>
        /// Current user of chat.
        /// </summary>
        private Author currentUser;

        public ICommand SendMessageCommand { get; set; }

        public GettingStartedViewModel()
        {
            this.messages = new ObservableCollection<object>();
            this.currentUser = new Author() { Name = "Nancy" };
            this.GenerateMessages();
            SendMessageCommand = new Command(ExecuteSendMessageCommand);
        }

        /// <summary>
        /// Gets or sets the collection of messages of a conversation.
        /// </summary>
        public ObservableCollection<object> Messages
        {
            get
            {
                return this.messages;
            }

            set
            {
                this.messages = value;
            }
        }

        /// <summary>
        /// Gets or sets the current user of the message.
        /// </summary>
        public Author CurrentUser
        {
            get
            {
                return this.currentUser;
            }
            set
            {
                this.currentUser = value;
                RaisePropertyChanged("CurrentUser");
            }
        }

        /// <summary>
        /// Property changed handler.
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Occurs when property is changed.
        /// </summary>
        /// <param name="propName">changed property name</param>
        public void RaisePropertyChanged(string propName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }

        private void GenerateMessages()
        {
            this.messages.Add(new TextMessage()
            {
                Author = currentUser,
                Text = "Hi guys, good morning! I'm very delighted to share with you the news that our team is going to launch a new mobile application.",
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Andrea", Avatar = "Andrea.png" },
                Text = "Oh! That's great.",
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Harrison", Avatar = "Harrison.png" },
                Text = "That is good news.",
            });

            this.messages.Add(new TextMessage()
            {
                Author = new Author() { Name = "Margaret", Avatar = "Margaret.png" },
                Text = "Are we going to develop the app natively or hybrid?",
            });

            this.messages.Add(new TextMessage()
            {
                Author = currentUser,
                Text = "We should develop this app in .NET MAUI, since it provides native experience and performance.\",",
            });
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

    }
}
