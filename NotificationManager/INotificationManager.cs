using System.Collections.Generic;

namespace Manager
{
    public interface INotificationManager
    {
        //Обработать сигнал
        void ProcessSignal(string signal);

        //Добавить адресата для сигнала
        void AddRecipientForSignal(string email, string signal);

        //Исключить адресата из сигнала
        void RemoveRecipientForSignal(string email, string signal);

        //Получить список поддерживаемых сигналов
        IList<string> ListOfSupportedSignals();

        //Добавить сигнал
        void AddSignal(string signal);

        //Проверить будет ли адресат получать уведомление для сигнала
        bool CheckNotificationSignal(string email, string signal);
    }
}
