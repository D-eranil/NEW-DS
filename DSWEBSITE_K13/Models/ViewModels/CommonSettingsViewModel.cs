using CMS.Core;
using CMS.EmailEngine;
using CMS.EventLog;
using CMS.SiteProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSWEBSITE_K13.Models.ViewModels
{
    public class CommonSettingsViewModel : EventLogManager
    {

        

        public bool EnableCallToTactionBanner { get; set; }
        public bool EnablePromotionsBanner { get; set; }
        public bool EnableBreadcrumb { get; set; }
        public bool AllowToViewInHeader { get; set; }
        public bool AllowToViewInFooter { get; set; }
        public bool DisableCache { get; set; }
    }


    public class EventLogManager
    {

        /// <summary>
        /// this method for log info.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="eventCode"></param>
        /// <param name="description"></param>
        public static void LogInformation(string source, string eventCode, string description)
        {
            IEventLogService eventLog = Service.Resolve<IEventLogService>();

            // Logs an information event into the event log
            eventLog.LogInformation(source, eventCode, eventDescription: description);
        }

        /// <summary>
        /// this method for log warning.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="eventCode"></param>
        /// <param name="description"></param>
        public static void LogWarning(string source, string eventCode, string description)//, int? siteId)
        {
            IEventLogService eventLog = Service.Resolve<IEventLogService>();

            // Logs a warning event into the event log
            eventLog.LogWarning(source, eventCode, eventDescription: description);
        }

        /// <summary>
        /// this method for log error.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="eventCode"></param>
        /// <param name="description"></param>
        public static void LogError(string source, string eventCode, string description)
        {
            IEventLogService eventLog = Service.Resolve<IEventLogService>();

            // Logs an error event into the event log
            eventLog.LogError(source, eventCode, eventDescription: description);
        }

        /// <summary>
        /// this method for log exception.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="eventCode"></param>
        /// <param name="message"></param>
        /// <param name="ex"></param>
        public static void LogException(string source, string eventCode, string message, Exception ex)
        {
            IEventLogService eventLog = Service.Resolve<IEventLogService>();

            // Logs an exception into the event log
            eventLog.LogException(source, eventCode, ex, additionalMessage: message);
        }

        /// <summary>
        /// this method for log full event.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="eventCode"></param>
        /// <param name="description"></param>
        /// <param name="ex"></param>
        public static void LogEvent(string source, string eventCode, string description, Exception ex)
        {
            IEventLogService eventLog = Service.Resolve<IEventLogService>();

            // Prepares an EventLogData object that holds all information about the event being logged
            EventLogData eventData = new EventLogData(EventTypeEnum.Information, source, eventCode)
            {
                SiteID = SiteContext.CurrentSiteID,
                EventTime = DateTime.Now,
                EventDescription = description
            };


            // Logs the event into the event log
            eventLog.LogEvent(eventData);
        }

        /// <summary>
        /// this method for send email to admin site.
        /// </summary>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <param name="subject"></param>
        public static void SendLogToEmail(string from, string to, string subject)
        {
            // Gets all error events logged in the past day
            var errors = EventLogInfo.Provider.Get()
                                            .WhereEquals("EventType", EventType.ERROR)
                                            .WhereGreaterThan("EventTime", DateTime.Now.Subtract(TimeSpan.FromDays(1)));

            if (errors.Count > 0)
            {
                // Creates the email message
                EmailMessage msg = new EmailMessage()
                {
                    From = from,
                    Recipients = to,
                    Subject = subject,
                    Body = "<html><body><ul>"
                };

                // Creates a list of the errors
                foreach (EventLogInfo errorEvent in errors)
                {
                    //msg.Body += String.Format("<li>{0} - {1} - {2}</li>", errorEvent.EventType, errorEvent.EventCode, errorEvent.EventDescription.Substring(0, 100));
                    // String Interpolation
                    msg.Body += $"<li>{errorEvent.EventType} - {errorEvent.EventCode} - {errorEvent.EventDescription.Substring(0, 100)}</li>";
                }

                msg.Body += "</ul></body></html>";

                // Sends out the email message
                EmailSender.SendEmail(msg);
            }
        }
    }
}
