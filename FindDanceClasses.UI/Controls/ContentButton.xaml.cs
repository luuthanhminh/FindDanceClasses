using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace FindDanceClasses.UI.Controls
{
    public partial class ContentButton : ContentView
    {
        private bool isCommandExecuting;

        public ContentButton()
        {
            InitializeComponent();
            isCommandExecuting = false;
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create("Command", typeof(ICommand), typeof(ContentButton), default(ICommand));

        public static readonly BindableProperty IsLockingCommandProperty =
            BindableProperty.Create(nameof(IsLockingCommand), typeof(bool), typeof(ContentButton), true);

        public bool IsLockingCommand
        {
            get { return (bool)GetValue(IsLockingCommandProperty); }
            set { SetValue(IsLockingCommandProperty, value); }
        }

        public ICommand Command
        {
            get
            {
                var command = (ICommand)GetValue(CommandProperty);
                var newCommand = new Command((obj) =>
                {
                    if (IsLockingCommand && isCommandExecuting)
                    {
                        return;
                    }

                    isCommandExecuting = true;

                    AnimateView(this, command, obj);
                });

                return newCommand;
            }
            set
            {
                SetValue(CommandProperty, value);
            }
        }

        public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create("CommandParameter", typeof(object), typeof(ContentButton), default(object));

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        private void AnimateView(View view, ICommand command, object commandParameter)
        {
            var reduceOpacityAnimation = new Animation((x) =>
            {
                view.Opacity = 1 - x * .5;
            }, finished: () =>
            {
                command?.Execute(commandParameter);
            });

            var increaseOpacityAnimation = new Animation((x) =>
            {
                view.Opacity = 1 - 0.5 + x * .5;
            }, finished: async () =>
            {
                await Task.Delay(1000);
                isCommandExecuting = false;
            });

            var animation = new Animation();
            animation.Add(0, 0.5, reduceOpacityAnimation);
            animation.Add(0.5, 1, increaseOpacityAnimation);
            animation.Commit(view, "Tap");
        }
    }
}
