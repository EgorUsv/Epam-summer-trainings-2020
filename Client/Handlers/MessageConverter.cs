using Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Client.Handlers
{
    /// <summary>
    /// Handles receiving messages from clients.
    /// </summary>
    public static class MessageConverter
    {
        /// <summary>
        /// Contains a list of all processed messages.
        /// </summary>
        public static List<string> ConvertedMessages = new List<string>();
        /// <summary>
        /// Message handler.
        /// </summary>
        public static MessageTranslator StringConveter = delegate (string message)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < message.Length; i++)
            {
                if (LatinToRus.ContainsKey(message[i]))
                    result.Append(LatinToRus[message[i]]);
                else
                if (RusToLatin.ContainsKey(message[i]))
                    result.Append(RusToLatin[message[i]]);
                else
                    result.Append(message[i]);
            }
            ConvertedMessages.Add(result.ToString());
        };
        /// <summary>
        /// Dictionary for translation from Latin into Russian.
        /// </summary>
        static Dictionary<char, string> LatinToRus = new Dictionary<char, string>()
        {
            {'A',"А"},  {'a', "а" },
            {'B',"Б" }, {'b', "б" },
            {'C',"Ц" }, {'c', "ц" },
            {'D', "Д"}, {'d', "д" },
            {'E', "Е"}, {'e', "е" },
            {'F', "Ф"}, {'f', "ф" },
            {'G', "Г"}, {'g', "г" },
            {'H', "Х"}, {'h', "х" },
            {'I', "И"}, {'i', "и" },
            {'J', "Ж"}, {'j', "ж" },
            {'K', "К"}, {'k', "к" },
            {'L', "Л"}, {'l', "л" },
            {'M', "М"}, {'m', "м" },
            {'N', "Н"}, {'n', "н" },
            {'O', "О"}, {'o', "о" },
            {'P', "П"}, {'p', "п" },
            {'Q', "КУ"},{'q', "ку"},
            {'R', "Р"}, {'r', "р" },
            {'S', "С"}, {'s', "с" },
            {'T', "Т"}, {'t', "т" },
            {'U', "У"}, {'u', "у" },
            {'V', "В"}, {'v', "в" },
            {'W', "В"}, {'w', "в" },
            {'X', "Х"}, {'x', "х" },
            {'Y', "У"}, {'y', "у" },
            {'Z', "З"}, {'z', "з" }
        };
        /// <summary>
        /// Dictionary for translation from Russian into Latin.
        /// </summary>
        static Dictionary<char, string> RusToLatin = new Dictionary<char, string>()
        {
            {'А',"A"},  {'а',"a"},
            {'Б',"B"},  {'б',"b"},
            {'В',"V"},  {'в',"v"},
            {'Г',"G"},  {'г',"g"},
            {'Д',"D"},  {'д',"d"},
            {'Е',"E"},  {'е',"e"},
            {'Ё',"YO"}, {'ё',"yo"},
            {'Ж',"ZH"}, {'ж',"zh"},
            {'З',"Z"},  {'з',"z"},
            {'И',"I"},  {'и',"i"},
            {'Й',"J"},  {'й',"j"},
            {'К',"K"},  {'к',"k"},
            {'Л',"L"},  {'л',"l"},
            {'М',"M"},  {'м',"m"},
            {'Н',"N"},  {'н',"n"},
            {'О',"O"},  {'о',"o"},
            {'П',"P"},  {'п',"p"},
            {'Р',"R"},  {'р',"r"},
            {'С',"S"},  {'с',"s"},
            {'Т',"T"},  {'т',"t"},
            {'У',"U"},  {'у',"u"},
            {'Ф',"F"},  {'ф',"f"},
            {'Х',"H"},  {'х',"h"},
            {'Ц',"C"},  {'ц',"c"},
            {'Ч',"CH"}, {'ч',"ch"},
            {'Ш',"SH"}, {'ш',"sh"},
            {'Щ',"SHH"},{'щ',"shh"},
            {'Ъ',"\'"}, {'ъ',"\'"},
            {'Ы',"Y"},  {'ы',"y"},
            {'Ь',""},   {'ь',""},
            {'Э',"E"},  {'э',"e"},
            {'Ю',"YU"}, {'ю',"yu"},
            {'Я',"YA"}, {'я',"ya"},
        };
    }
}
