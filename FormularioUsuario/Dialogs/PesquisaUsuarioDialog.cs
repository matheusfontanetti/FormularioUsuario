using FormularioUsuario.Formulario;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.FormFlow;
using Microsoft.Bot.Builder.Luis;
using Microsoft.Bot.Builder.Luis.Models;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace FormularioUsuario.Dialogs
{
    [Serializable]
    [LuisModel("d3a4492e-2efb-4539-8b35-69842d169aa9", "84b5886e7ecc4b079532fa88a470cee4")]

    public class PesquisaUsuarioDialog : LuisDialog<Pesquisa>
    {





        [LuisIntent("None")]
        public async Task None(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Não entendi o que você falou");

        }

        [LuisIntent("Saudar")]
        public async Task Saudar(IDialogContext context, LuisResult result)
        {

            await context.PostAsync("Olá, tudo bem? Eu sou Matheus!!");

        }

        [LuisIntent("Sobre")]
        public async Task Sobre(IDialogContext context, LuisResult result)
        {
            await context.PostAsync("Eu realizo pesquisas de satisfação!!");
        }



        [LuisIntent("responder-questionario")]
        public async Task ResponderQuestionario(IDialogContext context, LuisResult result)
        {
            var opcaoquestionario = result.Entities.Select(a => a.Entity).FirstOrDefault();



            switch (opcaoquestionario)
            {
                case "cliente":
                 
                    context.Call(new QuestionarioClienteDialog(), ResumeAfterOptionDialog);
                 
                    break;
                case "usuario":

                   context.Call(new QuestionarioUsuarioDialog(), ResumeAfterOptionDialog);
                    break;

                default:
                  await context.PostAsync("Informe o tipo do questionário");
                    break;

            }

        

        }

        private async Task ResumeAfterOptionDialog(IDialogContext context, IAwaitable<object> result)
        {
            try
            {
                var message = await result;
            }
            catch (Exception ex)
            {
                await context.PostAsync($"Failed with message: {ex.Message}");
            }
            finally
            {
                context.Wait(this.MessageReceived);
            }
        }

    }
}