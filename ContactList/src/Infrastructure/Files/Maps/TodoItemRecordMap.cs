﻿using System.Globalization;
using ContactList.Application.TodoLists.Queries.ExportTodos;
using CsvHelper.Configuration;

namespace ContactList.Infrastructure.Files.Maps;
public class TodoItemRecordMap : ClassMap<TodoItemRecord>
{
    public TodoItemRecordMap()
    {
        AutoMap(CultureInfo.InvariantCulture);

        Map(m => m.Done).Convert(c => c.Value.Done ? "Yes" : "No");
    }
}
