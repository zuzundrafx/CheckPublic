using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace Server.Services;

public class TelegramBotService : IHostedService
{
    private readonly TelegramBotClient _bot;
    private readonly string _webAppUrl;
    
    public TelegramBotService(IConfiguration config)
    {
        _bot = new TelegramBotClient(config["TelegramBotToken"]!);
        _webAppUrl = config["WebAppUrl"]!;
    }

    public Task StartAsync(CancellationToken ct)
    {
        _bot.StartReceiving(UpdateHandler, ErrorHandler, cancellationToken: ct);
        return Task.CompletedTask;
    }

    private async Task UpdateHandler(ITelegramBotClient bot, Update update, CancellationToken ct)
    {
        if (update.Message?.Text == "/start")
        {
            await bot.SendTextMessageAsync(
                update.Message.Chat.Id,
                "Добро пожаловать в UFC Fantasy!",
                replyMarkup: new InlineKeyboardMarkup(
                    InlineKeyboardButton.WithWebApp(
                        "🎮 Играть",
                        new WebAppInfo { Url = _webAppUrl }
                    )
                )
            );
        }
    }

    private Task ErrorHandler(ITelegramBotClient bot, Exception ex, CancellationToken ct)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken ct) => Task.CompletedTask;
}