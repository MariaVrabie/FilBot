using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Luis.Models;
using System.Threading;
using Microsoft.Bot.Builder.Luis;

namespace FilBot.Dialogs
{
    [LuisModel("", "")]
    [Serializable]
    public class RootDialog : LuisDialog<object>
    {
        [LuisIntent("None")]
        public async Task None(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            // Didn't understand the LUIS request, let's try hitting the FAQ service instead
            var msg = await message;
            var qnaDialog = new FAQDialog();
            await context.Forward(qnaDialog, AfterQnA, msg, CancellationToken.None);
        }

        [LuisIntent("K2Request")]
        public async Task ProcessK2Request(IDialogContext context, IAwaitable<IMessageActivity> message, LuisResult result)
        {
            // TODO: Process the K2Request
            var msg = await message;
            await context.Forward(new K2Dialog(), this.AfterK2Request, msg, CancellationToken.None);
        }

        // Callback, after the QnAMaker Dialog returns a result.
        private async Task AfterQnA(IDialogContext context, IAwaitable<object> result)
        {
            // TODO: Do stuff after QnA has completed
            await result;
            context.Done<object>(null);
        }

        // Callback, after the K2Dialog returns a result.
        public async Task AfterK2Request(IDialogContext context, IAwaitable<object> result)
        {
            // TODO: Do stuff after K2 has completed
            await result;
            context.Done<object>(null);
        }
    }
}