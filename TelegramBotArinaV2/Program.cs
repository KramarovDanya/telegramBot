using System;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types.ReplyMarkups;
using static System.Net.WebRequestMethods;
using TelegramBotArinaV2;
using System.IO;

namespace TelegramBotExperiments
{

    class Program
    {
        static ITelegramBotClient bot = new TelegramBotClient("5719592769:AAE0Iu9lwgPAfEGZKep326rd_58_s4cikqI");

        static string[] youTubeZ = Zaryadka.youTube;
        static string[] youTubeFB = NaVseTel.youTube;
        static string[] youTubeNY = NogiYag.youTube;
        static string[] youTubeС = Core.youTube;
        static string[] youTubeS = Spina.youTube;
        static string[] youTubeR = Rastyajka.youTube;
        static string[] youTubeMFR = MFR.youTube;

        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {

            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(update));
            
            if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
            {
                
                var message = update.Message;
                
                if (message.Text.ToLower() == "/start")
                {
                    await botClient.SendTextMessageAsync(message.Chat, "Добро пожаловать!\nЗдесь ты найдёшь тренировки на разные группы мышц, скорее пробуй 🎧🤍");
                    await botClient.SendTextMessageAsync(message.Chat, "Напиши «тренировка»");
                }
                if (message.Text.ToLower().Contains("тренировка"))
                {
                    await bot.SendTextMessageAsync(message.Chat, "Выбирай, чем ты хочешь заняться", replyMarkup: GetButton());
                    
                }

                if (message.Text.ToLower() == "зарядка")
                {
                    Random rand = new Random();
                    string pathSyou = youTubeZ[rand.Next(youTubeZ.Length)];

                    await botClient.SendTextMessageAsync(message.Chat, pathSyou);
                }
                if (message.Text.ToLower() == "на всё тело")
                {
                    Random rand = new Random();
                    string pathSyou = youTubeFB[rand.Next(youTubeFB.Length)];

                    await botClient.SendTextMessageAsync(message.Chat, pathSyou);
                }
                if (message.Text.ToLower() == "ноги и ягодицы")
                {
                    Random rand = new Random();
                    string pathSyou = youTubeNY[rand.Next(youTubeNY.Length)];

                    await botClient.SendTextMessageAsync(message.Chat, pathSyou);
                }
                if (message.Text.ToLower() == "пресс")
                {
                    Random rand = new Random();
                    string pathSyou = youTubeС[rand.Next(youTubeС.Length)];

                    await botClient.SendTextMessageAsync(message.Chat, pathSyou);
                }
                if (message.Text.ToLower() == "спина")
                {
                    Random rand = new Random();
                    string pathSyou = youTubeS[rand.Next(youTubeS.Length)];

                    await botClient.SendTextMessageAsync(message.Chat, pathSyou);
                }
                if (message.Text.ToLower() == "растяжка")
                {
                    Random rand = new Random();
                    string pathSyou = youTubeR[rand.Next(youTubeR.Length)];

                    await botClient.SendTextMessageAsync(message.Chat, pathSyou);
                }
                if (message.Text.ToLower() == "мфр")
                {
                    Random rand = new Random();
                    string pathSyou = youTubeMFR[rand.Next(youTubeMFR.Length)];

                    await botClient.SendTextMessageAsync(message.Chat, pathSyou);
                }
                
                
            }
            
        }

        private static IReplyMarkup? GetButton()
        {
            ReplyKeyboardMarkup replyKeyboardMarkup = new(new[]
            {new KeyboardButton[] { "Зарядка"},
            new KeyboardButton[] { "На всё тело"},
            new KeyboardButton[] { "Ноги и ягодицы" },
            new KeyboardButton[] { "Пресс"},
            new KeyboardButton[] { "Спина"  },
            new KeyboardButton[] { "Растяжка" },
             new KeyboardButton[] { "МФР" } })
            {
                ResizeKeyboard = true
            };
            
            return replyKeyboardMarkup;
        }

        public static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            // Некоторые действия
            Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(exception));
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Запущен бот " + bot.GetMeAsync().Result.FirstName);

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;
            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = { }, // receive all update types
            };
            
            bot.StartReceiving(
                HandleUpdateAsync,
                HandleErrorAsync,
                receiverOptions,
                cancellationToken);
            Console.ReadLine();
        }

    }
}

