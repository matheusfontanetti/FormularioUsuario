using FormularioUsuario.Formulario;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FormularioUsuario.Dialogs
{
    [Serializable]
    public class QuestionarioUsuarioDialog: IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {

            var questionarioFormDialog = FormDialog.FromForm(this.BuildQuestionarioForm, FormOptions.PromptInStart);
            context.Call(questionarioFormDialog, QuestionarioCompleto);

        }
        private IForm<QuestionarioUsuario> BuildQuestionarioForm()
        {
            var form = new FormBuilder<QuestionarioUsuario>();
            form.Configuration.DefaultPrompt.ChoiceStyle = ChoiceStyleOptions.Buttons;
            
            return form.Build();
         
        }
        async Task QuestionarioCompleto(IDialogContext context, IAwaitable<QuestionarioUsuario> result)
        {
            QuestionarioUsuario pesquisa = null;
            try
            {
                pesquisa = await result;
            }
            catch (OperationCanceledException)
            {

                await context.PostAsync("Você cancelou a pesquisa");
                return;
            }
            if (pesquisa != null)

                await context.PostAsync("Obrigado por responder o questionário!!");
            else
                await context.PostAsync("O questionário está vazio");

            context.Done<object>(null);

        }


    }
}