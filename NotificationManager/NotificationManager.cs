using System;
using System.Collections.Generic;
using System.Linq;

namespace Manager
{
    public class NotificationManager:INotificationManager
    {
        private IDictionary<string, IList<string>> dictSignal;

        public NotificationManager()
        {
            this.dictSignal = new Dictionary<string, IList<string>>();
            this.dictSignal.Add("T8", new List<string> { "lor@mail.ru" });
            this.dictSignal.Add("G15", new List<string> { "roma@yandex.ru", "worker115@yandex.ru" });
        }

        public NotificationManager(IDictionary<string,IList<string>> dictSignal)
        {
            this.dictSignal = dictSignal;
        }

        protected virtual void NewsLetter(string recipient, string signal)
        {
            //Реализация метода рассылки в зависимости от технологии .Net
        }

        public void ProcessSignal(string signal)
        {
            if (dictSignal.ContainsKey(signal))
            {
                foreach (string recipient in dictSignal[signal])
                {
                    NewsLetter(recipient, signal);
                }
            }
            else
            {
                throw new Exception("Данный сигнал отсутсвует!");
            }
        }

        public void AddRecipientForSignal(string email,string signal)
        {
            if (dictSignal.ContainsKey(signal))
            {
                dictSignal[signal].Add(email);
            }
            else
            {
                throw new Exception("Данный сигнал отсутствует!");
            }
        }

        public void RemoveRecipientForSignal(string email, string signal)
        {
            if (dictSignal.ContainsKey(signal))
            {
                dictSignal[signal].Remove(email);
            }
            else
            {
                throw new Exception("Данный сигнал отсутствует!");
            }
        }

        public IList<string> ListOfSupportedSignals()
        {
            return dictSignal.Keys.Where(key => dictSignal[key].Count != 0).ToList();
        }

        public void AddSignal(string signal)
        {
            dictSignal.Add(signal, new List<string> { });
        }

        public bool CheckNotificationSignal(string email, string signal)
        {
            if (dictSignal.ContainsKey(signal))
            {
                return dictSignal[signal].Contains(email);
            }
            else
            {
                throw new Exception("Данный сигнал отсутствует!");
            }
        }
    }
}
