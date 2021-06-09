using System;
using Vega.Enums;

namespace Vega.Entities
{
    public class Question : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Photo { get; set; }
        public float YesRate { get; set; }
        public float NoRate { get; set; }
        public AnswerState AnswerState { get; set; }
        public Answer? CorrectOption { get; set; }
        public DateTime? ExpireAt { get; set; }
    }
}