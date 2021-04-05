using System;
using System.Collections.Generic;
using System.Text;

namespace VotebanBot
{
    public static class BotConfig
    {
        public static string botToken { get; set; } = "1735511247:AAFC17DRg7TFdtEktcSmyHcHC9CgQlE2c8k";
        public static Dictionary<string, int> users { get; set; } = new Dictionary<string, int>()
        {
            {"Корш Саша Саня Александр @566826274 (Корш) Alex Kite", 566826274},
            {"Никита @cloudedbe @mogafk Некит", 63070657},
            {"Ваня Иван @Haharin", 112571278},
            {"Юля Юлия Полш Yul Polsh @yul_polsh", 176088764},
            {"Дима Диван Диман Дмитрий looser pacific @icinga_1312",  -1},
            {"Миша Mikhail Voronin Михаил",  374758888},
            {"8Man, Даня Данила Даниил Данилл Братан @z_8man", 637782235},
            {"@Ashendale Сева", 497973623},
            {"@Ged Ged Progress Паша Павел", 357896726 }

        };
        
    }
}
