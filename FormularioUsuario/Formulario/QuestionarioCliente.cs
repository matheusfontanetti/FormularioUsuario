
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormularioUsuario.Formulario
{
    [Serializable]
    public class QuestionarioCliente
    {
        [Prompt("Por favor me informe seu nome")]
        public string Nome { get; set; }
        [Prompt("Por favor me informe seu telefone")]
        public string Telefone { get; set; }
        [Prompt("Por favor me informe seu email")]
        public string Email { get; set; }
        [Prompt("{&}{||}")]
        public TipoQuestionarioCliente questionario { get; set; }
        [Prompt("{&}{||}")]
        public AvaliacaoResposta avaliacao { get; set; }
 
        }
        

    }
    public enum TipoQuestionarioCliente
    {
        AtendimentoTelefônico = 1,
        AtendimentoDaRecepção,
        TempoDeEsperaPeloAtendimentoMédico,
        AtendimentoMédico,
        OrientaçõesFornecidasPeloMédico,
        AtendimentoDaEnfermagem,
        OrientaçõesFornecidasPelaEnfermagem,
        LimpezaDoSetor,
        AtendimentoDeOutrosProfissionais
    }

    public enum AvaliacaoResposta
    {
      
        Otimo = 1,
        Bom,
        Ruim,
        Pessimo,
        NaoSeAplica,
        NaoQueroResponder
    }

