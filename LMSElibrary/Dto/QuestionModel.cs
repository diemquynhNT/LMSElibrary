﻿using System.ComponentModel.DataAnnotations;

namespace SubjectService.Dto
{
    public class QuestionModel
    {
        public string Title { get; set; }
        public string ContentQuestion { get; set; }
        public string? idClass { get; set; }
    }
}
