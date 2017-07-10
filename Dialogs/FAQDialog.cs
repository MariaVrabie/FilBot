using Microsoft.Bot.Builder.Dialogs;
using QnAMakerDialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FilBot.Dialogs
{
    [Serializable]
    [QnAMakerService("", "")]
    public class FAQDialog : QnAMakerDialog<object>
    {
        public override async Task NoMatchHandler(IDialogContext context, string originalQueryText)
        {
            await context.PostAsync("[FAQDialog] - sorry I didn't find anything in the QnA for you");
            context.Done<object>(null);
        }
    }
}