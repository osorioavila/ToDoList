using System.ComponentModel.DataAnnotations;

namespace ToDoList.Web.Models
{
    public class TaskModel
    {
        public virtual int Id { get; set; }

        [Display(Name = "Titulo")]
        [Required(ErrorMessage = "Preencha o Titulo")]
        [MaxLength(15, ErrorMessage ="Tamanho máximo de 15 caracteres")]
        public virtual string Title { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Preencha o Descrição")]
        public virtual string Description { get; set; }

        public virtual StatusTaskModel Status { get; set; }
    }
}