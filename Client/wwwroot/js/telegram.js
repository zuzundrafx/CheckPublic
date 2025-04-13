function getTelegramUserData() {
    const user = window.Telegram?.WebApp?.initDataUnsafe?.user;
    return {
        id: user?.id,
        username: user?.username
    };
}