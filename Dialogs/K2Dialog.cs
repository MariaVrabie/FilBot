using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FilBot.Dialogs
{
    public class K2Dialog: IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            await context.PostAsync($"[K2Dialog] I am the K2Dialog.");
            context.Wait(this.MessageReceivedAsync);
        }

        private async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> result)
        {
            var activity = await result as IMessageActivity;
            if (activity.Type == ActivityTypes.Message)
            {
                int length = (activity.Text ?? string.Empty).Length;
                await context.PostAsync($"[K2Dialog] You sent {activity.Text} which was {length} characters");
            }
            context.Wait(MessageReceivedAsync);
        }
    }
}