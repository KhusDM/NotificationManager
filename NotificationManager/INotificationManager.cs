using System.Collections.Generic;

namespace NotificationManager
{
     public interface INotificationManager
    {
        void ProcessSignal(string signal);

        void AddRecipientForSignal(string email, string signal);

        void RemoveRecipientForSignal(string email, string signal);

        IEnumerable<string> ListOfSupportedSignals();

        void AddSignal(string signal);

        bool CheckNotificationSignal(string email, string signal);
    }
}
