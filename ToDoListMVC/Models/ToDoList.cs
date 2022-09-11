﻿using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace ToDoListMVC.Models
{
    [ModelBinder]
    public class ToDoList
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        [BsonElement("Name")]
        [Required]
        public string? Name { get; set; }
        [BsonElement("Tasks")]
        public List<ToDoItem> Tasks = new List<ToDoItem>();

        public ToDoList()
        {

        }
        public ToDoList(string id, string name, List<ToDoItem> tasks)
        {
            this.Id = id;
            this.Name = name;
            this.Tasks = tasks;
        }
    }
}
