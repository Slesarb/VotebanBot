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
            {"Корш Саша Александр @566826274 (Корш)", 566826274},
            {"Никита @cloudedbe @mogafk", 63070657},
            {"Ваня Иван @Haharin", 112571278},
            {"Юля Юлия Полш Yul Polsh @yul_polsh", 176088764},
            {"Дима Диван Диман Дмитрий looser pacific @icinga_1312",  -1},
            {"Ржакабот мемы @super_rjaka_demotivator_bot",  1016409811},
            {"Миша Mikhail Voronin",  374758888}

        };
        
    }
}
