using gerenciamentoapirest.Models;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

public class GoogleCalendarService
{
    private readonly CalendarService _calendarService;

    public GoogleCalendarService(string tokenPath)
    {
        string[] scopes = { CalendarService.Scope.Calendar };

        UserCredential credential;

        using (var stream = new FileStream("credentials.json", FileMode.Open, FileAccess.Read))
        {
            credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                GoogleClientSecrets.Load(stream).Secrets,
                scopes,
                "user",
                CancellationToken.None,
                new FileDataStore(tokenPath, true)).Result;
        }

        _calendarService = new CalendarService(new BaseClientService.Initializer()
        {
            HttpClientInitializer = credential,
            ApplicationName = "Gerenciamento de Tarefas"
        });
    }

    // Removido o método duplicado CreateEvent
    public void CreateEvent(Tarefa tarefa)
    {
        var calendarEvent = new Google.Apis.Calendar.v3.Data.Event()
        {
            Summary = tarefa.Titulo,
            Description = tarefa.Descricao,
            Start = new Google.Apis.Calendar.v3.Data.EventDateTime()
            {
                DateTime = tarefa.DataInicio
            },
            End = new Google.Apis.Calendar.v3.Data.EventDateTime()
            {
                DateTime = tarefa.DataFim
            },
            Reminders = new Google.Apis.Calendar.v3.Data.Event.RemindersData()
            {
                UseDefault = false,
                Overrides = new List<Google.Apis.Calendar.v3.Data.EventReminder>()
                {
                    new Google.Apis.Calendar.v3.Data.EventReminder() { Method = "email", Minutes = 24 * 60 },
                    new Google.Apis.Calendar.v3.Data.EventReminder() { Method = "popup", Minutes = 10 }
                }
            }
        };

        var request = _calendarService.Events.Insert(calendarEvent, "primary");
        request.Execute();
    }

    public void CreateEventAsTarefa(Tarefa tarefa)
    {
        throw new NotImplementedException();
    }
}
