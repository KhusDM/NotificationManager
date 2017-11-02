using Microsoft.VisualStudio.TestTools.UnitTesting;
using Manager;
using System;

namespace ManagerTest
{
    [TestClass]
    public class NotificationManagerTest
    {
        [TestMethod]
        public void CheckNotificationSignal_AddRecipient_TrueNewsLetter()
        {
            INotificationManager notificationManager = new NotificationManager();
            bool expectedNotification = true, actuallyNotification;
            string email = "tt@mail.ru", signal = "G15";

            notificationManager.AddRecipientForSignal(email, signal);
            actuallyNotification = notificationManager.CheckNotificationSignal(email, signal);

            Assert.AreEqual(expectedNotification, actuallyNotification);
        }

        [TestMethod]
        public void CheckNotificationSignal_RemoveRecipient_FalseNewsLetter()
        {
            INotificationManager notificationManager = new NotificationManager();
            bool expectedNotification = false, actuallyNotification;
            string email = "tt@mail.ru", signal = "G15";

            notificationManager.AddRecipientForSignal(email, signal);
            notificationManager.RemoveRecipientForSignal(email, signal);
            actuallyNotification = notificationManager.CheckNotificationSignal(email, signal);

            Assert.AreEqual(expectedNotification, actuallyNotification);
        }

        [TestMethod]
        public void ListOfSupportedSignals_AddSignal_InSpisok()
        {
            INotificationManager notificationManager = new NotificationManager();
            bool expectedSupportedSingal = false, actuallySupportedSignal;
            string signal = "H89";

            notificationManager.AddSignal(signal);
            actuallySupportedSignal = notificationManager.ListOfSupportedSignals().Contains(signal);

            Assert.AreEqual(expectedSupportedSingal, actuallySupportedSignal);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CheckNotificationSignal_ThrowException_Exception()
        {
            INotificationManager notificationManager = new NotificationManager();
            string email = "tt@mail.ru", signal = "H89";

            notificationManager.CheckNotificationSignal(email, signal);
        }
    }
}
