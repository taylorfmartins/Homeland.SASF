using System.Collections.Generic;
using System.Linq;

namespace Homeland.SASF.Model
{
    public static class TipoNotificacaoExtensions
    {
        private static Dictionary<string, TipoNotificacao> mapa =
            new Dictionary<string, TipoNotificacao>
            {
                { "WhatsApp", TipoNotificacao.WhatsApp },
                { "Email", TipoNotificacao.Email },
                { "Telegram", TipoNotificacao.Telegram }
            };

        public static string ParaString(this TipoNotificacao tipo)
        {
            return mapa.First(s => s.Value == tipo).Key;
        }

        public static TipoNotificacao ParaTipo(this string texto)
        {
            return mapa.First(t => t.Key == texto).Value;
        }
    }

    public enum TipoNotificacao
    {
        WhatsApp,
        Email,
        Telegram
    }
}
