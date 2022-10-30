using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ToDoApp
{
    public class TodoItemDto:IValidatableObject
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(1000)]
        public string Text { get; set; }
        public IEnumerable<ValidationResult> Validate(
           ValidationContext validationContext)
        {
            if (Text == "a")
            {
                yield return new ValidationResult(
                    "Boş yapılacak bişi mi var",
                    new[] { "Text" }
                );
            }
        }
    }
}