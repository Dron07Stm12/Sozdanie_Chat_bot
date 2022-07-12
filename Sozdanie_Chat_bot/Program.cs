using System;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace Perenen_bot
{

   static class Program
    {
        public static string token = "5581361986:AAGAYSUgQdB7g_RVOyGEqW4nqpBkgtfH0ys";
        public static   TelegramBotClient? Client ;

        

        [Obsolete]
        static void Main()
        {

            Client = new TelegramBotClient(token);
            Client.StartReceiving();
            Client.OnMessage += OnMessageHandler;
            Console.ReadLine(); 
            Client.StopReceiving();

            

        }

        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
            var msg = e.Message;
            if (msg.Text != null)
            {
                Console.WriteLine($"Пришло сообщение с текстом: {msg.Text}");
                //replyMarkup -пользование кнопками
                await Client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyMarkup: GetButton());

                switch (msg.Text)
                {

                    case "Карандаш":
                        //var stic = await Client.SendStickerAsync(...
                       _ =  await Client.SendStickerAsync(
                    chatId: msg.Chat.Id,
                    sticker: "https://cdn-icons-png.flaticon.com/256/4228/4228689.png", replyToMessageId: msg.MessageId);
                        break;



                    case "Чип":
                        //var stic = await Client.SendStickerAsync(...
                        _ = await Client.SendStickerAsync(
                     chatId: msg.Chat.Id,
                     sticker: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRlDO8BaNpGwaV8k72jTPc4XCdYesCywSBP5w&usqp=CAU", replyToMessageId: msg.MessageId);
                        break;

                    case "Заец":
                        //var stic = await Client.SendStickerAsync(...
                        _ = await Client.SendStickerAsync(
                     chatId: msg.Chat.Id,
                     sticker: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcT82MpGejOSeCYChCPajspQG2Ys-hXIk3rMFA&usqp=CAU", replyToMessageId: msg.MessageId);
                        break;

                    case "Лелик":
                        //var stic = await Client.SendStickerAsync(...
                        _ = await Client.SendStickerAsync(
                     chatId: msg.Chat.Id,
                     sticker: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRA1Qywa_3c7Lsr8qpTvx5BOmC9Rcp_dNnELA&usqp=CAU", replyToMessageId: msg.MessageId);
                        break;

                    case "Ваз":
                        //var stic = await Client.SendStickerAsync(...
                        _ = await Client.SendStickerAsync(
                     chatId: msg.Chat.Id,
                     sticker: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRQQio7W0yCA67OLGAJ8JZPBfpoTNz9arsEog&usqp=CAU", replyToMessageId: msg.MessageId);
                        break;
                    case "Штирлиц":
                        //var stic = await Client.SendStickerAsync(...
                        _ = await Client.SendStickerAsync(
                     chatId: msg.Chat.Id,
                     sticker: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSsjIN3cj9SgHu1_e7llbCoWkIjpL-c3YwsKg&usqp=CAU", replyToMessageId: msg.MessageId);
                        break;

                    case "Профессор":
                        //var stic = await Client.SendStickerAsync(...
                        _ = await Client.SendStickerAsync(
                     chatId: msg.Chat.Id,
                     sticker: "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQSSeo1FNj41rJjTQ85UV2x7sH_5ZqtZpeVPg&usqp=CAU", replyToMessageId: msg.MessageId);
                        break;
                    //
                    //https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSsjIN3cj9SgHu1_e7llbCoWkIjpL-c3YwsKg&usqp=CAU
                    //
                    default:
                        await Client.SendTextMessageAsync(msg.Chat.Id, msg.Text,replyMarkup: GetButton());
                        break;
                }



                //switch (msg.Text)
                //{
                //    case "Стикер":
                //        var stic = await Client.SendStickerAsync(chatId: msg.Chat.Id, sticker: "https://cdn-icons-png.flaticon.com/256/4228/4228689.png",
                //           replyToMessageId: msg.MessageId, replyMarkup: GetButton());
                //        break;



                //    default:
                //        await Client.SendStickerAsync(msg.Chat.Id, "Выберите команду", replyMarkup: GetButton());
                //        break;
                //}

                //бот отправляет текст
                //await Client.SendTextMessageAsync(msg.Chat.Id, msg.Text, replyToMessageId: msg.MessageId);


                //бот отсылает стикер
                //var stic = await Client.SendStickerAsync(
                //    chatId: msg.Chat.Id,
                //    sticker: "https://cdn-icons-png.flaticon.com/256/4228/4228689.png",
                //    replyToMessageId: msg.MessageId);

                //Кнопки
                //  await Client.SendTextMessageAsync(msg.Chat.Id,msg.Text,replyMarkup: GetButton());    


            }
        }

        private static IReplyMarkup GetButton()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
               {
                 new List<KeyboardButton> {new KeyboardButton{Text = "Карандаш" },new KeyboardButton {Text = "Чип" } },
                 new List<KeyboardButton>{new KeyboardButton { Text = "Заец" },new KeyboardButton { Text = "Лелик" } },
                 new List<KeyboardButton>{new KeyboardButton { Text = "Ваз"},new KeyboardButton {Text ="Штирлиц"}, new KeyboardButton {Text = "Профессор"} }
               }
            };
        }
    }




















}