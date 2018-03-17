
using Microsoft.Bot.Builder.FormFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FormularioUsuario.Formulario
{
    [Serializable]
    public class QuestionarioUsuario
    {

        [Prompt("Por favor me informe seu nome")]
        public string Nome { get; set; }
        [Prompt("Por favor me informe seu telefone")]
        public string Telefone { get; set; }
        [Prompt("Me fala seu email")]
        public string Email { get; set; }

        [Prompt("{&}{||}")]
        public QuestionarioUsuarioTipo Questionario { get; set; }
        [Prompt("{&}{||}")]
        public AvaliacaoRespostaUsuario Resposta { get; set; }
    }
    public enum QuestionarioUsuarioTipo
    {
        AtendimentoEOrientaçãoDaRecepçãoEPortaria = 1,
        LimpezaDoQuarto,
        CondiçõesGeraisDaRoupaDoLeitoEDoBanhoFornecidas,
        ConfortoDoQuarto,
        QualidadeDaRefeição,
        RespeitoAPrivacidade,
        OpiniãoDoHorárioDeVisita,
        AtendimentoDaEnfermagem,
        TempoDeAtendimentoDaEnfermagem,
        AtendimentoMédico,
        QuantidadeDeVistasMédicas,
        TransporteAtéOCentroCirúrgico,
        RecepçãoDosFuncionáriosNoCentroCirúrgico,
        AssistênciaPrestada

    }
    public enum AvaliacaoRespostaUsuario
    {

        Otimo = 1,
        Bom,
        Ruim,
        Pessimo,
        NaoSeAplica,
        NaoQueroResponder
    }

}